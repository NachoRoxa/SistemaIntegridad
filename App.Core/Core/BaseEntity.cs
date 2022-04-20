// Decompiled with JetBrains decompiler
// Type: App.Core.Entities.Core.BaseEntity
// Assembly: App.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1BF6F6E1-2696-4F22-9AA9-802440B37AD4
// Assembly location: C:\Users\IROCHA\source\repos\Integridad\sintegridadweb\bin\App.Core.dll

using System.ComponentModel.DataAnnotations;

namespace App.Core.Entities.Core
{
  public class BaseEntity
  {
    [Display(Name = "Proceso")]
    public int? ProcesoId { get; set; }

    public virtual Proceso Proceso { get; set; }

    [Display(Name = "Workflow")]
    public int? WorkflowId { get; set; }

    public virtual Workflow Workflow { get; set; }

    public string Tarea { get; set; }

    public string Instrucciones { get; set; }
  }
}
