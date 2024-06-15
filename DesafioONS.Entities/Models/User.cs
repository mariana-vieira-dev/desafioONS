using System.Text.Json.Serialization;

namespace DesafioONS.Entities.Models
{
    public class User : Entity
    {  
        public string Name { get;  set; }
        public string Email { get; set; }
        public string Login { get;  set; }
        public string Password { get;  set; }
        public string Role { get; set; }
        public virtual ICollection<Contact> Contacts { get;  set; } = new List<Contact>();

        public User() { }

        [JsonConstructor]
        public User(string name, string email, string login, string password, string role)
        {

            Name = name;
            Email = email;
            Login = login;
            Password = password;
            Role = role;

        }
       
        public User(int id, string name, string email, string login, string password, string role)
        {            
            Id = id;
            Name = name;
            Email = email;
            Login = login;
            Password = password;
            Role = role;
        }
    }
}