// Decompiled with JetBrains decompiler
// Type: App.Core.Entities.Cometido.ViaticoHonorario
// Assembly: App.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1BF6F6E1-2696-4F22-9AA9-802440B37AD4
// Assembly location: C:\Users\IROCHA\source\repos\Integridad\sintegridadweb\bin\App.Core.dll

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Core.Entities.Cometido
{
  [Table("ViaticoHonorario")]
  public class ViaticoHonorario
  {
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    [Display(Name = "ViaticoHonorarioId")]
    public int ViaticoHonorarioId { get; set; }

    [Required(ErrorMessage = "Se debe ingresar un valor para el campo Año")]
    [Display(Name = "Año")]
    public int? Año { get; set; }

    [Required(ErrorMessage = "Se debe ingresar un valor para el campo Desde")]
    [Display(Name = "Desde")]
    public int? Desde { get; set; }

    [Required(ErrorMessage = "Se debe ingresar un valor para el campo Hasta")]
    [Display(Name = "Hasta")]
    public int? Hasta { get; set; }

    [Required(ErrorMessage = "Se debe ingresar un valor para el campo Paorcentaje 100%")]
    [Display(Name = "Porcentaje 100")]
    public int? Porcentaje100 { get; set; }

    [Required(ErrorMessage = "Se debe ingresar un valor para el campo Paorcentaje 60%")]
    [Display(Name = "Porcentaje 60%")]
    public int? Porcentaje60 { get; set; }

    [Required(ErrorMessage = "Se debe ingresar un valor para el campo Paorcentaje 40%")]
    [Display(Name = "Porcentaje 40%")]
    public int? Porcentaje40 { get; set; }

    [Required(ErrorMessage = "Se debe ingresar un valor para el campo Paorcentaje 50%")]
    [Display(Name = "Porcentaje 50")]
    public int? Porcentaje50 { get; set; }

    [Required(ErrorMessage = "Se debe ingresar un valor para el campo Tramo")]
    [Display(Name = "Tramo")]
    public string Tramo { get; set; }

    [Required(ErrorMessage = "Se debe ingresar un valor para el campo Activo")]
    [Display(Name = "Activo")]
    public bool Activo { get; set; } = true;
  }
}
