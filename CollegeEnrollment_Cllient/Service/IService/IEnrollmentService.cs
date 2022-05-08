using CollegeEnrollment_Models;

namespace CollegeEnrollment_Cllient.Service.IService
{
    public interface IEnrollmentService
    {
        public Task<IEnumerable<EnrollmentDTO>> GetAll(string? userId);
        public Task<EnrollmentDTO> Get(int enrollmentId);
        public Task<EnrollmentDTO> Create(EnrollmentFinalizeDTO enrollmentFinalizeDTO);
    }
}
