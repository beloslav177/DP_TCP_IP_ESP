using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Diagnostics;
using System.Linq;

namespace PHP
{
	public class LocalDatabase
	{
		//public string dbFile = "D:\\4. INGleto\\Diplomka\\PHP-C#\\PHP\\PHP\\bin\\Debug\\majetok.db";
		public string dbFile = Application.StartupPath+@"\majetok.db";
		
		public SQLiteConnection con;
		public SQLiteCommand cmd;
		public SQLiteDataAdapter adapter;
		public SQLiteDataReader reader;

		public List<Record> zaznamyRecord;
		public List<User> zaznamyUser;
		public List<Namespace> zaznamyNamespace;

		public int ListRecordToSqlite(List<DataTableRecords> udaje)
		{
			string truncateTable = "DELETE FROM kteem_record";
			//MessageBox.Show(dbFile);
			try
			{
				con = new SQLiteConnection("Data Source=" + dbFile);
				con.Open();
				cmd = con.CreateCommand();
				cmd.CommandText = truncateTable;
				cmd.ExecuteNonQuery();
			string insertCmd = "INSERT INTO kteem_record (id, meta_prev, meta_book, meta_page, meta_kategoria, meta_kategoria_number, meta_sap, " +
				"main_kategoria, main_number, main_year_tuke, main_year_kteem, main_year_record, private, id_owner, id_owner_temp, " +
				"data_name, data_sort1, data_sort2, data_production_code, data_price_sk, data_price_eu, data_repair, data_discard, data_rfid, " +
				"place_room_sap, place_room, place_locker, place_shelve, borrowed, borrowed_date, dummy1, dummy2, dummy3, dummy4) VALUES";


			//string insertCmd = "INSERT INTO kteem_record (id, meta_prev, meta_book, meta_page, meta_kategoria, meta_kategoria_number, meta_sap," +
			//	" main_kategoria, main_number, main_year_tuke, main_year_kteem, main_year_record, private, id_owner, id_owner_temp, data_name, " +
			//	"data_sort1, data_sort2, data_production_code, data_price_sk, data_price_eu, place_room_sap, place_locker, place_shelve) VALUES";
			foreach (DataTableRecords udaj in udaje)
				{

				if (insertCmd != "INSERT INTO kteem_record (id, meta_prev, meta_book, meta_page, meta_kategoria, meta_kategoria_number, meta_sap, " +
				"main_kategoria, main_number, main_year_tuke, main_year_kteem, main_year_record, private, id_owner, id_owner_temp, " +
				"data_name, data_sort1, data_sort2, data_production_code, data_price_sk, data_price_eu, data_repair, data_discard, data_rfid, " +
				"place_room_sap, place_room, place_locker, place_shelve, borrowed, borrowed_date, dummy1, dummy2, dummy3, dummy4) VALUES") insertCmd += " ";

				insertCmd += "(" + udaj.ID + "," + "'" + udaj.meta_prev + "'" + "," + udaj.meta_book + "," + udaj.meta_page + "," + "'" + udaj.meta_kategoria + "'" + "," +
					udaj.meta_kategoria_number + "," + udaj.meta_sap + "," + "'" + udaj.main_kategoria + "'" + "," + udaj.main_number + "," + udaj.main_year_tuke + "," + udaj.main_year_kteem + "," +
					udaj.main_year_record + "," + "'" + udaj.Private + "'" + "," + "'" + udaj.id_owner + "'" + "," + udaj.id_owner_temp + "," + "'" + udaj.data_name + "'" + "," +
					"'" + udaj.data_sort1 + "'" + "," + "'" + udaj.data_sort2 + "'" + "," + "'" + udaj.data_production_code + "'" + "," + udaj.data_price_sk + "," +
					udaj.data_price_eu + "," + "'" + udaj.data_repair + "'" + "," + "'" + udaj.data_discard + "'" + "," + "'" + udaj.data_rfid + "'" + "," +
					"'" + udaj.place_room_sap + "'" + "," + "'" + udaj.place_room + "'" + "," + "'" + udaj.place_locker + "'" + "," + udaj.place_shelve + "," + udaj.borrowed + "," +  "'" + udaj.borrowed_date + "'" +"," +
					"'" + udaj.dummy1 + "'" + "," + "'" + udaj.dummy2 + "'" + "," + "'" + udaj.dummy3 + "'" + "," + "'" + udaj.dummy4 + "'" + ")" + ",";


				//if (insertCmd != "INSERT INTO kteem_record(id, meta_prev, meta_book, meta_page, meta_kategoria, meta_kategoria_number, meta_sap, main_kategoria," +
				//	" main_number, main_year_tuke, main_year_kteem, main_year_record, private, id_owner, id_owner_temp, data_name, data_sort1, data_sort2," +
				//	" data_production_code, data_price_sk, data_price_eu, place_room_sap, place_locker, place_shelve) VALUES") insertCmd += " ";
				//insertCmd += "(" + udaj.ID + "," + "'" + udaj.meta_prev + "'" + "," + udaj.meta_book + "," + udaj.meta_page + ","+ "'" + udaj.meta_kategoria + "'" +
				//	"," + udaj.meta_kategoria_number + "," + udaj.meta_sap + "," + "'" + udaj.main_kategoria + "'" + "," + udaj.main_number  +  "," + udaj.main_year_tuke + 
				//	"," + udaj.main_year_kteem + "," + udaj.main_year_record + "," + "'" + udaj.Private + "'" + "," + "'" + udaj.id_owner + "'" + "," + udaj.id_owner_temp + 
				//	"," + "'" + udaj.data_name + "'" + "," + "'" + udaj.data_sort1 + "'" + "," + "'" + udaj.data_sort2 + "'" + "," + "'" + udaj.data_production_code + "'" + ","  + udaj.data_price_sk  + udaj.data_price_eu  +  ","  +  "," + "'" + udaj.place_room_sap + "'" + "," + "'" + udaj.place_locker + "'" + "," + udaj.place_shelve + ")" + ",";

			}
			insertCmd = insertCmd.TrimEnd(',');
					cmd.CommandText = insertCmd;
					cmd.ExecuteNonQuery();
					con.Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
				Debug.WriteLine(ex.Message);
				Debug.WriteLine(ex.StackTrace);
			}
			return 0;
			
		}
		public void SqliteRecordToList(PhpJSON php)
		{
			zaznamyRecord = new List<Record>();
			string selectSqliteTable = "SELECT id, meta_prev, meta_book, meta_page, meta_kategoria, meta_kategoria_number, meta_sap, " +
				"main_kategoria, main_number, main_year_tuke, main_year_kteem, main_year_record, private, id_owner, id_owner_temp, " +
				"data_name, data_sort1, data_sort2, data_production_code, data_price_sk, data_price_eu, data_repair, data_discard, data_rfid, " +
				"place_room_sap, place_room, place_locker, place_shelve, borrowed, borrowed_date, dummy1, dummy2, dummy3, dummy4 FROM kteem_record";
			try
			{
				con = new SQLiteConnection("Data Source=" + dbFile);
				con.Open();
				cmd = con.CreateCommand();
				cmd.CommandText = selectSqliteTable;
				reader = cmd.ExecuteReader();
				while (reader.Read())
				{
					zaznamyRecord.Add(new Record() {	
												id = reader[0].ToString(),
												meta_prev = reader[1].ToString(),
												meta_book = reader[2].ToString(),
												meta_page = reader[3].ToString(),
												meta_kategoria = reader[4].ToString(),
												meta_kategoria_number = reader[5].ToString(),
												meta_sap = reader[6].ToString(),
												main_kategoria = reader[7].ToString(),
												main_number = reader[8].ToString(),
												main_year_tuke = reader[9].ToString(),
												main_year_kteem = reader[10].ToString(),
												main_year_record = reader[11].ToString(),
												Private = reader[12].ToString(),
												id_owner = reader[13].ToString(),
												id_owner_temp = reader[14].ToString(),
												data_name = reader[15].ToString(),
												data_sort1 = reader[16].ToString(),
												data_sort2 = reader[17].ToString(),
												data_production_code = reader[18].ToString(),
												data_price_sk = reader[19].ToString(),
												data_price_eu = reader[20].ToString(),
												data_repair = reader[21].ToString(),
												data_discard = reader[22].ToString(),
												data_rfid = reader[23].ToString(),
												place_room_sap = reader[24].ToString(),
												place_room = reader[25].ToString(),
												place_locker = reader[26].ToString(), 
												place_shelve = reader[27].ToString(), 
												borrowed = reader[28].ToString(),
												borrowed_date = reader[29].ToString(),
												dummy1 = reader[30].ToString(),
												dummy2 = reader[31].ToString(),
												dummy3 = reader[32].ToString(),
												dummy4 = reader[33].ToString()
											  });
				}
				reader.Close();
				cmd.ExecuteNonQuery();
				//List<Record> zaznamySelected = zaznamy.Where(x => ((x.place_room_sap=))).ToList();
				foreach (var zaznam in zaznamyRecord)
					{
					//php.dataGridView1.DataSource = zaznamyRecord;
					php.listBoxShow.DataSource = zaznamyRecord;
				}

				con.Close();
			}
			catch (Exception exc)
			{
				MessageBox.Show(exc.Message);
			}
		}
		public int ListUsersToSqlite(List<DataTableUsers> udaje)
		{
			string truncateTable = "DELETE FROM kteem_users";
			try
			{
				con = new SQLiteConnection("Data Source=" + dbFile);
				con.Open();
				cmd = con.CreateCommand();
				cmd.CommandText = truncateTable;
				cmd.ExecuteNonQuery();
				string insertCmd = "INSERT INTO kteem_users (id, nickname, InitializeKey) VALUES";

				foreach (DataTableUsers udaj in udaje)
				{

					if (insertCmd != "INSERT INTO kteem_users (id, nickname, InitializeKey) VALUES") insertCmd += " ";

					insertCmd += "(" + udaj.id + "," + "'" + udaj.nickname + "'" + "," + "'" + udaj.InitializeKey + "'" + ")" + ",";

				}
				insertCmd = insertCmd.TrimEnd(',');
				cmd.CommandText = insertCmd;
				cmd.ExecuteNonQuery();
				con.Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
				Debug.WriteLine(ex.Message);
				Debug.WriteLine(ex.StackTrace);
			}
			return 0;

		}
		public void SqliteUserToList(PhpJSON php)
		{
			zaznamyUser = new List<User>();
			string selectSqliteTable = "SELECT id, nickname, InitializeKey FROM kteem_users";
			try
			{
				con = new SQLiteConnection("Data Source=" + dbFile);
				con.Open();
				cmd = con.CreateCommand();
				cmd.CommandText = selectSqliteTable;
				reader = cmd.ExecuteReader();
				while (reader.Read())
				{
					zaznamyUser.Add(new User()
					{
						id = reader[0].ToString(),
						nickname = reader[1].ToString(),
						InitializeKey = reader[2].ToString()
					});
				}
				reader.Close();
				cmd.ExecuteNonQuery();
				//List<Record> zaznamySelected = zaznamy.Where(x => ((x.place_room_sap=))).ToList();
				foreach (var zaznam in zaznamyUser)
				{

					//php.dataGridView1.DataSource = zaznamyUser;
				}

				con.Close();
			}
			catch (Exception exc)
			{
				MessageBox.Show(exc.Message);
			}
		}

		public int ListNamespaceToSqlite(List<DataTableNamespace> udaje)
		{
			string truncateTable = "DELETE FROM kteem_namespace";
			try
			{
				con = new SQLiteConnection("Data Source=" + dbFile);
				con.Open();
				cmd = con.CreateCommand();
				cmd.CommandText = truncateTable;
				cmd.ExecuteNonQuery();
				string insertCmd = "INSERT INTO kteem_namespace (id, original_room, original_locker, original_shelve, new) VALUES";

				foreach (DataTableNamespace udaj in udaje)
				{

					if (insertCmd != "INSERT INTO kteem_namespace (id, original_room, original_locker, original_shelve, new) VALUES") insertCmd += " ";

					insertCmd += "(" + udaj.id + "," + "'" + udaj.original_room + "'" + "," + "'" + udaj.original_locker + "'" + "," + "'" + udaj.original_shelve + "'" + "," + "'" + udaj.New + "'" + ")" + ",";

				}
				insertCmd = insertCmd.TrimEnd(',');
				cmd.CommandText = insertCmd;
				cmd.ExecuteNonQuery();
				con.Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
				Debug.WriteLine(ex.Message);
				Debug.WriteLine(ex.StackTrace);
			}
			return 0;

		}
		public void SqliteNamespaceToList(PhpJSON php)
		{
			zaznamyNamespace = new List<Namespace>();
			string selectSqliteTable = "SELECT id, original_room, original_locker, original_shelve, new FROM kteem_namespace";
			try
			{
				con = new SQLiteConnection("Data Source=" + dbFile);
				con.Open();
				cmd = con.CreateCommand();
				cmd.CommandText = selectSqliteTable;
				reader = cmd.ExecuteReader();
				while (reader.Read())
				{
					zaznamyNamespace.Add(new Namespace()
					{
						id = reader[0].ToString(),
						original_room = reader[1].ToString(),
						original_locker = reader[2].ToString(),
						original_shelve = reader[3].ToString(),
						New = reader[4].ToString()
					});
				}
				reader.Close();
				cmd.ExecuteNonQuery();
				//List<Record> zaznamySelected = zaznamy.Where(x => ((x.place_room_sap=))).ToList();
				foreach (var zaznam in zaznamyNamespace)
				{

					//php.dataGridView1.DataSource = zaznamyNamespace;
				}

				con.Close();
			}
			catch (Exception exc)
			{
				MessageBox.Show(exc.Message);
			}
		}

		public int VlozData(DataGridView dataGridView, PhpJSON php)
		{
			try
			{
				using (var conn = new SQLiteConnection("Data Source=" + dbFile + ";Version=3"))
				{
					conn.Open();
					using (SQLiteCommand comm = new SQLiteCommand(conn))
					{
						for (int i = 0; i < php.dataGridView1.Rows.Count; i++)
						{
							string StrQuery = @"INSERT INTO kteem_records VALUES ("
														+ php.dataGridView1.Rows[i].Cells["id"] + ", "
														+ php.dataGridView1.Rows[i].Cells["meta_sap"] + ", "
														+ php.dataGridView1.Rows[i].Cells["data_name"].ToString() + ", "
														+ php.dataGridView1.Rows[i].Cells["place_room_sap"].ToString() + ", "
														+ php.dataGridView1.Rows[i].Cells["place_locker"].ToString() + ", "
														+ php.dataGridView1.Rows[i].Cells["place_shelve"] + ");";
							comm.CommandText = StrQuery;
							comm.ExecuteNonQuery();
						}
					}

					conn.Close();
				}
			}
			catch (Exception exc)
			{
				Debug.WriteLine(exc.Message);
				Debug.WriteLine(exc.StackTrace);
				MessageBox.Show(exc.Message);
			}
			return 0;
		}
		public void ViewSqliteToDb(PhpJSON php)
		{
			con = new SQLiteConnection("Data Source= " + dbFile);
			adapter = new SQLiteDataAdapter();
			string CommandText = "SELECT id, meta_sap, data_name, place_room_sap, place_locker, place_shelve FROM kteem_record";
			con.Open();
			cmd = con.CreateCommand();
			cmd.CommandText = CommandText;
			cmd.ExecuteNonQuery();
			//adapter = new SQLiteDataAdapter(CommandText, con);
			//using (dt = new DataTable())
			//{
			//	adapter.Fill(dt);
			//	php.dataGridView1.DataSource = dt;
			//}
			using (SQLiteDataReader read = cmd.ExecuteReader())
			{
				while (read.Read())
				{
					php.dataGridView1.Rows.Add(new object[] {
					read.GetValue(0),  // U can use column index
					read.GetValue(read.GetOrdinal("id")),  // Or column name like this
					read.GetValue(read.GetOrdinal("meta_sap")),
					read.GetValue(read.GetOrdinal("data_name")),
					read.GetValue(read.GetOrdinal("place_room_sap")),
					read.GetValue(read.GetOrdinal("place_shelve")),
					});
				}
			}
			con.Close();
		}
		public void roomSelect(PhpJSON php)
		{
			con = new SQLiteConnection("Data Source=" + dbFile);
			try
			{
				string lockerQuery = "SELECT DISTINCT place_room_sap FROM kteem_record";

				con.Open();
				cmd = con.CreateCommand();
				cmd.CommandText = lockerQuery;
				cmd.ExecuteNonQuery();
				php.cmbBoxRoom.Items.Add("");

				//cmd.Parameters.Add(new SQLiteParameter("@place_room_sap", php.cmbBoxRoom.Text));
				//cmd.Parameters.AddWithValue("@place_room_sap", php.cmbBoxRoom.Text.ToString());

				reader = cmd.ExecuteReader();

				while (reader.Read())
				{
					//string roomSelect = reader.GetString("place_room_sap");
					//php.cmbBoxRoom.Items.Add(roomSelect);
				}

				con.Close();

			}
			catch (Exception exc)
			{
				Debug.WriteLine(exc.Message);
				Debug.WriteLine(exc.StackTrace);
				MessageBox.Show(exc.Message);
			}
		}
		public void lockerSelect(PhpJSON php)
        {
            try
            {
                string lockerQuery = "SELECT DISTINCT place_locker FROM kteem_record";

                using (var conn = new SQLiteConnection(@"Data Source=majetok.db3;Version=3", true))
                {
               
                    using (cmd = new SQLiteCommand(lockerQuery, conn))
                    {
                        conn.Open();
                        php.cmbBoxLocker.Items.Add("");
                        reader = cmd.ExecuteReader();

                            while (reader.Read())
                            {
								//string lockerSelect = reader.GetString("place_locker");
                                //php.cmbBoxLocker.Items.Add(lockerSelect);
                            }
                       
                        conn.Close();

                    }
                //cmd = new SQLiteCommand(insertCmd, conn);
                //cmd.CommandText = insertCmd;
                //cmd.ExecuteNonQuery();
                }
            }
            catch (Exception exc)
            {
                Debug.WriteLine(exc.Message);
                Debug.WriteLine(exc.StackTrace);
                MessageBox.Show(exc.Message);
            }
        }

		public void shelveSelect(PhpJSON php)
		{
			try
			{
				string shelveQuery = "SELECT DISTINCT place_shelve FROM kteem_record";

				using (var conn = new SQLiteConnection(@"Data Source=majetok.db3;Version=3", true))
				{

					using (cmd = new SQLiteCommand(shelveQuery, conn))
					{
						conn.Open();
						php.cmbBoxShelve.Items.Add("");
						reader = cmd.ExecuteReader();

						while (reader.Read())
						{
							//string lockerSelect = reader.GetString("place_shelve");
							//php.cmbBoxShelve.Items.Add(lockerSelect);
						}

						conn.Close();

					}
					//cmd = new SQLiteCommand(insertCmd, conn);
					//cmd.CommandText = insertCmd;
					//cmd.ExecuteNonQuery();
				}
			}
			catch (Exception exc)
			{
				Debug.WriteLine(exc.Message);
				Debug.WriteLine(exc.StackTrace);
				MessageBox.Show(exc.Message);
			}
		}

		private void DatabaseConnection()
        {
            con = new SQLiteConnection("Data Source=D:\\4. ING letný semester\\Diplomka\\Sqlite\\SqliteStart\\kteem_record.db;Version=3");
            con.Open();
        }
        public void SqliteCon(string databasename)
        {
            con = new SQLiteConnection(string.Format("Data Source=D:\\4. ING letný semester\\Diplomka\\PHP-C#\\PHP\\kteem_record.db;Version=3; Compress=True", databasename));
        }
        public int Execute(string sql_statement)
        {
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandText = sql_statement;
            int row_updated;
            try
            {
                row_updated = cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                con.Close();
                return 0;
            }
            con.Close();
            return row_updated;
        }

		//private void ExecuteQuery(string txtQuery)
		//{
		//	SetConnection();
		//	sql_con.Open();
		//	sql_cmd = sql_con.CreateCommand();
		//	sql_cmd.CommandText = txtQuery;
		//	sql_cmd.ExecuteNonQuery();
		//	sql_con.Close();
		//}
		//public DataTable GetDataTable(string tablename)
		//{
		//    DataTable dt = new DataTable();
		//    con.Open();
		//    cmd = con.CreateCommand();
		//    cmd.CommandText = string.Format("SELECT * FROM kteem_record", tablename);
		//    adapter = new SQLiteDataAdapter(cmd);
		//    adapter.AcceptChangesDuringFill = false;
		//    adapter.Fill(dt);
		//    con.Close();
		//    dt.TableName = tablename;
		//    foreach (DataRow row in dt.Rows)
		//    {
		//        row.AcceptChanges();
		//    }
		//    return dt;
		//}
		//public void SaveDataTable(DataTable dt)
		//{
		//    try
		//    {
		//        //Execute(string.Format("DELETE * FROM {0}", dt.TableName));
		//        con.Open();
		//        cmd = con.CreateCommand();
		//        cmd.CommandText = string.Format("SELECT * FROM kteem_record", dt.TableName);
		//        adapter = new SQLiteDataAdapter(cmd);
		//        SQLiteCommandBuilder builder = new SQLiteCommandBuilder(adapter);
		//        adapter.Update(dt);
		//        con.Close();
		//    }
		//    catch (Exception ex)
		//    {
		//        MessageBox.Show("Error\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
		//    }
		//}
		//public void SerializingMySQL()
		//{
		//    try
		//    {
		//        connection.Open();

		//        string selectQuery = "SELECT * FROM majetok.kteem_record WHERE id=";
		//        command = new MySqlCommand(selectQuery, connection);

		//        mdr = command.ExecuteReader();

		//        if (mdr.Read())
		//        {
		//            data_source = null;

		//            var _json = txtInput.Text;
		//            data_source = JsonConvert.DeserializeObject<List<DataUser_Deserealize>>(_json);

		//            dataGridView1.DataSource = data_source;
		//            connection.Close();
		//        }
		//        else
		//        {
		//            MessageBox.Show("Žiadne data");
		//            connection.Close();
		//        }
		//    }
		//    catch (Exception)
		//    {
		//        MessageBox.Show("Error dat");
		//    }
		//}
		//public void SqliteConnection(PhpJSON php)
		//{
		//    try
		//    {
		//        con = new SQLiteConnection("Data Source=" + dbFile + ";Version=3");
		//        con.Open();
		//        SQLiteCommand cmd = new SQLiteCommand
		//        {
		//            Connection = con,
		//            CommandText = "Select * from pokus"
		//        };
		//        using (SQLiteDataReader sdr = cmd.ExecuteReader())
		//        {
		//            DataTable dt = new DataTable();
		//            dt.Load(sdr);
		//            sdr.Close();
		//            con.Close();
		//            php.dataGridView1.DataSource = dt;
		//        }
		//    }
		//    catch (Exception ex)
		//    {
		//        MessageBox.Show(ex.Message);
		//    }
		//}
	}
}
