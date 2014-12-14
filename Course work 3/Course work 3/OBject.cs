using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace ConsoleApplication1
{
    [DataContract]
    public class OBject
    {
        [DataMember]
        public string name;
        public OBject() 
        {
            name = "";
        }
        public OBject(string name) 
        {
            this.name = name;
        }
    }
}
