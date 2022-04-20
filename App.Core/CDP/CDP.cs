// Decompiled with JetBrains decompiler
// Type: App.Core.Entities.CDP.CDP
// Assembly: App.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1BF6F6E1-2696-4F22-9AA9-802440B37AD4
// Assembly location: C:\Users\IROCHA\source\repos\Integridad\sintegridadweb\bin\App.Core.dll

using App.Core.Entities.Core;
using App.Core.Entities.Shared;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Core.Entities.CDP
{
  [Table("CDP")]
  public class CDP
  {
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Display(Name = "Id")]
    public int CDPId { get; set; }

    [Display(Name = "Institución")]
    public int? InstitucionId { get; set; }

    public virtual Institucion Institucion { get; set; }

    [Display(Name = "Tipo de solicitud")]
    public int? CDPTipoSolicitudId { get; set; }

    public virtual CDPTipoSolicitud CDPTipoSolicitud { get; set; }

    [Display(Name = "Bien")]
    public int? CDPBienId { get; set; }

    public virtual CDPBien CDPBien { get; set; }

    [Required(ErrorMessage = "Es necesario especificar este dato")]
    [Display(Name = "Solicitante")]
    public string Solicitante { get; set; }

    [Required(ErrorMessage = "Es necesario especificar este dato")]
    [Display(Name = "Fecha solicitud")]
    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
    [DataType(DataType.Date)]
    public DateTime? FechaSolicitud { get; set; }

    [Display(Name = "Región")]
    public int? RegionId { get; set; }

    public virtual Region Region { get; set; }

    [Display(Name = "Observaciones")]
    [DataType(DataType.MultilineText)]
    public string Observacion { get; set; }

    [Required]
    [Display(Name = "Monto")]
    public long Monto { get; set; }

    [Required(ErrorMessage = "Es necesario especificar este dato")]
    [Display(Name = "Detalle")]
    [DataType(DataType.MultilineText)]
    public string Detalle { get; set; }

    [Display(Name = "Proceso")]
    public int? ProcesoId { get; set; }

    public virtual Proceso Proceso { get; set; }

    [Display(Name = "Workflow")]
    public int? WorkflowId { get; set; }

    public virtual Workflow Workflow { get; set; }

    public string Tarea { get; set; }

    public string Instrucciones { get; set; }

    [NotMapped]
    public string EmailSolicitante { get; set; }

    [NotMapped]
    public string EmailSecretariaAsistente { get; set; }

    [NotMapped]
    public string EmailSuperiorDirector { get; set; }

    [NotMapped]
    public string EmailAutorizador { get; set; }
  }
}
