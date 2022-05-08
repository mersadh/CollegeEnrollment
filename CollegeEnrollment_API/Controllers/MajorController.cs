using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CollegeEnrollment_Business.Repository.IRepository;
using CollegeEnrollment_Models;
using CollegeEnrollment_Common;
using Microsoft.AspNetCore.Authorization;

namespace CollegeEnrollment_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MajorController : ControllerBase
    {
        private readonly IMajorRepository _majorRepository;
        public MajorController(IMajorRepository majorRepository)
        {
            _majorRepository = majorRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _majorRepository.GetAll());
        }

        [HttpGet("{majorId}")]
        public async Task<IActionResult> Get(int? majorId)
        {
            if(majorId==null || majorId==0)
            {
                return BadRequest(new ErrorModelDTO() {
                ErrorMessage = "Invalid Id",
                    StatusCode = StatusCodes.Status400BadRequest
                });
            }

            var major = await _majorRepository.Get(majorId.Value);
            if (major == null)
            {
                return BadRequest(new ErrorModelDTO()
                {
                    ErrorMessage = "Invalid Id",
                    StatusCode = StatusCodes.Status404NotFound
                }); 
            }
            return Ok(major);
        }
    }
}
