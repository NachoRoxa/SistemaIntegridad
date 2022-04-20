// Decompiled with JetBrains decompiler
// Type: App.Infrastructure.SIGPER.SIGPER
// Assembly: App.Infrastructure, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7D12F3AE-788C-4496-85EF-A6E23743B789
// Assembly location: C:\Users\IROCHA\source\repos\Integridad\sintegridadweb\bin\App.Infrastructure.dll

using App.Core.Entities.Cometido;
using App.Core.Entities.SIGPER;
using App.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace App.Infrastructure.SIGPER
{
  public class SIGPER : ISIGPER
  {
    public List<PECARGOS> GetCargos()
    {
      try
      {
        AppContext appContext = new AppContext();
        TurismoContext turismoContext = new TurismoContext();
        return appContext.PECARGOS.ToList<PECARGOS>().Select<PECARGOS, PECARGOS>((Func<PECARGOS, PECARGOS>) (q => new PECARGOS()
        {
          Pl_CodCar = q.Pl_CodCar,
          Pl_DesCar = q.Pl_DesCar.Trim() + " (ECONOMIA)"
        })).ToList<PECARGOS>().Union<PECARGOS>((IEnumerable<PECARGOS>) turismoContext.PECARGOS.ToList<PECARGOS>().Select<PECARGOS, PECARGOS>((Func<PECARGOS, PECARGOS>) (q => new PECARGOS()
        {
          Pl_CodCar = q.Pl_CodCar,
          Pl_DesCar = q.Pl_DesCar.Trim() + " (TURISMO)"
        })).ToList<PECARGOS>()).OrderBy<PECARGOS, string>((Func<PECARGOS, string>) (q => q.Pl_DesCar)).ToList<PECARGOS>();
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    public PECARGOS GetCargo(int codigo)
    {
      try
      {
        return new AppContext().PECARGOS.FirstOrDefault<PECARGOS>((Expression<Func<PECARGOS, bool>>) (q => q.Pl_CodCar == codigo));
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    public PLUNILAB GetUnidad(int codigo)
    {
      try
      {
        return new AppContext().PLUNILAB.FirstOrDefault<PLUNILAB>((Expression<Func<PLUNILAB, bool>>) (q => q.Pl_UndCod == codigo));
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    public App.Core.Entities.SIGPER.SIGPER GetUserByEmail(string email)
    {
      App.Core.Entities.SIGPER.SIGPER userByEmail = new App.Core.Entities.SIGPER.SIGPER()
      {
        Funcionario = (PEDATPER) null,
        Jefatura = (PEDATPER) null,
        Secretaria = (PEDATPER) null,
        Unidad = (PLUNILAB) null,
        FunDatosLaborales = (PeDatLab) null
      };
      try
      {
        AppContext appContext = new AppContext();
        PEDATPER funcionario = appContext.PEDATPER.FirstOrDefault<PEDATPER>((Expression<Func<PEDATPER, bool>>) (q => q.Rh_Mail == email));
        if (funcionario != null)
        {
          userByEmail.Funcionario = funcionario;
          PEDATPER pedatper1 = appContext.PEFERJEFAF.Join((IEnumerable<PEFERJEFAJ>) appContext.PEFERJEFAJ, (Expression<Func<PEFERJEFAF, Decimal>>) (f => f.PeFerJerCod), (Expression<Func<PEFERJEFAJ, Decimal>>) (j => j.PeFerJerCod), (f, j) => new
          {
            f = f,
            j = j
          }).Join((IEnumerable<PEDATPER>) appContext.PEDATPER, data => data.j.FyPFunARut, (Expression<Func<PEDATPER, int>>) (p => p.RH_NumInte), (data, p) => new
          {
            \u003C\u003Eh__TransparentIdentifier0 = data,
            p = p
          }).Where(data => data.\u003C\u003Eh__TransparentIdentifier0.f.FyPFunRut == funcionario.RH_NumInte).Where(data => data.p.RH_EstLab.Equals("A")).Where(data => data.\u003C\u003Eh__TransparentIdentifier0.j.PeFerJerAutEst == 1).Select(data => data.p).FirstOrDefault<PEDATPER>();
          if (pedatper1 != null)
            userByEmail.Jefatura = pedatper1;
          PeDatLab PeDatLab = appContext.PeDatLab.Where<PeDatLab>((Expression<Func<PeDatLab, bool>>) (q => q.RH_NumInte == funcionario.RH_NumInte && (int) q.RH_ContCod != 13 && q.RhConIni.Value.Year == 2020)).OrderByDescending<PeDatLab, short>((Expression<Func<PeDatLab, short>>) (q => q.RH_Correla)).FirstOrDefault<PeDatLab>();
          if (PeDatLab != null)
          {
            PLUNILAB unidad = appContext.PLUNILAB.FirstOrDefault<PLUNILAB>((Expression<Func<PLUNILAB, bool>>) (q => (int?) q.Pl_UndCod == PeDatLab.RhConUniCod));
            if (unidad != null)
            {
              userByEmail.Unidad = unidad;
              PEDATPER pedatper2 = appContext.PEDATPER.FirstOrDefault<PEDATPER>((Expression<Func<PEDATPER, bool>>) (q => q.RH_EstLab.Equals("A") && q.PeDatPerChq == unidad.Pl_UndNomSec));
              if (pedatper2 != null)
                userByEmail.Secretaria = pedatper2;
            }
            PeDatLab peDatLab = appContext.PeDatLab.Where<PeDatLab>((Expression<Func<PeDatLab, bool>>) (q => q.RH_NumInte == funcionario.RH_NumInte)).OrderByDescending<PeDatLab, short>((Expression<Func<PeDatLab, short>>) (q => q.RH_Correla)).FirstOrDefault<PeDatLab>();
            if (peDatLab != null)
              userByEmail.FunDatosLaborales = peDatLab;
          }
          return userByEmail;
        }
        TurismoContext turismoContext = new TurismoContext();
        funcionario = turismoContext.PEDATPER.FirstOrDefault<PEDATPER>((Expression<Func<PEDATPER, bool>>) (q => q.Rh_Mail == email));
        if (funcionario == null)
          return userByEmail;
        userByEmail.Funcionario = funcionario;
        PEDATPER pedatper3 = turismoContext.PEFERJEFAF.Join((IEnumerable<PEFERJEFAJ>) turismoContext.PEFERJEFAJ, (Expression<Func<PEFERJEFAF, Decimal>>) (f => f.PeFerJerCod), (Expression<Func<PEFERJEFAJ, Decimal>>) (j => j.PeFerJerCod), (f, j) => new
        {
          f = f,
          j = j
        }).Join((IEnumerable<PEDATPER>) turismoContext.PEDATPER, data => data.j.FyPFunARut, (Expression<Func<PEDATPER, int>>) (p => p.RH_NumInte), (data, p) => new
        {
          \u003C\u003Eh__TransparentIdentifier0 = data,
          p = p
        }).Where(data => data.\u003C\u003Eh__TransparentIdentifier0.f.FyPFunRut == funcionario.RH_NumInte).Where(data => data.p.RH_EstLab.Equals("A")).Where(data => data.\u003C\u003Eh__TransparentIdentifier0.j.PeFerJerAutEst == 1).Select(data => data.p).FirstOrDefault<PEDATPER>();
        if (pedatper3 != null)
          userByEmail.Jefatura = pedatper3;
        PeDatLab PeDatLab1 = turismoContext.PeDatLab.Where<PeDatLab>((Expression<Func<PeDatLab, bool>>) (q => q.RH_NumInte == funcionario.RH_NumInte)).OrderByDescending<PeDatLab, short>((Expression<Func<PeDatLab, short>>) (q => q.RH_Correla)).FirstOrDefault<PeDatLab>();
        if (PeDatLab1 != null)
        {
          PLUNILAB unidad = turismoContext.PLUNILAB.FirstOrDefault<PLUNILAB>((Expression<Func<PLUNILAB, bool>>) (q => (int?) q.Pl_UndCod == PeDatLab1.RhConUniCod));
          if (unidad != null)
          {
            userByEmail.Unidad = unidad;
            PEDATPER pedatper4 = turismoContext.PEDATPER.FirstOrDefault<PEDATPER>((Expression<Func<PEDATPER, bool>>) (q => q.RH_EstLab.Equals("A") && q.PeDatPerChq == unidad.Pl_UndNomSec));
            if (pedatper4 != null)
              userByEmail.Secretaria = pedatper4;
          }
        }
        return userByEmail;
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    public App.Core.Entities.SIGPER.SIGPER GetUserByRut(int rut)
    {
      App.Core.Entities.SIGPER.SIGPER userByRut = new App.Core.Entities.SIGPER.SIGPER()
      {
        Funcionario = (PEDATPER) null,
        Jefatura = (PEDATPER) null,
        Secretaria = (PEDATPER) null,
        Unidad = (PLUNILAB) null
      };
      try
      {
        AppContext appContext = new AppContext();
        PEDATPER funcionario = appContext.PEDATPER.FirstOrDefault<PEDATPER>((Expression<Func<PEDATPER, bool>>) (q => q.RH_NumInte == rut));
        if (funcionario != null)
        {
          userByRut.Funcionario = funcionario;
          PEDATPER pedatper1 = appContext.PEFERJEFAF.Join((IEnumerable<PEFERJEFAJ>) appContext.PEFERJEFAJ, (Expression<Func<PEFERJEFAF, Decimal>>) (f => f.PeFerJerCod), (Expression<Func<PEFERJEFAJ, Decimal>>) (j => j.PeFerJerCod), (f, j) => new
          {
            f = f,
            j = j
          }).Join((IEnumerable<PEDATPER>) appContext.PEDATPER, data => data.j.FyPFunARut, (Expression<Func<PEDATPER, int>>) (p => p.RH_NumInte), (data, p) => new
          {
            \u003C\u003Eh__TransparentIdentifier0 = data,
            p = p
          }).Where(data => data.\u003C\u003Eh__TransparentIdentifier0.f.FyPFunRut == funcionario.RH_NumInte).Where(data => data.p.RH_EstLab.Equals("A")).Where(data => data.\u003C\u003Eh__TransparentIdentifier0.j.PeFerJerAutEst == 1).Select(data => data.p).FirstOrDefault<PEDATPER>();
          if (pedatper1 != null)
            userByRut.Jefatura = pedatper1;
          PeDatLab PeDatLab = appContext.PeDatLab.Where<PeDatLab>((Expression<Func<PeDatLab, bool>>) (q => q.RH_NumInte == funcionario.RH_NumInte)).OrderByDescending<PeDatLab, short>((Expression<Func<PeDatLab, short>>) (q => q.RH_Correla)).FirstOrDefault<PeDatLab>();
          if (PeDatLab != null)
          {
            PLUNILAB unidad = appContext.PLUNILAB.FirstOrDefault<PLUNILAB>((Expression<Func<PLUNILAB, bool>>) (q => (int?) q.Pl_UndCod == PeDatLab.RhConUniCod));
            if (unidad != null)
            {
              userByRut.Unidad = unidad;
              PEDATPER pedatper2 = appContext.PEDATPER.FirstOrDefault<PEDATPER>((Expression<Func<PEDATPER, bool>>) (q => q.RH_EstLab.Equals("A") && q.PeDatPerChq == unidad.Pl_UndNomSec));
              if (pedatper2 != null)
                userByRut.Secretaria = pedatper2;
            }
          }
          return userByRut;
        }
        TurismoContext turismoContext = new TurismoContext();
        funcionario = turismoContext.PEDATPER.FirstOrDefault<PEDATPER>((Expression<Func<PEDATPER, bool>>) (q => q.RH_NumInte == rut));
        if (funcionario == null)
          return userByRut;
        userByRut.Funcionario = funcionario;
        PEDATPER pedatper3 = turismoContext.PEFERJEFAF.Join((IEnumerable<PEFERJEFAJ>) turismoContext.PEFERJEFAJ, (Expression<Func<PEFERJEFAF, Decimal>>) (f => f.PeFerJerCod), (Expression<Func<PEFERJEFAJ, Decimal>>) (j => j.PeFerJerCod), (f, j) => new
        {
          f = f,
          j = j
        }).Join((IEnumerable<PEDATPER>) turismoContext.PEDATPER, data => data.j.FyPFunARut, (Expression<Func<PEDATPER, int>>) (p => p.RH_NumInte), (data, p) => new
        {
          \u003C\u003Eh__TransparentIdentifier0 = data,
          p = p
        }).Where(data => data.\u003C\u003Eh__TransparentIdentifier0.f.FyPFunRut == funcionario.RH_NumInte).Where(data => data.p.RH_EstLab.Equals("A")).Where(data => data.\u003C\u003Eh__TransparentIdentifier0.j.PeFerJerAutEst == 1).Select(data => data.p).FirstOrDefault<PEDATPER>();
        if (pedatper3 != null)
          userByRut.Jefatura = pedatper3;
        PeDatLab PeDatLab1 = turismoContext.PeDatLab.Where<PeDatLab>((Expression<Func<PeDatLab, bool>>) (q => q.RH_NumInte == funcionario.RH_NumInte)).OrderByDescending<PeDatLab, short>((Expression<Func<PeDatLab, short>>) (q => q.RH_Correla)).FirstOrDefault<PeDatLab>();
        if (PeDatLab1 != null)
        {
          PLUNILAB unidad = turismoContext.PLUNILAB.FirstOrDefault<PLUNILAB>((Expression<Func<PLUNILAB, bool>>) (q => (int?) q.Pl_UndCod == PeDatLab1.RhConUniCod));
          if (unidad != null)
          {
            userByRut.Unidad = unidad;
            PEDATPER pedatper4 = turismoContext.PEDATPER.FirstOrDefault<PEDATPER>((Expression<Func<PEDATPER, bool>>) (q => q.RH_EstLab.Equals("A") && q.PeDatPerChq == unidad.Pl_UndNomSec));
            if (pedatper4 != null)
              userByRut.Secretaria = pedatper4;
          }
        }
        return userByRut;
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    public List<PLUNILAB> GetUnidades()
    {
      try
      {
        AppContext appContext = new AppContext();
        TurismoContext turismoContext = new TurismoContext();
        return appContext.PLUNILAB.ToList<PLUNILAB>().Select<PLUNILAB, PLUNILAB>((Func<PLUNILAB, PLUNILAB>) (q => new PLUNILAB()
        {
          Pl_UndCod = q.Pl_UndCod,
          Pl_UndDes = q.Pl_UndDes.Trim() + " (ECONOMIA)"
        })).ToList<PLUNILAB>().Union<PLUNILAB>((IEnumerable<PLUNILAB>) turismoContext.PLUNILAB.ToList<PLUNILAB>().Select<PLUNILAB, PLUNILAB>((Func<PLUNILAB, PLUNILAB>) (q => new PLUNILAB()
        {
          Pl_UndCod = q.Pl_UndCod,
          Pl_UndDes = q.Pl_UndDes.Trim() + " (TURISMO)"
        })).ToList<PLUNILAB>()).OrderBy<PLUNILAB, string>((Func<PLUNILAB, string>) (q => q.Pl_UndDes)).ToList<PLUNILAB>();
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    public List<PEDATPER> GetUserByUnidad(int codigoUnidad)
    {
      try
      {
        AppContext dbE = new AppContext();
        TurismoContext dbT = new TurismoContext();
        if (codigoUnidad != 0)
        {
          IQueryable<PEDATPER> source1 = dbE.PEDATPER.SelectMany((Expression<Func<PEDATPER, IEnumerable<PLUNILAB>>>) (PE => dbE.PLUNILAB), (PE, PL) => new
          {
            PE = PE,
            PL = PL
          }).Where(data => data.PL.Pl_UndCod == data.PE.RhSegUnd01.Value || data.PL.Pl_UndCod == data.PE.RhSegUnd02.Value || data.PL.Pl_UndCod == data.PE.RhSegUnd03.Value).Where(data => data.PL.Pl_UndCod == codigoUnidad).Where(data => data.PE.RH_EstLab.Equals("A")).Select(data => data.PE);
          IQueryable<PEDATPER> source2 = dbT.PEDATPER.SelectMany((Expression<Func<PEDATPER, IEnumerable<PLUNILAB>>>) (PE => dbT.PLUNILAB), (PE, PL) => new
          {
            PE = PE,
            PL = PL
          }).Where(data => data.PL.Pl_UndCod == data.PE.RhSegUnd01.Value || data.PL.Pl_UndCod == data.PE.RhSegUnd02.Value || data.PL.Pl_UndCod == data.PE.RhSegUnd03.Value).Where(data => data.PL.Pl_UndCod == codigoUnidad).Where(data => data.PE.RH_EstLab.Equals("A")).Select(data => data.PE);
          return source1.ToList<PEDATPER>().Union<PEDATPER>((IEnumerable<PEDATPER>) source2.ToList<PEDATPER>()).OrderBy<PEDATPER, string>((Func<PEDATPER, string>) (q => q.PeDatPerChq)).ToList<PEDATPER>();
        }
        IQueryable<PEDATPER> source3 = dbE.PEDATPER.SelectMany((Expression<Func<PEDATPER, IEnumerable<PLUNILAB>>>) (PE => dbE.PLUNILAB), (PE, PL) => new
        {
          PE = PE,
          PL = PL
        }).Where(data => data.PL.Pl_UndCod == data.PE.RhSegUnd01.Value || data.PL.Pl_UndCod == data.PE.RhSegUnd02.Value || data.PL.Pl_UndCod == data.PE.RhSegUnd03.Value).Where(data => data.PE.RH_EstLab.Equals("A")).Select(data => data.PE);
        IQueryable<PEDATPER> source4 = dbT.PEDATPER.SelectMany((Expression<Func<PEDATPER, IEnumerable<PLUNILAB>>>) (PE => dbT.PLUNILAB), (PE, PL) => new
        {
          PE = PE,
          PL = PL
        }).Where(data => data.PL.Pl_UndCod == data.PE.RhSegUnd01.Value || data.PL.Pl_UndCod == data.PE.RhSegUnd02.Value || data.PL.Pl_UndCod == data.PE.RhSegUnd03.Value).Where(data => data.PE.RH_EstLab.Equals("A")).Select(data => data.PE);
        return source3.ToList<PEDATPER>().Union<PEDATPER>((IEnumerable<PEDATPER>) source4.ToList<PEDATPER>()).OrderBy<PEDATPER, string>((Func<PEDATPER, string>) (q => q.PeDatPerChq)).ToList<PEDATPER>();
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    public List<PEDATPER> GetUserByTerm(string term)
    {
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      App.Infrastructure.SIGPER.SIGPER.\u003C\u003Ec__DisplayClass7_0 cDisplayClass70 = new App.Infrastructure.SIGPER.SIGPER.\u003C\u003Ec__DisplayClass7_0();
      // ISSUE: reference to a compiler-generated field
      cDisplayClass70.term = term;
      try
      {
        AppContext appContext = new AppContext();
        TurismoContext turismoContext = new TurismoContext();
        ParameterExpression parameterExpression1;
        ParameterExpression parameterExpression2;
        // ISSUE: method reference
        // ISSUE: method reference
        // ISSUE: field reference
        // ISSUE: method reference
        // ISSUE: method reference
        // ISSUE: method reference
        // ISSUE: method reference
        // ISSUE: field reference
        // ISSUE: method reference
        // ISSUE: method reference
        // ISSUE: method reference
        // ISSUE: field reference
        // ISSUE: method reference
        // ISSUE: method reference
        // ISSUE: method reference
        // ISSUE: method reference
        // ISSUE: field reference
        // ISSUE: method reference
        return appContext.PEDATPER.Where<PEDATPER>(Expression.Lambda<Func<PEDATPER, bool>>((Expression) Expression.OrElse((Expression) Expression.AndAlso(q.RH_EstLab.Equals("A"), (Expression) Expression.Call((Expression) Expression.Call(q.PeDatPerChq, (MethodInfo) MethodBase.GetMethodFromHandle(__methodref (string.ToLower)), Array.Empty<Expression>()), (MethodInfo) MethodBase.GetMethodFromHandle(__methodref (string.Contains)), (Expression) Expression.Call((Expression) Expression.Field((Expression) Expression.Constant((object) cDisplayClass70, typeof (App.Infrastructure.SIGPER.SIGPER.\u003C\u003Ec__DisplayClass7_0)), FieldInfo.GetFieldFromHandle(__fieldref (App.Infrastructure.SIGPER.SIGPER.\u003C\u003Ec__DisplayClass7_0.term))), (MethodInfo) MethodBase.GetMethodFromHandle(__methodref (string.ToLower)), Array.Empty<Expression>()))), (Expression) Expression.Call((Expression) Expression.Call((Expression) Expression.Property((Expression) parameterExpression1, (MethodInfo) MethodBase.GetMethodFromHandle(__methodref (PEDATPER.get_Rh_Mail))), (MethodInfo) MethodBase.GetMethodFromHandle(__methodref (string.ToLower)), Array.Empty<Expression>()), (MethodInfo) MethodBase.GetMethodFromHandle(__methodref (string.Contains)), (Expression) Expression.Call((Expression) Expression.Field((Expression) Expression.Constant((object) cDisplayClass70, typeof (App.Infrastructure.SIGPER.SIGPER.\u003C\u003Ec__DisplayClass7_0)), FieldInfo.GetFieldFromHandle(__fieldref (App.Infrastructure.SIGPER.SIGPER.\u003C\u003Ec__DisplayClass7_0.term))), (MethodInfo) MethodBase.GetMethodFromHandle(__methodref (string.ToLower)), Array.Empty<Expression>()))), parameterExpression1)).ToList<PEDATPER>().Union<PEDATPER>((IEnumerable<PEDATPER>) turismoContext.PEDATPER.Where<PEDATPER>(Expression.Lambda<Func<PEDATPER, bool>>((Expression) Expression.OrElse((Expression) Expression.AndAlso(q.RH_EstLab.Equals("A"), (Expression) Expression.Call((Expression) Expression.Call(q.PeDatPerChq, (MethodInfo) MethodBase.GetMethodFromHandle(__methodref (string.ToLower)), Array.Empty<Expression>()), (MethodInfo) MethodBase.GetMethodFromHandle(__methodref (string.Contains)), (Expression) Expression.Call((Expression) Expression.Field((Expression) Expression.Constant((object) cDisplayClass70, typeof (App.Infrastructure.SIGPER.SIGPER.\u003C\u003Ec__DisplayClass7_0)), FieldInfo.GetFieldFromHandle(__fieldref (App.Infrastructure.SIGPER.SIGPER.\u003C\u003Ec__DisplayClass7_0.term))), (MethodInfo) MethodBase.GetMethodFromHandle(__methodref (string.ToLower)), Array.Empty<Expression>()))), (Expression) Expression.Call((Expression) Expression.Call((Expression) Expression.Property((Expression) parameterExpression2, (MethodInfo) MethodBase.GetMethodFromHandle(__methodref (PEDATPER.get_Rh_Mail))), (MethodInfo) MethodBase.GetMethodFromHandle(__methodref (string.ToLower)), Array.Empty<Expression>()), (MethodInfo) MethodBase.GetMethodFromHandle(__methodref (string.Contains)), (Expression) Expression.Call((Expression) Expression.Field((Expression) Expression.Constant((object) cDisplayClass70, typeof (App.Infrastructure.SIGPER.SIGPER.\u003C\u003Ec__DisplayClass7_0)), FieldInfo.GetFieldFromHandle(__fieldref (App.Infrastructure.SIGPER.SIGPER.\u003C\u003Ec__DisplayClass7_0.term))), (MethodInfo) MethodBase.GetMethodFromHandle(__methodref (string.ToLower)), Array.Empty<Expression>()))), parameterExpression2)).ToList<PEDATPER>()).OrderBy<PEDATPER, string>((Func<PEDATPER, string>) (q => q.PeDatPerChq)).ToList<PEDATPER>();
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    public App.Core.Entities.SIGPER.SIGPER GetJefaturaByUnidad(int codigo)
    {
      App.Core.Entities.SIGPER.SIGPER jefaturaByUnidad = new App.Core.Entities.SIGPER.SIGPER()
      {
        Funcionario = (PEDATPER) null,
        Jefatura = (PEDATPER) null,
        Secretaria = (PEDATPER) null,
        Unidad = (PLUNILAB) null
      };
      try
      {
        AppContext appContext = new AppContext();
        PLUNILAB plunilab1 = appContext.PLUNILAB.FirstOrDefault<PLUNILAB>((Expression<Func<PLUNILAB, bool>>) (q => q.Pl_UndCod == codigo));
        jefaturaByUnidad.Unidad = plunilab1;
        PEFERJEFAJ jef = appContext.PEFERJEFAJ.FirstOrDefault<PEFERJEFAJ>((Expression<Func<PEFERJEFAJ, bool>>) (q => q.PeFerJerCod == (Decimal) codigo));
        PEDATPER pedatper1 = appContext.PEDATPER.FirstOrDefault<PEDATPER>((Expression<Func<PEDATPER, bool>>) (q => q.RH_EstLab.Equals("A") && q.RH_NumInte == jef.FyPFunARut));
        jefaturaByUnidad.Jefatura = pedatper1;
        if (jefaturaByUnidad.Jefatura != null)
          return jefaturaByUnidad;
        TurismoContext turismoContext = new TurismoContext();
        PLUNILAB plunilab2 = turismoContext.PLUNILAB.FirstOrDefault<PLUNILAB>((Expression<Func<PLUNILAB, bool>>) (q => q.Pl_UndCod == codigo));
        jefaturaByUnidad.Unidad = plunilab2;
        jef = turismoContext.PEFERJEFAJ.FirstOrDefault<PEFERJEFAJ>((Expression<Func<PEFERJEFAJ, bool>>) (q => q.PeFerJerCod == (Decimal) codigo));
        PEDATPER pedatper2 = turismoContext.PEDATPER.FirstOrDefault<PEDATPER>((Expression<Func<PEDATPER, bool>>) (q => q.RH_EstLab.Equals("A") && q.RH_NumInte == jef.FyPFunARut));
        jefaturaByUnidad.Jefatura = pedatper2;
        return jefaturaByUnidad;
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    public App.Core.Entities.SIGPER.SIGPER GetSecretariaByUnidad(int codigo)
    {
      App.Core.Entities.SIGPER.SIGPER secretariaByUnidad = new App.Core.Entities.SIGPER.SIGPER()
      {
        Funcionario = (PEDATPER) null,
        Jefatura = (PEDATPER) null,
        Secretaria = (PEDATPER) null,
        Unidad = (PLUNILAB) null
      };
      try
      {
        AppContext appContext = new AppContext();
        PLUNILAB unidad = appContext.PLUNILAB.FirstOrDefault<PLUNILAB>((Expression<Func<PLUNILAB, bool>>) (q => q.Pl_UndCod == codigo));
        secretariaByUnidad.Unidad = unidad;
        PEDATPER pedatper = appContext.PEDATPER.FirstOrDefault<PEDATPER>((Expression<Func<PEDATPER, bool>>) (q => q.RH_EstLab.Equals("A") && q.PeDatPerChq == unidad.Pl_UndNomSec));
        secretariaByUnidad.Secretaria = pedatper;
        return secretariaByUnidad;
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    public List<DGREGIONES> GetRegion()
    {
      try
      {
        return new AppContext().DGREGIONES.ToList<DGREGIONES>();
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    public List<DGCOMUNAS> GetDGCOMUNAs()
    {
      try
      {
        return new AppContext().DGCOMUNAS.ToList<DGCOMUNAS>();
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    public List<DGPAISES> GetDGPAISESs()
    {
      try
      {
        return new AppContext().DGPAISES.ToList<DGPAISES>();
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    public List<DGESCALAFONES> GetGESCALAFONEs()
    {
      try
      {
        return new AppContext().DGESCALAFONES.ToList<DGESCALAFONES>();
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    public List<DGCONTRATOS> GetDGCONTRATOS()
    {
      try
      {
        return new AppContext().DGCONTRATOS.ToList<DGCONTRATOS>();
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    public List<PECARGOS> GetPECARGOs()
    {
      try
      {
        return new AppContext().PECARGOS.ToList<PECARGOS>();
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    public List<DGESTAMENTOS> GetDGESTAMENTOs()
    {
      try
      {
        return new AppContext().DGESTAMENTOS.ToList<DGESTAMENTOS>();
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    public List<ReContra> GetReContra()
    {
      try
      {
        return new AppContext().ReContra.Where<ReContra>((Expression<Func<ReContra, bool>>) (c => (int) c.ReContraSed != 0)).ToList<ReContra>();
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    public string GetRegionbyComuna(string codComuna)
    {
      try
      {
        AppContext appContext = new AppContext();
        string region = appContext.DGCOMUNAS.Where<DGCOMUNAS>((Expression<Func<DGCOMUNAS, bool>>) (c => c.Pl_CodCom == codComuna)).FirstOrDefault<DGCOMUNAS>().Pl_CodReg;
        return appContext.DGREGIONES.Where<DGREGIONES>((Expression<Func<DGREGIONES, bool>>) (r => r.Pl_CodReg == region)).FirstOrDefault<DGREGIONES>().Pl_DesReg;
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    public List<DGCOMUNAS> GetComunasbyRegion(string IdRegion)
    {
      try
      {
        return new AppContext().DGCOMUNAS.Where<DGCOMUNAS>((Expression<Func<DGCOMUNAS, bool>>) (c => c.Pl_CodReg == IdRegion)).ToList<DGCOMUNAS>();
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    public Destinos GetMontoViaticos(int CometidoId, int Cantdias)
    {
      Destinos montoViaticos = new Destinos()
      {
        Dias100Monto = new int?(),
        Dias60Monto = new int?(),
        Dias40Monto = new int?(),
        Dias50Monto = new int?()
      };
      try
      {
        return montoViaticos;
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }
  }
}
