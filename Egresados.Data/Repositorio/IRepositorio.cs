using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Egresados.Data.Repositorio
{ 
    public partial interface IRepositorio<TEntity>
    {
        #region Methods

        /// <summary>
        /// Exist entity 
        /// </summary>
        /// <param name="predicate">Identifier</param>
        /// <returns>Entity</returns>
        Task<bool> Exists(Expression<Func<TEntity, bool>> predicate);

    /// <summary>
    /// Get entity by identifier
    /// </summary>
    /// <param name="id">Identifier</param>
    /// <returns>Entity</returns>
        TEntity GetOne(Expression<Func<TEntity, Boolean>> Filtro);

    /// <summary>
    /// Get entity by identifier
    /// </summary>
    /// <param name="id">Identifier</param>
    /// <returns>Entity</returns>
    TEntity GetOne(Expression<Func<TEntity, Boolean>> Filtro, String[] Includes);

    /// <summary>
    /// Insert entity
    /// </summary>
    /// <param name="entity">Entity</param>
    void Insert(TEntity entity);

    /// <summary>
    /// Insert entities
    /// </summary>
    /// <param name="entities">Entities</param>
    void Insert(IEnumerable<TEntity> entities);

    /// <summary>
    /// Update entity
    /// </summary>
    /// <param name="entity">Entity</param>
    void Update(TEntity entity);

    /// <summary>
    /// Update entities
    /// </summary>
    /// <param name="entities">Entities</param>
    void Update(IEnumerable<TEntity> entities);

    /// <summary>
    /// Delete entity
    /// </summary>
    /// <param name="entity">Entity</param>
    void Delete(TEntity entity);

    /// <summary>
    /// Delete entities
    /// </summary>
    /// <param name="entities">Entities</param>
    void Delete(IEnumerable<TEntity> entities);

    /// <summary>
    /// GetList entities
    /// </summary>
    /// <param name="entities">Entities</param>
    List<TEntity> GetList();

    /// <summary>
    /// GetList entities
    /// </summary>
    /// <param name="entities">Entities</param>
    List<TEntity> GetList(String[] Includes);

    /// <summary>
    /// GetList entities
    /// </summary>
    /// <param name="entities">Entities</param>
    List<TEntity> GetList(Expression<Func<TEntity, bool>> Filtro);

    /// <summary>
    /// GetList entities
    /// </summary>
    /// <param name="entities">Entities</param>
    List<TEntity> GetList(Expression<Func<TEntity, bool>> Filtro, String[] Includes);



    Task<TEntity> GetOneAync(Expression<Func<TEntity, Boolean>> Filtro);

    Task<TEntity> GetOneAync(Expression<Func<TEntity, Boolean>> Filtro, String[] Includes);

    Task<List<TEntity>> GetListAsync();

    Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> Filtro);

    Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> Filtro, String[] Includes);

    Task<TEntity> InsertAsync(TEntity entity);

    Task UpdateAsync(TEntity entity);

    Task DeleteAsync(TEntity entity);


    #endregion

    #region Properties

    /// <summary>
    /// Gets a table
    /// </summary>
    IQueryable<TEntity> Table { get; }

    /// <summary>
    /// Gets a table with "no tracking" enabled (EF feature) Use it only when you load record(s) only for read-only operations
    /// </summary>
    IQueryable<TEntity> TableNoTracking { get; }

    #endregion
}
}
