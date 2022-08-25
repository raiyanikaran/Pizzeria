using System;
using System.Collections.Generic;
using System.Text;

namespace pizzeria.interfaces.Common
{
    public interface IBaseRepository<T>
    {
        List<T> GetAll(string tableName);
        T GetById(int id, string tableName);
        T Add(T Object, string tableName);
        T Update(T Object, string tableName);
        bool DeleteEntity(int id, string tableName);
    }
}
