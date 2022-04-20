// Decompiled with JetBrains decompiler
// Type: App.Core.Entities.CuentaRed.CuentaRed
// Assembly: App.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1BF6F6E1-2696-4F22-9AA9-802440B37AD4
// Assembly location: C:\Users\IROCHA\source\repos\Integridad\sintegridadweb\bin\App.Core.dll

using App.Core.Entities.Core;
using App.Core.Entities.Shared;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Core.Entities.CuentaRed
{
  [Table("CuentaRed")]
  public class CuentaRed
  {
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Display(Name = "Id")]
    public int CuentaRedId { get; set; }

    [Display(Name = "Solicitante")]
    public string Solicitante { get; set; }

    [Display(Name = "Apellido parterno")]
    public string ApellidoParterno { get; set; }

    [Display(Name = "Apellido materno")]
    public string ApellidoMaterno { get; set; }

    [Display(Name = "Nombres")]
    public string Nombres { get; set; }

    [Display(Name = "RUT (sin puntos ni guión)")]
    public int RUT { get; set; }

    [Display(Name = "Fecha nacimiento")]
    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
    [DataType(DataType.Date)]
    public DateTime? FechaNacimiento { get; set; }

    [Display(Name = "Género")]
    public int? GeneroId { get; set; }

    public virtual Genero Genero { get; set; }

    [Display(Name = "Unidad")]
    public int? Pl_UndCod { get; set; }

    [Display(Name = "Unidad")]
    public string Pl_UndDes { get; set; }

    [Display(Name = "Cargo")]
    public int? Pl_CodCar { get; set; }

    [Display(Name = "Cargo")]
    public string Pl_DesCar { get; set; }

    [Display(Name = "Fecha ingreso")]
    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
    [DataType(DataType.Date)]
    public DateTime? FechaIngreso { get; set; }

    [Display(Name = "Requiere PC?")]
    public bool RequierePC { get; set; }

    [Display(Name = "Número teléfono")]
    public string NumeroTelefono { get; set; }

    [Display(Name = "Número anexo")]
    public string NumeroAnexo { get; set; }

    [Display(Name = "Dependencia administrativa")]
    public string DependenciaAdministrativa { get; set; }

    [Display(Name = "Ubicación física")]
    public string UbicacionFisica { get; set; }

    [Display(Name = "Región")]
    public int? RegionId { get; set; }

    public virtual Region Region { get; set; }

    [Display(Name = "Autor")]
    [EmailAddress(ErrorMessage = "Debe ingresar un correo válido")]
    public string Email { get; set; }

    [Display(Name = "Secretaria asistente")]
    public string SecretariaAsistente { get; set; }

    [Display(Name = "Superior directo")]
    public string SuperiorDirecto { get; set; }

    [Display(Name = "Autorizador")]
    public string Autorizador { get; set; }

    [DataType(DataType.MultilineText)]
    public string Observacion { get; set; }

    [Display(Name = "Proceso")]
    public int? ProcesoId { get; set; }

    public virtual Proceso Proceso { get; set; }

    [Display(Name = "Workflow")]
    public int? WorkflowId { get; set; }

    public virtual Workflow Workflow { get; set; }

    [NotMapped]
    public string EmailSolicitante { get; set; }

    [NotMapped]
    public string EmailSecretariaAsistente { get; set; }

    [NotMapped]
    public string EmailSuperiorDirector { get; set; }

    [NotMapped]
    public string EmailAutorizador { get; set; }
  }
}
