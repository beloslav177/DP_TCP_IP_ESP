using System;
using System.Collections.Generic;
using PHP.Properties;
using System.Globalization;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Text;
using System.Net;

namespace PHP
{
	public class Record
	{
		public string id { get; set; }
		public string meta_prev { get; set; }
		public string meta_book { get; set; }
		public string meta_page { get; set; }
		public string meta_kategoria { get; set; }
		public string meta_kategoria_number { get; set; }
		public string meta_sap { get; set; }
		public string main_kategoria { get; set; }
		public string main_number { get; set; }
		public string main_year_tuke { get; set; }
		public string main_year_kteem { get; set; }
		public string main_year_record { get; set; }
		public string Private { get; set; }
		public string id_owner { get; set; }
		public string id_owner_temp { get; set; }
		public string data_name { get; set; }
		public string data_sort1 { get; set; }
		public string data_sort2 { get; set; }
		public string data_production_code { get; set; }
		public string data_price_sk { get; set; }
		public string data_price_eu { get; set; }
		public string data_repair { get; set; }
		public string data_discard { get; set; }
		public string data_rfid { get; set; }
		public string place_room_sap { get; set; }
		public string place_room { get; set; }
		public string place_locker { get; set; }
		public string place_shelve { get; set; }
		public string borrowed { get; set; }
		public string borrowed_date { get; set; }
		public string dummy1 { get; set; }
		public string dummy2 { get; set; }
		public string dummy3 { get; set; }
		public string dummy4 { get; set; }
		public override string ToString()
		{
			return  $"{id}\t" +
					$"{meta_book}\t" +
					$"{meta_page}\t" +
					$"{meta_kategoria}\t" +
					$"{meta_kategoria_number}\t" +
					$"{meta_sap}\t" +
					$"{main_kategoria}\t" +
					$"{main_number}\t" +
					$"{main_year_tuke}\t" +
					$"{main_year_kteem}\t" +
					$"{main_year_record}\t" +
					$"{Private}\t" +
					$"{id_owner}\t" +
					$"{id_owner_temp}\t" +
					$"{data_name}\t" +
					$"{data_sort1}\t" +
					$"{data_sort2}\t" +
					$"{data_production_code}\t" +
					$"{data_price_sk}\t" +
					$"{data_price_eu}\t" +
					$"{data_repair}\t" +
					$"{data_discard}\t" +
					$"{data_rfid}\t" +
					$"{place_room_sap}\t" +
					$"{place_room}\t" +
					$"{place_locker}\t" +
					$"{place_shelve}\t" +
					$"{borrowed}\t" +
					$"{borrowed_date}\t" +
					$"{dummy1}\t" +
					$"{dummy2}\t" +
					$"{dummy3}\t" +
					$" {dummy4}";
		}
	}

    public class Udaje
    {
        public string ID { get; set; }
        public string meta_sap { get; set; }
        public string data_name { get; set; }
        public string place_room_sap { get; set; }
        public string place_locker { get; set; }
        public int place_shelve { get; set; }
        

        internal bool Insert<TType>(TType item)
        {
            throw new NotImplementedException();
        }
    }
  
    public class DataTableRecords
    {
        [JsonProperty("ID")] 
        public int ID { get; set; }

		[JsonProperty("meta_prev")]
		public string meta_prev { get; set; }

		[JsonProperty("meta_book")]
		public int meta_book { get; set; }

		[JsonProperty("meta_page")]
		public int meta_page { get; set; }

		[JsonProperty("meta_kategoria")]
		public string meta_kategoria { get; set; }

		[JsonProperty("meta_kategoria_number")]
		public int meta_kategoria_number { get; set; }

		[JsonProperty("met_sap")]
        public int meta_sap { get; set; }														

		[JsonProperty("main_kategoria")]
		public string main_kategoria { get; set; }	
  
		[JsonProperty("main_number")]
		public int main_number { get; set; }

		[JsonProperty("main_year_tuke")]
		public int main_year_tuke { get; set; }

		[JsonProperty("main_year_kteem")]
		public int main_year_kteem { get; set; }

		[JsonProperty("main_year_record")]
		public int main_year_record { get; set; }

		[JsonProperty("private")]
		public string Private { get; set; }

		[JsonProperty("id_owner")]
		public string id_owner { get; set; }

		[JsonProperty("id_owner_temp")]
		public int id_owner_temp { get; set; }

		[JsonProperty("data_name")]
        public string data_name { get; set; }

		[JsonProperty("data_sort1")]
		public string data_sort1 { get; set; }

		[JsonProperty("data_sort2")]
		public string data_sort2 { get; set; }

		[JsonProperty("data_production_code")]
		public string data_production_code { get; set; }

		[JsonProperty("data_price_sk")]
		public float data_price_sk { get; set; }

		[JsonProperty("data_price_eu")]
		public float data_price_eu { get; set; }

		[JsonProperty("data_repair")]
		public string data_repair { get; set; }

		[JsonProperty("data_discard")]
		public string data_discard { get; set; }

		[JsonProperty("data_rfid")]
		public string data_rfid { get; set; }

		[JsonProperty("place_room_sap")]
        public string place_room_sap { get; set; }

		[JsonProperty("place_room")]
		public string place_room { get; set; }

		[JsonProperty("place_locker")]
        public string place_locker { get; set; }
		
        [JsonProperty("place_shelve")]
        public int place_shelve { get; set; }

		[JsonProperty("borrowed")]
		public int borrowed { get; set; }

		[JsonProperty("borrowed_date")]
		public DateTime? borrowed_date { get; set; }

		[JsonProperty("dummy1")]
		public string dummy1 { get; set; }

		[JsonProperty("dummy2")]
		public string dummy2 { get; set; }

		[JsonProperty("dummy3")]
		public string dummy3 { get; set; }

		[JsonProperty("dummy4")]
		public string dummy4 { get; set; }
	}
	public class DataTableUsers
	{
		[JsonProperty("id")]
		public int id { get; set; }

		[JsonProperty("nickname")]
		public string nickname { get; set; }

		[JsonProperty("access")]
		public int access { get; set; }

		[JsonProperty("Name")]
		public string Name { get; set; }

		[JsonProperty("Surname")]
		public string Surname { get; set; }

		[JsonProperty("InitializeKey")]
		public string InitializeKey { get; set; }

	}
	public class User
	{
		public string id { get; set; }
		public string nickname { get; set; }
		public string access { get; set; }
		public string Name { get; set; }
		public string Surname { get; set; }
		public string InitializeKey { get; set; }
	}

	public class DataTableNamespace
	{
		[JsonProperty("id")]
		public int id { get; set; }

		[JsonProperty("original_room")]
		public string original_room { get; set; }

		[JsonProperty("original_locker")]
		public string original_locker { get; set; }

		[JsonProperty("original_shelve")]
		public string original_shelve { get; set; }

		[JsonProperty("new")]
		public string New { get; set; }

	}
	public class Namespace
	{
		public string id { get; set; }
		public string original_room { get; set; }
		public string original_locker { get; set; }
		public string original_shelve { get; set; }
		public string New { get; set; }
	}

	public class DataUser
    {

        public DataTableRecords[] DataUser_Deserealizes { get; set; }
    }
   
    //public class InfoDatabase
    //{
    //    readonly SQLiteAsyncConnection database;
    //    public InfoDatabase(string dbPath)
    //    {
    //        database = new SQLiteAsyncConnection(dbPath);
    //        database.CreateTableAsync<DataUser_Deserealize>();
    //    }
    //    public Task<List<DataUser_Deserealize>> Get
    //}

    //private async Task<string> InsertRecords<TType>(HttpResponseMessage response)
    //{
    //    try
    //    {
    //        Udaje u = new Udaje();
    //        string responseString = await response.Content.ReadAsStringAsync();
    //        var responseBody = JsonConvert.DeserializeObject<List<TType>>(responseString);
    //        foreach (TType item in responseBody)
    //        {
    //            bool resultInser = u.Insert(item);
    //        }
    //        return ResponseToMessage(response, "Insert Records");
    //    }
    //    catch (Exception ex)
    //    {
    //        Log.Info("DeserializeObject", ex.Message);
    //        throw;
    //    }
    //}


}
