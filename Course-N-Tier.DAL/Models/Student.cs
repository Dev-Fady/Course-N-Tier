using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course_N_Tier.DAL.Models
{
    public class Student
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "الاسم مطلوب")]
        [StringLength(100, ErrorMessage = "الاسم لا يمكن أن يزيد عن 100 حرف")]
        public string Name { get; set; }

        [StringLength(250, ErrorMessage = "الوصف لا يمكن أن يزيد عن 250 حرف")]
        public string Description { get; set; }

        public DateTime JoinStudent { get; set; }

        public Guid InstructorId { get; set; }
        public Instructor Instructor { get; set; }

    }
}
