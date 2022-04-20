// Decompiled with JetBrains decompiler
// Type: App.Core.Entities.SIGPER.SIGPERTipoVehiculo
// Assembly: App.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1BF6F6E1-2696-4F22-9AA9-802440B37AD4
// Assembly location: C:\Users\IROCHA\source\repos\Integridad\sintegridadweb\bin\App.Core.dll

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Core.Entities.SIGPER
{
  [Table("SIGPERTipoVehiculo")]
  public class SIGPERTipoVehiculo
  {
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    [Display(Name = "Id")]
    public int SIGPERTipoVehiculoId { get; set; }

    [Required(ErrorMessage = "Es necesario especificar este dato")]
    [Display(Name = "Nombre")]
    public string Vehiculo { get; set; }

    [Display(Name = "Activo")]
    public bool Activo { get; set; } = true;
  }
}
