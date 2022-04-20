// Decompiled with JetBrains decompiler
// Type: App.Infrastructure.GestionProcesos.Configuration
// Assembly: App.Infrastructure, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7D12F3AE-788C-4496-85EF-A6E23743B789
// Assembly location: C:\Users\IROCHA\source\repos\Integridad\sintegridadweb\bin\App.Infrastructure.dll

using System.Data.Entity.Migrations;

namespace App.Infrastructure.GestionProcesos
{
  internal sealed class Configuration : DbMigrationsConfiguration<AppContext>
  {
    public Configuration()
    {
      this.AutomaticMigrationsEnabled = true;
      this.AutomaticMigrationDataLossAllowed = true;
    }

    protected override void Seed(AppContext context)
    {
    }
  }
}
