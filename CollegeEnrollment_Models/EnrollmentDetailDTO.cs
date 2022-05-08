using CollegeEnrollment_Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeEnrollment_Models
{
    public class EnrollmentDetailDTO
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int EnrollmentHeaderId { get; set; }
        [Required]
        public int MajorId { get; set; }

        public MajorDTO Major { get; set; }
        [Required]
        public int Count;
        [Required]
        public string MajorName { get; set; }
  
    }

}
