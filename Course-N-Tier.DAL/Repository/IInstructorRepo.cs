using Course_N_Tier.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course_N_Tier.DAL.Repository
{
    public interface IInstructorRepo
    {
        IQueryable<Instructor> GetAllInInstructor();
        Instructor GetInstructorById(Guid Id);

        void AddInstructor(Instructor instructor);
        void UpdateInstructor(Instructor instructor);
        void DeleteInstructor(Guid Id);
    }
}
