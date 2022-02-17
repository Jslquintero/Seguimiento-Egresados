using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Egresados.Model.Entities
{
    [Table("AspNetRoles")]
    public class Rol : IdentityRole
    {
    }
}
