// Decompiled with JetBrains decompiler
// Type: App.Core.Entities.Cometido.GeneracionCDP
// Assembly: App.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1BF6F6E1-2696-4F22-9AA9-802440B37AD4
// Assembly location: C:\Users\IROCHA\source\repos\Integridad\sintegridadweb\bin\App.Core.dll

using App.Core.Entities.Core;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Core.Entities.Cometido
{
  public class GeneracionCDP : BaseEntity
  {
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Display(Name = "GeneracionCDPId")]
    public int GeneracionCDPId { get; set; }

    [ForeignKey("Cometido")]
    [Display(Name = "CometidoId")]
    public int? CometidoId { get; set; }

    public virtual App.Core.Entities.Cometido.Cometido Cometido { get; set; }

    [ForeignKey("TipoPartida")]
    [Display(Name = "Partida")]
    public int? VtcTipoPartidaId { get; set; }

    public virtual TipoPartida TipoPartida { get; set; }

    [ForeignKey("TipoCapitulo")]
    [Display(Name = "Capitulo")]
    public int? VtcTipoCapituloId { get; set; }

    public virtual TipoCapitulo TipoCapitulo { get; set; }

    [ForeignKey("CentroCosto")]
    [Display(Name = "Programa")]
    public int? VtcCentroCostoId { get; set; }

    public virtual CentroCosto CentroCosto { get; set; }

    [ForeignKey("TipoSubTitulo")]
    [Display(Name = "SubTitulo")]
    public int? VtcTipoSubTituloId { get; set; }

    public virtual TipoSubTitulo TipoSubTitulo { get; set; }

    [ForeignKey("TipoItem")]
    [Display(Name = "Item")]
    public int? VtcTipoItemId { get; set; }

    public virtual TipoItem TipoItem { get; set; }

    [ForeignKey("TipoAsignacion")]
    [Display(Name = "Asignacion")]
    public int? VtcTipoAsignacionId { get; set; }

    public virtual TipoAsignacion TipoAsignacion { get; set; }

    [ForeignKey("TipoSubAsignacion")]
    [Display(Name = "SubAsignacion")]
    public int? VtcTipoSubAsignacionId { get; set; }

    public virtual TipoSubAsignacion TipoSubAsignacion { get; set; }

    [Display(Name = "IdCompromiso")]
    public string VtcIdCompromiso { get; set; }

    [Display(Name = "Codigo Compromiso")]
    public string VtcCodCompromiso { get; set; }

    [Display(Name = "Presupuesto Total")]
    public string VtcPptoTotal { get; set; }

    [Display(Name = "Compromiso Acumulado")]
    public string VtcCompromisoAcumulado { get; set; }

    [Display(Name = "Obligacion Actual")]
    public string VtcObligacionActual { get; set; }

    [Display(Name = "Saldo")]
    public string VtcSaldo { get; set; }

    [Display(Name = "Valor Viatico")]
    public string VtcValorViatico { get; set; }

    [ForeignKey("PsjTipoPartida")]
    [Display(Name = "Partida")]
    public int? PsjTipoPartidaId { get; set; }

    public virtual TipoPartida PsjTipoPartida { get; set; }

    [ForeignKey("PsjTipoCapitulo")]
    [Display(Name = "Capitulo")]
    public int? PsjVtcTipoCapituloId { get; set; }

    public virtual TipoCapitulo PsjTipoCapitulo { get; set; }

    [ForeignKey("PsjCentroCosto")]
    [Display(Name = "Programa")]
    public int? PsjCentroCostoId { get; set; }

    public virtual CentroCosto PsjCentroCosto { get; set; }

    [ForeignKey("PsjTipoSubTitulo")]
    [Display(Name = "TipoSubTitulo")]
    public int? PsjTipoSubTituloId { get; set; }

    public virtual TipoSubTitulo PsjTipoSubTitulo { get; set; }

    [ForeignKey("PsjTipoItem")]
    [Display(Name = "Item")]
    public int? PsjTipoItemId { get; set; }

    public virtual TipoItem PsjTipoItem { get; set; }

    [ForeignKey("PsjTipoAsignacion")]
    [Display(Name = "Asignacion")]
    public int? PsjTipoAsignacionId { get; set; }

    public virtual TipoAsignacion PsjTipoAsignacion { get; set; }

    [ForeignKey("PsjTipoSubAsignacion")]
    [Display(Name = "SubAsignacion")]
    public int? PsjTipoSubAsignacionId { get; set; }

    public virtual TipoSubAsignacion PsjTipoSubAsignacion { get; set; }

    [Display(Name = "Compromiso")]
    public string PsjIdCompromiso { get; set; }

    [Display(Name = "Codigo Compromiso")]
    public string PsjCodCompromiso { get; set; }

    [Display(Name = "Presupuesto Total")]
    public string PsjPptoTotal { get; set; }

    [Display(Name = "Compromiso Acumulado")]
    public string PsjCompromisoAcumulado { get; set; }

    [Display(Name = "Obligacion Actual")]
    public string PsjObligacionActual { get; set; }

    [Display(Name = "Saldo")]
    public string PsjSaldo { get; set; }

    [Display(Name = "Valor Viatico")]
    public string PsjValorViatico { get; set; }

    [NotMapped]
    [Display(Name = "Fecha Resolucion")]
    public DateTime FechaFirma { get; set; }

    [NotMapped]
    [Display(Name = "Fecha Resolucion")]
    public DateTime PsjFechaFirma { get; set; }
  }
}
