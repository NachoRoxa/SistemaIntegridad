// Decompiled with JetBrains decompiler
// Type: App.Core.Entities.Core.Documento
// Assembly: App.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1BF6F6E1-2696-4F22-9AA9-802440B37AD4
// Assembly location: C:\Users\IROCHA\source\repos\Integridad\sintegridadweb\bin\App.Core.dll

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Core.Entities.Core
{
  [Table("CoreDocumento")]
  public class Documento
  {
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int DocumentoId { get; set; }

    [Required(ErrorMessage = "Es necesario especificar este dato")]
    [Display(Name = "Proceso")]
    public int ProcesoId { get; set; }

    public virtual Proceso Proceso { get; set; }

    [Required(ErrorMessage = "Es necesario especificar este dato")]
    [Display(Name = "Proceso")]
    public int WorkflowId { get; set; }

    public virtual Workflow Workflow { get; set; }

    [Display(Name = "Tipo documento")]
    public int? TipoDocumentoId { get; set; }

    public virtual TipoDocumento TipoDocumento { get; set; }

    [Display(Name = "Privacidad")]
    public int? TipoPrivacidadId { get; set; } = new int?(1);

    public virtual TipoPrivacidad TipoPrivacidad { get; set; }

    [Display(Name = "Fecha")]
    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy HH:mm:ss}")]
    public DateTime Fecha { get; set; } = DateTime.Now;

    [Display(Name = "Autor")]
    public string Email { get; set; }

    [Display(Name = "Nombre")]
    public string FileName { get; set; }

    [Display(Name = "Extensión")]
    public string Extension { get; set; }

    [Display(Name = "URL")]
    public string URL { get; set; }

    [Display(Name = "Archivo")]
    public byte[] File { get; set; }

    [Display(Name = "Texto")]
    public string Texto { get; set; }

    [Display(Name = "Metadata")]
    public string Metadata { get; set; }

    [Display(Name = "Metadata")]
    public string Type { get; set; }

    [Display(Name = "Ubicación")]
    public string Ubicacion { get; set; }

    [Display(Name = "Firmado")]
    public bool Signed { get; set; }

    [Display(Name = "Código")]
    public string Codigo { get; set; }

    [Display(Name = "Código de barra")]
    public byte[] BarCode { get; set; }

    [NotMapped]
    public bool Selected { get; set; }

    [NotMapped]
    [Display(Name = "Certificado electrónico")]
    public string SerialNumber { get; set; }

    [Display(Name = "Hash md5")]
    public string Md5 { get; set; }
  }
}
