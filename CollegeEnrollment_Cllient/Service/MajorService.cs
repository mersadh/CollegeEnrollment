using CollegeEnrollment_Cllient.Service.IService;
using CollegeEnrollment_Models;
using Newtonsoft.Json;

namespace CollegeEnrollment_Cllient.Service
{
    public class MajorService : IMajorService
    {
        private readonly HttpClient _httpClient;
        private IConfiguration _configuration;
        private string BaseServerUrl;
    

    public MajorService(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _configuration = configuration;
            BaseServerUrl = _configuration.GetSection("BaseServerUrl").Value;
    }
            
        public async Task<MajorDTO> Get(int majorId)
        {
            var response = await _httpClient.GetAsync($"/api/major/{majorId}");
            var content = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                var major = JsonConvert.DeserializeObject<MajorDTO>(content);
                major.ImageUrl = BaseServerUrl + major.ImageUrl;
                return major;
            }
            else
            {
                var errorModel = JsonConvert.DeserializeObject<ErrorModelDTO>(content);
                throw new Exception(errorModel.ErrorMessage);
            }
        }

        public async Task<IEnumerable<MajorDTO>> GetAll()
        {
            var response = await _httpClient.GetAsync("/api/major");
            if(response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var majors = JsonConvert.DeserializeObject<IEnumerable<MajorDTO>>(content);
                foreach(var maj in majors)
                {
                    maj.ImageUrl= BaseServerUrl + maj.ImageUrl;
                }
                return majors;
            }
            return new List<MajorDTO>();
        }
    }
}
