using AutoMapper;
using CollegeEnrollment_DataAccess;
using CollegeEnrollment_DataAccess.Data;
using CollegeEnrollment_DataAccess.ViewModel;
using CollegeEnrollment_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeEnrollment_Business.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<Major, MajorDTO>().ReverseMap();
            CreateMap<EnrollmentHeaderDTO, EnrollmentHeader>().ReverseMap();
            CreateMap<EnrollmentDetail, EnrollmentDetailDTO>().ReverseMap();
            CreateMap<EnrollmentDTO, Enrollment>().ReverseMap();
            //  CreateMap<CategoryDTO, Category>();
        }

    }
}
