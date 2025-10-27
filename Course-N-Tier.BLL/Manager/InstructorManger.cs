using Course_N_Tier.BLL.Dtos;
using Course_N_Tier.DAL;
using Course_N_Tier.DAL.Models;
using Course_N_Tier.DAL.Repository;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course_N_Tier.BLL.Manager
{
    public class InstructorManger : IInstructorManger
    {
        private readonly IInstructorRepo instructorRepo;
        private readonly IMemoryCache _cache;

        public InstructorManger(IInstructorRepo instructorRepo, IMemoryCache cache)
        {
            this.instructorRepo = instructorRepo;
            _cache = cache;
        }
        public void AddInstructor(InstructorAddDto instructor)
        {
            var newinstructor = new Instructor
            {
                Name = instructor.Name,
                Description = instructor.Description,
                SaleryPrice = instructor.SaleryPrice,
                Rate = instructor.Rate,
                Poines  = instructor.Poines,
            };

            instructorRepo.AddInstructor(newinstructor);
        }

        public void DeleteInstructor(Guid id)
        {
            var existing = instructorRepo.GetInstructorById(id);
            if (existing == null)
                throw new Exception("المدرب غير موجود");
            instructorRepo.DeleteInstructor(id);
            _cache.Remove($"{CacheConstant.InstructorCacheKey}_{id}");
            if (_cache.TryGetValue(CacheConstant.InstructorCacheKey, out IEnumerable<InstructorReadDto> dtos))
            {
                var newInstructorDtos = dtos.Where(i => i.Id != id).ToList();
                _cache.Set(CacheConstant.InstructorCacheKey, newInstructorDtos, TimeSpan.FromMinutes(1));
            }
        }

        public IEnumerable<InstructorReadDto> GetAllInstructors()
        {
            if (!_cache.TryGetValue(CacheConstant.InstructorCacheKey,out IEnumerable<InstructorReadDto> dtos))
            {

                var instructors = instructorRepo.GetAllInInstructor();

                 dtos = instructors.Select(i => new InstructorReadDto
                {
                    Id = i.Id,
                    Name = i.Name,
                    Description = i.Description,
                    SaleryPrice = i.SaleryPrice,
                    Rate = i.Rate,
                    Poines = i.Poines,
                    Students = i.Students
                }).ToList();

                _cache.Set(CacheConstant.InstructorCacheKey, dtos, TimeSpan.FromMinutes(1));
            }

            return dtos;
        }

        public InstructorReadDto GetInstructorById(Guid id)
        {
            string cacheKey = $"{CacheConstant.InstructorCacheKey}_{id}";

            if (!_cache.TryGetValue(cacheKey, out InstructorReadDto dto))
            {
                var instructor = instructorRepo.GetInstructorById(id);
                if (instructor == null)
                    return null;

                dto = new InstructorReadDto
                {
                    Id = instructor.Id,
                    Name = instructor.Name,
                    Description = instructor.Description,
                    SaleryPrice = instructor.SaleryPrice,
                    Rate = instructor.Rate,
                    Poines = instructor.Poines,
                    Students = instructor.Students
                };

                _cache.Set(cacheKey, dto, TimeSpan.FromMinutes(1));
            }

            return dto;
        }

        public void UpdateInstructor(InstructorUpdateDto instructor)
        {
            var existing = instructorRepo.GetInstructorById(instructor.Id);
            if (existing == null)
                throw new Exception("المدرب غير موجود");

            existing.Name = instructor.Name;
            existing.Description = instructor.Description;
            existing.SaleryPrice = instructor.SaleryPrice;
            existing.Rate = instructor.Rate;
            existing.Poines = instructor.Poines;

            instructorRepo.UpdateInstructor(existing);

            _cache.Remove($"{CacheConstant.InstructorCacheKey}_{existing.Id}");
            if (_cache.TryGetValue(CacheConstant.InstructorCacheKey, out IEnumerable<InstructorReadDto> dtos))
            {
                var newInstructorDtos = dtos.Where(i => i.Id != existing.Id).ToList();
                newInstructorDtos.Add(new InstructorReadDto
                {
                    Id = existing.Id,
                    Name = existing.Name,
                    Description = existing.Description,
                    SaleryPrice = existing.SaleryPrice,
                    Rate = existing.Rate,
                    Poines = existing.Poines,
                });
                _cache.Set(CacheConstant.InstructorCacheKey, newInstructorDtos, TimeSpan.FromMinutes(1));
            }
        }
    }
}
