namespace PHP
{
    public partial class PhpJSON
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.txtInput = new System.Windows.Forms.TextBox();
			this.btnClear = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.txtURL = new System.Windows.Forms.TextBox();
			this.btnConnectLocalHost = new System.Windows.Forms.Button();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.btnSerialServer = new System.Windows.Forms.Button();
			this.btnScan = new System.Windows.Forms.Button();
			this.btnStopScan = new System.Windows.Forms.Button();
			this.btnServerConnect = new System.Windows.Forms.Button();
			this.btnDisconnect = new System.Windows.Forms.Button();
			this.txtOut = new System.Windows.Forms.TextBox();
			this.txtIn = new System.Windows.Forms.TextBox();
			this.txtIpAddress = new System.Windows.Forms.TextBox();
			this.backGround = new System.ComponentModel.BackgroundWorker();
			this.prgBarBack = new System.Windows.Forms.ProgressBar();
			this.cmbBoxRoom = new System.Windows.Forms.ComboBox();
			this.cmbBoxLocker = new System.Windows.Forms.ComboBox();
			this.cmbBoxShelve = new System.Windows.Forms.ComboBox();
			this.lblRoom = new System.Windows.Forms.Label();
			this.lblLocker = new System.Windows.Forms.Label();
			this.lvlShelve = new System.Windows.Forms.Label();
			this.btnSelect = new System.Windows.Forms.Button();
			this.btnDGVclear = new System.Windows.Forms.Button();
			this.listBoxShow = new System.Windows.Forms.ListBox();
			this.btnSelectComboBoxes = new System.Windows.Forms.Button();
			this.txtOutput = new System.Windows.Forms.TextBox();
			this.txtRoom = new System.Windows.Forms.TextBox();
			this.txtLocker = new System.Windows.Forms.TextBox();
			this.txtShelve = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.SuspendLayout();
			// 
			// txtInput
			// 
			this.txtInput.Location = new System.Drawing.Point(804, 146);
			this.txtInput.Multiline = true;
			this.txtInput.Name = "txtInput";
			this.txtInput.Size = new System.Drawing.Size(308, 85);
			this.txtInput.TabIndex = 0;
			// 
			// btnClear
			// 
			this.btnClear.Location = new System.Drawing.Point(308, 71);
			this.btnClear.Name = "btnClear";
			this.btnClear.Size = new System.Drawing.Size(71, 23);
			this.btnClear.TabIndex = 9;
			this.btnClear.Text = "Clear Data";
			this.btnClear.UseVisualStyleBackColor = true;
			this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(4, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(32, 13);
			this.label1.TabIndex = 11;
			this.label1.Text = "URL:";
			// 
			// txtURL
			// 
			this.txtURL.Location = new System.Drawing.Point(42, 5);
			this.txtURL.Name = "txtURL";
			this.txtURL.Size = new System.Drawing.Size(163, 20);
			this.txtURL.TabIndex = 12;
			// 
			// btnConnectLocalHost
			// 
			this.btnConnectLocalHost.Location = new System.Drawing.Point(209, 3);
			this.btnConnectLocalHost.Name = "btnConnectLocalHost";
			this.btnConnectLocalHost.Size = new System.Drawing.Size(106, 23);
			this.btnConnectLocalHost.TabIndex = 13;
			this.btnConnectLocalHost.Text = "Connect LocalHost";
			this.btnConnectLocalHost.UseVisualStyleBackColor = true;
			this.btnConnectLocalHost.Click += new System.EventHandler(this.btnConnect_Click);
			// 
			// dataGridView1
			// 
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Location = new System.Drawing.Point(7, 100);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.Size = new System.Drawing.Size(614, 170);
			this.dataGridView1.TabIndex = 14;
			// 
			// btnSerialServer
			// 
			this.btnSerialServer.Location = new System.Drawing.Point(154, 71);
			this.btnSerialServer.Name = "btnSerialServer";
			this.btnSerialServer.Size = new System.Drawing.Size(71, 23);
			this.btnSerialServer.TabIndex = 16;
			this.btnSerialServer.Text = "Update";
			this.btnSerialServer.UseVisualStyleBackColor = true;
			this.btnSerialServer.Click += new System.EventHandler(this.btnSerialServer_Click);
			// 
			// btnScan
			// 
			this.btnScan.Location = new System.Drawing.Point(4, 71);
			this.btnScan.Name = "btnScan";
			this.btnScan.Size = new System.Drawing.Size(69, 23);
			this.btnScan.TabIndex = 17;
			this.btnScan.Text = "Scan";
			this.btnScan.UseVisualStyleBackColor = true;
			this.btnScan.Click += new System.EventHandler(this.btnScan_Click);
			// 
			// btnStopScan
			// 
			this.btnStopScan.Location = new System.Drawing.Point(79, 71);
			this.btnStopScan.Name = "btnStopScan";
			this.btnStopScan.Size = new System.Drawing.Size(69, 23);
			this.btnStopScan.TabIndex = 18;
			this.btnStopScan.Text = "Stop Scan";
			this.btnStopScan.UseVisualStyleBackColor = true;
			this.btnStopScan.Click += new System.EventHandler(this.btnStopScan_Click);
			// 
			// btnServerConnect
			// 
			this.btnServerConnect.Location = new System.Drawing.Point(493, 3);
			this.btnServerConnect.Name = "btnServerConnect";
			this.btnServerConnect.Size = new System.Drawing.Size(92, 23);
			this.btnServerConnect.TabIndex = 19;
			this.btnServerConnect.Text = "Connect Server";
			this.btnServerConnect.UseVisualStyleBackColor = true;
			this.btnServerConnect.Click += new System.EventHandler(this.btnServerConnect_Click);
			// 
			// btnDisconnect
			// 
			this.btnDisconnect.Location = new System.Drawing.Point(591, 3);
			this.btnDisconnect.Name = "btnDisconnect";
			this.btnDisconnect.Size = new System.Drawing.Size(73, 23);
			this.btnDisconnect.TabIndex = 20;
			this.btnDisconnect.Text = "Disconnect";
			this.btnDisconnect.UseVisualStyleBackColor = true;
			this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
			// 
			// txtOut
			// 
			this.txtOut.Location = new System.Drawing.Point(627, 100);
			this.txtOut.Multiline = true;
			this.txtOut.Name = "txtOut";
			this.txtOut.Size = new System.Drawing.Size(37, 170);
			this.txtOut.TabIndex = 21;
			this.txtOut.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// txtIn
			// 
			this.txtIn.Location = new System.Drawing.Point(670, 146);
			this.txtIn.Multiline = true;
			this.txtIn.Name = "txtIn";
			this.txtIn.Size = new System.Drawing.Size(128, 33);
			this.txtIn.TabIndex = 22;
			this.txtIn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// txtIpAddress
			// 
			this.txtIpAddress.Location = new System.Drawing.Point(321, 4);
			this.txtIpAddress.Multiline = true;
			this.txtIpAddress.Name = "txtIpAddress";
			this.txtIpAddress.Size = new System.Drawing.Size(166, 22);
			this.txtIpAddress.TabIndex = 23;
			this.txtIpAddress.Text = "192.168.100.142";
			this.txtIpAddress.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// backGround
			// 
			this.backGround.WorkerReportsProgress = true;
			this.backGround.WorkerSupportsCancellation = true;
			this.backGround.DoWork += new System.ComponentModel.DoWorkEventHandler(this.Update);
			this.backGround.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.UpdateChanged);
			this.backGround.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.Completed);
			// 
			// prgBarBack
			// 
			this.prgBarBack.Location = new System.Drawing.Point(385, 73);
			this.prgBarBack.Name = "prgBarBack";
			this.prgBarBack.Size = new System.Drawing.Size(102, 23);
			this.prgBarBack.TabIndex = 24;
			// 
			// cmbBoxRoom
			// 
			this.cmbBoxRoom.FormattingEnabled = true;
			this.cmbBoxRoom.Location = new System.Drawing.Point(4, 44);
			this.cmbBoxRoom.Name = "cmbBoxRoom";
			this.cmbBoxRoom.Size = new System.Drawing.Size(121, 21);
			this.cmbBoxRoom.TabIndex = 26;
			this.cmbBoxRoom.SelectedIndexChanged += new System.EventHandler(this.cmbBoxRoom_SelectedIndexChanged);
			// 
			// cmbBoxLocker
			// 
			this.cmbBoxLocker.FormattingEnabled = true;
			this.cmbBoxLocker.Location = new System.Drawing.Point(131, 44);
			this.cmbBoxLocker.Name = "cmbBoxLocker";
			this.cmbBoxLocker.Size = new System.Drawing.Size(121, 21);
			this.cmbBoxLocker.TabIndex = 27;
			this.cmbBoxLocker.SelectedIndexChanged += new System.EventHandler(this.cmbBoxLocker_SelectedIndexChanged);
			// 
			// cmbBoxShelve
			// 
			this.cmbBoxShelve.FormattingEnabled = true;
			this.cmbBoxShelve.Location = new System.Drawing.Point(258, 44);
			this.cmbBoxShelve.Name = "cmbBoxShelve";
			this.cmbBoxShelve.Size = new System.Drawing.Size(121, 21);
			this.cmbBoxShelve.TabIndex = 28;
			this.cmbBoxShelve.SelectedIndexChanged += new System.EventHandler(this.cmbBoxShelve_SelectedIndexChanged);
			// 
			// lblRoom
			// 
			this.lblRoom.AutoSize = true;
			this.lblRoom.Location = new System.Drawing.Point(4, 28);
			this.lblRoom.Name = "lblRoom";
			this.lblRoom.Size = new System.Drawing.Size(38, 13);
			this.lblRoom.TabIndex = 29;
			this.lblRoom.Text = "Room:";
			// 
			// lblLocker
			// 
			this.lblLocker.AutoSize = true;
			this.lblLocker.Location = new System.Drawing.Point(128, 28);
			this.lblLocker.Name = "lblLocker";
			this.lblLocker.Size = new System.Drawing.Size(43, 13);
			this.lblLocker.TabIndex = 30;
			this.lblLocker.Text = "Locker:";
			// 
			// lvlShelve
			// 
			this.lvlShelve.AutoSize = true;
			this.lvlShelve.Location = new System.Drawing.Point(255, 28);
			this.lvlShelve.Name = "lvlShelve";
			this.lvlShelve.Size = new System.Drawing.Size(43, 13);
			this.lvlShelve.TabIndex = 31;
			this.lvlShelve.Text = "Shelve:";
			// 
			// btnSelect
			// 
			this.btnSelect.Location = new System.Drawing.Point(231, 71);
			this.btnSelect.Name = "btnSelect";
			this.btnSelect.Size = new System.Drawing.Size(71, 23);
			this.btnSelect.TabIndex = 32;
			this.btnSelect.Text = "ShowData";
			this.btnSelect.UseVisualStyleBackColor = true;
			this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
			// 
			// btnDGVclear
			// 
			this.btnDGVclear.Location = new System.Drawing.Point(462, 44);
			this.btnDGVclear.Name = "btnDGVclear";
			this.btnDGVclear.Size = new System.Drawing.Size(71, 23);
			this.btnDGVclear.TabIndex = 33;
			this.btnDGVclear.Text = "ClearData";
			this.btnDGVclear.UseVisualStyleBackColor = true;
			this.btnDGVclear.Click += new System.EventHandler(this.btnDGVclear_Click);
			// 
			// listBoxShow
			// 
			this.listBoxShow.FormattingEnabled = true;
			this.listBoxShow.Location = new System.Drawing.Point(7, 276);
			this.listBoxShow.Name = "listBoxShow";
			this.listBoxShow.Size = new System.Drawing.Size(1105, 251);
			this.listBoxShow.TabIndex = 34;
			// 
			// btnSelectComboBoxes
			// 
			this.btnSelectComboBoxes.Location = new System.Drawing.Point(385, 44);
			this.btnSelectComboBoxes.Name = "btnSelectComboBoxes";
			this.btnSelectComboBoxes.Size = new System.Drawing.Size(71, 23);
			this.btnSelectComboBoxes.TabIndex = 37;
			this.btnSelectComboBoxes.Text = "ShowData";
			this.btnSelectComboBoxes.UseVisualStyleBackColor = true;
			this.btnSelectComboBoxes.Click += new System.EventHandler(this.btnSelectComboBoxes_Click);
			// 
			// txtOutput
			// 
			this.txtOutput.Location = new System.Drawing.Point(670, 3);
			this.txtOutput.Multiline = true;
			this.txtOutput.Name = "txtOutput";
			this.txtOutput.Size = new System.Drawing.Size(442, 137);
			this.txtOutput.TabIndex = 38;
			// 
			// txtRoom
			// 
			this.txtRoom.Location = new System.Drawing.Point(670, 185);
			this.txtRoom.Multiline = true;
			this.txtRoom.Name = "txtRoom";
			this.txtRoom.Size = new System.Drawing.Size(128, 20);
			this.txtRoom.TabIndex = 39;
			this.txtRoom.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// txtLocker
			// 
			this.txtLocker.Location = new System.Drawing.Point(670, 211);
			this.txtLocker.Multiline = true;
			this.txtLocker.Name = "txtLocker";
			this.txtLocker.Size = new System.Drawing.Size(128, 20);
			this.txtLocker.TabIndex = 40;
			this.txtLocker.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// txtShelve
			// 
			this.txtShelve.Location = new System.Drawing.Point(670, 237);
			this.txtShelve.Multiline = true;
			this.txtShelve.Name = "txtShelve";
			this.txtShelve.Size = new System.Drawing.Size(442, 33);
			this.txtShelve.TabIndex = 41;
			this.txtShelve.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// PhpJSON
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.ClientSize = new System.Drawing.Size(1124, 533);
			this.Controls.Add(this.txtShelve);
			this.Controls.Add(this.txtLocker);
			this.Controls.Add(this.txtRoom);
			this.Controls.Add(this.txtOutput);
			this.Controls.Add(this.btnSelectComboBoxes);
			this.Controls.Add(this.listBoxShow);
			this.Controls.Add(this.btnDGVclear);
			this.Controls.Add(this.btnSelect);
			this.Controls.Add(this.lvlShelve);
			this.Controls.Add(this.lblLocker);
			this.Controls.Add(this.lblRoom);
			this.Controls.Add(this.cmbBoxShelve);
			this.Controls.Add(this.cmbBoxLocker);
			this.Controls.Add(this.cmbBoxRoom);
			this.Controls.Add(this.prgBarBack);
			this.Controls.Add(this.txtIpAddress);
			this.Controls.Add(this.txtIn);
			this.Controls.Add(this.txtOut);
			this.Controls.Add(this.btnDisconnect);
			this.Controls.Add(this.btnServerConnect);
			this.Controls.Add(this.btnStopScan);
			this.Controls.Add(this.btnScan);
			this.Controls.Add(this.txtInput);
			this.Controls.Add(this.btnSerialServer);
			this.Controls.Add(this.dataGridView1);
			this.Controls.Add(this.btnConnectLocalHost);
			this.Controls.Add(this.txtURL);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btnClear);
			this.Name = "PhpJSON";
			this.Text = "PHP";
			this.Load += new System.EventHandler(this.PhpJSON_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.Button btnClear;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox txtURL;
        public System.Windows.Forms.Button btnConnectLocalHost;
        public System.Windows.Forms.DataGridView dataGridView1;
        public System.Windows.Forms.Button btnSerialServer;
        public System.Windows.Forms.TextBox txtInput;
        public System.Windows.Forms.Button btnScan;
        public System.Windows.Forms.Button btnStopScan;
        public System.Windows.Forms.Button btnServerConnect;
        public System.Windows.Forms.Button btnDisconnect;
        public System.Windows.Forms.TextBox txtOut;
        public System.Windows.Forms.TextBox txtIn;
        public System.Windows.Forms.TextBox txtIpAddress;
        public System.ComponentModel.BackgroundWorker backGround;
        public System.Windows.Forms.ProgressBar prgBarBack;
        public System.Windows.Forms.ComboBox cmbBoxRoom;
        public System.Windows.Forms.ComboBox cmbBoxLocker;
        public System.Windows.Forms.ComboBox cmbBoxShelve;
        public System.Windows.Forms.Label lblRoom;
        public System.Windows.Forms.Label lblLocker;
        public System.Windows.Forms.Label lvlShelve;
		public System.Windows.Forms.Button btnSelect;
		public System.Windows.Forms.Button btnDGVclear;
		public System.Windows.Forms.ListBox listBoxShow;
		public System.Windows.Forms.Button btnSelectComboBoxes;
		public System.Windows.Forms.TextBox txtOutput;
		public System.Windows.Forms.TextBox txtRoom;
		public System.Windows.Forms.TextBox txtLocker;
		public System.Windows.Forms.TextBox txtShelve;
	}
}

