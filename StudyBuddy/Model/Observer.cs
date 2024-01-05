using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyBuddy.Model
{
    public interface Observer<T>
    {
        bool GetById(int objectId);
         bool GetByName(string objectName);
        void CreateNew();
       void CreateObjectFromReader(SqlDataReader reader);
        void Update(T obj);
        
    }
}
