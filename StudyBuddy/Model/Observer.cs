using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyBuddy.Model
{
    public abstract class Observer<T>
    {
       public  abstract bool  GetById(int objectId);
       public  abstract bool GetByName(string objectName);
      public abstract void CreateNew();
       public abstract void CreateObjectFromReader(SqlDataReader reader);


        public abstract void Update(string propertyName, object newValue);
        
    }
}
