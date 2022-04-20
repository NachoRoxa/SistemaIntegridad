// Decompiled with JetBrains decompiler
// Type: App.Core.Entities.Core.ConsultaModel
// Assembly: App.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1BF6F6E1-2696-4F22-9AA9-802440B37AD4
// Assembly location: C:\Users\IROCHA\source\repos\Integridad\sintegridadweb\bin\App.Core.dll

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Core.Entities.Core
{
  [NotMapped]
  public class ConsultaModel
  {
    [Required(ErrorMessage = "Se debe indicar la fecha")]
    [Display(Name = "Fecha")]
    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
    [DataType(DataType.Date)]
    public DateTime Fecha { get; set; } = DateTime.Now;

    [Required(ErrorMessage = "Es necesario especificar este dato")]
    [Display(Name = "Nombre : ")]
    public string Nombre { get; set; }

    [Required(ErrorMessage = "Es necesario especificar este dato")]
    [RegularExpression("\\d{8}", ErrorMessage = "Excede el largo máximo (8)")]
    [Display(Name = "Rut : ")]
    public int Rut { get; set; }

    [Required(ErrorMessage = "Es necesario especificar este dato")]
    [StringLength(1, ErrorMessage = "Excede el largo máximo (1)")]
    [Display(Name = "DV")]
    public string DV { get; set; }

    [Required(ErrorMessage = "Es necesario especificar este dato")]
    [RegularExpression("[^@]+@[^\\.]+\\.[a-zA-Z]{2,}", ErrorMessage = "Direccion de email no es correcta")]
    [Display(Name = "Email : ")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Es necesario especificar este dato")]
    [Display(Name = "Región : ")]
    public string Region { get; set; }

    [Required(ErrorMessage = "Es necesario especificar este dato")]
    [Display(Name = "Desea que sus datos sean revelados o compartidos : ")]
    public bool? CampoPrivacidad { get; set; }

    [Required(ErrorMessage = "Es necesario especificar este dato")]
    [Display(Name = "Seleccione Tipo de Respuesta : ")]
    public bool? TipoRespuesta { get; set; }

    [Required(ErrorMessage = "Es necesario especificar este dato")]
    [Display(Name = "Descripción : ")]
    [DataType(DataType.MultilineText)]
    public string Descripcion { get; set; }

    [Display(Name = "Calle, Avenida o Pasaje : ")]
    [DataType(DataType.MultilineText)]
    public string Direccion { get; set; }

    [Display(Name = "Número : ")]
    public string Numero { get; set; }

    [Display(Name = "Depto/Oficina : ")]
    public string DeptoOficina { get; set; }

    [Display(Name = "Comuna : ")]
    [DataType(DataType.MultilineText)]
    public string Comuna { get; set; }

    [Display(Name = "Código Postal : ")]
    public string CodigoPostal { get; set; }

    [Display(Name = "Ciudad : ")]
    [DataType(DataType.MultilineText)]
    public string Ciudad { get; set; }
  }
}
