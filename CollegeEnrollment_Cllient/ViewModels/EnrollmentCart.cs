using CollegeEnrollment_Models;

namespace CollegeEnrollment_Cllient.ViewModels
{
    public class EnrollmentCart
    {

        public int MajorId { get; set; }
        public MajorDTO Major { get; set; }
        public int Count { get; set; }
    }
}
