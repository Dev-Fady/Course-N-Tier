using Course_N_Tier.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course_N_Tier.DAL.Repository
{
    public interface IStudentRepo
    {
        IQueryable<Student> GetAllStuedt();
        Student GetStuedtById(Guid Id);

        void AddStudent(Student student);
        void UpdateStudent(Student student);
        void DeleteStudent(Guid Id);
    }
}
