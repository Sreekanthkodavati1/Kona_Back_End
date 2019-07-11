using Core_DALInterface;
using PetaPoco;
using PetaPoco.Providers;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_DAL
{

    public class PostgresSqlRepository<T> : IRepository<T> where T : class
    {

        IDatabase db;
        public PostgresSqlRepository()
        {
            db = DatabaseConfiguration.Build().UsingConnectionString("Username = postgres; Password = password; Host = localhost; Port = 5432; Database = ProjectKona; ").UsingProvider(new PostgreSQLDatabaseProvider()).Create();
            db.OpenSharedConnection();
        }

        public async Task<List<T>> FetchAll()
        {
            try
            {
                //using (db)
                //{
                var list = await db.FetchAsync<T>();
                return list;
                //};
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<T> FetchById(int id)
        {
            try
            {
                //using (db)
                //{
                var list = await db.SingleOrDefaultAsync<T>(id);
                return list;
                //};
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public async Task<Tuple<int, bool>> Insert(T entity)
        {

            using (db)
            {
                try
                {
                    var records = await db.InsertAsync(entity);
                    return new Tuple<int, bool>(Convert.ToInt32(records), Convert.ToInt32(records) > 0);
                }
                catch (Exception ex)
                {

                    throw ex;
                }
                //db.Query<T>(sql);

            };
        }

        public async Task<bool> Delete(T entity, int id)
        {
            try {
                var records = await db.DeleteAsync<T>(id);
                return records > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
            
        }

        public async Task<bool> Save(T entity)
        {
            try
            {
                await db.SaveAsync(entity);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> Update(T entity)
        {
            try
            {
                var records = await db.UpdateAsync(entity);
                return records > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
