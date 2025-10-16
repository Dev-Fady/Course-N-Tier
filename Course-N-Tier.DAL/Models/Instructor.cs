using System.ComponentModel.DataAnnotations;

namespace Course_N_Tier.DAL.Models
{
    public class Instructor 
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "الاسم مطلوب")]
        [StringLength(100, ErrorMessage = "الاسم لا يمكن أن يزيد عن 100 حرف")]
        public string Name { get; set; }

        [StringLength(250, ErrorMessage = "الوصف لا يمكن أن يزيد عن 250 حرف")]
        public string Description { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "المرتب يجب أن يكون رقمًا موجبًا")]
        public decimal SaleryPrice { get; set; }

        [Range(0, 5, ErrorMessage = "التقييم يجب أن يكون بين 0 و 5")]
        public float Rate { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "النقاط لا يمكن أن تكون سالبة")]
        public int Poines { get; set; }

        public ICollection<Student> Students { get; set; } = new List<Student>();
    }
}
