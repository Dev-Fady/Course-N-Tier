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
        public void AddStudent(StudentAddDto studentDto)
        {
            var student = new Student
            {
                Name = studentDto.Name,
                Description = studentDto.Description,
                InstructorId=studentDto.Guid
            };

            studentRepo.AddStudent(student);
        }

        public void DeleteStudent(Guid Id)
        {
            var existingStudent = studentRepo.GetStuedtById(Id);

            if (existingStudent == null)
                throw new Exception("الطالب غير موجود");

            studentRepo.DeleteStudent(Id);
        }

        public IEnumerable<StudentReadDto> GetAllStuedt()
        {
            var studennt= studentRepo.GetAllStuedt();
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

        public StudentReadDto GetStuedtById(Guid id)
        {
            var s = studentRepo.GetStuedtById(id);

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

        public void UpdateStudent(StudentUpdateDto student)
        {
            var existingStudent = studentRepo.GetStuedtById(student.Id);

            if (existingStudent == null)
                throw new Exception("الطالب غير موجود");

            var Updatestudent = new Student
            {
                Name = student.Name,
                Description = student.Description
            };

            studentRepo.UpdateStudent(Updatestudent);
        }
    }
}