using Course_N_Tier.DAL.Database;
using Course_N_Tier.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace Course_N_Tier.DAL.Repository
{
    public class StudentRepo : IStudentRepo
    {
        private readonly AppDbContext context;

        public StudentRepo(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<IQueryable<Student>> GetAllStuedt()
        {
            return await Task.FromResult(context.Students.AsNoTracking().AsQueryable());
        }

        public async Task<Student?> GetStuedtById(Guid Id)
        {
            return await context.Students.FirstOrDefaultAsync(a => a.Id == Id);
        }
        public async Task AddStudent(Student student)
        {
            context.Add(student);
            await context.SaveChangesAsync();
        }

        public async Task DeleteStudent(Guid id)
        {
            var student = await context.Students.FirstOrDefaultAsync(a => a.Id == id);

            if (student != null)
            {
                context.Students.Remove(student);
                await context.SaveChangesAsync();
            }
        }


        public async Task UpdateStudent(Student student)
        {
            context.Update(student);
            await context.SaveChangesAsync();
        }
    }
}
