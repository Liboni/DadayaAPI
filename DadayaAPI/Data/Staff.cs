namespace DadayaAPI.Data
{
    public class Staff
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public string Position { get; set; }
        public string Phonenumber { get; set; }
        public string ImagePath { get; set; }
        public string DateCreated { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
