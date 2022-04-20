// Decompiled with JetBrains decompiler
// Type: App.Core.Entities.GestionDocumental.GDTipoIngreso
// Assembly: App.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1BF6F6E1-2696-4F22-9AA9-802440B37AD4
// Assembly location: C:\Users\IROCHA\source\repos\Integridad\sintegridadweb\bin\App.Core.dll

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Core.Entities.GestionDocumental
{
  [Table("GDTipoIngreso")]
  public class GDTipoIngreso
  {
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Display(Name = "Id")]
    public int GDTipoIngresoId { get; set; }

    [Display(Name = "Nombre")]
    public string Nombre { get; set; }
  }
}
