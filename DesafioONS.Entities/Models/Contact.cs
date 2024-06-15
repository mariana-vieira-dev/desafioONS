using System.Text.Json.Serialization;

namespace DesafioONS.Entities.Models
{
    public class Contact : Entity
    {       
        public string PhoneNumber { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }

        public Contact() { }

        [JsonConstructor]
        public Contact(int id, string phoneNumber, int userId)
        {            
            Id = id;
            PhoneNumber = phoneNumber;
            UserId = userId;
        }          
    }
}