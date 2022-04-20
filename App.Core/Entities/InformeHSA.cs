// Decompiled with JetBrains decompiler
// Type: App.Core.Entities.InformeHSA.InformeHSA
// Assembly: App.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1BF6F6E1-2696-4F22-9AA9-802440B37AD4
// Assembly location: D:\Users\IROCHA\Documents\Projects\BackUps\sintegridadweb\bin\App.Core.dll

using App.Core.Entities.Core;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Core.Entities.InformeHSA
{
  [Table("InformeHSA")]
  public class InformeHSA
  {
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Display(Name = "Id")]
    public int InformeHSAId { get; set; }

    [Display(Name = "Fecha solicitud")]
    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
    [DataType(DataType.Date)]
    public DateTime? FechaSolicitud { get; set; }

    [Required(ErrorMessage = "Es necesario especificar este dato")]
    [Display(Name = "Desde")]
    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
    [DataType(DataType.Date)]
    public DateTime? FechaDesde { get; set; }

    [Required(ErrorMessage = "Es necesario especificar este dato")]
    [Display(Name = "Hasta")]
    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
    [DataType(DataType.Date)]
    public DateTime? FechaHasta { get; set; }

    [Required(ErrorMessage = "Es necesario especificar este dato")]
    [Display(Name = "RUT")]
    public int RUT { get; set; }

    [Required(ErrorMessage = "Es necesario especificar este dato")]
    [Display(Name = "Nombre")]
    public string Nombre { get; set; }

    [Display(Name = "Unidad de Desempeño")]
    public string Unidad { get; set; }

    [Required(ErrorMessage = "Es necesario especificar este dato")]
    [Display(Name = "Jefatura responsable")]
    public string NombreJefatura { get; set; }

    [Display(Name = "Con jornada?")]
    public bool ConJornada { get; set; }

    [Required(ErrorMessage = "Es necesario especificar este dato")]
    [Display(Name = "Funciones establecidas en el contrato, numeradas.")]
    [DataType(DataType.MultilineText)]
    public string Funciones { get; set; }

    [Required(ErrorMessage = "Es necesario especificar este dato")]
    [Display(Name = "Actividades desarrolladas en el periodo")]
    [DataType(DataType.MultilineText)]
    public string Actividades { get; set; }

    [Display(Name = "Observaciones")]
    [DataType(DataType.MultilineText)]
    public string Observaciones { get; set; }

    [Required(ErrorMessage = "Es necesario especificar este dato")]
    [Display(Name = "Número de boleta")]
    public string NumeroBoleta { get; set; }

    [Required(ErrorMessage = "Es necesario especificar este dato")]
    [Display(Name = "Fecha de emisión de boleta")]
    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
    [DataType(DataType.Date)]
    public DateTime? FechaBoleta { get; set; }

    [Display(Name = "Proceso")]
    public int? ProcesoId { get; set; }

    public virtual Proceso Proceso { get; set; }

    [Display(Name = "Workflow")]
    public int? WorkflowId { get; set; }

    public virtual Workflow Workflow { get; set; }

    [NotMapped]
    public byte[] QR { get; set; }

    [NotMapped]
    public byte[] Signature { get; set; }
  }
}
