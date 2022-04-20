// Decompiled with JetBrains decompiler
// Type: App.Core.Entities.Cometido.Cometido
// Assembly: App.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1BF6F6E1-2696-4F22-9AA9-802440B37AD4
// Assembly location: C:\Users\IROCHA\source\repos\Integridad\sintegridadweb\bin\App.Core.dll

using App.Core.Entities.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Core.Entities.Cometido
{
  [Table("Cometido")]
  public class Cometido : BaseEntity
  {
    public Cometido()
    {
      this.Destinos = new List<App.Core.Entities.Cometido.Destinos>();
      this.GeneracionCDP = new List<App.Core.Entities.Cometido.GeneracionCDP>();
    }

    [Display(Name = "Lista GeneracionCDP")]
    public virtual List<App.Core.Entities.Cometido.GeneracionCDP> GeneracionCDP { get; set; }

    [Display(Name = "Lista Destinos")]
    public virtual List<App.Core.Entities.Cometido.Destinos> Destinos { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Display(Name = "Numero Cometido")]
    public int CometidoId { get; set; }

    [Required(ErrorMessage = "Se debe indicar la fecha")]
    [Display(Name = "Fecha Solicitud")]
    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:G}")]
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

    [Required(ErrorMessage = "Es necesario especificar este dato")]
    [Display(Name = "Unidad")]
    public int? IdUnidad { get; set; }

    [Required(ErrorMessage = "Es necesario especificar este dato")]
    [Display(Name = "Unidad")]
    public string UnidadDescripcion { get; set; }

    [Required(ErrorMessage = "Es necesario especificar este dato")]
    [Display(Name = "Calidad Juridica")]
    public int? IdCalidad { get; set; }

    [Required(ErrorMessage = "Es necesario especificar este dato")]
    [Display(Name = "Calidad Juridica")]
    public string CalidadDescripcion { get; set; }

    [Required(ErrorMessage = "Es necesario especificar este dato")]
    [Display(Name = "GradoUES")]
    public string IdGrado { get; set; }

    [Required(ErrorMessage = "Es necesario especificar este dato")]
    [Display(Name = "GradoUES")]
    public string GradoDescripcion { get; set; }

    [Display(Name = "Grado de contratación (en caso de HSA se debe homologr a un grado de la EUS)")]
    public string Grado { get; set; }

    [Required(ErrorMessage = "Es necesario especificar este dato")]
    [Display(Name = "Cargo")]
    public int? IdCargo { get; set; }

    [Required(ErrorMessage = "Es necesario especificar este dato")]
    [Display(Name = "Cargo")]
    public string CargoDescripcion { get; set; }

    [Display(Name = "Estamento")]
    public int? IdEstamento { get; set; }

    [Display(Name = "Estamento")]
    public string EstamentoDescripcion { get; set; }

    [Display(Name = "Programa")]
    public int? IdPrograma { get; set; }

    [Display(Name = "Programa")]
    public string ProgramaDescripcion { get; set; }

    [Display(Name = "Conglomerado")]
    public int? IdConglomerado { get; set; }

    [Display(Name = "Conglomerado")]
    public string ConglomeradoDescripcion { get; set; }

    [Display(Name = "Financia Organismo Invitante")]
    public bool? FinanciaOrganismo { get; set; }

    [Display(Name = "Alojamiento")]
    public bool Alojamiento { get; set; }

    [Display(Name = "Alimentacion")]
    public bool Alimentacion { get; set; }

    [Display(Name = "Pasajes")]
    public bool Pasajes { get; set; }

    [Display(Name = "Viatico")]
    public bool SolicitaViatico { get; set; }

    [Display(Name = "Pasaje Aereo")]
    public bool ReqPasajeAereo { get; set; }

    [Display(Name = "Pasaje Terrestre")]
    public bool ReqPasajeTerrestre { get; set; }

    [Display(Name = "Vehiculo")]
    public bool Vehiculo { get; set; }

    [Display(Name = "Reembolso")]
    public bool SolicitaReembolso { get; set; }

    [Display(Name = "Tipo Vehiculo")]
    public int? TipoVehiculoId { get; set; }

    [Display(Name = "Tipo Vehiculo")]
    public string TipoVehiculoDescripcion { get; set; }

    [Display(Name = "Placa Vehiculo")]
    public string PlacaVehiculo { get; set; }

    [Display(Name = "Tipo Reembolso")]
    public int? TipoReembolsoId { get; set; }

    [Display(Name = "Tipo Reembolso")]
    public string TipoReembolsoDescripcion { get; set; }

    [Required(ErrorMessage = "Es necesario especificar este dato")]
    [Display(Name = "Descripcion Cometido")]
    public string CometidoDescripcion { get; set; }

    [Display(Name = "Folio")]
    public string Folio { get; set; }

    [NotMapped]
    [Display(Name = "Dias")]
    public int? Dias { get; set; }

    [NotMapped]
    [Display(Name = "DiasPlural")]
    public string DiasPlural { get; set; }

    [NotMapped]
    [Display(Name = "Tiempo")]
    public string Tiempo { get; set; }

    [NotMapped]
    [Display(Name = "Anno")]
    public string Anno { get; set; }

    [NotMapped]
    [Display(Name = "Subscretaria")]
    public string Subscretaria { get; set; }

    [NotMapped]
    [Display(Name = "Fecha Resolucion")]
    public DateTime FechaResolucion { get; set; }

    [NotMapped]
    [Display(Name = "Numero Resolucion")]
    public int? NumeroResolucion { get; set; }

    [NotMapped]
    [Display(Name = "Orden")]
    public string Orden { get; set; }

    [NotMapped]
    [Display(Name = "Firmante")]
    public string Firmante { get; set; }

    [NotMapped]
    [Display(Name = "Cargo Firmante")]
    public string CargoFirmante { get; set; }

    [NotMapped]
    [Display(Name = "Vistos")]
    public string Vistos { get; set; }

    [Display(Name = "Cometido Ok")]
    public bool? CometidoOk { get; set; }
  }
}
