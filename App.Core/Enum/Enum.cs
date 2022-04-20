// Decompiled with JetBrains decompiler
// Type: App.Core.Enum.Enum
// Assembly: App.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1BF6F6E1-2696-4F22-9AA9-802440B37AD4
// Assembly location: D:\Users\IROCHA\Documents\Projects\BackUps\sintegridadweb\bin\App.Core.dll

namespace App.Core.Enum
{
  public static class Enum
  {
    public enum Entidad
    {
      CDP,
      HSA,
      CuentaRed,
      Contrato,
      InformeHSA,
      GDIngreso,
      SIACSolicitud,
      RadioTaxi,
      Cometido,
      Pasaje,
      Denuncia,
      Consulta,
      WebConsulta,
    }

    public enum Grupo
    {
      Administrador,
      Operador,
      Consultor,
    }

    public enum TipoWorkflow
    {
      Create = 1,
      Edit = 2,
      Details = 3,
      Sign = 4,
      Validate = 5,
      Evaluate = 6,
      Finish = 7,
      AskArchive = 8,
    }

    public enum Firmas
    {
      Orden = 1,
      Firmante = 2,
      CargoFirmante = 3,
      OrdenSubse = 4,
      FirmanteSubse = 5,
      CargoSubse = 6,
      OrdenMinistro = 8,
      FirmanteMinistro = 9,
      CargoMinistro = 10, // 0x0000000A
      VistosRME = 11, // 0x0000000B
      VistoRAE = 12, // 0x0000000C
      VistoOP = 13, // 0x0000000D
    }

    public enum TipoAprobacion
    {
      SinAprobacion = 1,
      Aprobada = 2,
      Rechazada = 3,
    }

    public enum TipoEjecucion
    {
      CualquierPersonaGrupo = 1,
      EjecutaQuienIniciaElProceso = 2,
      EjecutaPorJefaturaDeQuienIniciaProceso = 3,
      EjecutaDestinoInicial = 4,
      EjecutaGrupoEspecifico = 5,
      EjecutaUsuarioEspecifico = 6,
      EjecutaPorJefaturaDeQuienEjecutoTareaAnterior = 7,
      EjecutaDestinoGD = 8,
    }

    public enum Configuracion
    {
      PlantillaCorreoNotificacionTarea = 1,
      AsuntoCorreoNotificacionTarea = 2,
      HSMUser = 4,
      HSMPassword = 5,
      PlantillaCorreoArchivoTarea = 7,
      PlantillaCorreoNuevoProceso = 8,
      PlantillaCorreoProcesoAnulado = 9,
      PlantillaCorreoCambioEstado = 10, // 0x0000000A
    }

    public enum DefinicionProceso
    {
      SIACIngreso = 7,
      Consulta = 13, // 0x0000000D
    }

    public enum Estadoorganizacion
    {
      EnConstitucion = 1,
      Vigente = 2,
      Disuelta = 3,
      Inexistente = 4,
      Cancelada = 5,
      RolAsignado = 6,
    }

    public enum TipoOrganizacion
    {
      Cooperativa = 1,
      AsociacionGremial = 2,
      AsociacionConsumidores = 3,
      AunNoDefinida = 4,
    }

    public enum Cometidos
    {
      DiasAnticipacionIngreso = 7,
    }
  }
}
