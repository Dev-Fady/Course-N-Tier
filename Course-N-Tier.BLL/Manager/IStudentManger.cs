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
        IEnumerable<StudentReadDto> GetAllStuedt();
        StudentReadDto GetStuedtById(Guid Id);

        void AddStudent(StudentAddDto student);
        void UpdateStudent(StudentUpdateDto student);
        void DeleteStudent(Guid Id);
    }
}
