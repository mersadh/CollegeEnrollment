using CollegeEnrollment_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeEnrollment_Business.Repository.IRepository
{
    public interface IMajorRepository
    {
        public Task<MajorDTO> Create(MajorDTO objDTO);

        public Task<MajorDTO> Update(MajorDTO objDTO);

        public Task<int> Delete(int id);

        public Task<MajorDTO> Get(int id);

        public Task<IEnumerable<MajorDTO>> GetAll();
    }
}
