// Decompiled with JetBrains decompiler
// Type: App.Core.Entities.Core.Proceso
// Assembly: App.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1BF6F6E1-2696-4F22-9AA9-802440B37AD4
// Assembly location: C:\Users\IROCHA\source\repos\Integridad\sintegridadweb\bin\App.Core.dll

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Core.Entities.Core
{
  [Table("CoreProceso")]
  public class Proceso
  {
    public Proceso()
    {
      this.Workflows = (ICollection<Workflow>) new HashSet<Workflow>();
      this.Documentos = (ICollection<Documento>) new HashSet<Documento>();
    }

    public ConsultaModel Denuncia { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Editable(false)]
    [Display(Name = "Id")]
    public int ProcesoId { get; set; }

    [Required(ErrorMessage = "Es necesario especificar este dato")]
    [Display(Name = "Definición proceso")]
    public int DefinicionProcesoId { get; set; }

    public virtual DefinicionProceso DefinicionProceso { get; set; }

    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy HH:mm:ss}")]
    [Display(Name = "Fecha creación")]
    [DataType(DataType.Date)]
    public DateTime FechaCreacion { get; set; }

    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy HH:mm:ss}")]
    [Display(Name = "Fecha vencimiento")]
    [DataType(DataType.Date)]
    public DateTime? FechaVencimiento { get; set; }

    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy HH:mm:ss}")]
    [Display(Name = "Fecha término")]
    [DataType(DataType.Date)]
    public DateTime? FechaTermino { get; set; }

    [Display(Name = "Observaciones")]
    [DataType(DataType.MultilineText)]
    public string Observacion { get; set; }

    [Display(Name = "Terminado?")]
    public bool Terminada { get; set; }

    [Display(Name = "Anulada?")]
    public bool Anulada { get; set; }

    [Display(Name = "Autor")]
    public string Email { get; set; }

    [NotMapped]
    [Display(Name = "Tiempo ejecución")]
    public TimeSpan Span => (this.FechaTermino.HasValue ? this.FechaTermino.Value : DateTime.Now) - this.FechaCreacion;

    public virtual ICollection<Workflow> Workflows { get; set; }

    public virtual ICollection<Documento> Documentos { get; set; }
  }
}
