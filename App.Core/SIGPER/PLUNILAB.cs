// Decompiled with JetBrains decompiler
// Type: App.Core.Entities.SIGPER.PLUNILAB
// Assembly: App.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1BF6F6E1-2696-4F22-9AA9-802440B37AD4
// Assembly location: C:\Users\IROCHA\source\repos\Integridad\sintegridadweb\bin\App.Core.dll

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Core.Entities.SIGPER
{
  [Table("PLUNILAB")]
  public class PLUNILAB
  {
    [Key]
    public int Pl_UndCod { get; set; }

    public string Pl_UndDes { get; set; }

    public string Pl_UndNomSec { get; set; }
  }
}
