// Decompiled with JetBrains decompiler
// Type: App.Core.Entities.SIGPER.DGPAISES
// Assembly: App.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1BF6F6E1-2696-4F22-9AA9-802440B37AD4
// Assembly location: C:\Users\IROCHA\source\repos\Integridad\sintegridadweb\bin\App.Core.dll

using System.ComponentModel.DataAnnotations;

namespace App.Core.Entities.SIGPER
{
  public class DGPAISES
  {
    [Key]
    [Display(Name = "Pl_CodPai")]
    public short Pl_CodPai { get; set; }

    [Display(Name = "pl_DesPai")]
    public string pl_DesPai { get; set; }
  }
}
