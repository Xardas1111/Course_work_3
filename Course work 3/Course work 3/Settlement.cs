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
    public class Settlement
    {
        [DataMember]
        public string name;
        [DataMember]
        public List<OBject> Objects;
        public Settlement(string name, List<OBject> Objects) 
        {
            this.name = name;
            this.Objects = Objects;
        }
        public Settlement() 
        {
            name = "";
            Objects = new List<OBject>();
        }
    }
}
