using Microsoft.AspNetCore.Mvc.Rendering;

namespace MvcGroentenEnFruit.Data
{
    public class RolesData
    {
        public static string RoleAankoper = "Aankoper";
        public const string RoleVerkoper = "Verkoper";
        public static string RoleAdmin = "Administrator";
        public static SelectList Roles() => new SelectList(GetRoles(), "Id", "RoleName");
        private static IEnumerable<RoleItem> GetRoles()
        {
            return new List<RoleItem>
            {
                new RoleItem { Id = 1, RoleName = RoleAankoper },
                new RoleItem { Id = 2, RoleName = RoleVerkoper }
            };
        }       
        
        public static string GetRoleName(int id)
        {
            var role = GetRoles()
                .Where(x => x.Id == id)
                .Select(x => x.RoleName).FirstOrDefault();
            return (role == null) ? string.Empty : role;
        }
    }
    public class RoleItem
    {
        public int Id { get; set; }
        public string RoleName { get; set; }
    }
}
