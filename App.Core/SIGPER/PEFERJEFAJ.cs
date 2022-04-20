// Decompiled with JetBrains decompiler
// Type: App.Core.Entities.SIGPER.PEFERJEFAJ
// Assembly: App.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1BF6F6E1-2696-4F22-9AA9-802440B37AD4
// Assembly location: C:\Users\IROCHA\source\repos\Integridad\sintegridadweb\bin\App.Core.dll

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Core.Entities.SIGPER
{
  [Table("PEFERJEFAJ")]
  public class PEFERJEFAJ
  {
    [Key]
    [Column(Order = 0)]
    [StringLength(3)]
    public string PeFerJerInst { get; set; }

    public Decimal PeFerJerCod { get; set; }

    public int FyPFunARut { get; set; }

    public int PeFerJerAutEst { get; set; }
  }
}
