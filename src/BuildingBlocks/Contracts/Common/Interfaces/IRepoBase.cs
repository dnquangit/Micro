﻿using Contracts.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Linq.Expressions;

namespace Contracts.Common.Interfaces;

public interface IRepoQueryBase<T, K, TContex> where T : EntityBase<K> where TContex : DbContext
{

}

public interface IRepoQueryBase<T, K> where T : EntityBase<K>
{
    IQueryable<T> FindAll(bool trackChanges = false);

    IQueryable<T> FindAll(bool trackChanges = false, params Expression<Func<T, object>>[] includeProperties);

    IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges = false,
                  params Expression<Func<T, object>>[] includeProperties);
    IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges = false);

    Task<T?> GetByIdAsync(K id);

    Task<T?> GetByIdAsync(K id, params Expression<Func<T, object>>[] includeProperties);

}

public interface IRepoBase<T, K, TContext> : IRepoBase<T, K> where T : EntityBase<K> where TContext : DbContext
{

}

public interface IRepoBase<T, K> : IRepoQueryBase<T, K> where T : EntityBase<K>
{

    void Create(T entity);
    Task<K> CreateAsync(T entity);

    IList<K> CreateList(IEnumerable<T> entities);
    Task<IList<K>> CreateListAsync(IEnumerable<T> entities);

    void Update(T entity);
    Task UpdateAsync(T entity);

    void UpdateList(IEnumerable<T> entities);
    Task UpdateListAsync(IEnumerable<T> entities);

    void Delete(T entity);
    Task DeleteAsync(T entity);

    void DeleteList(IEnumerable<T> entities);
    Task DeleteListAsync(IEnumerable<T> entities);

    Task<int> SaveChangesAsync();

    Task<IDbContextTransaction> BeginTrasactionsAsync();

    Task EndTrasactionAsync();

    Task RollbackTrasactionAsync();

}