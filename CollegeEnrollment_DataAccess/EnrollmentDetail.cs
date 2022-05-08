using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeEnrollment_DataAccess
{
    public class EnrollmentDetail
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int EnrollmentHeaderId { get; set; }
        [Required]
        public int MajorId { get; set; }
        [ForeignKey("MajorId")]
        [NotMapped]
        public virtual Major Major { get; set; }
        [Required]
        public int Count;
        [Required]
        public string MajorName { get; set; }
  
    }

}
