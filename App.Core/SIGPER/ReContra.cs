// Decompiled with JetBrains decompiler
// Type: App.Core.Entities.SIGPER.ReContra
// Assembly: App.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1BF6F6E1-2696-4F22-9AA9-802440B37AD4
// Assembly location: C:\Users\IROCHA\source\repos\Integridad\sintegridadweb\bin\App.Core.dll

using System;
using System.ComponentModel.DataAnnotations;

namespace App.Core.Entities.SIGPER
{
  public class ReContra
  {
    [Key]
    [Display(Name = "RH_NumInte")]
    public int RH_NumInte { get; set; }

    [Display(Name = "Re_ConPyt")]
    public Decimal Re_ConPyt { get; set; }

    [Display(Name = "ReContraSed")]
    public short ReContraSed { get; set; }

    [Display(Name = "Re_ConIni")]
    public DateTime Re_ConIni { get; set; }

    [Display(Name = "Re_ConPyt")]
    public Decimal Re_SuelBas { get; set; }
  }
}
