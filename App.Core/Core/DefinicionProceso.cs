// Decompiled with JetBrains decompiler
// Type: App.Core.Entities.Core.DefinicionProceso
// Assembly: App.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1BF6F6E1-2696-4F22-9AA9-802440B37AD4
// Assembly location: C:\Users\IROCHA\source\repos\Integridad\sintegridadweb\bin\App.Core.dll

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Core.Entities.Core
{
  [Table("CoreDefinicionProceso")]
  public class DefinicionProceso
  {
    public DefinicionProceso()
    {
      this.DefinicionWorkflows = (ICollection<DefinicionWorkflow>) new HashSet<DefinicionWorkflow>();
      this.Procesos = (ICollection<Proceso>) new HashSet<Proceso>();
    }

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Display(Name = "Id")]
    public int DefinicionProcesoId { get; set; }

    [Required(ErrorMessage = "Es necesario especificar este dato")]
    [Display(Name = "Nombre proceso")]
    public string Nombre { get; set; }

    [Required(ErrorMessage = "Es necesario especificar este dato")]
    [Display(Name = "Descripción")]
    [DataType(DataType.MultilineText)]
    public string Descripcion { get; set; }

    [Required(ErrorMessage = "Es necesario especificar este dato")]
    [Display(Name = "Duración (horas)")]
    public int DuracionHoras { get; set; }

    [Required(ErrorMessage = "Es necesario especificar este dato")]
    [Display(Name = "Habilitado?")]
    public bool Habilitado { get; set; }

    [Required(ErrorMessage = "Es necesario especificar este dato")]
    [Display(Name = "Ir a la bandeja de tareas tras iniciar proceso")]
    public bool EjecutarInmediatamente { get; set; }

    public virtual ICollection<DefinicionWorkflow> DefinicionWorkflows { get; set; }

    public virtual ICollection<Proceso> Procesos { get; set; }

    [NotMapped]
    [Display(Name = "Participantes")]
    public string Grupos { get; set; }
  }
}
