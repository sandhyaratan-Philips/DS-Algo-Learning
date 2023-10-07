using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenAddressing
{
    public class StudentRecord
    {
        private int Id;
        private string Name;

        public StudentRecord(int i,string name)
        {
            Id = i;
            Name = name;
        }
        public int getId() { return Id; }
        public void setId(int i) { Id=i; }
        public string toString() { return Id+" "+ Name; }
    }
}
