namespace Shbl.Spt.Model.Core.Dto
{
    public class RegisterUserDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public byte AgeGroup { get; set; }
        public byte ProficiencyLevel { get; set; }
    }
}