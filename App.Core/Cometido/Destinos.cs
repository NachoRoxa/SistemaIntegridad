// Decompiled with JetBrains decompiler
// Type: App.Core.Entities.Cometido.Destinos
// Assembly: App.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1BF6F6E1-2696-4F22-9AA9-802440B37AD4
// Assembly location: C:\Users\IROCHA\source\repos\Integridad\sintegridadweb\bin\App.Core.dll

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Core.Entities.Cometido
{
  [Table("Destinos")]
  public class Destinos
  {
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    [Display(Name = "DestinosId")]
    public int DestinoId { get; set; }

    [ForeignKey("Cometido")]
    [Display(Name = "CometidoId")]
    public int? CometidoId { get; set; }

    public virtual App.Core.Entities.Cometido.Cometido Cometido { get; set; }

    [Required(ErrorMessage = "Se debe indicar la Fecha Inicio")]
    [Display(Name = "Fecha Inicio")]
    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:G}")]
    [DataType(DataType.Date)]
    public DateTime FechaInicio { get; set; }

    [Required(ErrorMessage = "Se debe indicar la Fecha Fin")]
    [Display(Name = "Fecha Hasta")]
    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:G}")]
    [DataType(DataType.Date)]
    public DateTime FechaHasta { get; set; }

    [Display(Name = "Días 100% (Pasaje + Alimentación)")]
    public int? Dias100 { get; set; }

    [Display(Name = "Días 60% (Pernoctar)")]
    public int? Dias60 { get; set; }

    [Display(Name = "Días 40% (Alimentación)")]
    public int? Dias40 { get; set; }

    [Display(Name = "Días 50%")]
    public int? Dias50 { get; set; }

    [Display(Name = "Días 0%")]
    public int? Dias00 { get; set; }

    [Display(Name = "Días 100% Aprobados")]
    public int? Dias100Aprobados { get; set; }

    [Display(Name = "Días 60% Aprobados")]
    public int? Dias60Aprobados { get; set; }

    [Display(Name = "Días 40% Aprobados")]
    public int? Dias40Aprobados { get; set; }

    [Display(Name = "Días 50% Aprobados")]
    public int? Dias50Aprobados { get; set; }

    [Display(Name = "Días 0% Aprobados")]
    public int? Dias00Aprobados { get; set; }

    [Display(Name = "Días 100% Monto")]
    public int? Dias100Monto { get; set; }

    [Display(Name = "Días 60% Monto")]
    public int? Dias60Monto { get; set; }

    [Display(Name = "Días 40% Monto")]
    public int? Dias40Monto { get; set; }

    [Display(Name = "Días 50% Monto")]
    public int? Dias50Monto { get; set; }

    [Display(Name = "Días 0% Monto")]
    public int? Dias00Monto { get; set; }

    [Display(Name = "Total")]
    public int? Total { get; set; }

    [Display(Name = "Total Viatico")]
    public int? TotalViatico { get; set; }

    [Display(Name = "Comuna")]
    public string IdComuna { get; set; }

    [Display(Name = "Comuna")]
    public string ComunaDescripcion { get; set; }

    [Required(ErrorMessage = "Es necesario especificar este dato")]
    [Display(Name = "Region")]
    public string IdRegion { get; set; }

    [Display(Name = "Region")]
    public string RegionDescripcion { get; set; }

    [NotMapped]
    [Display(Name = "Workflow")]
    public int? WorkflowId { get; set; }

    [NotMapped]
    [Display(Name = "Total Viatico Palabras")]
    public string TotalViaticoPalabras { get; set; }
  }
}
