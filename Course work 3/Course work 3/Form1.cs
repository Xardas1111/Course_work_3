﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Net;
using ConsoleApplication1;
using System.Diagnostics;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Course_work_3
{
    public partial class Form1 : Form
    {
        List<ExecutedAction> executedactionlist;
        List<RecommendedActions> recommendedactionlist;
        List<Country> countrylist;
        List<Region> regionlist;
        List<Settlement> settlementlist;
        List<OBject> objectlist;
        List<AccidentType> typelist;
        List<Stage> stagelist;
        public Form1()
        {
            InitializeComponent();
        }

        private void Discard_Click(object sender, EventArgs e)
        {
            
        }

        private void Check_Input(object sender, EventArgs e) 
        { 
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            executedactionlist = new List<ExecutedAction>();
            //Country.Items.Clear();
            //Type_of_accident.Items.Clear();
            //countrylist = new List<ConsoleApplication1.Country>();
            //Receiver<Country> country_receiver = new Receiver<ConsoleApplication1.Country>();
            //SendingRequest<Country> country_sender = new SendingRequest<Country>("get", "Country", new Country());
            //ServerUpp<Country, Country>(country_sender,ref country_receiver);
            //countrylist = country_receiver.data;
            //for (int i = 0; i < country_receiver.data.Count;i++ )
            //{
            //    Country.Items.Add(country_receiver.data[i].name);
            //}
            //Receiver<Region> Region_receiver = new Receiver<ConsoleApplication1.Region>();
            //SendingRequest<Region> Region_sender = new SendingRequest<Region>("get", "Region", new Region());
            //ServerUpp<Region, Region>(Region_sender, ref Region_receiver);
            //regionlist = Region_receiver.data;
            //Receiver<Settlement> Settlement_receiver = new Receiver<ConsoleApplication1.Settlement>();
            //SendingRequest<Settlement> Settlement_sender = new SendingRequest<Settlement>("get", "Settlement", new Settlement());
            //ServerUpp<Settlement, Settlement>(Settlement_sender, ref Settlement_receiver);
            //settlementlist = Settlement_receiver.data;
            //Receiver<OBject> object_receiver = new Receiver<ConsoleApplication1.OBject>();
            //SendingRequest<OBject> object_sender = new SendingRequest<OBject>("get", "Object", new OBject());
            //ServerUpp<OBject, OBject>(object_sender, ref object_receiver);
            //objectlist = object_receiver.data;
            //Receiver<AccidentType> AccidentType_receiver = new Receiver<ConsoleApplication1.AccidentType>();
            //SendingRequest<AccidentType> AccidentType_sender = new SendingRequest<AccidentType>("get", "AccidentType", new AccidentType());
            //ServerUpp<AccidentType, AccidentType>(AccidentType_sender, ref AccidentType_receiver);
            //typelist = AccidentType_receiver.data;
            //for (int i = 0; i < typelist.Count; i++) 
            //{
            //    Type_of_accident.Items.Add(typelist[i].name);
            //}
            //Receiver<Stage> Stage_receiver = new Receiver<Stage>();
            //SendingRequest<Stage> Stage_sender = new SendingRequest<Stage>("get", "Stage", new Stage());
            //ServerUpp<Stage, Stage>(Stage_sender, ref Stage_receiver);
            //stagelist = Stage_receiver.data;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            if ((Login.Text == "Admin" || Login.Text == "admin") && Pass.Text=="admin")
            {
                Login.Visible = false;
                Pass.Visible = false;
                LoginButton.Visible = false;
            }
        }

        private void Submit_Click(object sender, EventArgs e)
        {
            RegistrationForm form = new RegistrationForm();
            form.located_money = Budget.Text;
            form.Commentary = Description.Text;
            form.Date = Date.Value.Year + "-" + Date.Value.Month + "-" + Date.Value.Day + "T" + Date.Value.Hour + ":" + Date.Value.Minute + ":" + Date.Value.Second;
            string id = "";
            for (int i = 0; i < objectlist.Count; i++) 
            {
                if (Object.Text == objectlist[i].name) 
                {
                    id = objectlist[i].id;
                    break;
                }
            }
            form.Object_id = id;
            for (int i = 0; i < typelist.Count; i++)
            {
                if (Type_of_accident.Text == typelist[i].name)
                {
                    id = typelist[i].id;
                    break;
                }
            }
            form.Accident_Type_id = id;
            SendingRequest<RegistrationForm> request = new SendingRequest<RegistrationForm>("set", "RegistrationForm", form);
            Receiver<RegistrationForm> receiver = new Receiver<RegistrationForm>();
            ServerUpp<RegistrationForm, RegistrationForm>(request, ref receiver);
            for (int i = 0; i < executedactionlist.Count; i++) 
            { 
                
            }
                if (DialogResult.Yes == MessageBox.Show("Event Registered. Do you want to print a report?", "Result", MessageBoxButtons.YesNo))
                {

                }
        }

        private void Add_action_Click(object sender, EventArgs e)
        {
            ExecutedAction action = new ExecutedAction();
            action.Date = Executed_action_date.Value.Year + "-" + Executed_action_date.Value.Month + "-" + Executed_action_date.Value.Day + "T" + Executed_action_date.Value.Hour + ":" + Executed_action_date.Value.Minute + ":" + Executed_action_date.Value.Second;
            action.Description = Executed_action_text.Text;
            executedactionlist.Add(action);
            Executed_action_text.Text = "";
            MessageBox.Show("Added a new action!", "Result", MessageBoxButtons.OK);
        }
        private void Country_changed(object sender, EventArgs e)
        {
            Region.Text = "";
            Region.Items.Clear();
            string id = "";
            for (int i=0;i<countrylist.Count;i++)
            {
                if (Country.Text == countrylist[i].name)
                {
                    id = countrylist[i].id;
                    break;
                }
            }
            for (int i = 0; i < regionlist.Count; i++) 
            {
                if (id == regionlist[i].country) 
                {
                    Region.Items.Add(regionlist[i].name);
                }
            }
        }

        private void ServerUpp<T, K>(SendingRequest<T> sending_data,ref Receiver<K> receiving_data) 
        {

            MemoryStream m1 = new MemoryStream();
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(SendingRequest<T>));
            js.WriteObject(m1, sending_data);
            WebRequest request = WebRequest.Create("http://25.115.249.50:8080");
            request.Method = "POST";
            byte[] byteArray = m1.ToArray();
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = byteArray.Length;
            Stream dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();
            WebResponse response = request.GetResponse();
            dataStream = response.GetResponseStream();
            js = new DataContractJsonSerializer(typeof(Receiver<K>));
            receiving_data = (Receiver<K>)js.ReadObject(dataStream);
            dataStream.Close();
            response.Close();
        }
        private void Region_changed(object sender, EventArgs e)
        {
            Settlement.Items.Clear();
            string id = "";
            for (int i = 0; i < regionlist.Count; i++)
            {
                if (Region.Text == regionlist[i].name)
                {
                    id = regionlist[i].id;
                    break;
                }
            }
            for (int i = 0; i < settlementlist.Count; i++)
            {
                if (id == settlementlist[i].region)
                {
                    Settlement.Items.Add(settlementlist[i].name);
                }
            }
        }
        private void Settlement_changed(object sender, EventArgs e)
        {
            Object.Items.Clear();
            string id = "";
            for (int i = 0; i < settlementlist.Count; i++)
            {
                if (Settlement.Text == settlementlist[i].name)
                {
                    id = settlementlist[i].id;
                    break;
                }
            }
            for (int i = 0; i < objectlist.Count; i++)
            {
                if (id == objectlist[i].settlement)
                {
                    Object.Items.Add(objectlist[i].name);
                }
            }
        }

        private void PrintReport(RegistrationForm form,string country, string region, string settlement, string ect) 
        {
            var boldfont = FontFactory.GetFont(FontFactory.TIMES_BOLD, 14);
            var font = FontFactory.GetFont(FontFactory.TIMES_ROMAN, 12);
            var doc = new Document();
            PdfWriter.GetInstance(doc, new FileStream(@"D:\Document.pdf", FileMode.OpenOrCreate));
            doc.Open();
            doc.Add(new Phrase("Registered event №" +form.id+" :", boldfont));
            doc.Add(new Phrase("Country", font));
            doc.Close();
            Process.Start(@"D:\Document.pdf");
        }
    }
}