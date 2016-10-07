using System.Collections.Generic;
using Matey.Domain.Models.Common;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Matey.Service.Common
{
    public interface IEntityService<T> where T : Entity
    {
        /// <summary>
        ///     Add a new entity in the database.
        /// </summary>
        /// <param name="entity">Entity to add.</param>
        /// <returns>Added entity.</returns>
        EntityEntry<T> Create(T entity);

        /// <summary>
        ///     Update an entity in the database.
        /// </summary>
        /// <param name="entity">Entity to update.</param>
        /// <returns>Updated entity.</returns>
        T Update(T entity);

        /// <summary>
        ///     Delete an entity from the database.
        /// </summary>
        /// <param name="entity">Entity to delete.</param>
        /// <returns>Deleted entity.</returns>
        EntityEntry<T> Delete(T entity);

        /// <summary>
        ///     Get an entity by its id.
        /// </summary>
        /// <param name="id">Id of the entity.</param>
        /// <returns>Entity with specified id or null or if does not exist.</returns>
        T GetById(int id);

        /// <summary>
        ///     Get all entities from the database.
        /// </summary>
        /// <returns>All entities from the database.</returns>
        IEnumerable<T> GetAll();
    }
}