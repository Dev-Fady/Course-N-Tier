using Course_N_Tier.DAL.Database;
using Course_N_Tier.DAL.Models;

namespace Course_N_Tier.DAL.Repository
{
    public class StudentRepo : IStudentRepo
    {
        private readonly AppDbContext context;

        public StudentRepo(AppDbContext context)
        {
            this.context = context;
        }

        public IQueryable<Student> GetAllStuedt()
        {
            return context.Students;
        }

        public Student GetStuedtById(Guid Id)
        {
            return context.Students.FirstOrDefault(a => a.Id == Id);
        }
        public void AddStudent(Student student)
        {
            context.Add(student);
            context.SaveChanges();
        }

        public void DeleteStudent(Guid id)
        {
            var student = context.Students.FirstOrDefault(a => a.Id == id);

            if (student != null)
            {
                context.Students.Remove(student);
                context.SaveChanges();
            }
        }


        public void UpdateStudent(Student student)
        {
           context.Update(student);
            context.SaveChanges();
        }
    }
}
