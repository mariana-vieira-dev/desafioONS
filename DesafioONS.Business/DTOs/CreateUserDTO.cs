namespace DesafioONS.Business.DTOs
{
    public record class CreateUserDTO    
    {        
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Login { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public List<CreateContactDTO> Contacts { get; set; } = new List<CreateContactDTO>();

    }
}