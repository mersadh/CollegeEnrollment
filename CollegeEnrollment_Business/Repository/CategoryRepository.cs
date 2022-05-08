﻿using AutoMapper;
using CollegeEnrollment_Business.Repository.IRepository;
using CollegeEnrollment_DataAccess.Data;
using CollegeEnrollment_Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeEnrollment_Business.Repository
{

    public class CategoryRepository : ICategoryRepository
    {

        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public CategoryRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }


        public async Task<CategoryDTO> Create(CategoryDTO objDTO)
        {
            //Category category = new Category()
            //{
            //    Name = objDTO.Name,
            //    Id = objDTO.Id,
            //    CreateDate = DateTime.Now,
            //};

            var obj = _mapper.Map<CategoryDTO, Category>(objDTO);   
            obj.CreateDate = DateTime.Now;
            var addedObj = _db.Categories.Add(obj);
            await _db.SaveChangesAsync();
            //return new CategoryDTO()
            //{
            //    Id = category.Id,
            //    Name = category.Name,
            //};

            return _mapper.Map<Category, CategoryDTO>(addedObj.Entity);    
        }

        public async Task<int> Delete(int id)
        {
            var obj = await _db.Categories.FirstOrDefaultAsync(u => u.Id == id);
            if(obj!=null)
            {
                _db.Categories.Remove(obj);
                return await _db.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<CategoryDTO> Get(int id)
        {
            var obj = await _db.Categories.FirstOrDefaultAsync(u => u.Id == id);
            if (obj != null)
            {
               return _mapper.Map<Category, CategoryDTO>(obj);
            }
            return new CategoryDTO();
        }

        public async Task<IEnumerable<CategoryDTO>> GetAll()
        {
            return _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryDTO>>(_db.Categories);
        }

        public async Task<CategoryDTO> Update(CategoryDTO objDTO)
        {
            var objFromDb = await _db.Categories.FirstOrDefaultAsync(u => u.Id == objDTO.Id);
            if (objFromDb != null)
            {
                objFromDb.Name=objDTO.Name;
                _db.Categories.Update(objFromDb);
                await _db.SaveChangesAsync();
                return _mapper.Map<Category, CategoryDTO>(objFromDb);
            }
            return objDTO;
        }
    }
}