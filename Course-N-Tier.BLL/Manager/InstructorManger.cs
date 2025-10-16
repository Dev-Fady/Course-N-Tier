using Course_N_Tier.BLL.Dtos;
using Course_N_Tier.DAL.Models;
using Course_N_Tier.DAL.Repository;
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

        public InstructorManger(IInstructorRepo instructorRepo)
        {
            this.instructorRepo = instructorRepo;
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
        }

        public IEnumerable<InstructorReadDto> GetAllInstructors()
        {
            var instructors = instructorRepo.GetAllInInstructor();

            var dtos = instructors.Select(i => new InstructorReadDto
            {
                Id = i.Id,
                Name = i.Name,
                Description = i.Description,
                SaleryPrice = i.SaleryPrice,
                Rate = i.Rate,
                Poines = i.Poines,
                Students = i.Students
            }).ToList();

            return dtos;
        }

        public InstructorReadDto GetInstructorById(Guid id)
        {
            var instructor = instructorRepo.GetInstructorById(id);

            if (instructor == null)
                return null;

            return new InstructorReadDto
            {
                Id = instructor.Id,
                Name = instructor.Name,
                Description = instructor.Description,
                SaleryPrice = instructor.SaleryPrice,
                Rate = instructor.Rate,
                Poines = instructor.Poines,
                Students = instructor.Students
            };
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
        }
    }
}
