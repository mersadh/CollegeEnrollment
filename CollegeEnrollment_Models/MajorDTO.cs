using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeEnrollment_Models
{
    public class MajorDTO
    {

        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public bool SchoolFavorites { get; set; }
        public bool StudentFavorites { get; set; }
        public string Duration { get; set; }
        public string ImageUrl { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Molimo popunite vrstu studija")]
        public int CategoryId { get; set; }
        public CategoryDTO Category { get; set; }
    }
}
