// Decompiled with JetBrains decompiler
// Type: App.Core.Entities.Core.TipoEjecucion
// Assembly: App.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1BF6F6E1-2696-4F22-9AA9-802440B37AD4
// Assembly location: C:\Users\IROCHA\source\repos\Integridad\sintegridadweb\bin\App.Core.dll

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Core.Entities.Core
{
  [Table("CoreTipoEjecucion")]
  public class TipoEjecucion
  {
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Display(Name = "Id")]
    public int TipoEjecucionId { get; set; }

    [Required(ErrorMessage = "Es necesario especificar este dato")]
    [Display(Name = "Tipo ejecución")]
    public string Nombre { get; set; }

    public bool Activo { get; set; } = true;

    [Display(Name = "Orden")]
    public int Order { get; set; }
  }
}
