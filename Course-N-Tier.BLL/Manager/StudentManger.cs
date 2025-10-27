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
    public class StudentManger : IStudentManger
    {
        private readonly IStudentRepo studentRepo;

        public StudentManger(IStudentRepo studentRepo)
        {
            this.studentRepo = studentRepo;
        }
        public async Task AddStudent(StudentAddDto studentDto)
        {
            var student = new Student
            {
                Name = studentDto.Name,
                Description = studentDto.Description,
                InstructorId=studentDto.Guid
            };

            await studentRepo.AddStudent(student);
        }

        public async Task DeleteStudent(Guid Id)
        {
            var existingStudent = await studentRepo.GetStuedtById(Id);

            if (existingStudent == null)
                throw new Exception("الطالب غير موجود");

           await studentRepo.DeleteStudent(Id);
        }

        public async Task<IEnumerable<StudentReadDto>> GetAllStuedt()
        {
            var studennt=await studentRepo.GetAllStuedt();
            var studetsDtos = studennt.Select(s => new StudentReadDto
            {
                Id = s.Id,
                Name = s.Name,
                Description = s.Description,
                InstructorId = s.InstructorId,
                JoinStudent = s.JoinStudent,
                Instructor = s.Instructor
            }).ToList();
            return studetsDtos;
        }

        public async Task<StudentReadDto?> GetStuedtById(Guid id)
        {
            var s = await studentRepo.GetStuedtById(id);

            if (s == null) return null;

            return new StudentReadDto
            {
                Id = s.Id,
                Name = s.Name,
                Description = s.Description,
                InstructorId = s.InstructorId,
                JoinStudent = s.JoinStudent,
                Instructor = s.Instructor
            };
        }

        public async Task UpdateStudent(StudentUpdateDto student)
        {
            var existingStudent = await studentRepo.GetStuedtById(student.Id);

            if (existingStudent == null)
                throw new Exception("الطالب غير موجود");

            var Updatestudent = new Student
            {
                Name = student.Name,
                Description = student.Description
            };

            await studentRepo.UpdateStudent(Updatestudent);
        }
    }
}