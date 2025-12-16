namespace MvcGroentenEnFruit.ViewModels.Identity
{
    public class UserRoleViewModel
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string RoleId { get; set; }

        // UserId en RoleId zijn hier altijd string omdat binnen de objecten IdentityRole en IdentityUser de properties ook als string gedefinieerd zijn primary key
    }
}
