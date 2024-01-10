using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyBuddy.Model
{
    public class Flashcard : Observer<Flashcard>
    {
        public int ID {  get; set; }
        public string Name { get; set; }
        public string rightAnswer {  get; set; }
        public int IDUnit {  get; set; }
        public int IDAnswer {  get; set; }
        public Flashcard() { 
            Name = string.Empty;
            rightAnswer = string.Empty;
        }
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
