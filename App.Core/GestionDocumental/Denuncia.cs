// Decompiled with JetBrains decompiler
// Type: App.Core.Entities.FlujosIntegridad.Denuncia
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
  [Table("Denuncia")]
  public class Denuncia
  {
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Display(Name = "Id Denuncia")]
    public int DenunciaId { get; set; }

    [Required(ErrorMessage = "Es necesario especificar una fecha")]
    [Display(Name = "Fecha (Campo Obligatorio)")]
    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
    [DataType(DataType.Date)]
    public DateTime Fecha { get; set; } = DateTime.Now;

    [Required(ErrorMessage = "Es necesario especificar un nombre")]
    [Display(Name = "Nombre (Campo Obligatorio)")]
    public string Nombre { get; set; }

    [Required(ErrorMessage = "Es necesario especificar un rut")]
    [RegularExpression("\\d{8}", ErrorMessage = "Excede el largo maximo (8)")]
    [Display(Name = "Rut (Campo Obligatorio)")]
    public int Rut { get; set; }

    [Required(ErrorMessage = "Es necesario especificar un dígito verificador")]
    [StringLength(1, ErrorMessage = "Excede el largo maximo (1)")]
    [Display(Name = "DV (Campo Obligatorio)")]
    public string DV { get; set; }

    [Required(ErrorMessage = "Es necesario especificar una unidad")]
    [Display(Name = "Unidad (Campo Obligatorio)")]
    public string Unidad { get; set; }

    [Required(ErrorMessage = "Es necesario especificar un correo electrónico")]
    [RegularExpression("[^@]+@[^\\.]+\\.[a-zA-Z]{2,}", ErrorMessage = "Direccion de email no es correcta")]
    [Display(Name = "Email (Campo Obligatorio)")]
    public string Email { get; set; }

    [RequiredIf("Region", null, ErrorMessage = "Es necesario especificar una región")]
    [Display(Name = "Región (Campo Obligatorio)")]
    public string Region { get; set; }

    [RequiredIf("Comuna", null, ErrorMessage = "Es necesario especificar una comuna")]
    [Display(Name = "Comuna donde sucedieron los hechos (Campo Obligatorio)")]
    public string Comuna { get; set; }

    [Display(Name = "Nombre del Denunciado")]
    public string NombreDenunciado { get; set; }

    [Display(Name = "Lugar de los Hechos")]
    [DataType(DataType.MultilineText)]
    public string LugarHechos { get; set; }

    [RequiredIf("Descripcion", null, ErrorMessage = "Es necesario especificar una descripción")]
    [Display(Name = "Descripción de los Hechos (Campo Obligatorio)")]
    [DataType(DataType.MultilineText)]
    public string Descripcion { get; set; }

    [Display(Name = "Antecedentes Adicionales")]
    [DataType(DataType.MultilineText)]
    public string Antecedentes { get; set; }

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
  }
}
