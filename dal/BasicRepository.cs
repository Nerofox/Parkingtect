using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dal
{
    public class BasicRepository<T>
    {

        public List<T> FindAll()
        {
            return new List<T>();
        }

        public void Update(T obj)
        {

        }

        public void Create(T obj)
        {

        }

        public void Remove(int id)
        {

        }
    }
}
