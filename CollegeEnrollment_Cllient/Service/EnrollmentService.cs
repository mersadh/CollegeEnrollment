using CollegeEnrollment_Cllient.Service.IService;
using CollegeEnrollment_Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace CollegeEnrollment_Cllient.Service
{
    public class EnrollmentService : IEnrollmentService
    {
        private readonly HttpClient _httpClient;
        private IConfiguration _configuration;
        private string BaseServerUrl;

        public EnrollmentService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            BaseServerUrl = _configuration.GetSection("BaseServerUrl").Value;
        }

        public async Task<EnrollmentDTO> Create(EnrollmentFinalizeDTO enrollmentFinalizeDTO)
        {
            var content = JsonConvert.SerializeObject(enrollmentFinalizeDTO);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("api/Enrollment/Create", bodyContent);
            string responseResult = response.Content.ReadAsStringAsync().Result;
            if (response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<EnrollmentDTO>(responseResult);
                return result;
            }
            return new EnrollmentDTO();
        }

        public async Task<EnrollmentDTO> Get(int enrollmentHeaderId)
        {
            var response = await _httpClient.GetAsync($"/api/enrollment/{enrollmentHeaderId}");
            var content = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                var enrollment = JsonConvert.DeserializeObject<EnrollmentDTO>(content);
                return enrollment;
            }
            else
            {
                var errorModel = JsonConvert.DeserializeObject<ErrorModelDTO>(content);
                throw new Exception(errorModel.ErrorMessage);
            }
        }

        public async Task<IEnumerable<EnrollmentDTO>> GetAll(string? userId = null)
        {
            var response = await _httpClient.GetAsync("/api/enrollment");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var enrollments = JsonConvert.DeserializeObject<IEnumerable<EnrollmentDTO>>(content);

                return enrollments;
            }
            return new List<EnrollmentDTO>();
        }
    }
}
