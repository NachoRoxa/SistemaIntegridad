// Decompiled with JetBrains decompiler
// Type: App.Core.Interfaces.ISIGPER
// Assembly: App.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1BF6F6E1-2696-4F22-9AA9-802440B37AD4
// Assembly location: C:\Users\IROCHA\source\repos\Integridad\sintegridadweb\bin\App.Core.dll

using App.Core.Entities.Cometido;
using App.Core.Entities.SIGPER;
using System.Collections.Generic;

namespace App.Core.Interfaces
{
  public interface ISIGPER
  {
    List<PECARGOS> GetCargos();

    PECARGOS GetCargo(int codigo);

    PLUNILAB GetUnidad(int codigo);

    App.Core.Entities.SIGPER.SIGPER GetUserByEmail(string email);

    App.Core.Entities.SIGPER.SIGPER GetUserByRut(int rut);

    List<PEDATPER> GetUserByTerm(string term);

    List<PEDATPER> GetUserByUnidad(int codigo);

    List<PLUNILAB> GetUnidades();

    App.Core.Entities.SIGPER.SIGPER GetJefaturaByUnidad(int codigo);

    App.Core.Entities.SIGPER.SIGPER GetSecretariaByUnidad(int codigo);

    List<DGREGIONES> GetRegion();

    string GetRegionbyComuna(string codComuna);

    List<DGCOMUNAS> GetComunasbyRegion(string IdRegion);

    List<DGCOMUNAS> GetDGCOMUNAs();

    List<DGPAISES> GetDGPAISESs();

    List<DGESCALAFONES> GetGESCALAFONEs();

    List<PECARGOS> GetPECARGOs();

    List<DGESTAMENTOS> GetDGESTAMENTOs();

    List<ReContra> GetReContra();

    List<DGCONTRATOS> GetDGCONTRATOS();

    Destinos GetMontoViaticos(int CometidoId, int Cantdias);
  }
}
