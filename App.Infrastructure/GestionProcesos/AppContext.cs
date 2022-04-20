// Decompiled with JetBrains decompiler
// Type: App.Infrastructure.GestionProcesos.AppContext
// Assembly: App.Infrastructure, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7D12F3AE-788C-4496-85EF-A6E23743B789
// Assembly location: C:\Users\IROCHA\source\repos\Integridad\sintegridadweb\bin\App.Infrastructure.dll

using App.Core.Entities.CDP;
using App.Core.Entities.GestionDocumental;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.SqlServer;

namespace App.Infrastructure.GestionProcesos
{
  public class AppContext : DbContext
  {
    public AppContext()
      : base("name=GestionProcesos")
    {
    }

    public virtual DbSet<App.Core.Entities.Core.Configuracion> Configuracion { get; set; }

    public virtual DbSet<App.Core.Entities.Core.DefinicionProceso> DefinicionProceso { get; set; }

    public virtual DbSet<App.Core.Entities.Core.DefinicionWorkflow> DefinicionWorkflow { get; set; }

    public virtual DbSet<App.Core.Entities.Core.Proceso> Proceso { get; set; }

    public virtual DbSet<App.Core.Entities.Core.Usuario> Usuario { get; set; }

    public virtual DbSet<App.Core.Entities.CuentaRed.CuentaRed> Indice { get; set; }

    public virtual DbSet<App.Core.Entities.Shared.Region> Region { get; set; }

    public virtual DbSet<App.Core.Entities.Shared.Genero> Genero { get; set; }

    public virtual DbSet<App.Core.Entities.Shared.Subsecretaria> Subsecretaria { get; set; }

    public virtual DbSet<App.Core.Entities.Contrato.Contrato> Contrato { get; set; }

    public virtual DbSet<App.Core.Entities.Shared.Programa> Programa { get; set; }

    public virtual DbSet<App.Core.Entities.CDP.CDP> CDP { get; set; }

    public virtual DbSet<CDPBien> Bien { get; set; }

    public virtual DbSet<CDPTipoSolicitud> TipoSolicitud { get; set; }

    public virtual DbSet<App.Core.Entities.Shared.Institucion> Institucion { get; set; }

    public virtual DbSet<App.Core.Entities.Core.Documento> Documento { get; set; }

    public virtual DbSet<App.Core.Entities.InformeHSA.InformeHSA> InformeHSA { get; set; }

    public virtual DbSet<GDIngreso> Ingreso { get; set; }

    public virtual DbSet<GDTipoIngreso> TipoIngreso { get; set; }

    public virtual DbSet<App.Core.Entities.Core.TipoDocumento> TipoDocumento { get; set; }

    public virtual DbSet<App.Core.Entities.Core.TipoAprobacion> TipoAprobacion { get; set; }

    public virtual DbSet<App.Core.Entities.Core.TipoEjecucion> TipoEjecucion { get; set; }

    public virtual DbSet<App.Core.Entities.Core.Accion> Accion { get; set; }

    public virtual DbSet<App.Core.Entities.Core.Entidad> Entidad { get; set; }

    public virtual DbSet<App.Core.Entities.Core.Rubrica> Rubrica { get; set; }

    public virtual DbSet<App.Core.Entities.Core.TipoPrivacidad> TipoPrivacidad { get; set; }

    public virtual DbSet<App.Core.Entities.SIAC.SIACSolicitud> SIACSolicitud { get; set; }

    public virtual DbSet<App.Core.Entities.SIAC.SIACOcupacion> SIACOcupacion { get; set; }

    public virtual DbSet<App.Core.Entities.SIAC.SIACTema> SIACTema { get; set; }

    public virtual DbSet<App.Core.Entities.SIAC.SIACTipoSolicitud> SIACTipoSolicitud { get; set; }

    public virtual DbSet<App.Core.Entities.RadioTaxi.RadioTaxi> RadioTaxi { get; set; }

    public virtual DbSet<App.Core.Entities.Cometido.Cometido> Cometido { get; set; }

    public virtual DbSet<App.Core.Entities.Cometido.Destinos> Destinos { get; set; }

    public virtual DbSet<App.Core.Entities.Cometido.Viatico> Viatico { get; set; }

    public virtual DbSet<App.Core.Entities.Cometido.ViaticoHonorario> ViaticoHonorario { get; set; }

    public virtual DbSet<App.Core.Entities.Cometido.TipoAsignacion> TipoAsignacion { get; set; }

    public virtual DbSet<App.Core.Entities.Cometido.TipoCapitulo> TipoCapitulo { get; set; }

    public virtual DbSet<App.Core.Entities.Cometido.TipoItem> TipoItem { get; set; }

    public virtual DbSet<App.Core.Entities.Cometido.TipoPartida> TipoPartida { get; set; }

    public virtual DbSet<App.Core.Entities.Cometido.TipoSubAsignacion> TipoSubAsignacion { get; set; }

    public virtual DbSet<App.Core.Entities.Cometido.TipoSubTitulo> TipoSubTitulo { get; set; }

    public virtual DbSet<App.Core.Entities.Cometido.GeneracionCDP> GeneracionCDP { get; set; }

    public virtual DbSet<App.Core.Entities.Cometido.CentroCosto> CentroCosto { get; set; }

    public virtual DbSet<App.Core.Entities.Cometido.Parrafos> Parrafos { get; set; }

    public virtual DbSet<App.Core.Entities.Pasajes.Pasaje> Pasaje { get; set; }

    public virtual DbSet<App.Core.Entities.Cometido.Mantenedor> Mantenedor { get; set; }

    public virtual DbSet<App.Core.Entities.FlujosIntegridad.Denuncia> Denuncia { get; set; }

    public virtual DbSet<App.Core.Entities.FlujosIntegridad.Consulta> Consulta { get; set; }

    public virtual DbSet<App.Core.Entities.FlujosIntegridad.WebConsulta> WebConsulta { get; set; }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
      Database.SetInitializer<AppContext>((IDatabaseInitializer<AppContext>) null);
      base.OnModelCreating(modelBuilder);
      modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
      modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
      SqlProviderServices instance = SqlProviderServices.Instance;
    }
  }
}
