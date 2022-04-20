// Decompiled with JetBrains decompiler
// Type: App.Infrastructure.GestionProcesos.EntityFrameworkRepository`1
// Assembly: App.Infrastructure, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7D12F3AE-788C-4496-85EF-A6E23743B789
// Assembly location: C:\Users\IROCHA\source\repos\Integridad\sintegridadweb\bin\App.Infrastructure.dll

using App.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace App.Infrastructure.GestionProcesos
{
  public class EntityFrameworkRepository<TContext> : IGestionProcesos where TContext : DbContext
  {
    protected readonly TContext context;

    public EntityFrameworkRepository(TContext context) => this.context = context;

    public virtual void Create<TEntity>(TEntity entity, string createdBy = null) where TEntity : class => this.context.Set<TEntity>().Add(entity);

    public virtual void Update<TEntity>(TEntity entity, string modifiedBy = null) where TEntity : class
    {
      this.context.Set<TEntity>().Attach(entity);
      this.context.Entry<TEntity>(entity).State = EntityState.Modified;
    }

    public virtual void Delete<TEntity>(object id) where TEntity : class => this.Delete<TEntity>(this.context.Set<TEntity>().Find(new object[1]
    {
      id
    }));

    public virtual void Delete<TEntity>(TEntity entity) where TEntity : class
    {
      DbSet<TEntity> dbSet = this.context.Set<TEntity>();
      if (this.context.Entry<TEntity>(entity).State == EntityState.Detached)
        dbSet.Attach(entity);
      dbSet.Remove(entity);
    }

    public virtual void Save()
    {
      try
      {
        this.context.SaveChanges();
      }
      catch (DbEntityValidationException ex)
      {
        this.ThrowEnhancedValidationException(ex);
      }
    }

    public virtual Task SaveAsync()
    {
      try
      {
        return (Task) this.context.SaveChangesAsync();
      }
      catch (DbEntityValidationException ex)
      {
        this.ThrowEnhancedValidationException(ex);
      }
      return (Task) Task.FromResult<int>(0);
    }

    protected virtual void ThrowEnhancedValidationException(DbEntityValidationException e)
    {
      string str = string.Join("; ", e.EntityValidationErrors.SelectMany<DbEntityValidationResult, DbValidationError>((Func<DbEntityValidationResult, IEnumerable<DbValidationError>>) (x => (IEnumerable<DbValidationError>) x.ValidationErrors)).Select<DbValidationError, string>((Func<DbValidationError, string>) (x => x.ErrorMessage)));
      throw new DbEntityValidationException(e.Message + " The validation errors are: " + str, e.EntityValidationErrors);
    }

    protected virtual IQueryable<TEntity> GetQueryable<TEntity>(
      Expression<Func<TEntity, bool>> filter = null,
      Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
      string includeProperties = null,
      int? skip = null,
      int? take = null)
      where TEntity : class
    {
      includeProperties = includeProperties ?? string.Empty;
      IQueryable<TEntity> source = (IQueryable<TEntity>) this.context.Set<TEntity>();
      if (filter != null)
        source = source.Where<TEntity>(filter);
      string str = includeProperties;
      char[] separator = new char[1]{ ',' };
      foreach (string path in str.Split(separator, StringSplitOptions.RemoveEmptyEntries))
        source = source.Include<TEntity>(path);
      if (orderBy != null)
        source = (IQueryable<TEntity>) orderBy(source);
      if (skip.HasValue)
        source = Queryable.Skip<TEntity>(source, skip.Value);
      if (take.HasValue)
        source = Queryable.Take<TEntity>(source, take.Value);
      return source;
    }

    public virtual IEnumerable<TEntity> GetAll<TEntity>(
      Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
      string includeProperties = null,
      int? skip = null,
      int? take = null)
      where TEntity : class
    {
      return (IEnumerable<TEntity>) this.GetQueryable<TEntity>(orderBy: orderBy, includeProperties: includeProperties, skip: skip, take: take).ToList<TEntity>();
    }

    public virtual async Task<IEnumerable<TEntity>> GetAllAsync<TEntity>(
      Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
      string includeProperties = null,
      int? skip = null,
      int? take = null)
      where TEntity : class
    {
      return (IEnumerable<TEntity>) await this.GetQueryable<TEntity>(orderBy: orderBy, includeProperties: includeProperties, skip: skip, take: take).ToListAsync<TEntity>();
    }

    public virtual IEnumerable<TEntity> Get<TEntity>(
      Expression<Func<TEntity, bool>> filter = null,
      Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
      string includeProperties = null,
      int? skip = null,
      int? take = null)
      where TEntity : class
    {
      return (IEnumerable<TEntity>) this.GetQueryable<TEntity>(filter, orderBy, includeProperties, skip, take).ToList<TEntity>();
    }

    public virtual async Task<IEnumerable<TEntity>> GetAsync<TEntity>(
      Expression<Func<TEntity, bool>> filter = null,
      Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
      string includeProperties = null,
      int? skip = null,
      int? take = null)
      where TEntity : class
    {
      return (IEnumerable<TEntity>) await this.GetQueryable<TEntity>(filter, orderBy, includeProperties, skip, take).ToListAsync<TEntity>();
    }

    public virtual TEntity GetOne<TEntity>(
      Expression<Func<TEntity, bool>> filter = null,
      string includeProperties = "")
      where TEntity : class
    {
      return Queryable.SingleOrDefault<TEntity>(this.GetQueryable<TEntity>(filter, includeProperties: includeProperties));
    }

    public virtual async Task<TEntity> GetOneAsync<TEntity>(
      Expression<Func<TEntity, bool>> filter = null,
      string includeProperties = null)
      where TEntity : class
    {
      return await this.GetQueryable<TEntity>(filter, includeProperties: includeProperties).SingleOrDefaultAsync<TEntity>();
    }

    public virtual TEntity GetFirst<TEntity>(
      Expression<Func<TEntity, bool>> filter = null,
      Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
      string includeProperties = "")
      where TEntity : class
    {
      return Queryable.FirstOrDefault<TEntity>(this.GetQueryable<TEntity>(filter, orderBy, includeProperties));
    }

    public virtual async Task<TEntity> GetFirstAsync<TEntity>(
      Expression<Func<TEntity, bool>> filter = null,
      Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
      string includeProperties = null)
      where TEntity : class
    {
      return await this.GetQueryable<TEntity>(filter, orderBy, includeProperties).FirstOrDefaultAsync<TEntity>();
    }

    public virtual TEntity GetById<TEntity>(object id) where TEntity : class => this.context.Set<TEntity>().Find(new object[1]
    {
      id
    });

    public virtual Task<TEntity> GetByIdAsync<TEntity>(object id) where TEntity : class => this.context.Set<TEntity>().FindAsync(id);

    public virtual int GetCount<TEntity>(Expression<Func<TEntity, bool>> filter = null) where TEntity : class => Queryable.Count<TEntity>(this.GetQueryable<TEntity>(filter));

    public virtual Task<int> GetCountAsync<TEntity>(Expression<Func<TEntity, bool>> filter = null) where TEntity : class => this.GetQueryable<TEntity>(filter).CountAsync<TEntity>();

    public virtual bool GetExists<TEntity>(Expression<Func<TEntity, bool>> filter = null) where TEntity : class => Queryable.Any<TEntity>(this.GetQueryable<TEntity>(filter));

    public virtual Task<bool> GetExistsAsync<TEntity>(Expression<Func<TEntity, bool>> filter = null) where TEntity : class => this.GetQueryable<TEntity>(filter).AnyAsync<TEntity>();
  }
}
