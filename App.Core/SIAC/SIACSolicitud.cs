// Decompiled with JetBrains decompiler
// Type: App.Core.Entities.SIAC.SIACSolicitud
// Assembly: App.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1BF6F6E1-2696-4F22-9AA9-802440B37AD4
// Assembly location: C:\Users\IROCHA\source\repos\Integridad\sintegridadweb\bin\App.Core.dll

using App.Core.Entities.Core;
using App.Core.Entities.Shared;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;

namespace App.Core.Entities.SIAC
{
  [Table("SIACSolicitud")]
  public class SIACSolicitud
  {
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Display(Name = "Id")]
    public int SIACSolicitudId { get; set; }

    [Display(Name = "Tipo de solicitud")]
    public int? SIACTipoSolicitudId { get; set; }

    public virtual SIACTipoSolicitud SIACTipoSolicitud { get; set; }

    [Required(ErrorMessage = "Es necesario especificar este dato")]
    [Display(Name = "RUT (sin puntos ni guión)")]
    public int RUT { get; set; }

    [Display(Name = "Nombres")]
    public string Nombres { get; set; }

    [Display(Name = "Fecha nacimiento")]
    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
    [DataType(DataType.Date)]
    public DateTime? FechaNacimiento { get; set; }

    [Display(Name = "Teléfono")]
    public string Telefono { get; set; }

    [Display(Name = "Dirección")]
    public string Direccion { get; set; }

    [Display(Name = "Email")]
    [EmailAddress(ErrorMessage = "Debe ingresar un correo válido")]
    public string Email { get; set; }

    [Display(Name = "Región")]
    public int? RegionId { get; set; }

    public virtual Region Region { get; set; }

    [Display(Name = "Género")]
    public int? GeneroId { get; set; }

    public virtual Genero Genero { get; set; }

    [Display(Name = "Ocupación")]
    public int? SIACOcupacionId { get; set; }

    public virtual SIACOcupacion SIACOcupacion { get; set; }

    [Display(Name = "Tema")]
    public int? SIACTemaId { get; set; }

    public virtual SIACTema SIACTema { get; set; }

    [Required(ErrorMessage = "Es necesario especificar este dato")]
    [Display(Name = "Consulta")]
    [DataType(DataType.MultilineText)]
    public string Consulta { get; set; }

    [Display(Name = "Respuesta")]
    [DataType(DataType.MultilineText)]
    public string Respuesta { get; set; }

    [Display(Name = "Archivo")]
    [DataType(DataType.Upload)]
    public byte[] ArchivoBinary { get; set; }

    [NotMapped]
    [Display(Name = "Curriculum vitae actualizado")]
    [DataType(DataType.Upload)]
    public HttpPostedFileBase Archivo { get; set; }

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
