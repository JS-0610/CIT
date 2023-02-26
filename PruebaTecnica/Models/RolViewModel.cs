using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PruebaTecnica.Models
{
    public class RolViewModel
    {
        public int Id { get; set; }
        public string Rol { get; set; }
    }

    public class RolAddViewModel
    {
        [Required]
        [StringLength(10, MinimumLength = 1, ErrorMessage = "El rol debe tener de 1 a 10 letras")]
        public string Rol { get; set; }
    }

    public class RolEditViewModel
    {
        [Required]
        [StringLength(10, MinimumLength = 1, ErrorMessage = "El rol debe tener de 1 a 10 letras")]
        public string Rol { get; set; }

        public int Id { get; set; }
    }

}