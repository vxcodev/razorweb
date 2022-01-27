using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
namespace Razorweb.Models{
    public class AppUser:IdentityUser{
        [Column(TypeName ="nvarchar")]
        [StringLength(500,MinimumLength =3)]
        public string HomeAddress { get; set; }
    }
}