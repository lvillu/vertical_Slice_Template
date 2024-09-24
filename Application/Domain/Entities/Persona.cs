namespace Application.Domain.Entities
{
    public class Persona
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public int Age { get; set; }
        public bool Active { get; set; } = true;
    }
}
