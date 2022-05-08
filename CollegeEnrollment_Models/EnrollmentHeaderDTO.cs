﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeEnrollment_Models
{
    public class EnrollmentHeaderDTO
    {
        public int Id { get; set; }
        [Required]
        public string userId { get; set; }
        [Required]
        [Display(Name = "Number of Enrollments")]
        public int NumberOfEnrollments { get; set; }

        [Required]
        public DateTime EnrollmentDate { get; set; }

        [Required]
        public string Status { get; set; }

        [Required]
        public string Ime { get; set; }

        [Required]
        public string Prezime { get; set; }

        [Required]
        public DateTime DatumRodjenja { get; set; }

        [Required]
        public string Jmbg { get; set; }

        [Required]
        public string NazivSrednjeSkole { get; set; }

        [Required]
        public string BrojDiplome { get; set; }

        [Display(Name = "Email")]
        [Required]
        public string Email { get; set; }
    }

}

