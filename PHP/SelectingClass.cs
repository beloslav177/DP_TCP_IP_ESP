using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Data.SQLite;

namespace PHP
{
	public class SelectingClass
	{
		public List<string> miestnosti;
		public List<Record> SelectRoom = new List<Record>();
		public List<Record> SelectLocker = new List<Record>();
		public List<Record> SelectShelve = new List<Record>();
		private string roomSap;
		private string lockerSap;
		private string shelveSap;

		public void SelectDataMysql(PhpJSON php)
        {
            php.selecting.roomSelectMysql(php);
            php.selecting.lockerSelectMysql(php);
            php.selecting.shelveSelectMysql(php);
			
        }
		public void SelectDataSqliteCombobox(PhpJSON php)
		{
			SelectDistinctRoom(php);
			SelectDistinctLocker(php);
			SelectDistinctShelve(php);
		}

		public void SelectRoomToCombo(PhpJSON php)
		{
			try
			{

				Dictionary<string, string> miestnostiDic = new Dictionary<string, string>();
				foreach (var item in php.localDatabase.zaznamyNamespace)
				{
					miestnostiDic.Add(item.New, item.original_room);
					//php.cmbBoxRoom.Items.Add(item.New);
				}

				List<string> miestnosti = php.localDatabase.zaznamyNamespace.Select(x => x.New).ToList();
				miestnosti.Sort();
				php.cmbBoxRoom.Items.AddRange(miestnosti.ToArray());

				List<string> skrine = php.localDatabase.zaznamyRecord.Select(x => x.place_locker).Distinct().ToList();
				skrine.Sort();
				php.cmbBoxLocker.Items.AddRange(skrine.ToArray());

				List<string> policky = php.localDatabase.zaznamyRecord.Select(x => x.place_shelve).Distinct().ToList();
				policky.Sort();
				php.cmbBoxShelve.Items.AddRange(policky.ToArray());

				//php.cmbBoxLocker.Items.AddRange(php.localDatabase.zaznamyRecord.Select(x => x.place_locker).Distinct().ToArray());
				//php.cmbBoxShelve.Items.AddRange(php.localDatabase.zaznamyRecord.Select(x => x.place_shelve).Distinct().ToArray());
				
				//List<string> zaznamySelected = php.localDatabase.zaznamyRecord.Where(x =>
				//	(x.place_room_sap = php.cmbBoxRoom.Text) &&
				//	(x.place_locker = php.cmbBoxLocker.Text) &&
				//	(x.place_shelve = php.cmbBoxShelve.Text)).ToList();

			}
			catch (Exception exc)
			{
				MessageBox.Show(exc.Message);
			}
		}
		public void showRooms(PhpJSON php)
		{
			try
			{
				string roomSap = php.localDatabase.zaznamyNamespace.Find(x => x.New == php.cmbBoxRoom.Text).original_room;
				php.txtRoom.Text = roomSap.ToString();
				SelectRoom = php.localDatabase.zaznamyRecord.Where(x =>
					(x.place_room_sap == roomSap)).ToList();
				//TODO:osetritstavnull alebonepsrad

				string nullExpresion = php.localDatabase.zaznamyRecord.Where(x => x.place_room_sap.Count() == null).ToString(); 
				foreach (var item in SelectRoom)
				{
					if (php.localDatabase.zaznamyNamespace.Where(x => x.New) != php.cmbBoxRoom.Text)
					{
						MessageBox.Show("Daná požiadavka sa nenachádza v tabuľke.");
						php.dataGridView1.DataSource = string.Empty;
					}
					else
					{

					}
					php.dataGridView1.DataSource = SelectRoom;
				}

			}
			catch (Exception exc)
			{

				MessageBox.Show(exc.Message);
			}
			
		}
		public void showLockers(PhpJSON php)
		{
			try
			{
				SelectLocker = SelectRoom.Where(x =>
						(x.place_locker == php.cmbBoxLocker.Text)).ToList();
				foreach (var item in SelectLocker)
				{
					php.dataGridView1.DataSource = SelectLocker;
				}

			}
			catch (Exception exc)
			{

				MessageBox.Show(exc.Message);
			}
		}
		public void showShelves(PhpJSON php)
		{
			try
			{
				SelectShelve = SelectLocker.Where(x =>
						(x.place_shelve == php.cmbBoxShelve.Text)).ToList();
				foreach (var item in SelectShelve)
				{
					php.dataGridView1.DataSource = SelectShelve;
				}

			}
			catch (Exception exc)
			{

				MessageBox.Show(exc.Message);
			}
		}

		public void cmbBoxEnabled(PhpJSON php)
		{
			if (php.cmbBoxRoom.Text == null)
			{
				php.cmbBoxLocker.Enabled = false;
				php.cmbBoxShelve.Enabled = false;
			}
			else
			{
				php.cmbBoxLocker.Enabled = true;
				php.cmbBoxShelve.Enabled = true;
			}
		}

		public void SelectLockerToCombo(PhpJSON php)
		{
			try
			{
				php.cmbBoxLocker.Items.AddRange(php.localDatabase.zaznamyRecord.Select(x => x.place_locker).Distinct().ToArray());

			}
			catch (Exception exc)
			{
				MessageBox.Show(exc.Message);
			}
		}

		public void SelectShelveToCombo(PhpJSON php)
		{
			try
			{
				php.cmbBoxShelve.Items.AddRange(php.localDatabase.zaznamyRecord.Select(x => x.place_shelve).Distinct().ToArray());

			}
			catch (Exception exc)
			{
				MessageBox.Show(exc.Message);
			}
		}
		public void cmbIndexChanged(PhpJSON php)
        {
            string shelveAll = "SELECT id, meta_sap, data_name, place_room_sap, place_locker, place_shelve FROM majetok.kteem_record WHERE place_shelve='" + php.cmbBoxShelve.Text + "' AND place_room_sap= '" + php.cmbBoxRoom.Text + "' AND place_locker='" + php.cmbBoxLocker.Text + "'";
            php.onDatabase.adapterRoomDb = new MySqlDataAdapter(shelveAll, php.onDatabase.sqlConnection);
            php.onDatabase.adapterRoomDb.Fill(php.onDatabase.ds, "kteem_record");
            php.dataGridView1.DataSource = php.onDatabase.ds;
            php.dataGridView1.DataMember = "kteem_record";
        }
		public void SelectDistinctRoom(PhpJSON php)
		{
			List<Record> roomZaznam = new List<Record>();
			string selectRoom = "SELECT DISTINCT place_room_sap FROM kteem_record";
			try
			{
				php.localDatabase.con = new SQLiteConnection("Data Source=" + php.localDatabase.dbFile);
				php.localDatabase.con.Open();
				php.localDatabase.cmd = php.localDatabase.con.CreateCommand();
				php.localDatabase.cmd.CommandText = selectRoom;
				php.localDatabase.reader = php.localDatabase.cmd.ExecuteReader();
				php.cmbBoxRoom.Items.Add(" ");


				while (php.localDatabase.reader.Read())
				{

					roomZaznam.Add(new Record()
					{
						place_room_sap = php.localDatabase.reader[0].ToString()
					});
					php.cmbBoxRoom.Items.Add(php.localDatabase.reader[0]);
				}
				php.localDatabase.reader.Close();
				php.localDatabase.cmd.ExecuteNonQuery();
				php.localDatabase.con.Close();
			}
			catch (Exception exc)
			{
				MessageBox.Show(exc.Message);
			}
		}
		public void SelectDistinctLocker(PhpJSON php)
		{
			List<Record> lockerZaznam = new List<Record>();
			string selectRoom = "SELECT DISTINCT place_locker FROM kteem_record";
			try
			{
				php.localDatabase.con = new SQLiteConnection("Data Source=" + php.localDatabase.dbFile);
				php.localDatabase.con.Open();
				php.localDatabase.cmd = php.localDatabase.con.CreateCommand();
				php.localDatabase.cmd.CommandText = selectRoom;
				php.localDatabase.reader = php.localDatabase.cmd.ExecuteReader();
				php.cmbBoxLocker.Items.Add(" ");

				while (php.localDatabase.reader.Read())
				{

					lockerZaznam.Add(new Record()
					{
						place_locker = php.localDatabase.reader[0].ToString()
					});
					php.cmbBoxLocker.Items.Add(php.localDatabase.reader[0]);
				}
				php.localDatabase.reader.Close();
				php.localDatabase.cmd.ExecuteNonQuery();
				php.localDatabase.con.Close();
			}
			catch (Exception exc)
			{
				MessageBox.Show(exc.Message);
			}
		}
		public void SelectDistinctShelve(PhpJSON php)
		{
			List<Record> shelveZaznam = new List<Record>();
			string selectShelve = "SELECT DISTINCT place_shelve FROM kteem_record";
			try
			{
				php.localDatabase.con = new SQLiteConnection("Data Source=" + php.localDatabase.dbFile);
				php.localDatabase.con.Open();
				php.localDatabase.cmd = php.localDatabase.con.CreateCommand();
				php.localDatabase.cmd.CommandText = selectShelve;
				php.localDatabase.reader = php.localDatabase.cmd.ExecuteReader();
				php.cmbBoxShelve.Items.Add(" ");

				while (php.localDatabase.reader.Read())
				{

					shelveZaznam.Add(new Record()
					{
						place_shelve = php.localDatabase.reader[0].ToString()
					});
					php.cmbBoxShelve.Items.Add(php.localDatabase.reader[0]);
				}
				php.localDatabase.reader.Close();
				php.localDatabase.cmd.ExecuteNonQuery();
				php.localDatabase.con.Close();
			}
			catch (Exception exc)
			{
				MessageBox.Show(exc.Message);
			}
		}
		public void comboBoxShowData(PhpJSON php)
		{
			List<Record> shelveAllZoznam = new List<Record>();
			string shelveAll = "SELECT id, meta_prev, meta_book, meta_page, meta_kategoria, meta_kategoria_number, meta_sap, " +
				"main_kategoria, main_number, main_year_tuke, main_year_kteem, main_year_record, private, id_owner, id_owner_temp, " +
				"data_name, data_sort1, data_sort2, data_production_code, data_price_sk, data_price_eu, data_repair, data_discard, data_rfid, " +
				"place_room_sap, place_room, place_locker, place_shelve, borrowed, borrowed_date, dummy1, dummy2, dummy3, dummy4 FROM kteem_record " +
				"WHERE place_shelve='" + php.cmbBoxShelve.Text +
								"' AND place_room_sap= '" + php.cmbBoxRoom.Text +
								"' AND place_locker='" + php.cmbBoxLocker.Text + "'";
			try
			{
				php.localDatabase.con = new SQLiteConnection("Data Source=" + php.localDatabase.dbFile);
				php.localDatabase.con.Open();
				php.localDatabase.cmd = php.localDatabase.con.CreateCommand();
				php.localDatabase.cmd.CommandText = shelveAll;
				php.localDatabase.reader = php.localDatabase.cmd.ExecuteReader();

				while (php.localDatabase.reader.Read())
				{
					shelveAllZoznam.Add(new Record()
					{
						id = php.localDatabase.reader[0].ToString(),
						meta_prev = php.localDatabase.reader[1].ToString(),
						meta_book = php.localDatabase.reader[2].ToString(),
						meta_page = php.localDatabase.reader[3].ToString(),
						meta_kategoria = php.localDatabase.reader[4].ToString(),
						meta_kategoria_number = php.localDatabase.reader[5].ToString(),
						meta_sap = php.localDatabase.reader[6].ToString(),
						main_kategoria = php.localDatabase.reader[7].ToString(),
						main_number = php.localDatabase.reader[8].ToString(),
						main_year_tuke = php.localDatabase.reader[9].ToString(),
						main_year_kteem = php.localDatabase.reader[10].ToString(),
						main_year_record = php.localDatabase.reader[11].ToString(),
						Private = php.localDatabase.reader[12].ToString(),
						id_owner = php.localDatabase.reader[13].ToString(),
						id_owner_temp = php.localDatabase.reader[14].ToString(),
						data_name = php.localDatabase.reader[15].ToString(),
						data_sort1 = php.localDatabase.reader[16].ToString(),
						data_sort2 = php.localDatabase.reader[17].ToString(),
						data_production_code = php.localDatabase.reader[18].ToString(),
						data_price_sk = php.localDatabase.reader[19].ToString(),
						data_price_eu = php.localDatabase.reader[20].ToString(),
						data_repair = php.localDatabase.reader[21].ToString(),
						data_discard = php.localDatabase.reader[22].ToString(),
						data_rfid = php.localDatabase.reader[23].ToString(),
						place_room_sap = php.localDatabase.reader[24].ToString(),
						place_room = php.localDatabase.reader[25].ToString(),
						place_locker = php.localDatabase.reader[26].ToString(),
						place_shelve = php.localDatabase.reader[27].ToString(),
						borrowed = php.localDatabase.reader[28].ToString(),
						borrowed_date = php.localDatabase.reader[29].ToString(),
						dummy1 = php.localDatabase.reader[30].ToString(),
						dummy2 = php.localDatabase.reader[31].ToString(),
						dummy3 = php.localDatabase.reader[32].ToString(),
						dummy4 = php.localDatabase.reader[33].ToString()
					});
				}
				php.localDatabase.reader.Close();
				php.localDatabase.cmd.ExecuteNonQuery();
				php.localDatabase.con.Close();
				List<Record> zaznamySelected = shelveAllZoznam.Where(x => ((x.place_room_sap == "L") && (x.place_locker == "1") && (x.place_locker == "1"))).ToList();
				foreach (var zaznam in shelveAllZoznam)
				{
					
					php.dataGridView1.DataSource = shelveAllZoznam;
				}

				php.localDatabase.con.Close();
			}
			catch (Exception exc)
			{
				MessageBox.Show(exc.Message);
			}
		}
		public void roomSelectMysql(PhpJSON php)
		{
			string roomQuery = "SELECT DISTINCT place_room_sap FROM majetok.kteem_record";
			php.onDatabase.sqlConnection = new MySqlConnection(php.onDatabase.conString);
			php.onDatabase.command = new MySqlCommand(roomQuery, php.onDatabase.sqlConnection);

			php.cmbBoxRoom.Items.Add("");

			try
			{
				php.onDatabase.sqlConnection.Open();
				php.onDatabase.myReader = php.onDatabase.command.ExecuteReader();

				while (php.onDatabase.myReader.Read())
				{
					string roomSelect = php.onDatabase.myReader.GetString("place_room_sap");
					php.cmbBoxRoom.Items.Add(roomSelect);
				}
			}
			catch (Exception ex)
			{

				MessageBox.Show(ex.Message);
			}

		}
		public void lockerSelectMysql(PhpJSON php)
		{
			string lockerQuery = "SELECT DISTINCT place_locker FROM majetok.kteem_record";
			php.onDatabase.sqlConnection = new MySqlConnection(php.onDatabase.conString);
			php.onDatabase.command = new MySqlCommand(lockerQuery, php.onDatabase.sqlConnection);

			php.cmbBoxLocker.Items.Add("");

			try
			{
				php.onDatabase.sqlConnection.Open();
				php.onDatabase.myReader = php.onDatabase.command.ExecuteReader();

				while (php.onDatabase.myReader.Read())
				{
					string lockerSelect = php.onDatabase.myReader.GetString("place_locker");
					php.cmbBoxLocker.Items.Add(lockerSelect);
				}
			}
			catch (Exception ex)
			{

				MessageBox.Show(ex.Message);
			}
		}
		public void shelveSelectMysql(PhpJSON php)
		{
			string shelveQuery = "SELECT DISTINCT shelve_locker FROM majetok.kteem_record";
			php.onDatabase.sqlConnection = new MySqlConnection(php.onDatabase.conString);
			php.onDatabase.command = new MySqlCommand(shelveQuery, php.onDatabase.sqlConnection);

			php.cmbBoxLocker.Items.Add("");

			try
			{
				php.onDatabase.sqlConnection.Open();
				php.onDatabase.myReader = php.onDatabase.command.ExecuteReader();

				while (php.onDatabase.myReader.Read())
				{
					string shelveSelect = php.onDatabase.myReader.GetString("place_locker");
					php.cmbBoxLocker.Items.Add(shelveSelect);
				}
			}
			catch (Exception ex)
			{

				MessageBox.Show(ex.Message);
			}
		}

	}
}
