// Decompiled with JetBrains decompiler
// Type: App.Core.Interfaces.ISistemaIntegrado
// Assembly: App.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1BF6F6E1-2696-4F22-9AA9-802440B37AD4
// Assembly location: C:\Users\IROCHA\source\repos\Integridad\sintegridadweb\bin\App.Core.dll

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace App.Core.Interfaces
{
  public interface ISistemaIntegrado
  {
    void Create<TEntity>(TEntity entity, string createdBy = null) where TEntity : class;

    void Update<TEntity>(TEntity entity, string modifiedBy = null) where TEntity : class;

    void Delete<TEntity>(object id) where TEntity : class;

    void Delete<TEntity>(TEntity entity) where TEntity : class;

    void Save();

    Task SaveAsync();

    IEnumerable<TEntity> GetAll<TEntity>(
      Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
      string includeProperties = null,
      int? skip = null,
      int? take = null)
      where TEntity : class;

    Task<IEnumerable<TEntity>> GetAllAsync<TEntity>(
      Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
      string includeProperties = null,
      int? skip = null,
      int? take = null)
      where TEntity : class;

    IEnumerable<TEntity> Get<TEntity>(
      Expression<Func<TEntity, bool>> filter = null,
      Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
      string includeProperties = null,
      int? skip = null,
      int? take = null)
      where TEntity : class;

    Task<IEnumerable<TEntity>> GetAsync<TEntity>(
      Expression<Func<TEntity, bool>> filter = null,
      Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
      string includeProperties = null,
      int? skip = null,
      int? take = null)
      where TEntity : class;

    TEntity GetOne<TEntity>(Expression<Func<TEntity, bool>> filter = null, string includeProperties = null) where TEntity : class;

    Task<TEntity> GetOneAsync<TEntity>(
      Expression<Func<TEntity, bool>> filter = null,
      string includeProperties = null)
      where TEntity : class;

    TEntity GetFirst<TEntity>(
      Expression<Func<TEntity, bool>> filter = null,
      Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
      string includeProperties = null)
      where TEntity : class;

    Task<TEntity> GetFirstAsync<TEntity>(
      Expression<Func<TEntity, bool>> filter = null,
      Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
      string includeProperties = null)
      where TEntity : class;

    TEntity GetById<TEntity>(object id) where TEntity : class;

    Task<TEntity> GetByIdAsync<TEntity>(object id) where TEntity : class;

    int GetCount<TEntity>(Expression<Func<TEntity, bool>> filter = null) where TEntity : class;

    Task<int> GetCountAsync<TEntity>(Expression<Func<TEntity, bool>> filter = null) where TEntity : class;

    bool GetExists<TEntity>(Expression<Func<TEntity, bool>> filter = null) where TEntity : class;

    Task<bool> GetExistsAsync<TEntity>(Expression<Func<TEntity, bool>> filter = null) where TEntity : class;
  }
}
