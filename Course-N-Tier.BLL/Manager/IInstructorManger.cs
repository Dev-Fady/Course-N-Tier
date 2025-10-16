using Course_N_Tier.BLL.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course_N_Tier.BLL.Manager
{
    public interface IInstructorManger
    {
        IEnumerable<InstructorReadDto> GetAllInstructors();
        InstructorReadDto GetInstructorById(Guid id);
        void AddInstructor(InstructorAddDto instructor);
        void UpdateInstructor(InstructorUpdateDto instructor);
        void DeleteInstructor(Guid id);
    }
}
