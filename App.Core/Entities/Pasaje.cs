// Decompiled with JetBrains decompiler
// Type: App.Core.Entities.Pasajes.Pasaje
// Assembly: App.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1BF6F6E1-2696-4F22-9AA9-802440B37AD4
// Assembly location: C:\Users\IROCHA\source\repos\Integridad\sintegridadweb\bin\App.Core.dll

using App.Core.Entities.Core;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Core.Entities.Pasajes
{
  [Table("Pasaje")]
  public class Pasaje : BaseEntity
  {
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Display(Name = "Numero Pasaje")]
    public int PasajeId { get; set; }

    [Required(ErrorMessage = "Se debe indicar la fecha")]
    [Display(Name = "Fecha Solicitud")]
    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
    [DataType(DataType.Date)]
    public DateTime FechaSolicitud { get; set; }

    [Display(Name = "Nombre")]
    public string Nombre { get; set; }

    [Display(Name = "Nombre Id")]
    public int? NombreId { get; set; }

    [Required(ErrorMessage = "Es necesario especificar este dato")]
    [Display(Name = "Rut")]
    public int Rut { get; set; }

    [Required(ErrorMessage = "Es necesario especificar este dato")]
    [StringLength(1, ErrorMessage = "Excede el largo maximo (1)")]
    [Display(Name = "DV")]
    public string DV { get; set; }

    [Display(Name = "Calidad Juridica")]
    public int? IdCalidad { get; set; }

    [Display(Name = "Calidad Juridica")]
    public string CalidadDescripcion { get; set; }

    [Required(ErrorMessage = "Es necesario especificar este dato")]
    [Display(Name = "Descripcion Pasaje")]
    public string PasajeDescripcion { get; set; }

    [Display(Name = "Destino Nacional")]
    public bool? TipoDestino { get; set; }

    [Display(Name = "Comuna")]
    public string IdComuna { get; set; }

    [Display(Name = "Comuna")]
    public string ComunaDescripcion { get; set; }

    [Display(Name = "Region")]
    public string IdRegion { get; set; }

    [Display(Name = "Region")]
    public string RegionDescripcion { get; set; }

    [Display(Name = "Pais")]
    public string IdPais { get; set; }

    [Display(Name = "Pais")]
    public string PaisDescripcion { get; set; }

    [Display(Name = "Ciudad")]
    public string IdCiudad { get; set; }

    [Display(Name = "Ciudad")]
    public string CiudadDescripcion { get; set; }

    [Required(ErrorMessage = "Se debe indicar la Fecha Ida")]
    [Display(Name = "Fecha Ida")]
    [DataType(DataType.Date)]
    public DateTime FechaIda { get; set; }

    [Display(Name = "Hora Ida")]
    [DataType(DataType.Time)]
    public DateTime HoraIda { get; set; }

    [Required(ErrorMessage = "Se debe indicar la Fecha Vuelta")]
    [Display(Name = "Fecha Vuelta")]
    [DataType(DataType.Date)]
    public DateTime FechaVuelta { get; set; }

    [Display(Name = "Hora Vuelta")]
    [DataType(DataType.Time)]
    public DateTime? HoraVuelta { get; set; }
  }
}
