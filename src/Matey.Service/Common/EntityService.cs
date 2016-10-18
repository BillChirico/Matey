using System;
using System.Collections.Generic;
using System.Linq;
using Matey.Domain.Models.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Matey.Service.Common
{
    public class EntityService<T> : IEntityService<T> where T : Entity
    {
        protected readonly DbSet<T> Dbset;
        protected DbContext Entities;

        /// <summary>
        ///     Entity Service.
        /// </summary>
        /// <param name="context">Context to use for entity access.</param>
        public EntityService(DbContext context)
        {
            Entities = context;
            Dbset = context.Set<T>();
        }

        /// <summary>
        ///     Add a new entity in the database.
        /// </summary>
        /// <param name="entity">Entity to add.</param>
        /// <returns>Added entity.</returns>
        public virtual EntityEntry<T> Create(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            var e = Dbset.Add(entity);
            Entities.SaveChanges();

            return e;
        }

        /// <summary>
        ///     Update an entity in the database.
        /// </summary>
        /// <param name="entity">Entity to update.</param>
        /// <returns>Updated entity.</returns>
        public virtual T Update(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            Entities.Entry(entity).State = EntityState.Modified;
            Entities.SaveChanges();

            return entity;
        }

        /// <summary>
        ///     Delete an entity from the database.
        /// </summary>
        /// <param name="entity">Entity to delete.</param>
        /// <returns>Deleted entity.</returns>
        public virtual EntityEntry<T> Delete(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            var e = Dbset.Remove(entity);
            Entities.SaveChanges();

            return e;
        }

        /// <summary>
        ///     Get an entity by its id.
        /// </summary>
        /// <param name="id">Id of the entity.</param>
        /// <returns>Entity with specified id or null or if does not exist.</returns>
        public virtual T GetById(int id)
        {
            return Dbset.FirstOrDefault(e => e.Id == id);
        }

        /// <summary>
        ///     Get all entities from the database.
        /// </summary>
        /// <returns>All entities from the database.</returns>
        public virtual IEnumerable<T> GetAll()
        {
            return Dbset.AsEnumerable();
        }
    }
}