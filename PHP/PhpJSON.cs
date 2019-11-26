using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Net;
using System.Data.SQLite;
using System.Data;
using System.Diagnostics;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;


namespace PHP
{
	public partial class PhpJSON : Form
	{
		public string URLadresaRecord = "http://127.0.0.1/test/recordsTable.php?id=";
		public string URLadresaAllRecord = "http://127.0.0.1/test/recordsTable.php";
		public string URLadresaUsers = "http://127.0.0.1/test/usersTable.php?id=";
		public string URLadresaAllUsers = "http://127.0.0.1/test/usersTable.php";
		public string URLadresaNamespace = "http://127.0.0.1/test/namespaceTable.php?id=";
		public string URLadresaAllNamespace = "http://127.0.0.1/test/namespaceTable.php";
		TCPClass tcp;
		public OnlineDatabase onDatabase = new OnlineDatabase();
		public SelectingClass selecting = new SelectingClass();
		public LocalDatabase localDatabase = new LocalDatabase();
		public int i;
		public string msg;
		public int numBytesRead;
		public string ReadData;
		public int Count;
		public string responseData;
		public string Scan = "B";
		public string StopScan = "C";
		public string ContinueScan = "E";
		public string RepeatEnable = "F";
		public string RepeatDisable = "G";
		public char ScanChar = 'B';
		public char StopChar = 'C';
		public char ContinueScanChar = 'E';
		public char RepeatEnableChar = 'F';
		public char RepeatDisableChar = 'G';
		public PhpJSON()
		{
			InitializeComponent();
			tcp = new TCPClass();
			//selecting.SelectDataMysql(this);
			//selecting.SelectDataSqliteCombobox(this);
			tcp.RemoveChars(this);

			localDatabase.SqliteRecordToList(this);
			localDatabase.SqliteUserToList(this);
			localDatabase.SqliteNamespaceToList(this);

			selecting.SelectRoomToCombo(this);
			selecting.cmbBoxEnabled(this);
		}

		private void btnClear_Click(object sender, EventArgs e)
		{
			txtOutput.Text = string.Empty;
			txtInput.Text = string.Empty;
			txtIn.Text = string.Empty;
			txtOut.Text = string.Empty;
			dataGridView1.DataSource = string.Empty;
			listBoxShow.Text = string.Empty;

		}

		#region UI EventHandlers
		private void btnConnect_Click(object sender, EventArgs e)
		{
			onDatabase.ShowWebsiteRecords(this);
			//onDatabase.ShowWebsiteUsers(this);
			//onDatabase.ShowWebsiteNamespace(this);

		}
		private void btnSelect_Click(object sender, EventArgs e)
		{
			localDatabase.SqliteRecordToList(this);
			//localDatabase.SqliteUserToList(this);
			//localDatabase.SqliteNamespaceToList(this);

		}
		private void btnSelectComboBoxes_Click(object sender, EventArgs e)
		{
			selecting.comboBoxShowData(this);
		}
		private void btnDGVclear_Click(object sender, EventArgs e)
		{
			dataGridView1.DataSource = null;
			cmbBoxLocker.Items.Remove(cmbBoxLocker.Text);
			cmbBoxRoom.Items.Remove(cmbBoxRoom.Text);
			cmbBoxShelve.Items.Remove(cmbBoxShelve.Text);

		}

		#endregion
		private void btnSerialServer_Click(object sender, EventArgs e)
		{
			onDatabase.ShowServerUsers(this);
			onDatabase.ShowServerNamespace(this);
			onDatabase.ShowServerRecords(this);
		}

		private void Update(object sender, System.ComponentModel.DoWorkEventArgs e)
		{
			tcp.Connect(txtIpAddress.Text, 5045);
			if (tcp.tcpClient.Connected && !backGround.CancellationPending)
			{
				try
				{
					byte[] data = new byte[1024];
					using (MemoryStream ms = new MemoryStream())
					{
						Debug.WriteLine("Data sa prijmaju");
						while ((tcp.netStream != null))
						{
							numBytesRead = tcp.netStream.Read(data, 0, data.Length);
							ms.Write(data, 0, numBytesRead);
							Debug.WriteLine("numBytesRead=" + numBytesRead.ToString() + "; msCount=" + ms.ToArray().Count());
							responseData = string.Empty;
							responseData = Encoding.ASCII.GetString(ms.ToArray(), 0, (int)ms.Length);
							ReadData = responseData;

							if (responseData != string.Empty)
							{
								backGround.ReportProgress(0, responseData);
								responseData = responseData.Substring(9, responseData.Length - 14);

								//UpdateChanged(15, responseData);
							}
						}
					}
				}
				catch (Exception)
				{
					tcp.Disconnect();
				}
			}
			//if (backGround.CancellationPending)
			//{
			//    e.Cancel = true;
			//    backGround.ReportProgress(i, "TEst: uz som na");
			//    backGround.ReportProgress(i, msg);
			//    return;
			//}
			//backGround.ReportProgress(100);
		}

	
        private void UpdateChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            prgBarBack.Value = e.ProgressPercentage;
            msg = (string)e.UserState;
			

			txtIn.Text = responseData;
        }

        private void Completed(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                //lblPrgStatus.Text = "Task Cancelled.";
            }
            else if (e.Error != null)
            {
              //  lblPrgStatus.Text = "Error while performing background operation.";
            }
            else
            {
                //lblPrgStatus.Text = "Odoslajuca sprava: " + txtIn.Text;
            }
            btnServerConnect.Enabled = true;
        }

        private void btnServerConnect_Click(object sender, EventArgs e)
        {
            try
            {
                btnServerConnect.Enabled = false;
                btnScan.Enabled = true;
                btnDisconnect.Enabled = true;
                btnStopScan.Enabled = false;
                backGround.RunWorkerAsync();
            }
            catch (Exception)
            {
                MessageBox.Show("Server nie je zapnutý");
            }
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            try
            {
                backGround.CancelAsync();
                tcp.Disconnect();
                btnDisconnect.Enabled = false;
                btnServerConnect.Enabled = true;
                btnScan.Enabled = false;
            }
            catch (Exception)
            {
                MessageBox.Show("Klient je pripojený k serveru");
            }
        }

        private void PhpJSON_Load(object sender, EventArgs e)
        {
            btnServerConnect.Enabled = true;
            btnScan.Enabled = false;
            btnDisconnect.Enabled = false;
        }

        private void btnScan_Click(object sender, EventArgs e)
        {
            //tcp.SendMsg(txtOut.Text);
            btnStopScan.Enabled = true;
            tcp.SendMsg(Scan);
            txtOut.Text = Scan.ToString(); // "B"

            //tcp.SendMsg(ContinueScan);
            //txtOut.Text = Scan.ToString();   //   "E"

            //tcp.SendMsg(RepeatEnable);
            //txtOut.Text = RepeatEnable.ToString(); //   "F"

            //tcp.SendMsg(RepeatDisable);
            //txtOut.Text = RepeatDisable.ToString();  //   "G"
        }

        private void btnStopScan_Click(object sender, EventArgs e)
        {
            tcp.SendMsg(StopScan);
            txtOut.Text = StopScan.ToString();
        }

        private void cmbBoxRoom_SelectedIndexChanged(object sender, EventArgs e)
        {			
			selecting.showRooms(this);

		}

		private void cmbBoxLocker_SelectedIndexChanged(object sender, EventArgs e)
        {
			selecting.showLockers(this);
		}

        private void cmbBoxShelve_SelectedIndexChanged(object sender, EventArgs e)
        {
			selecting.showShelves(this);
		}

		
	}
}
