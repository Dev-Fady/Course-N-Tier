namespace Course_N_Tier.BLL.Dtos
{
    public class InstructorUpdateDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal SaleryPrice { get; set; }

        public float Rate { get; set; }

        public int Poines { get; set; }
    }
}
