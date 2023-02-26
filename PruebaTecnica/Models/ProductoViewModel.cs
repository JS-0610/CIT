using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PruebaTecnica.Models
{
    public class ProductoViewModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public double Precio { get; set; }
        public string Descripcion { get; set;}
        public string Imagen { get; set;}
        public string Unidad { get; set; }
        public double Cantidad { get; set;}

    }

    public class ProductoAddViewModel
    {
        [Required]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [RegularExpression("^[0-9]+([.][0-9]+)?$", ErrorMessage = "Solo se permiten números enteros y decimales(usar '.')")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "El precio es obligatorio")]
        [Display(Name = "Precio")]
        public double Precio { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "La descripción debe tener 1 a 50 caracteres")]
        [Display(Name = "Descripcion")]
        public string Descripcion { get; set; }

        [Required]
        [Display(Name = "Imagen")]
        public string Imagen { get; set; }

        [Required]
        [StringLength(2, MinimumLength = 2, ErrorMessage = "La unidad debe tener 2 caracteres")]
        [Display(Name = "Unidad")]
        public string Unidad { get; set; }

        [Required]
        [RegularExpression("^[0-9]+([.][0-9]+)?$", ErrorMessage = "Solo se permiten números enteros y decimales(usar '.')")]
        [Display(Name = "Cantidad")]
        public double Cantidad { get; set; }

    }

    public class ProductoEditViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [RegularExpression("^[0-9]+([.][0-9]+)?$", ErrorMessage = "Solo se permiten números enteros y decimales(usar '.')")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "El precio es obligatorio")]
        [Display(Name = "Precio")]
        public double Precio { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "La descripción debe tener 1 a 50 caracteres")]
        [Display(Name = "Descripcion")]
        public string Descripcion { get; set; }

        [Required]
        [Display(Name = "Imagen")]
        public string Imagen { get; set; }

        [Required]
        [StringLength(2, MinimumLength = 2, ErrorMessage = "La unidad debe tener 2 caracteres")]
        [Display(Name = "Unidad")]
        public string Unidad { get; set; }

        [Required]
        [RegularExpression("^[0-9]+([.][0-9]+)?$", ErrorMessage = "Solo se permiten números enteros y decimales(usar '.')")]
        [Display(Name = "Cantidad")]
        public double Cantidad { get; set; }

    }
}