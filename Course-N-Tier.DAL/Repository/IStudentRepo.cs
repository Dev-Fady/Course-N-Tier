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
       Task<IQueryable<Student>> GetAllStuedt();
        Task<Student?> GetStuedtById(Guid Id);

        Task AddStudent(Student student);
        Task UpdateStudent(Student student);
        Task DeleteStudent(Guid Id);
    }
}
