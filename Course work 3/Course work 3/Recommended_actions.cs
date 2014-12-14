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
        public string id;
        [DataMember]
        public string name;
        [DataMember]
        public string price;
        [DataMember]
        public string Description;
        [DataMember]
        public string AccidentType_id;
        public RecommendedActions() : this("", "", "", "", "") { }
        public RecommendedActions(string name, string price, string Description, string AccidentType_id, string id) 
        {
            this.name = name;
            this.price = price;
            this.Description = Description;
            this.AccidentType_id = AccidentType_id;
            this.id = id;
        }
    }
}
