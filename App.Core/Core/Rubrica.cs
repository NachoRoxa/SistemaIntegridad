// Decompiled with JetBrains decompiler
// Type: App.Core.Entities.Core.Rubrica
// Assembly: App.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1BF6F6E1-2696-4F22-9AA9-802440B37AD4
// Assembly location: C:\Users\IROCHA\source\repos\Integridad\sintegridadweb\bin\App.Core.dll

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Core.Entities.Core
{
  [Table("CoreRubrica")]
  public class Rubrica
  {
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Display(Name = "Id")]
    public int RubricaId { get; set; }

    [Display(Name = "Autor")]
    public string Email { get; set; }

    [Display(Name = "Nombre archivo")]
    public string FileName { get; set; }

    [Display(Name = "Archivo")]
    public byte[] File { get; set; }

    [Display(Name = "Identificador de firma electrónica")]
    public string IdentificadorFirma { get; set; }
  }
}
