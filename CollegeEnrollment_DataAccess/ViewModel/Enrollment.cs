using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeEnrollment_DataAccess.ViewModel
{
    public class Enrollment
    {
        public EnrollmentHeader EnrollmentHeader { get; set; }
        public IEnumerable<EnrollmentDetail> EnrollmentDetails { get; set; }
    }
}
