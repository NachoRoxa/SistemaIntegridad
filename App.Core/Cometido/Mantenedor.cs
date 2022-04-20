// Decompiled with JetBrains decompiler
// Type: App.Core.Entities.Cometido.Mantenedor
// Assembly: App.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1BF6F6E1-2696-4F22-9AA9-802440B37AD4
// Assembly location: C:\Users\IROCHA\source\repos\Integridad\sintegridadweb\bin\App.Core.dll

using App.Core.Entities.Core;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Core.Entities.Cometido
{
  [Table("Mantenedor")]
  public class Mantenedor : BaseEntity
  {
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Display(Name = "Mantenedor Id")]
    public int MantenedorId { get; set; }

    [Display(Name = "Nombre Campo")]
    public string NombreCampo { get; set; }

    [Display(Name = "Valor Campo")]
    public string ValorCampo { get; set; }

    [Display(Name = "Numero Cometido")]
    public string IdCometido { get; set; }
  }
}
