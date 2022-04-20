// Decompiled with JetBrains decompiler
// Type: App.Infrastructure.SIGPER.AppContext
// Assembly: App.Infrastructure, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7D12F3AE-788C-4496-85EF-A6E23743B789
// Assembly location: C:\Users\IROCHA\source\repos\Integridad\sintegridadweb\bin\App.Infrastructure.dll

using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.SqlServer;
using System.Linq.Expressions;

namespace App.Infrastructure.SIGPER
{
  public class AppContext : DbContext
  {
    public AppContext()
      : base("name=Economia")
    {
    }

    public virtual DbSet<App.Core.Entities.SIGPER.PEDATPER> PEDATPER { get; set; }

    public virtual DbSet<App.Core.Entities.SIGPER.PeDatLab> PeDatLab { get; set; }

    public virtual DbSet<App.Core.Entities.SIGPER.PLUNILAB> PLUNILAB { get; set; }

    public virtual DbSet<App.Core.Entities.SIGPER.PEFERJEF> PEFERJEF { get; set; }

    public virtual DbSet<App.Core.Entities.SIGPER.PEFERJEFAF> PEFERJEFAF { get; set; }

    public virtual DbSet<App.Core.Entities.SIGPER.PEFERJEFAJ> PEFERJEFAJ { get; set; }

    public virtual DbSet<App.Core.Entities.SIGPER.PECARGOS> PECARGOS { get; set; }

    public virtual DbSet<App.Core.Entities.SIGPER.DGREGIONES> DGREGIONES { get; set; }

    public virtual DbSet<App.Core.Entities.SIGPER.DGCOMUNAS> DGCOMUNAS { get; set; }

    public virtual DbSet<App.Core.Entities.SIGPER.DGPAISES> DGPAISES { get; set; }

    public virtual DbSet<App.Core.Entities.SIGPER.DGESCALAFONES> DGESCALAFONES { get; set; }

    public virtual DbSet<App.Core.Entities.SIGPER.DGESTAMENTOS> DGESTAMENTOS { get; set; }

    public virtual DbSet<App.Core.Entities.SIGPER.ReContra> ReContra { get; set; }

    public virtual DbSet<App.Core.Entities.SIGPER.DGCONTRATOS> DGCONTRATOS { get; set; }

    public virtual DbSet<App.Core.Entities.SIGPER.SIGPERTipoReembolso> SIGPERTipoReembolso { get; set; }

    public virtual DbSet<App.Core.Entities.SIGPER.SIGPERTipoVehiculo> SIGPERTipoVehiculo { get; set; }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
      Database.SetInitializer<AppContext>((IDatabaseInitializer<AppContext>) null);
      base.OnModelCreating(modelBuilder);
      modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
      SqlProviderServices instance = SqlProviderServices.Instance;
      modelBuilder.Entity<App.Core.Entities.SIGPER.PEDATPER>().Property((Expression<Func<App.Core.Entities.SIGPER.PEDATPER, string>>) (e => e.Rh_InstPub)).IsFixedLength().IsUnicode(new bool?(false));
      modelBuilder.Entity<App.Core.Entities.SIGPER.PEDATPER>().Property((Expression<Func<App.Core.Entities.SIGPER.PEDATPER, string>>) (e => e.RH_DvNuInt)).IsFixedLength().IsUnicode(new bool?(false));
      modelBuilder.Entity<App.Core.Entities.SIGPER.PEDATPER>().Property((Expression<Func<App.Core.Entities.SIGPER.PEDATPER, string>>) (e => e.RH_PaterFun)).IsFixedLength().IsUnicode(new bool?(false));
      modelBuilder.Entity<App.Core.Entities.SIGPER.PEDATPER>().Property((Expression<Func<App.Core.Entities.SIGPER.PEDATPER, string>>) (e => e.RH_MaterFun)).IsFixedLength().IsUnicode(new bool?(false));
      modelBuilder.Entity<App.Core.Entities.SIGPER.PEDATPER>().Property((Expression<Func<App.Core.Entities.SIGPER.PEDATPER, string>>) (e => e.RH_NombFun)).IsFixedLength().IsUnicode(new bool?(false));
      modelBuilder.Entity<App.Core.Entities.SIGPER.PEDATPER>().Property((Expression<Func<App.Core.Entities.SIGPER.PEDATPER, string>>) (e => e.RH_DirCal)).IsFixedLength().IsUnicode(new bool?(false));
      modelBuilder.Entity<App.Core.Entities.SIGPER.PEDATPER>().Property((Expression<Func<App.Core.Entities.SIGPER.PEDATPER, string>>) (e => e.RH_DirNum)).IsFixedLength().IsUnicode(new bool?(false));
      modelBuilder.Entity<App.Core.Entities.SIGPER.PEDATPER>().Property((Expression<Func<App.Core.Entities.SIGPER.PEDATPER, string>>) (e => e.RH_DirDep)).IsFixedLength().IsUnicode(new bool?(false));
      modelBuilder.Entity<App.Core.Entities.SIGPER.PEDATPER>().Property((Expression<Func<App.Core.Entities.SIGPER.PEDATPER, string>>) (e => e.RH_DirBlo)).IsFixedLength().IsUnicode(new bool?(false));
      modelBuilder.Entity<App.Core.Entities.SIGPER.PEDATPER>().Property((Expression<Func<App.Core.Entities.SIGPER.PEDATPER, string>>) (e => e.Pl_CodPla)).IsFixedLength().IsUnicode(new bool?(false));
      modelBuilder.Entity<App.Core.Entities.SIGPER.PEDATPER>().Property((Expression<Func<App.Core.Entities.SIGPER.PEDATPER, string>>) (e => e.Pl_CodCom)).IsFixedLength().IsUnicode(new bool?(false));
      modelBuilder.Entity<App.Core.Entities.SIGPER.PEDATPER>().Property((Expression<Func<App.Core.Entities.SIGPER.PEDATPER, string>>) (e => e.RH_Telefono)).IsFixedLength().IsUnicode(new bool?(false));
      modelBuilder.Entity<App.Core.Entities.SIGPER.PEDATPER>().Property((Expression<Func<App.Core.Entities.SIGPER.PEDATPER, string>>) (e => e.RH_LugNac)).IsFixedLength().IsUnicode(new bool?(false));
      modelBuilder.Entity<App.Core.Entities.SIGPER.PEDATPER>().Property((Expression<Func<App.Core.Entities.SIGPER.PEDATPER, string>>) (e => e.RH_SexoCod)).IsFixedLength().IsUnicode(new bool?(false));
      modelBuilder.Entity<App.Core.Entities.SIGPER.PEDATPER>().Property((Expression<Func<App.Core.Entities.SIGPER.PEDATPER, string>>) (e => e.RH_EstCivi)).IsFixedLength().IsUnicode(new bool?(false));
      modelBuilder.Entity<App.Core.Entities.SIGPER.PEDATPER>().Property((Expression<Func<App.Core.Entities.SIGPER.PEDATPER, string>>) (e => e.RH_IncMil)).IsFixedLength().IsUnicode(new bool?(false));
      modelBuilder.Entity<App.Core.Entities.SIGPER.PEDATPER>().Property((Expression<Func<App.Core.Entities.SIGPER.PEDATPER, string>>) (e => e.RH_EstLab)).IsFixedLength().IsUnicode(new bool?(false));
      modelBuilder.Entity<App.Core.Entities.SIGPER.PEDATPER>().Property((Expression<Func<App.Core.Entities.SIGPER.PEDATPER, string>>) (e => e.RH_Foto)).IsFixedLength().IsUnicode(new bool?(false));
      modelBuilder.Entity<App.Core.Entities.SIGPER.PEDATPER>().Property((Expression<Func<App.Core.Entities.SIGPER.PEDATPER, string>>) (e => e.RH_TarjCAs)).IsFixedLength().IsUnicode(new bool?(false));
      modelBuilder.Entity<App.Core.Entities.SIGPER.PEDATPER>().Property((Expression<Func<App.Core.Entities.SIGPER.PEDATPER, string>>) (e => e.RH_ObsMen)).IsFixedLength().IsUnicode(new bool?(false));
      modelBuilder.Entity<App.Core.Entities.SIGPER.PEDATPER>().Property((Expression<Func<App.Core.Entities.SIGPER.PEDATPER, string>>) (e => e.RH_FunMed)).IsFixedLength().IsUnicode(new bool?(false));
      modelBuilder.Entity<App.Core.Entities.SIGPER.PEDATPER>().Property((Expression<Func<App.Core.Entities.SIGPER.PEDATPER, string>>) (e => e.RH_FunEnf)).IsFixedLength().IsUnicode(new bool?(false));
      modelBuilder.Entity<App.Core.Entities.SIGPER.PEDATPER>().Property((Expression<Func<App.Core.Entities.SIGPER.PEDATPER, string>>) (e => e.RH_FunAle)).IsFixedLength().IsUnicode(new bool?(false));
      modelBuilder.Entity<App.Core.Entities.SIGPER.PEDATPER>().Property((Expression<Func<App.Core.Entities.SIGPER.PEDATPER, string>>) (e => e.RH_FunEme)).IsFixedLength().IsUnicode(new bool?(false));
      modelBuilder.Entity<App.Core.Entities.SIGPER.PEDATPER>().Property((Expression<Func<App.Core.Entities.SIGPER.PEDATPER, Decimal?>>) (e => e.RH_FunEst)).HasPrecision((byte) 10, (byte) 4);
      modelBuilder.Entity<App.Core.Entities.SIGPER.PEDATPER>().Property((Expression<Func<App.Core.Entities.SIGPER.PEDATPER, string>>) (e => e.RH_Bienest)).IsFixedLength().IsUnicode(new bool?(false));
      modelBuilder.Entity<App.Core.Entities.SIGPER.PEDATPER>().Property((Expression<Func<App.Core.Entities.SIGPER.PEDATPER, string>>) (e => e.RH_TipSocB)).IsFixedLength().IsUnicode(new bool?(false));
      modelBuilder.Entity<App.Core.Entities.SIGPER.PEDATPER>().Property((Expression<Func<App.Core.Entities.SIGPER.PEDATPER, string>>) (e => e.RH_BieJub)).IsFixedLength().IsUnicode(new bool?(false));
      modelBuilder.Entity<App.Core.Entities.SIGPER.PEDATPER>().Property((Expression<Func<App.Core.Entities.SIGPER.PEDATPER, string>>) (e => e.RH_BieEstL)).IsFixedLength().IsUnicode(new bool?(false));
      modelBuilder.Entity<App.Core.Entities.SIGPER.PEDATPER>().Property((Expression<Func<App.Core.Entities.SIGPER.PEDATPER, Decimal?>>) (e => e.RH_BieSuel)).HasPrecision((byte) 19, (byte) 4);
      modelBuilder.Entity<App.Core.Entities.SIGPER.PEDATPER>().Property((Expression<Func<App.Core.Entities.SIGPER.PEDATPER, string>>) (e => e.RE_Ac1EspCod)).IsFixedLength().IsUnicode(new bool?(false));
      modelBuilder.Entity<App.Core.Entities.SIGPER.PEDATPER>().Property((Expression<Func<App.Core.Entities.SIGPER.PEDATPER, string>>) (e => e.RE_Ac2EspCod)).IsFixedLength().IsUnicode(new bool?(false));
      modelBuilder.Entity<App.Core.Entities.SIGPER.PEDATPER>().Property((Expression<Func<App.Core.Entities.SIGPER.PEDATPER, string>>) (e => e.RH_BcoCod)).IsFixedLength().IsUnicode(new bool?(false));
      modelBuilder.Entity<App.Core.Entities.SIGPER.PEDATPER>().Property((Expression<Func<App.Core.Entities.SIGPER.PEDATPER, string>>) (e => e.RH_BcoAbo)).IsFixedLength().IsUnicode(new bool?(false));
      modelBuilder.Entity<App.Core.Entities.SIGPER.PEDATPER>().Property((Expression<Func<App.Core.Entities.SIGPER.PEDATPER, string>>) (e => e.RH_CtaCrr)).IsFixedLength().IsUnicode(new bool?(false));
      modelBuilder.Entity<App.Core.Entities.SIGPER.PEDATPER>().Property((Expression<Func<App.Core.Entities.SIGPER.PEDATPER, string>>) (e => e.Rh_BcoEst)).IsFixedLength().IsUnicode(new bool?(false));
      modelBuilder.Entity<App.Core.Entities.SIGPER.PEDATPER>().Property((Expression<Func<App.Core.Entities.SIGPER.PEDATPER, string>>) (e => e.Rh_ClaIne)).IsFixedLength().IsUnicode(new bool?(false));
      modelBuilder.Entity<App.Core.Entities.SIGPER.PEDATPER>().Property((Expression<Func<App.Core.Entities.SIGPER.PEDATPER, string>>) (e => e.Rh_Mail)).IsFixedLength().IsUnicode(new bool?(false));
      modelBuilder.Entity<App.Core.Entities.SIGPER.PEDATPER>().Property((Expression<Func<App.Core.Entities.SIGPER.PEDATPER, string>>) (e => e.Rh_TelOfi)).IsFixedLength().IsUnicode(new bool?(false));
      modelBuilder.Entity<App.Core.Entities.SIGPER.PEDATPER>().Property((Expression<Func<App.Core.Entities.SIGPER.PEDATPER, string>>) (e => e.Rh_FotoTyp)).IsFixedLength().IsUnicode(new bool?(false));
      modelBuilder.Entity<App.Core.Entities.SIGPER.PEDATPER>().Property((Expression<Func<App.Core.Entities.SIGPER.PEDATPER, string>>) (e => e.Rh_Celular)).IsFixedLength().IsUnicode(new bool?(false));
      modelBuilder.Entity<App.Core.Entities.SIGPER.PEDATPER>().Property((Expression<Func<App.Core.Entities.SIGPER.PEDATPER, string>>) (e => e.Rh_ViPoCo)).IsFixedLength().IsUnicode(new bool?(false));
      modelBuilder.Entity<App.Core.Entities.SIGPER.PEDATPER>().Property((Expression<Func<App.Core.Entities.SIGPER.PEDATPER, string>>) (e => e.Rh_SitCant)).IsFixedLength().IsUnicode(new bool?(false));
      modelBuilder.Entity<App.Core.Entities.SIGPER.PEDATPER>().Property((Expression<Func<App.Core.Entities.SIGPER.PEDATPER, string>>) (e => e.Pl_CodReg)).IsFixedLength().IsUnicode(new bool?(false));
      modelBuilder.Entity<App.Core.Entities.SIGPER.PEDATPER>().Property((Expression<Func<App.Core.Entities.SIGPER.PEDATPER, string>>) (e => e.Rh_IdeFun)).IsFixedLength().IsUnicode(new bool?(false));
      modelBuilder.Entity<App.Core.Entities.SIGPER.PEDATPER>().Property((Expression<Func<App.Core.Entities.SIGPER.PEDATPER, string>>) (e => e.Rh_Indica)).IsFixedLength().IsUnicode(new bool?(false));
      modelBuilder.Entity<App.Core.Entities.SIGPER.PEDATPER>().Property((Expression<Func<App.Core.Entities.SIGPER.PEDATPER, string>>) (e => e.Rh_PassWeb)).IsFixedLength().IsUnicode(new bool?(false));
      modelBuilder.Entity<App.Core.Entities.SIGPER.PEDATPER>().Property((Expression<Func<App.Core.Entities.SIGPER.PEDATPER, string>>) (e => e.Rh_KeyWeb)).IsFixedLength().IsUnicode(new bool?(false));
      modelBuilder.Entity<App.Core.Entities.SIGPER.PEDATPER>().Property((Expression<Func<App.Core.Entities.SIGPER.PEDATPER, string>>) (e => e.Rh_CalInd)).IsFixedLength().IsUnicode(new bool?(false));
      modelBuilder.Entity<App.Core.Entities.SIGPER.PEDATPER>().Property((Expression<Func<App.Core.Entities.SIGPER.PEDATPER, string>>) (e => e.Rh_MailPer)).IsFixedLength().IsUnicode(new bool?(false));
      modelBuilder.Entity<App.Core.Entities.SIGPER.PEDATPER>().Property((Expression<Func<App.Core.Entities.SIGPER.PEDATPER, string>>) (e => e.Rh_AntUti)).IsFixedLength().IsUnicode(new bool?(false));
      modelBuilder.Entity<App.Core.Entities.SIGPER.PEDATPER>().Property((Expression<Func<App.Core.Entities.SIGPER.PEDATPER, string>>) (e => e.Rh_BieBlq)).IsFixedLength().IsUnicode(new bool?(false));
      modelBuilder.Entity<App.Core.Entities.SIGPER.PEDATPER>().Property((Expression<Func<App.Core.Entities.SIGPER.PEDATPER, string>>) (e => e.Rh_BieBlqLeyA)).IsFixedLength().IsUnicode(new bool?(false));
      modelBuilder.Entity<App.Core.Entities.SIGPER.PEDATPER>().Property((Expression<Func<App.Core.Entities.SIGPER.PEDATPER, string>>) (e => e.Rh_BieBlqLeyB)).IsFixedLength().IsUnicode(new bool?(false));
      modelBuilder.Entity<App.Core.Entities.SIGPER.PEDATPER>().Property((Expression<Func<App.Core.Entities.SIGPER.PEDATPER, string>>) (e => e.Rh_AsiMarca)).IsFixedLength().IsUnicode(new bool?(false));
      modelBuilder.Entity<App.Core.Entities.SIGPER.PEDATPER>().Property((Expression<Func<App.Core.Entities.SIGPER.PEDATPER, string>>) (e => e.Rh_BieSegSal)).IsFixedLength().IsUnicode(new bool?(false));
      modelBuilder.Entity<App.Core.Entities.SIGPER.PEDATPER>().Property((Expression<Func<App.Core.Entities.SIGPER.PEDATPER, string>>) (e => e.RH_NomFunCap)).IsFixedLength().IsUnicode(new bool?(false));
      modelBuilder.Entity<App.Core.Entities.SIGPER.PEDATPER>().Property((Expression<Func<App.Core.Entities.SIGPER.PEDATPER, string>>) (e => e.Rh_NomLDAP)).IsFixedLength().IsUnicode(new bool?(false));
      modelBuilder.Entity<App.Core.Entities.SIGPER.PEDATPER>().Property((Expression<Func<App.Core.Entities.SIGPER.PEDATPER, string>>) (e => e.Rh_IndConAct)).IsFixedLength().IsUnicode(new bool?(false));
      modelBuilder.Entity<App.Core.Entities.SIGPER.PEDATPER>().Property((Expression<Func<App.Core.Entities.SIGPER.PEDATPER, string>>) (e => e.RhH_TarjTip)).IsFixedLength().IsUnicode(new bool?(false));
      modelBuilder.Entity<App.Core.Entities.SIGPER.PEDATPER>().Property((Expression<Func<App.Core.Entities.SIGPER.PEDATPER, string>>) (e => e.Rh_BieComUna)).IsFixedLength().IsUnicode(new bool?(false));
      modelBuilder.Entity<App.Core.Entities.SIGPER.PEDATPER>().Property((Expression<Func<App.Core.Entities.SIGPER.PEDATPER, string>>) (e => e.Rh_BieComDes)).IsFixedLength().IsUnicode(new bool?(false));
      modelBuilder.Entity<App.Core.Entities.SIGPER.PEDATPER>().Property((Expression<Func<App.Core.Entities.SIGPER.PEDATPER, string>>) (e => e.Rh_MarcaAC)).IsFixedLength().IsUnicode(new bool?(false));
      modelBuilder.Entity<App.Core.Entities.SIGPER.PEDATPER>().Property((Expression<Func<App.Core.Entities.SIGPER.PEDATPER, string>>) (e => e.PeDatPerAutEle)).IsFixedLength().IsUnicode(new bool?(false));
      modelBuilder.Entity<App.Core.Entities.SIGPER.PEDATPER>().Property((Expression<Func<App.Core.Entities.SIGPER.PEDATPER, string>>) (e => e.PeDatPerAutEst)).IsFixedLength().IsUnicode(new bool?(false));
      modelBuilder.Entity<App.Core.Entities.SIGPER.PEDATPER>().Property((Expression<Func<App.Core.Entities.SIGPER.PEDATPER, string>>) (e => e.PeDatPerIndExt)).IsFixedLength().IsUnicode(new bool?(false));
      modelBuilder.Entity<App.Core.Entities.SIGPER.PEDATPER>().Property((Expression<Func<App.Core.Entities.SIGPER.PEDATPER, string>>) (e => e.PeDatPerChq)).IsFixedLength().IsUnicode(new bool?(false));
      modelBuilder.Entity<App.Core.Entities.SIGPER.PEDATPER>().Property((Expression<Func<App.Core.Entities.SIGPER.PEDATPER, string>>) (e => e.RH_Alias)).IsFixedLength().IsUnicode(new bool?(false));
      modelBuilder.Entity<App.Core.Entities.SIGPER.PEDATPER>().Property((Expression<Func<App.Core.Entities.SIGPER.PEDATPER, string>>) (e => e.DgAgrCod)).IsFixedLength().IsUnicode(new bool?(false));
      modelBuilder.Entity<App.Core.Entities.SIGPER.PEDATPER>().Property((Expression<Func<App.Core.Entities.SIGPER.PEDATPER, Decimal?>>) (e => e.Gde_DatPerBlob)).HasPrecision((byte) 15, (byte) 0);
      modelBuilder.Entity<App.Core.Entities.SIGPER.PEDATPER>().Property((Expression<Func<App.Core.Entities.SIGPER.PEDATPER, string>>) (e => e.Rh_IdSd)).IsUnicode(new bool?(false));
      modelBuilder.Entity<App.Core.Entities.SIGPER.PEDATPER>().Property((Expression<Func<App.Core.Entities.SIGPER.PEDATPER, string>>) (e => e.RhRutExt)).IsFixedLength().IsUnicode(new bool?(false));
      modelBuilder.Entity<App.Core.Entities.SIGPER.PEDATPER>().Property((Expression<Func<App.Core.Entities.SIGPER.PEDATPER, string>>) (e => e.RH_ObsSeg)).IsFixedLength().IsUnicode(new bool?(false));
      modelBuilder.Entity<App.Core.Entities.SIGPER.PEDATPER>().Property((Expression<Func<App.Core.Entities.SIGPER.PEDATPER, Decimal?>>) (e => e.Gde_DatPerFir)).HasPrecision((byte) 15, (byte) 0);
      modelBuilder.Entity<App.Core.Entities.SIGPER.PEDATPER>().Property((Expression<Func<App.Core.Entities.SIGPER.PEDATPER, string>>) (e => e.Rh_TipSocPas)).IsFixedLength().IsUnicode(new bool?(false));
      modelBuilder.Entity<App.Core.Entities.SIGPER.PEDATPER>().Property((Expression<Func<App.Core.Entities.SIGPER.PEDATPER, string>>) (e => e.RhFunCod)).IsFixedLength().IsUnicode(new bool?(false));
      modelBuilder.Entity<App.Core.Entities.SIGPER.PEDATPER>().Property((Expression<Func<App.Core.Entities.SIGPER.PEDATPER, Decimal?>>) (e => e.Rh_MonSocPas)).HasPrecision((byte) 10, (byte) 4);
      modelBuilder.Entity<App.Core.Entities.SIGPER.PEDATPER>().Property((Expression<Func<App.Core.Entities.SIGPER.PEDATPER, string>>) (e => e.Rh_NumInsPasDv)).IsFixedLength().IsUnicode(new bool?(false));
      modelBuilder.Entity<App.Core.Entities.SIGPER.PEDATPER>().Property((Expression<Func<App.Core.Entities.SIGPER.PEDATPER, Decimal?>>) (e => e.Rh_NumInsPas)).HasPrecision((byte) 13, (byte) 0);
      modelBuilder.Entity<App.Core.Entities.SIGPER.PEDATPER>().Property((Expression<Func<App.Core.Entities.SIGPER.PEDATPER, string>>) (e => e.RH_NumInteExt)).IsFixedLength().IsUnicode(new bool?(false));
      modelBuilder.Entity<App.Core.Entities.SIGPER.PEDATPER>().Property((Expression<Func<App.Core.Entities.SIGPER.PEDATPER, string>>) (e => e.Rh_UbiFun)).IsFixedLength().IsUnicode(new bool?(false));
      modelBuilder.Entity<App.Core.Entities.SIGPER.PEDATPER>().Property((Expression<Func<App.Core.Entities.SIGPER.PEDATPER, Decimal?>>) (e => e.Rh_SumPun)).HasPrecision((byte) 19, (byte) 4);
      modelBuilder.Entity<App.Core.Entities.SIGPER.PEDATPER>().Property((Expression<Func<App.Core.Entities.SIGPER.PEDATPER, Decimal?>>) (e => e.Rh_FacCom)).HasPrecision((byte) 19, (byte) 4);
      modelBuilder.Entity<App.Core.Entities.SIGPER.PEDATPER>().Property((Expression<Func<App.Core.Entities.SIGPER.PEDATPER, string>>) (e => e.Rh_AseTip)).IsFixedLength().IsUnicode(new bool?(false));
      modelBuilder.Entity<App.Core.Entities.SIGPER.PEDATPER>().Property((Expression<Func<App.Core.Entities.SIGPER.PEDATPER, string>>) (e => e.Rh_TipTraDisCod)).IsFixedLength().IsUnicode(new bool?(false));
      modelBuilder.Entity<App.Core.Entities.SIGPER.PEDATPER>().Property((Expression<Func<App.Core.Entities.SIGPER.PEDATPER, string>>) (e => e.Rh_ConImpCod)).IsFixedLength().IsUnicode(new bool?(false));
      modelBuilder.Entity<App.Core.Entities.SIGPER.PEDATPER>().Property((Expression<Func<App.Core.Entities.SIGPER.PEDATPER, string>>) (e => e.Rh_ResTraCod)).IsFixedLength().IsUnicode(new bool?(false));
      modelBuilder.Entity<App.Core.Entities.SIGPER.PEDATPER>().Property((Expression<Func<App.Core.Entities.SIGPER.PEDATPER, string>>) (e => e.Rh_ConDisCod)).IsFixedLength().IsUnicode(new bool?(false));
      modelBuilder.Entity<App.Core.Entities.SIGPER.PEDATPER>().Property((Expression<Func<App.Core.Entities.SIGPER.PEDATPER, string>>) (e => e.Rh_TipTraCod)).IsFixedLength().IsUnicode(new bool?(false));
      modelBuilder.Entity<App.Core.Entities.SIGPER.PEDATPER>().Property((Expression<Func<App.Core.Entities.SIGPER.PEDATPER, string>>) (e => e.UbiFunIns)).IsFixedLength().IsUnicode(new bool?(false));
      modelBuilder.Entity<App.Core.Entities.SIGPER.PEDATPER>().Property((Expression<Func<App.Core.Entities.SIGPER.PEDATPER, string>>) (e => e.Rh_NroPriRes)).IsFixedLength().IsUnicode(new bool?(false));
    }
  }
}
