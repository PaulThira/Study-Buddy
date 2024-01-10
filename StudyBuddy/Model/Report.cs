using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyBuddy.Model
{
    public class Report : Observer<Report>
    {
        public override void CreateNew()
        {
            throw new NotImplementedException();
        }

        public override void CreateObjectFromReader(SqlDataReader reader)
        {
            throw new NotImplementedException();
        }

        public override bool GetById(int objectId)
        {
            throw new NotImplementedException();
        }

        public override bool GetByName(string objectName)
        {
            throw new NotImplementedException();
        }

        public override void Update(string propertyName, object newValue)
        {
            throw new NotImplementedException();
        }
    }
}
