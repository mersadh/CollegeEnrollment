using CollegeEnrollment_Cllient.ViewModels;

namespace CollegeEnrollment_Cllient.Service.IService
{
    public interface IEnrollmentCartService
    {
        Task DecrementEnrollmentCart(EnrollmentCart enrollmentCart);
        Task IncrementEnrollmentCart(EnrollmentCart enrollmentCart);
    }
}
