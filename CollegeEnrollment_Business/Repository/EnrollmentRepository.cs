using AutoMapper;
using CollegeEnrollment_Business.Repository.IRepository;
using CollegeEnrollment_Common;
using CollegeEnrollment_DataAccess;
using CollegeEnrollment_DataAccess.Data;
using CollegeEnrollment_DataAccess.ViewModel;
using CollegeEnrollment_Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeEnrollment_Business.Repository
{
    public class EnrollmentRepository : IEnrollmentRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public EnrollmentRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<EnrollmentDTO> Create(EnrollmentDTO objDTO)
        {
            try {
                var obj = _mapper.Map<EnrollmentDTO, Enrollment>(objDTO);
                _db.EnrollmentHeaders.Add(obj.EnrollmentHeader);
                await _db.SaveChangesAsync();

                foreach (var details in obj.EnrollmentDetails)
                {
                    details.EnrollmentHeaderId = obj.EnrollmentHeader.Id;
                  //  _db.EnrollmentDetails.Add(details);
                    
                }
                _db.EnrollmentDetails.AddRange(obj.EnrollmentDetails);
                await _db.SaveChangesAsync();

                return new EnrollmentDTO()
                {
                    EnrollmentHeader = _mapper.Map<EnrollmentHeader, EnrollmentHeaderDTO>(obj.EnrollmentHeader),
                    EnrollmentDetails = _mapper.Map<IEnumerable<EnrollmentDetail>, IEnumerable<EnrollmentDetailDTO>>(obj.EnrollmentDetails).ToList()
                };
            }
            catch (Exception ex){
                throw ex;
            }
            return objDTO;
        }

        public async Task<int> Delete(int id)
        {
            var objHeader = await _db.EnrollmentHeaders.FirstOrDefaultAsync(u => u.Id == id);
            if (objHeader != null)
            {
                IEnumerable<EnrollmentDetail> objDetail = _db.EnrollmentDetails.Where(u => u.EnrollmentHeaderId == id);

                _db.EnrollmentDetails.RemoveRange(objDetail);
                _db.EnrollmentHeaders.Remove(objHeader);
                return _db.SaveChanges();
            }
            return 0;
        }

        public async Task<EnrollmentDTO> Get(int id)
        {
            Enrollment enrollment = new()
            {
                EnrollmentHeader = _db.EnrollmentHeaders.FirstOrDefault(u => u.Id == id),
                EnrollmentDetails = _db.EnrollmentDetails.Where(u => u.EnrollmentHeaderId == id),
            };
            if (enrollment != null)
            {
                return _mapper.Map<Enrollment, EnrollmentDTO>(enrollment);
            }
            return new EnrollmentDTO();
        }

        public async Task<IEnumerable<EnrollmentDTO>> GetAll(string? userId = null, string? status = null)
        {
            List<Enrollment> EnrollmentFromDb = new List<Enrollment>();
            IEnumerable<EnrollmentHeader> enrollmentHeaderList = _db.EnrollmentHeaders;
            IEnumerable<EnrollmentDetail> enrollmentDetailList = _db.EnrollmentDetails;

            foreach (EnrollmentHeader header in enrollmentHeaderList)
            {
                Enrollment enrollment = new()
                {
                    EnrollmentHeader = header,
                    EnrollmentDetails = enrollmentDetailList.Where(u => u.EnrollmentHeaderId == header.Id),
                };
                EnrollmentFromDb.Add(enrollment);
            }
            //do some filtering #TODO

            return _mapper.Map<IEnumerable<Enrollment>, IEnumerable<EnrollmentDTO>>(EnrollmentFromDb);
        }

        public async Task<bool> UpdateEnrollmentStatus(int enrollmentId, string status)
        {
            var data = await _db.EnrollmentHeaders.FindAsync(enrollmentId);
            if (data == null)
            {
                return false;
            }
            data.Status = status;

            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<EnrollmentHeaderDTO> MarkEnrollmentSuccessful(int id)
        {
            var data = await _db.EnrollmentHeaders.FindAsync(id);
            if (data == null)
            {
                return new EnrollmentHeaderDTO();
            }
            if (data.Status == SD.Status_Pending)
            {
                data.Status = SD.Status_Confirmed;
                await _db.SaveChangesAsync();
                return _mapper.Map<EnrollmentHeader, EnrollmentHeaderDTO>(data);
            }
            return new EnrollmentHeaderDTO();
        }

        public async Task<EnrollmentHeaderDTO> UpdateHeader(EnrollmentHeaderDTO objDTO)
        {
            if (objDTO != null)
            {
                var enrollmentHeaderFromDb = _db.EnrollmentHeaders.FirstOrDefault(u => u.Id == objDTO.Id);
                enrollmentHeaderFromDb.Ime = objDTO.Ime;
                enrollmentHeaderFromDb.Prezime = objDTO.Prezime;
                enrollmentHeaderFromDb.Jmbg = objDTO.Jmbg;
                enrollmentHeaderFromDb.NazivSrednjeSkole = objDTO.NazivSrednjeSkole;
                enrollmentHeaderFromDb.DatumRodjenja = objDTO.DatumRodjenja;
                enrollmentHeaderFromDb.BrojDiplome = objDTO.BrojDiplome;
                enrollmentHeaderFromDb.Status = objDTO.Status;

                await _db.SaveChangesAsync();
                return _mapper.Map<EnrollmentHeader, EnrollmentHeaderDTO>(enrollmentHeaderFromDb);
            }
            return new EnrollmentHeaderDTO();
        }

        public async Task<EnrollmentHeaderDTO> CancelEnrollment(int id)
        {
            var enrollmentHeader = await _db.EnrollmentHeaders.FindAsync(id);
            if (enrollmentHeader == null)
            {
                return new EnrollmentHeaderDTO();
            }

            if (enrollmentHeader.Status == SD.Status_Pending)
            {
                enrollmentHeader.Status = SD.Status_Cancelled;
                await _db.SaveChangesAsync();
            }


            return _mapper.Map<EnrollmentHeader, EnrollmentHeaderDTO>(enrollmentHeader);
        }
    }
}
