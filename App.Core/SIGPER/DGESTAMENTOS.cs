// Decompiled with JetBrains decompiler
// Type: App.Core.Entities.SIGPER.DGESTAMENTOS
// Assembly: App.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1BF6F6E1-2696-4F22-9AA9-802440B37AD4
// Assembly location: C:\Users\IROCHA\source\repos\Integridad\sintegridadweb\bin\App.Core.dll

using System.ComponentModel.DataAnnotations;

namespace App.Core.Entities.SIGPER
{
  public class DGESTAMENTOS
  {
    [Key]
    [Display(Name = "DgEstCod")]
    public short DgEstCod { get; set; }

    [Display(Name = "DgEstDsc")]
    public string DgEstDsc { get; set; }
  }
}
