using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Core.Entities
{
    public class AuthenticateResponse
    {

        [Key]
        public string? Token { get; set; }

    }
}
