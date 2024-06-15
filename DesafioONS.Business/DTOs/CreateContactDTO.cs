namespace DesafioONS.Business.DTOs
{
    public record class CreateContactDTO
    {       
        public string PhoneNumber { get; set; } = string.Empty;
        
    }
}