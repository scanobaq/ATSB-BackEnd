using Microsoft.AspNetCore.Identity;

namespace ATSB.Api.Areas.Identity.Entities.Security
{
    public class UserAtsb : IdentityUser
    {
        public string? Nombre { get; set; }
        public string? Apellido1 { get; set; }
        public string? Apellido2 { get; set; }
    }
}