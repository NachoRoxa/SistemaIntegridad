// Decompiled with JetBrains decompiler
// Type: App.Core.Entities.SIGPER.DGCOMUNAS
// Assembly: App.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1BF6F6E1-2696-4F22-9AA9-802440B37AD4
// Assembly location: C:\Users\IROCHA\source\repos\Integridad\sintegridadweb\bin\App.Core.dll

using System.ComponentModel.DataAnnotations;

namespace App.Core.Entities.SIGPER
{
  public class DGCOMUNAS
  {
    [Display(Name = "Pl_CodReg")]
    public string Pl_CodReg { get; set; }

    [Key]
    [Display(Name = "Pl_CodCom")]
    public string Pl_CodCom { get; set; }

    [Display(Name = "Pl_DesCom")]
    public string Pl_DesCom { get; set; }
  }
}
