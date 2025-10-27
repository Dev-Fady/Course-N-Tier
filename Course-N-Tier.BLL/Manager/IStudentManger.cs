using Course_N_Tier.BLL.Dtos;
using Course_N_Tier.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course_N_Tier.BLL.Manager
{
    public interface IStudentManger
    {
        Task<IEnumerable<StudentReadDto>?> GetAllStuedt();
        Task<StudentReadDto?> GetStuedtById(Guid Id);

        Task AddStudent(StudentAddDto student);
        Task UpdateStudent(StudentUpdateDto student);
        Task DeleteStudent(Guid Id);
    }
}
