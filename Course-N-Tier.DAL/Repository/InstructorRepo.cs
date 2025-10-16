using Course_N_Tier.DAL.Database;
using Course_N_Tier.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course_N_Tier.DAL.Repository
{
    public class InstructorRepo : IInstructorRepo
    {
        private readonly AppDbContext context;

        public InstructorRepo(AppDbContext context)
        {
            this.context = context;
        }
        public void AddInstructor(Instructor instructor)
        {
            context.Add(instructor);
            context.SaveChanges();
        }

        public void DeleteInstructor(Guid Id)
        {
            var instructor = context.Instructors.FirstOrDefault(a => a.Id == Id);

            if (instructor != null)
            {
                context.Instructors.Remove(instructor);
                context.SaveChanges();
            }
        }

        public IQueryable<Instructor> GetAllInInstructor()
        {
            return context.Instructors;
        }

        public Instructor GetInstructorById(Guid Id)
        {
            return context.Instructors.FirstOrDefault(x => x.Id == Id);
        }

        public void UpdateInstructor(Instructor instructor)
        {
            context.Update(instructor);
            context.SaveChanges();
        }
    }
}
