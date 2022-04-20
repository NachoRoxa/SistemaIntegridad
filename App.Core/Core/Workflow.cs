// Decompiled with JetBrains decompiler
// Type: App.Core.Entities.Core.Workflow
// Assembly: App.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1BF6F6E1-2696-4F22-9AA9-802440B37AD4
// Assembly location: C:\Users\IROCHA\source\repos\Integridad\sintegridadweb\bin\App.Core.dll

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Core.Entities.Core
{
  [Table("CoreWorkflow")]
  public class Workflow
  {
    public Workflow() => this.Documentos = (ICollection<Documento>) new HashSet<Documento>();

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Display(Name = "Id")]
    public int WorkflowId { get; set; }

    [Required(ErrorMessage = "Es necesario especificar este dato")]
    [Display(Name = "Proceso Id")]
    public int ProcesoId { get; set; }

    public virtual Proceso Proceso { get; set; }

    [Required(ErrorMessage = "Es necesario especificar este dato")]
    [Display(Name = "Tarea")]
    public int DefinicionWorkflowId { get; set; }

    public virtual DefinicionWorkflow DefinicionWorkflow { get; set; }

    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy HH:mm:ss}")]
    [Display(Name = "Fecha creación")]
    public DateTime FechaCreacion { get; set; }

    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy HH:mm:ss}")]
    [Display(Name = "Fecha vencimiento")]
    [DataType(DataType.Date)]
    public DateTime? FechaVencimiento { get; set; }

    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy HH:mm:ss}")]
    [Display(Name = "Fecha término")]
    [DataType(DataType.Date)]
    public DateTime? FechaTermino { get; set; }

    [Display(Name = "Grupo")]
    public int? GrupoId { get; set; }

    public virtual Grupo Grupo { get; set; }

    [Display(Name = "Unidad")]
    public int? Pl_UndCod { get; set; }

    [Display(Name = "Unidad")]
    public string Pl_UndDes { get; set; }

    [Display(Name = "Funcionario")]
    public string Email { get; set; }

    [Display(Name = "Funcionario")]
    public string To { get; set; }

    [Display(Name = "Observaciones")]
    [DataType(DataType.MultilineText)]
    public string Observacion { get; set; }

    [Display(Name = "Observaciones")]
    [DataType(DataType.MultilineText)]
    public string Mensaje { get; set; }

    [Display(Name = "Tipo aprobación")]
    public int? TipoAprobacionId { get; set; }

    public virtual TipoAprobacion TipoAprobacion { get; set; }

    [Display(Name = "Terminada?")]
    public bool Terminada { get; set; }

    [Display(Name = "Anulada?")]
    public bool Anulada { get; set; }

    [Display(Name = "Tarea es personal?")]
    public bool TareaPersonal { get; set; }

    public int? WorkflowGrupoId { get; set; }

    public string Entity { get; set; }

    public int? EntityId { get; set; }

    [NotMapped]
    [Display(Name = "Certificado electrónico")]
    public string SerialNumber { get; set; }

    [NotMapped]
    [Display(Name = "Tiempo ejecución")]
    public TimeSpan Span => (this.FechaTermino.HasValue ? this.FechaTermino.Value : DateTime.Now) - this.FechaCreacion;

    public virtual ICollection<Documento> Documentos { get; set; }
  }
}
