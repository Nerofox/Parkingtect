using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dal
{
    public class BasicRepository<T> where T : class
    {

        private Context ctx;
        private DbSet<T> dbSet;

        public BasicRepository(Context ctx = null)
        {
            this.ctx = ctx;
            if (ctx == null)
            {
                this.ctx = new Context();
            }

            this.dbSet = this.ctx.Set<T>();
        }

        public BasicRepository<U> CreateRepository<U>() where U : class
        {
            return new BasicRepository<U>(this.ctx);
        }

        public T Find(int id)
        {
            return this.dbSet.Find(id);
        }

        public List<T> FindAll()
        {
            return this.dbSet.ToList();
        }

        public virtual void Update(T obj)
        {
            this.ctx.Entry(obj).State = EntityState.Modified;
            this.Save();
        }

        public void Create(T obj)
        {
            this.dbSet.Add(obj);
            this.Save();
        }

        public void Remove(T obj)
        {
            this.dbSet.Remove(obj);
            this.Save();
        }

        protected void Save()
        {
            try
            {
                this.ctx.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        protected virtual void Dispose()
        {
            this.ctx.Dispose();
        }
    }
}
