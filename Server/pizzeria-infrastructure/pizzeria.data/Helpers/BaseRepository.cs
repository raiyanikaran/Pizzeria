using System;
using System.Collections.Generic;
using System.Text;
using pizzeria.interfaces.Common;

namespace pizzeria.data.Helpers
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        public List<T> GetAll(string tableName)
        {
            return JsonHelper.GetAll<T>(tableName);
        }

        public T GetById(int id, string tableName)
        {
            return JsonHelper.GetDataById<T>(tableName, id);
        }

        public T Add(T obj, string tableName)
        {
            JsonHelper.Add(tableName, obj);
            return obj;

        }

        public T Update(T obj, string tableName)
        {
            //JsonHelper.Update(tableName, obj);
            return obj;
        }

        public bool DeleteEntity(int id, string tableName)
        {
            //JsonHelper.Update(tableName, obj, id);
            return true;
        }
    }
}
