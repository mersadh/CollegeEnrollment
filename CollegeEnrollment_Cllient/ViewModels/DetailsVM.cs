using System.ComponentModel.DataAnnotations;

namespace CollegeEnrollment_Cllient.ViewModels
{
    public class DetailsVM
    {
        public DetailsVM()
        {
            BrojStudija = 1;
        }
        [Range(1, int.MaxValue, ErrorMessage="Molimo unesite broj studija veći od 0")]
        public int BrojStudija { get; set; }
    }
}
