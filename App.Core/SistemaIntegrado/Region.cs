// Decompiled with JetBrains decompiler
// Type: App.Core.Entities.SistemaIntegrado.Region
// Assembly: App.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1BF6F6E1-2696-4F22-9AA9-802440B37AD4
// Assembly location: C:\Users\IROCHA\source\repos\Integridad\sintegridadweb\bin\App.Core.dll

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Core.Entities.SistemaIntegrado
{
  public class Region
  {
    public Region() => this.Comunas = (ICollection<Comuna>) new HashSet<Comuna>();

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Display(Name = "Id")]
    public int RegionId { get; set; }

    [Display(Name = "Código")]
    public int? Codigo { get; set; }

    [Required(ErrorMessage = "Es necesario especificar este dato")]
    [Display(Name = "Región")]
    public string Nombre { get; set; }

    public virtual ICollection<Comuna> Comunas { get; set; }
  }
}
