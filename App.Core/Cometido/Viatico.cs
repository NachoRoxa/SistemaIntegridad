// Decompiled with JetBrains decompiler
// Type: App.Core.Entities.Cometido.Viatico
// Assembly: App.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1BF6F6E1-2696-4F22-9AA9-802440B37AD4
// Assembly location: C:\Users\IROCHA\source\repos\Integridad\sintegridadweb\bin\App.Core.dll

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Core.Entities.Cometido
{
  [Table("Viatico")]
  public class Viatico
  {
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    [Display(Name = "ViaticoId")]
    public int ViaticoId { get; set; }

    [Required(ErrorMessage = "Se debe ingresar un valor para el Rango 1")]
    [Display(Name = "Rango1")]
    public int? Rango1 { get; set; }

    [Required(ErrorMessage = "Se debe ingresar un valor para el Rango 2")]
    [Display(Name = "Rango2")]
    public int? Rango2 { get; set; }

    [Required(ErrorMessage = "Se debe ingresar un valor para el Rango 3")]
    [Display(Name = "Rango3")]
    public int? Rango3 { get; set; }

    [Required(ErrorMessage = "Se debe ingresar un valor para el Rango 4")]
    [Display(Name = "Rango4")]
    public int? Rango4 { get; set; }

    [Required(ErrorMessage = "Se debe ingresar un valor para el Rango 5")]
    [Display(Name = "Rango5")]
    public int? Rango5 { get; set; }

    [Required(ErrorMessage = "Se debe ingresar un valor para el Año")]
    [Display(Name = "Año")]
    public int? Año { get; set; }

    [Required(ErrorMessage = "Se debe ingresar un valor para el campo Activo")]
    [Display(Name = "Activo")]
    public bool Activo { get; set; } = true;
  }
}
