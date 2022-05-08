using CollegeEnrollment_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeEnrollment_Models
{
    public class EnrollmentDTO
    {
        public EnrollmentHeaderDTO EnrollmentHeader { get; set; }
        public List<EnrollmentDetailDTO> EnrollmentDetails { get; set; }
    }
}
