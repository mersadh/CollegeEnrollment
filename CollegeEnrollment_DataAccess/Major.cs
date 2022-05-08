using CollegeEnrollment_DataAccess.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeEnrollment_DataAccess
{
    public class Major
    {
        [Key]
        public int Id { get; set; } 

        public string Name { get; set; }
        public string Description { get; set; }
        public bool SchoolFavorites { get; set; }
        public bool StudentFavorites { get; set; }
        public string Duration { get; set; }
        public string ImageUrl { get; set; }
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }

    }
}
