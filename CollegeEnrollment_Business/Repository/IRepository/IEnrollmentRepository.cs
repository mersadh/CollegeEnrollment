using CollegeEnrollment_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeEnrollment_Business.Repository.IRepository
{
    public interface IEnrollmentRepository
    {
        public Task<EnrollmentDTO> Get(int id);

        public Task<IEnumerable<EnrollmentDTO>> GetAll(string? userId = null, string? status = null);

        public Task<EnrollmentDTO> Create(EnrollmentDTO objDTO);

        public Task<int> Delete(int id);

        public Task<EnrollmentHeaderDTO> MarkEnrollmentSuccessful(int id);

        public Task<EnrollmentHeaderDTO> UpdateHeader(EnrollmentHeaderDTO objDTO);

        public Task<bool> UpdateEnrollmentStatus(int enrollmentID, string status);

        public Task<EnrollmentHeaderDTO> CancelEnrollment(int id);
    }
}
