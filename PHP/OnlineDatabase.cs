using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Data;
using Newtonsoft.Json;
using System.Net;

namespace PHP
{
    public class OnlineDatabase
    {
        public MySqlConnection sqlConnection;
		public MySqlDataAdapter adapterRoomDb;
		public MySqlCommand command;
		public MySqlDataReader myReader;
		public DataTable dt = new DataTable();
		public DataSet ds = new DataSet();
		public List<DataTableRecords> data_source_records = null;
		public List<DataTableUsers> data_source_users = null;
		public List<DataTableNamespace> data_source_namespace = null;
		public string conString = "datasource=127.0.0.1;port=3306;username=dplight;password=123456;";
		

		public void ShowWebsiteRecords(PhpJSON php)
        {
            sqlConnection = new MySqlConnection(conString);
            string query = "SELECT* FROM majetok.kteem_record";

            using (MySqlConnection sqlCon = new MySqlConnection(conString))
            {
                command = new MySqlCommand(query, sqlConnection);
                try
                {
                    sqlConnection.Open();
                    php.txtInput.Text = string.Empty;
                    php.txtURL.Text = php.URLadresaAllRecord;
                    RestClient rClient = new RestClient();
                    rClient.endPoint = php.URLadresaAllRecord;

                    string strResponse = string.Empty;
                    strResponse = rClient.MakeRequest();
                    JsonParser.DeserializeInput(php, strResponse);
                }
                catch (MySqlException)
                {
                    MessageBox.Show("Žiadne data pre toto ID");
                }
            }
        }
		public void ShowServerRecords(PhpJSON php)
		{
			MySqlToListRecords(php);
			php.txtOutput.Text = string.Empty;
			foreach (DataTableRecords du in data_source_records)
			{
				php.txtOutput.Text += du.ID.ToString() + "\t" + du.meta_sap + "\t" + du.data_name + "\t" + du.place_room_sap + "\t" + du.place_locker + "\t" + du.place_shelve + Environment.NewLine;

			}
		}
		public void MySqlToListRecords(PhpJSON php)
		{
			string result;
			string server = "http://127.0.0.1/test/recordsTable.php";
			using (WebClient client = new WebClient())
			{
				result = client.DownloadString(new Uri(server));
			};
			data_source_records = null;
			data_source_records = JsonConvert.DeserializeObject<List<DataTableRecords>>(result);
			//php.dataGridView1.DataSource = data_source;
			php.localDatabase.ListRecordToSqlite(data_source_records);

			//php.dbz.VlozData(php.dataGridView1, php);
			//dbz.ViewSqliteToDb(this);
		}
		public void ShowWebsiteUsers(PhpJSON php)
		{
			sqlConnection = new MySqlConnection(conString);
			string query = "SELECT* FROM majetok.kteem_users";

			using (MySqlConnection sqlCon = new MySqlConnection(conString))
			{
				command = new MySqlCommand(query, sqlConnection);
				try
				{
					sqlConnection.Open();
					php.txtInput.Text = string.Empty;
					php.txtURL.Text = php.URLadresaAllUsers;
					RestClient rClient = new RestClient();
					rClient.endPoint = php.URLadresaAllUsers;

					string strResponse = string.Empty;
					strResponse = rClient.MakeRequest();
					JsonParser.DeserializeInput(php, strResponse);
				}
				catch (MySqlException)
				{
					MessageBox.Show("Žiadne data pre toto ID");
				}
			}
		}
		public void ShowServerUsers(PhpJSON php)
		{
			MySqlToListUsers(php);
			php.txtOutput.Text = string.Empty;
			foreach (DataTableUsers du in data_source_users)
			{
				php.txtOutput.Text += du.id.ToString() + "\t" + du.nickname + "\t" + du.InitializeKey + "\t" + Environment.NewLine;

			}
		}
		public void MySqlToListUsers(PhpJSON php)
		{
			string result;
			string server = "http://127.0.0.1/test/usersTable.php";
			using (WebClient client = new WebClient())
			{
				result = client.DownloadString(new Uri(server));
			};
			data_source_users = null;
			data_source_users = JsonConvert.DeserializeObject<List<DataTableUsers>>(result);
			//php.dataGridView1.DataSource = data_source;
			php.localDatabase.ListUsersToSqlite(data_source_users);

			//php.dbz.VlozData(php.dataGridView1, php);
			//dbz.ViewSqliteToDb(this);
		}
		public void ShowWebsiteNamespace(PhpJSON php)
		{
			sqlConnection = new MySqlConnection(conString);
			string query = "SELECT* FROM majetok.kteem_namespace";

			using (MySqlConnection sqlCon = new MySqlConnection(conString))
			{
				command = new MySqlCommand(query, sqlConnection);
				try
				{
					sqlConnection.Open();
					php.txtInput.Text = string.Empty;
					php.txtURL.Text = php.URLadresaAllNamespace;
					RestClient rClient = new RestClient();
					rClient.endPoint = php.URLadresaAllNamespace;

					string strResponse = string.Empty;
					strResponse = rClient.MakeRequest();
					JsonParser.DeserializeInput(php, strResponse);
				}
				catch (MySqlException)
				{
					MessageBox.Show("Žiadne data pre toto ID");
				}
			}
		}
		public void ShowServerNamespace(PhpJSON php)
		{
			MySqlToListNamespace(php);
			php.txtOutput.Text = string.Empty;
			foreach (DataTableNamespace du in data_source_namespace)
			{
				php.txtOutput.Text += du.id.ToString() + "\t" + du.original_room + "\t" + du.New + "\t" + Environment.NewLine;

			}
		}
		public void MySqlToListNamespace(PhpJSON php)
		{
			string result;
			string server = "http://127.0.0.1/test/namespaceTable.php";
			using (WebClient client = new WebClient())
			{
				result = client.DownloadString(new Uri(server));
			};
			data_source_namespace = null;
			data_source_namespace = JsonConvert.DeserializeObject<List<DataTableNamespace>>(result);
			//php.dataGridView1.DataSource = data_source;
			php.localDatabase.ListNamespaceToSqlite(data_source_namespace);

			//php.dbz.VlozData(php.dataGridView1, php);
			//dbz.ViewSqliteToDb(this);
		}
	}
}
