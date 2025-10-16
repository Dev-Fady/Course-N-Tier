using Course_N_Tier.DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course_N_Tier.BLL.Dtos
{
    public class StudentReadDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        public DateTime JoinStudent { get; set; }

        public Guid InstructorId { get; set; }
        public Instructor Instructor { get; set; }

    }
}
