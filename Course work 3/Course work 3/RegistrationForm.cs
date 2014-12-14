using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace ConsoleApplication1
{
    [DataContract]
    public struct ExecutedAction
    {
        [DataMember]
        public string Date;
        [DataMember]
        public string Description;
        public ExecutedAction(DateTime Date, string Description)
        {
            this.Description = Description;
            if (Date == null)
            {
                this.Date = "";
            }
            else
            {
                this.Date = "" + Date.Year + "-" + Date.Month + "-" + Date.Day + "T" + Date.Hour + ":" + Date.Minute + ":" + Date.Second;
            }
        }
    }
    [DataContract]
    public class RegistrationForm
    {
        [DataMember]
        public string Country;
        [DataMember]
        public string Region;
        [DataMember]
        public string Settlement;
        [DataMember]
        public string Object;
        [DataMember]
        public string Type;
        [DataMember]
        public string Budget;
        [DataMember]
        public string Date_of_accident;
        [DataMember]
        List<ExecutedAction> ActionList;
        public RegistrationForm() 
        {
            Country = "";
            Region = "";
            Settlement = "";
            Object = "";
            Type = "";
            Budget = "";
            this.Date_of_accident = "";
            ActionList = new List<ExecutedAction>();
        }
        public RegistrationForm(string Country, string Region, string Settlement, string Object, string Type, string Budget, string Date_of_accident, List<ExecutedAction> ActionList) 
        { 
            this.Country = Country;
            this.Region = Region;
            this.Settlement = Settlement;
            this.Object = Object;
            this.Type = Type;
            this.Budget = Budget;
            this.Date_of_accident = Date_of_accident;
            this.ActionList = ActionList;
        }
    }
}