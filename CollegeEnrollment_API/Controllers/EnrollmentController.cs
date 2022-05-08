using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CollegeEnrollment_Business.Repository.IRepository;
using CollegeEnrollment_Models;

namespace CollegeEnrollment_API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EnrollmentController : ControllerBase
    {
        private readonly IEnrollmentRepository _enrollmentRepository;
        public EnrollmentController(IEnrollmentRepository enrollmentRepository)
        {
            _enrollmentRepository = enrollmentRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _enrollmentRepository.GetAll());
        }

        [HttpGet("{enrollmentHeaderId}")]
        public async Task<IActionResult> Get(int? enrollmentHeaderId)
        {
            if(enrollmentHeaderId == null || enrollmentHeaderId == 0)
            {
                return BadRequest(new ErrorModelDTO() {
                ErrorMessage = "Invalid Id",
                    StatusCode = StatusCodes.Status400BadRequest
                });
            }

            var enrollmentHeader = await _enrollmentRepository.Get(enrollmentHeaderId.Value);
            if (enrollmentHeader == null)
            {
                return BadRequest(new ErrorModelDTO()
                {
                    ErrorMessage = "Invalid Id",
                    StatusCode = StatusCodes.Status404NotFound
                }); 
            }
            return Ok(enrollmentHeader);
        }

        [HttpPost]
        [ActionName("Create")]
        public async Task<IActionResult> Create([FromBody] EnrollmentFinalizeDTO enrollmentFinalizeDTO)
        {
            enrollmentFinalizeDTO.Enrollment.EnrollmentHeader.EnrollmentDate=DateTime.Now;
            var result = await _enrollmentRepository.Create(enrollmentFinalizeDTO.Enrollment);
            return Ok(result);
        }
    }
}
