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
    public class Region
    {
        [DataMember]
        public string name;
        [DataMember]
        List<Settlement> Settlements;
        public Region(string name, List<Settlement> Settlements) 
        {
            this.name = name;
            this.Settlements = Settlements;
        }

        public Region() 
        {
            name = "";
            Settlements = new List<Settlement>();
        }
    }
}