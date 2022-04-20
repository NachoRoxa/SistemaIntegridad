// Decompiled with JetBrains decompiler
// Type: App.Core.Entities.GestionDocumental.GDIngreso
// Assembly: App.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1BF6F6E1-2696-4F22-9AA9-802440B37AD4
// Assembly location: D:\Users\IROCHA\Documents\Projects\BackUps\sintegridadweb\bin\App.Core.dll

using App.Core.Entities.Core;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Core.Entities.GestionDocumental
{
  [Table("GDIngreso")]
  public class GDIngreso
  {
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Display(Name = "Id")]
    public int GDIngresoId { get; set; }

    [Display(Name = "Tipo ingreso")]
    public int? GDTipoIngresoId { get; set; }

    public virtual GDTipoIngreso TipoIngreso { get; set; }

    [Display(Name = "Fecha solicitud")]
    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
    [DataType(DataType.Date)]
    public DateTime? Fecha { get; set; } = new DateTime?(DateTime.Now);

    [Required(ErrorMessage = "Es necesario especificar este dato")]
    [Display(Name = "Asunto")]
    [DataType(DataType.MultilineText)]
    public string Asunto { get; set; }

    [Display(Name = "Referencia")]
    [DataType(DataType.MultilineText)]
    public string Referencia { get; set; }

    [Required(ErrorMessage = "Es necesario especificar este dato")]
    [Display(Name = "Descripción")]
    [DataType(DataType.MultilineText)]
    public string Descripcion { get; set; }

    [Display(Name = "Autor")]
    public string Autor { get; set; }

    [Display(Name = "Grupo")]
    public int? GrupoId { get; set; }

    public virtual Grupo Grupo { get; set; }

    [Display(Name = "Unidad destino")]
    public int? Pl_UndCod { get; set; }

    [Display(Name = "Unidad destino")]
    public string Pl_UndDes { get; set; }

    [Display(Name = "Usuario destino")]
    public string UsuarioDestino { get; set; }

    [Display(Name = "Organización")]
    public string OrganizacionId { get; set; }

    [Display(Name = "Organización")]
    public string RazonSocial { get; set; }

    [Display(Name = "Folio")]
    public string Folio { get; set; }

    [Display(Name = "Código de barra")]
    public byte[] BarCode { get; set; }

    [Display(Name = "Proceso")]
    public int? ProcesoId { get; set; }

    public virtual Proceso Proceso { get; set; }

    [Display(Name = "Workflow")]
    public int? WorkflowId { get; set; }

    public virtual Workflow Workflow { get; set; }

    public void GetFolio() => this.Folio = DateTime.Now.Year.ToString() + this.Pl_UndCod.ToString().PadLeft(6, '0') + (!string.IsNullOrWhiteSpace(this.OrganizacionId) ? this.OrganizacionId.ToString().PadLeft(5, '0') : "0".PadLeft(5, '0')) + this.GDTipoIngresoId.ToString().PadLeft(3, '0') + "0".PadLeft(7, '0');
  }
}
