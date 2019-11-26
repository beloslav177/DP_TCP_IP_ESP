using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

/*
"ID": "5", 
"Meno": "Samo",
"Datum": "2019-03-02 13:31:52"
*/

namespace PHP
{
    public class JsonParser
    {
        public string ID { get; set; }
        public string meta_sap { get; set; }
        public string data_name { get; set; }
        public string place_room_sap { get; set; }
        public string place_locker { get; set; }
        public string place_shelve { get; set; }

        public static void DeserializeJSON(PhpJSON p, string strJSON)
        {
            try
            {
                //var jPerson = JsonConvert.DeserializeObject<dynamic>(strJSON);

                var jPerson = JsonConvert.DeserializeObject<JsonParser>(strJSON);
                //DeserializeOutput("JSON Object:" + jPerson.ToString());

                DeserializeOutput(p, "ID:" + jPerson.ID);
                DeserializeOutput(p, "meta_sap:" + jPerson.meta_sap);
                DeserializeOutput(p, "data_name:" + jPerson.data_name);
                DeserializeOutput(p, "place_room_sap:" + jPerson.place_room_sap);
                DeserializeOutput(p, "place_locker:" + jPerson.place_locker);
                DeserializeOutput(p, "place_shelve:" + jPerson.place_shelve);
            }
            catch (Exception ex)
            {
                DeserializeOutput(p, "Error:" + ex.Message.ToString());
            }
        }
        public static void DeserializeJsonList(PhpJSON p, string strJSON)
        {
            try
            {
                //var jPerson = JsonConvert.DeserializeObject<dynamic>(strJSON);
                //var jPerson = JsonConvert.DeserializeObject<JsonParser>(strJSON);

                var jPerson = JsonConvert.DeserializeObject<Udaje>(strJSON);
                //DeserializeOutput("JSON Object:" + jPerson.ToString());

                DeserializeOutput(p, "ID:" + jPerson.ID);
                DeserializeOutput(p, "meta_sap:" + jPerson.meta_sap);
                DeserializeOutput(p, "data_name:" + jPerson.data_name);
                DeserializeOutput(p, "place_room_sap:" + jPerson.place_room_sap);
                DeserializeOutput(p, "place_locker:" + jPerson.place_locker);
                DeserializeOutput(p, "place_shelve:" + jPerson.place_shelve);
            }
            catch (Exception ex)
            {
                DeserializeOutput(p, "Error:" + ex.Message.ToString());
            }
        }
        public static void DeserializeOutput(PhpJSON p, string strDeserializeText)
        {
            try
            {
                System.Diagnostics.Debug.Write(strDeserializeText + Environment.NewLine);
                p.txtOutput.Text = p.txtOutput.Text + strDeserializeText + Environment.NewLine;
                p.txtOutput.SelectionStart = p.txtOutput.TextLength;
                p.txtOutput.ScrollToCaret();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Write(ex.Message.ToString() + Environment.NewLine);
            }
        }
        public static void DeserializeInput(PhpJSON p, string strDeserializeText)
        {
            try
            {
                System.Diagnostics.Debug.Write(strDeserializeText + Environment.NewLine);
                p.txtInput.Text = p.txtInput.Text + strDeserializeText + Environment.NewLine;
                p.txtInput.SelectionStart = p.txtInput.TextLength;
                p.txtInput.ScrollToCaret();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Write(ex.Message.ToString() + Environment.NewLine);
            }
        }
    }
}
