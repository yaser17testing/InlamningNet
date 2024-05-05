namespace Net.UI.Models.Entity
{
    public class AppUser
    {

        public Guid Id { get; set; }


        public string Name { get; set; }

        public string LastName { get; set; }

        public string? ProfilImage {  get; set; } 
        public string? Bio {  get; set; }
        public string IdentityUserId { get; set; }

        public ICollection<Order> Orders { get; set; }

        public Adress Adress { get; set; }
    }
}
