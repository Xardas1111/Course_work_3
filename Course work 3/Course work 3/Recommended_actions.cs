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
    public class RecommendedActions
    {
        [DataMember]
        public string name;
        [DataMember]
        public string price;
        [DataMember]
        public string Description;
        public RecommendedActions() 
        {
            name = "";
            price = "";
            Description = "";
        }
        public RecommendedActions(string name, string price, string Description) 
        {
            this.name = name;
            this.price = price;
            this.Description = Description;
        }
    }
}
