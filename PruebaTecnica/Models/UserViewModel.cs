using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PruebaTecnica.Models
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Usuario { get; set; }
        public string Email { get; set; }
        public string Celular { get; set; }
        public string Puesto { get; set; }
    }

    public class UserAddViewModel
    {
        [Required]
        public string Nombre { get; set; }

        [Required]
        [StringLength(15, ErrorMessage = "El Usuario es demasiado largo")]
        public string Usuario { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Correo Electrónico")]
        public string Email { get; set; }

        [RegularExpression("(^[0-9]+$)", ErrorMessage = "Solo se permiten números")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "El número es obligatorio")]
        [StringLength(8,MinimumLength =8, ErrorMessage = "El número debe ser de 8 digitos")]
        public string Celular { get; set; }
    }

    public class UserEditViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        [StringLength(15, ErrorMessage = "El Usuario es demasiado largo")]
        public string Usuario { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Correo Electrónico")]
        public string Email { get; set; }

        [RegularExpression("(^[0-9]+$)", ErrorMessage = "Solo se permiten números")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "El número es obligatorio")]
        [StringLength(8, MinimumLength = 8, ErrorMessage = "El número debe ser de 8 digitos")]
        public string Celular { get; set; }
    }
}