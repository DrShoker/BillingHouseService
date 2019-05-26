using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BH.DAL.Entities.TypeConfigurations;
using BH.DTOL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BH.DAL.Repositories
{
    public class EntityFrameworkUnitOfWork : DbContext, IUnitOfWork
    {
        public IRepository Repository { get; }

        public EntityFrameworkUnitOfWork(DbContextOptions<EntityFrameworkUnitOfWork> options) : base(options)
        {
            //Database.EnsureCreated();
            this.Repository = new EntityFrameworkRepository<EntityFrameworkUnitOfWork>(this);
        }

        public virtual void Create<TEntity>(TEntity entity)
            where TEntity : class, IEntity
        {
            Set<TEntity>().Add(entity);
        }

        new public virtual void Update<TEntity>(TEntity entity)
            where TEntity : class, IEntity
        {
            Set<TEntity>().Attach(entity);
        }

        public virtual void Delete<TEntity>(object id)
            where TEntity : class, IEntity
        {
            TEntity entity = Set<TEntity>().Find(id);
            Delete(entity);
        }

        public virtual void Delete<TEntity>(TEntity entity)
            where TEntity : class, IEntity
        {
            var dbSet = Set<TEntity>();
            if (Entry(entity).State == EntityState.Detached)
            {
                dbSet.Attach(entity);
            }
            dbSet.Remove(entity);
        }

        public Task SaveAsync()
        {
            return SaveChangesAsync();
        }

        public void Save()
        {
            SaveChanges();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // Fluent API Using
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.ApplyConfiguration(new CompanyConfiguration());
            modelBuilder.ApplyConfiguration(new CompanyConstructionMaterialConfiguration());
            modelBuilder.ApplyConfiguration(new CompanyConstructionWorksConfiguration());
            modelBuilder.ApplyConfiguration(new CompanyConstructionWorksConstructionMaterialConfiguration());
            modelBuilder.ApplyConfiguration(new CompanyContactPhonesConfiguration());
            modelBuilder.ApplyConfiguration(new ConstructionMaterialConfiguration());
            modelBuilder.ApplyConfiguration(new ConstructionWorksConfiguration());
            modelBuilder.ApplyConfiguration(new ProjectSchemeConfiguration());
            modelBuilder.ApplyConfiguration(new SchemeConstructionWorksConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new UserFeedbackAboutCompanyConfiguration());
            modelBuilder.ApplyConfiguration(new UserProjectConfiguration());
            modelBuilder.ApplyConfiguration(new SchemeWallConfiguration());
        }
    }
}
