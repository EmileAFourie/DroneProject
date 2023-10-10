namespace Livestock_Tracking
{
    partial class TrackingData
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
            this.dgvTrackingData = new System.Windows.Forms.DataGridView();
            this.lblLogin = new System.Windows.Forms.Label();
            this.cbDatesList = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnViewAll = new System.Windows.Forms.Button();
            this.btnCows = new System.Windows.Forms.Button();
            this.btnHorse = new System.Windows.Forms.Button();
            this.btnSheep = new System.Windows.Forms.Button();
            this.btnThermal = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTrackingData)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvTrackingData
            // 
            this.dgvTrackingData.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.dgvTrackingData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTrackingData.GridColor = System.Drawing.Color.Teal;
            this.dgvTrackingData.Location = new System.Drawing.Point(28, 92);
            this.dgvTrackingData.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvTrackingData.Name = "dgvTrackingData";
            this.dgvTrackingData.RowHeadersWidth = 51;
            this.dgvTrackingData.RowTemplate.Height = 24;
            this.dgvTrackingData.Size = new System.Drawing.Size(628, 202);
            this.dgvTrackingData.TabIndex = 0;
            this.dgvTrackingData.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // lblLogin
            // 
            this.lblLogin.AutoSize = true;
            this.lblLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLogin.ForeColor = System.Drawing.Color.Teal;
            this.lblLogin.Location = new System.Drawing.Point(234, 39);
            this.lblLogin.Name = "lblLogin";
            this.lblLogin.Size = new System.Drawing.Size(227, 25);
            this.lblLogin.TabIndex = 7;
            this.lblLogin.Text = "Animal tracking data";
            this.lblLogin.Click += new System.EventHandler(this.lblLogin_Click);
            // 
            // cbDatesList
            // 
            this.cbDatesList.ForeColor = System.Drawing.Color.Black;
            this.cbDatesList.FormattingEnabled = true;
            this.cbDatesList.Location = new System.Drawing.Point(38, 358);
            this.cbDatesList.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbDatesList.Name = "cbDatesList";
            this.cbDatesList.Size = new System.Drawing.Size(140, 21);
            this.cbDatesList.TabIndex = 8;
            this.cbDatesList.SelectedIndexChanged += new System.EventHandler(this.cbDatesList_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(34, 335);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "Search by date";
            // 
            // btnViewAll
            // 
            this.btnViewAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnViewAll.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnViewAll.Location = new System.Drawing.Point(38, 390);
            this.btnViewAll.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnViewAll.Name = "btnViewAll";
            this.btnViewAll.Size = new System.Drawing.Size(140, 30);
            this.btnViewAll.TabIndex = 10;
            this.btnViewAll.Text = "View all";
            this.btnViewAll.UseVisualStyleBackColor = true;
            this.btnViewAll.Click += new System.EventHandler(this.btnViewAll_Click);
            // 
            // btnCows
            // 
            this.btnCows.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnCows.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnCows.Location = new System.Drawing.Point(571, 390);
            this.btnCows.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnCows.Name = "btnCows";
            this.btnCows.Size = new System.Drawing.Size(86, 30);
            this.btnCows.TabIndex = 11;
            this.btnCows.Text = "Cows";
            this.btnCows.UseVisualStyleBackColor = true;
            this.btnCows.Click += new System.EventHandler(this.btnCows_Click);
            // 
            // btnHorse
            // 
            this.btnHorse.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnHorse.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnHorse.Location = new System.Drawing.Point(480, 390);
            this.btnHorse.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnHorse.Name = "btnHorse";
            this.btnHorse.Size = new System.Drawing.Size(86, 30);
            this.btnHorse.TabIndex = 12;
            this.btnHorse.Text = "Horses";
            this.btnHorse.UseVisualStyleBackColor = true;
            this.btnHorse.Click += new System.EventHandler(this.btnHorse_Click);
            // 
            // btnSheep
            // 
            this.btnSheep.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnSheep.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnSheep.Location = new System.Drawing.Point(389, 390);
            this.btnSheep.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSheep.Name = "btnSheep";
            this.btnSheep.Size = new System.Drawing.Size(86, 30);
            this.btnSheep.TabIndex = 13;
            this.btnSheep.Text = "Sheeps";
            this.btnSheep.UseVisualStyleBackColor = true;
            this.btnSheep.Click += new System.EventHandler(this.btnSheep_Click);
            // 
            // btnThermal
            // 
            this.btnThermal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnThermal.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnThermal.Location = new System.Drawing.Point(299, 390);
            this.btnThermal.Margin = new System.Windows.Forms.Padding(2);
            this.btnThermal.Name = "btnThermal";
            this.btnThermal.Size = new System.Drawing.Size(86, 30);
            this.btnThermal.TabIndex = 14;
            this.btnThermal.Text = "Thermal";
            this.btnThermal.UseVisualStyleBackColor = true;
            this.btnThermal.Click += new System.EventHandler(this.btnThermal_Click);
            // 
            // TrackingData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(692, 466);
            this.Controls.Add(this.btnThermal);
            this.Controls.Add(this.btnSheep);
            this.Controls.Add(this.btnHorse);
            this.Controls.Add(this.btnCows);
            this.Controls.Add(this.btnViewAll);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbDatesList);
            this.Controls.Add(this.lblLogin);
            this.Controls.Add(this.dgvTrackingData);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "TrackingData";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TrackingData";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TrackingData_FormClosing);
            this.Load += new System.EventHandler(this.TrackingData_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTrackingData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvTrackingData;
        private System.Windows.Forms.Label lblLogin;
        private System.Windows.Forms.ComboBox cbDatesList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnViewAll;
        private System.Windows.Forms.Button btnCows;
        private System.Windows.Forms.Button btnHorse;
        private System.Windows.Forms.Button btnSheep;
        private System.Windows.Forms.Button btnThermal;
    }
}