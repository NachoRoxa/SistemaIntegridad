// Decompiled with JetBrains decompiler
// Type: App.Core.Entities.DTO.DTOFolio
// Assembly: App.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1BF6F6E1-2696-4F22-9AA9-802440B37AD4
// Assembly location: C:\Users\IROCHA\source\repos\Integridad\sintegridadweb\bin\App.Core.dll

using System.ComponentModel.DataAnnotations;

namespace App.Core.Entities.DTO
{
  public class DTOFolio
  {
    public string status { get; set; }

    public string error { get; set; }

    [Required(ErrorMessage = "Es necesario especificar este dato")]
    [Display(Name = "Año")]
    public string periodo { get; set; }

    [Required(ErrorMessage = "Es necesario especificar este dato")]
    [Display(Name = "Código tipo documento")]
    public string tipodocumento { get; set; }

    [Required(ErrorMessage = "Es necesario especificar este dato")]
    [Display(Name = "Solicitante")]
    public string solicitante { get; set; }

    public string folio { get; set; }
  }
}
