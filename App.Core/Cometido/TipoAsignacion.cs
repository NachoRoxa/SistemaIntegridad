// Decompiled with JetBrains decompiler
// Type: App.Core.Entities.Cometido.TipoAsignacion
// Assembly: App.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1BF6F6E1-2696-4F22-9AA9-802440B37AD4
// Assembly location: C:\Users\IROCHA\source\repos\Integridad\sintegridadweb\bin\App.Core.dll

using App.Core.Entities.Core;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Core.Entities.Cometido
{
  [Table("TipoAsignacion")]
  public class TipoAsignacion : BaseEntity
  {
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Display(Name = "TipoAsignacionId")]
    public int TipoAsignacionId { get; set; }

    [Required(ErrorMessage = "Es necesario especificar este dato")]
    [Display(Name = "Nombre")]
    public string TasNombre { get; set; }

    [Required(ErrorMessage = "Es necesario especificar este dato")]
    [Display(Name = "Activo")]
    public bool TasActivo { get; set; }
  }
}
