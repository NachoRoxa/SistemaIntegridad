// Decompiled with JetBrains decompiler
// Type: App.Core.Interfaces.IEmail
// Assembly: App.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1BF6F6E1-2696-4F22-9AA9-802440B37AD4
// Assembly location: C:\Users\IROCHA\source\repos\Integridad\sintegridadweb\bin\App.Core.dll

using App.Core.Entities.Core;

namespace App.Core.Interfaces
{
  public interface IEmail
  {
    void NotificarCambioWorkflow(
      Workflow workflow,
      Configuracion plantillaCorreo,
      Configuracion asunto);

    void NotificarInicioProceso(
      Proceso proceso,
      Configuracion plantillaCorreo,
      Configuracion asunto);

    void NotificarRespuestaSIAC(
      Proceso proceso,
      Configuracion plantillaCorreo,
      Configuracion asunto);
  }
}
