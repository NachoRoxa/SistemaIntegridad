// Decompiled with JetBrains decompiler
// Type: App.Core.Entities.Core.Configuracion
// Assembly: App.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1BF6F6E1-2696-4F22-9AA9-802440B37AD4
// Assembly location: C:\Users\IROCHA\source\repos\Integridad\sintegridadweb\bin\App.Core.dll

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Core.Entities.Core
{
  [Table("CoreConfiguracion")]
  public class Configuracion
  {
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Display(Name = "Id")]
    public int ConfiguracionId { get; set; }

    [Required(ErrorMessage = "Es necesario especificar este dato")]
    [Display(Name = "Clave")]
    public string Nombre { get; set; }

    [Required(ErrorMessage = "Es necesario especificar este dato")]
    [DataType(DataType.MultilineText)]
    [Display(Name = "Valor")]
    public string Valor { get; set; }
  }
}
