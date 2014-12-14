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
    public class Country
    {
        [DataMember]
        public string name;
        [DataMember]
        public List<Region> Regions;
        public Country() 
        {
            name = "";
            Regions = new List<Region>();
        }
        public Country(string name, List<Region> Regions) 
        {
            this.name = name;
            this.Regions = Regions;
        }
    }
}
