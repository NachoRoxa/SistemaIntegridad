// Decompiled with JetBrains decompiler
// Type: App.Core.Entities.FlujosIntegridad.Consulta
// Assembly: App.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1BF6F6E1-2696-4F22-9AA9-802440B37AD4
// Assembly location: C:\Users\IROCHA\source\repos\Integridad\sintegridadweb\bin\App.Core.dll

using App.Core.Entities.Core;
using Foolproof;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Core.Entities.FlujosIntegridad
{
  [Table("Consulta")]
  public class Consulta
  {
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Display(Name = "Id Consulta")]
    public int ConsultaId { get; set; }

    [Required(ErrorMessage = "Es necesario epecificar una fecha")]
    [Display(Name = "Fecha (Campo Obligatorio)")]
    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
    [DataType(DataType.Date)]
    public DateTime Fecha { get; set; } = DateTime.Now;

    [Required(ErrorMessage = "Es necesario especificar un nombre")]
    [Display(Name = "Nombre (Campo Obligatorio)")]
    public string Nombre { get; set; }

    [Required(ErrorMessage = "Es necesario especificar un rut")]
    [RegularExpression("\\d{8}", ErrorMessage = "Excede el largo máximo (8)")]
    [Display(Name = "Rut (Campo Obligatorio)")]
    public int Rut { get; set; }

    [Required(ErrorMessage = "Es necesario especificar un dígito verificador")]
    [RequiredIf("DV", null, ErrorMessage = "Es necesario especificar un dígito verificador")]
    [StringLength(1, ErrorMessage = "Excede el largo máximo (1)")]
    [Display(Name = "DV (Campo Obligatorio)")]
    public string DV { get; set; }

    [Display(Name = "Unidad")]
    public string Unidad { get; set; }

    [Required(ErrorMessage = "Es necesario especificar un correo electrónico")]
    [RegularExpression("[^@]+@[^\\.]+\\.[a-zA-Z]{2,}", ErrorMessage = "Direccion de email no es correcta")]
    [Display(Name = "Email (Campo Obligatorio)")]
    public string Email { get; set; }

    [RequiredIf("Region", null, ErrorMessage = "Es necesario especificar una región")]
    [Display(Name = "Región (Campo Obligatorio)")]
    public string Region { get; set; }

    [Required(ErrorMessage = "Es necesario especificar si sus datos pueden ser revelados")]
    [Display(Name = "Desea que sus datos sean revelados o compartidos : (Campo Obligatorio)")]
    public bool? CampoPrivacidad { get; set; } = new bool?(false);

    [Required(ErrorMessage = "Es necesario especificar un tipo de respuesta")]
    [Display(Name = "Seleccione Tipo de Respuesta (Campo Obligatorio)")]
    public bool? TipoRespuesta { get; set; } = new bool?(true);

    [Display(Name = "Calle, Avenida o Pasaje (Campo Obligatorio)")]
    [DataType(DataType.MultilineText)]
    [RequiredIf("TipoRespuesta", true, ErrorMessage = "Es necesario especificar una dirección")]
    public string Direccion { get; set; }

    [Display(Name = "Número (Campo Obligatorio)")]
    [RequiredIf("TipoRespuesta", true, ErrorMessage = "Es necesario especificar un número")]
    public string Numero { get; set; }

    [Display(Name = "Depto/Oficina")]
    public string DeptoOficina { get; set; }

    [Display(Name = "Comuna (Campo Obligatorio)")]
    [DataType(DataType.MultilineText)]
    [RequiredIf("TipoRespuesta", true, ErrorMessage = "Es necesario especificar una comuna")]
    public string Comuna { get; set; }

    [Display(Name = "Código Postal")]
    public string CodigoPostal { get; set; }

    [Display(Name = "Ciudad (Campo Obligatorio)")]
    [DataType(DataType.MultilineText)]
    [RequiredIf("TipoRespuesta", true, ErrorMessage = "Es necesario especificar una ciudad")]
    public string Ciudad { get; set; }

    [RequiredIf("Descripcion", null, ErrorMessage = "Es necesario especificar una descripción")]
    [Display(Name = "Descripción (Campo Obligatorio)")]
    [DataType(DataType.MultilineText)]
    public string Descripcion { get; set; }

    [Display(Name = "Proceso")]
    public int? ProcesoId { get; set; }

    public virtual Proceso Proceso { get; set; }

    [Display(Name = "Workflow")]
    public int? WorkflowId { get; set; }

    public virtual Workflow Workflow { get; set; }

    [NotMapped]
    public byte[] QR { get; set; }

    [NotMapped]
    public byte[] Signature { get; set; }

    public object Consultas { get; set; }
  }
}
