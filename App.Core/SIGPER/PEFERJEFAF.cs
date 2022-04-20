// Decompiled with JetBrains decompiler
// Type: App.Core.Entities.SIGPER.PEFERJEFAF
// Assembly: App.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1BF6F6E1-2696-4F22-9AA9-802440B37AD4
// Assembly location: C:\Users\IROCHA\source\repos\Integridad\sintegridadweb\bin\App.Core.dll

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Core.Entities.SIGPER
{
  [Table("PEFERJEFAF")]
  public class PEFERJEFAF
  {
    [Key]
    [Column(Order = 0)]
    [StringLength(3)]
    public string PeFerJerInst { get; set; }

    public Decimal PeFerJerCod { get; set; }

    public int FyPFunRut { get; set; }
  }
}
