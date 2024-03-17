﻿using System.Linq;
namespace UserManagement.Data;

public interface IDataContext
{
    IQueryable<TEntity> FilterByActive<TEntity>(bool isActive) where TEntity : class;

    /// <summary>
    /// Get a list of items
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <returns></returns>
    IQueryable<TEntity> GetAll<TEntity>() where TEntity : class;

    /// <summary>
    /// Create a new item
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <param name="entity"></param>
    /// <returns></returns>
    TEntity Create<TEntity>(TEntity entity) where TEntity : class;

    /// <summary>
    /// Uodate an existing item matching the ID
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <param name="entity"></param>
    /// <returns></returns>
    TEntity Update<TEntity>(TEntity entity) where TEntity : class;

    TEntity Delete<TEntity>(TEntity entity) where TEntity : class;

}
