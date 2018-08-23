
namespace DadayaAPI.Models
{
    using Microsoft.AspNetCore.Http;

    public class StaffModel
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public string Position { get; set; }
        public string Phonenumber { get; set; }
        public IFormFile Image { get; set; }
        public string DateCreated { get; set; }
    }
}
