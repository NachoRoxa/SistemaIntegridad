// Decompiled with JetBrains decompiler
// Type: App.Core.Entities.Core.Usuario
// Assembly: App.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1BF6F6E1-2696-4F22-9AA9-802440B37AD4
// Assembly location: C:\Users\IROCHA\source\repos\Integridad\sintegridadweb\bin\App.Core.dll

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Core.Entities.Core
{
  [Table("CoreUsuario")]
  public class Usuario
  {
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Display(Name = "Id")]
    public int UsuarioId { get; set; }

    [Required(ErrorMessage = "Es necesario especificar este dato")]
    [Display(Name = "Grupo")]
    public int GrupoId { get; set; }

    public virtual Grupo Grupo { get; set; }

    [Display(Name = "Nombre usuario")]
    public string Nombre { get; set; }

    [Required(ErrorMessage = "Es necesario especificar este dato")]
    [Display(Name = "Correo electrónico")]
    public string Email { get; set; }

    public bool Habilitado { get; set; } = true;
  }
}
