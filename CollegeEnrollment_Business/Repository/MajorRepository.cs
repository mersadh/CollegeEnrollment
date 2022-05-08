using AutoMapper;
using CollegeEnrollment_Business.Repository.IRepository;
using CollegeEnrollment_DataAccess;
using CollegeEnrollment_DataAccess.Data;
using CollegeEnrollment_Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeEnrollment_Business.Repository
{

    public class MajorRepository : IMajorRepository
    {

        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public MajorRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }


        public async Task<MajorDTO> Create(MajorDTO objDTO)
        {
            //Category category = new Category()
            //{
            //    Name = objDTO.Name,
            //    Id = objDTO.Id,
            //    CreateDate = DateTime.Now,
            //};

            var obj = _mapper.Map<MajorDTO, Major>(objDTO);   
            var addedObj = _db.Majors.Add(obj);
            await _db.SaveChangesAsync();
            //return new CategoryDTO()
            //{
            //    Id = category.Id,
            //    Name = category.Name,
            //};

            return _mapper.Map<Major, MajorDTO>(addedObj.Entity);    
        }

        public async Task<int> Delete(int id)
        {
            var obj = await _db.Majors.FirstOrDefaultAsync(u => u.Id == id);
            if(obj!=null)
            {
                _db.Majors.Remove(obj);
                return await _db.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<MajorDTO> Get(int id)
        {
            var obj = await _db.Majors.Include(u=>u.Category).FirstOrDefaultAsync(u => u.Id == id);
            if (obj != null)
            {
               return _mapper.Map<Major, MajorDTO>(obj);
            }
            return new MajorDTO();
        }

        public async Task<IEnumerable<MajorDTO>> GetAll()
        {
            return _mapper.Map<IEnumerable<Major>, IEnumerable<MajorDTO>>(_db.Majors.Include(u=>u.Category));
        }

        public async Task<MajorDTO> Update(MajorDTO objDTO)
        {
            var objFromDb = await _db.Majors.FirstOrDefaultAsync(u => u.Id == objDTO.Id);
            if (objFromDb != null)
            {
                objFromDb.Name=objDTO.Name;
                objFromDb.Description=objDTO.Description;
                objFromDb.StudentFavorites=objDTO.StudentFavorites;
                objFromDb.SchoolFavorites=objDTO.SchoolFavorites;
                objFromDb.ImageUrl=objDTO.ImageUrl;
                objFromDb.Duration=objDTO.Duration;
                objFromDb.CategoryId=objDTO.CategoryId;
                _db.Majors.Update(objFromDb);
                await _db.SaveChangesAsync();
                return _mapper.Map<Major, MajorDTO>(objFromDb);
            }
            return objDTO;
        }
    }
}
