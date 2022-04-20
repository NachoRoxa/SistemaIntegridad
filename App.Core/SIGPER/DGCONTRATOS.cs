// Decompiled with JetBrains decompiler
// Type: App.Core.Entities.SIGPER.DGCONTRATOS
// Assembly: App.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1BF6F6E1-2696-4F22-9AA9-802440B37AD4
// Assembly location: C:\Users\IROCHA\source\repos\Integridad\sintegridadweb\bin\App.Core.dll

using System.ComponentModel.DataAnnotations;

namespace App.Core.Entities.SIGPER
{
  public class DGCONTRATOS
  {
    [Key]
    [Display(Name = "RH_ContCod")]
    public short RH_ContCod { get; set; }

    [Display(Name = "RH_ContDes")]
    public string RH_ContDes { get; set; }
  }
}
