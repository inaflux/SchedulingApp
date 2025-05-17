namespace SchedulingApp
{
    partial class ReportsForm
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
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("");
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.numOfApptList = new System.Windows.Forms.ListView();
            this.mySqlCommand1 = new MySql.Data.MySqlClient.MySqlCommand();
            this.currentApptDVG = new System.Windows.Forms.DataGridView();
            this.numOfCitiesBtn = new System.Windows.Forms.Button();
            this.citiList = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.userComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.backBtn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.monthPicker = new System.Windows.Forms.DateTimePicker();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            ((System.ComponentModel.ISupportInitialize)(this.currentApptDVG)).BeginInit();
            this.SuspendLayout();
            // 
            // numOfApptList
            // 
            this.numOfApptList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.numOfApptList.HideSelection = false;
            this.numOfApptList.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.numOfApptList.Location = new System.Drawing.Point(322, 656);
            this.numOfApptList.Name = "numOfApptList";
            this.numOfApptList.Size = new System.Drawing.Size(362, 129);
            this.numOfApptList.TabIndex = 2;
            this.numOfApptList.UseCompatibleStateImageBehavior = false;
            this.numOfApptList.View = System.Windows.Forms.View.List;
            // 
            // mySqlCommand1
            // 
            this.mySqlCommand1.CacheAge = 0;
            this.mySqlCommand1.Connection = null;
            this.mySqlCommand1.EnableCaching = false;
            this.mySqlCommand1.Transaction = null;
            // 
            // currentApptDVG
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.currentApptDVG.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.currentApptDVG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.currentApptDVG.DefaultCellStyle = dataGridViewCellStyle2;
            this.currentApptDVG.Location = new System.Drawing.Point(440, 210);
            this.currentApptDVG.Name = "currentApptDVG";
            this.currentApptDVG.RowHeadersWidth = 62;
            this.currentApptDVG.RowTemplate.Height = 28;
            this.currentApptDVG.Size = new System.Drawing.Size(962, 250);
            this.currentApptDVG.TabIndex = 4;
            // 
            // numOfCitiesBtn
            // 
            this.numOfCitiesBtn.BackColor = System.Drawing.Color.DarkSlateGray;
            this.numOfCitiesBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.numOfCitiesBtn.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numOfCitiesBtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.numOfCitiesBtn.Location = new System.Drawing.Point(1129, 577);
            this.numOfCitiesBtn.Name = "numOfCitiesBtn";
            this.numOfCitiesBtn.Size = new System.Drawing.Size(441, 77);
            this.numOfCitiesBtn.TabIndex = 5;
            this.numOfCitiesBtn.Text = "Generate";
            this.numOfCitiesBtn.UseVisualStyleBackColor = false;
            this.numOfCitiesBtn.Click += new System.EventHandler(this.numOfCitiesBtn_Click);
            // 
            // citiList
            // 
            this.citiList.HideSelection = false;
            this.citiList.Location = new System.Drawing.Point(1129, 707);
            this.citiList.Name = "citiList";
            this.citiList.Size = new System.Drawing.Size(441, 100);
            this.citiList.TabIndex = 6;
            this.citiList.UseCompatibleStateImageBehavior = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(596, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(597, 29);
            this.label1.TabIndex = 7;
            this.label1.Text = "Choose user to display their current Appointments";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(317, 523);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(471, 29);
            this.label2.TabIndex = 8;
            this.label2.Text = "Number of appointment types by month";
            // 
            // userComboBox
            // 
            this.userComboBox.FormattingEnabled = true;
            this.userComboBox.Location = new System.Drawing.Point(440, 131);
            this.userComboBox.Name = "userComboBox";
            this.userComboBox.Size = new System.Drawing.Size(222, 28);
            this.userComboBox.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(1115, 509);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(455, 29);
            this.label3.TabIndex = 10;
            this.label3.Text = "Number of different cities in database";
            // 
            // backBtn
            // 
            this.backBtn.BackColor = System.Drawing.Color.DarkSlateGray;
            this.backBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.backBtn.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backBtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.backBtn.Location = new System.Drawing.Point(53, 843);
            this.backBtn.Name = "backBtn";
            this.backBtn.Size = new System.Drawing.Size(129, 51);
            this.backBtn.TabIndex = 11;
            this.backBtn.Text = "Back";
            this.backBtn.UseVisualStyleBackColor = false;
            this.backBtn.Click += new System.EventHandler(this.backBtn_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Roboto", 26F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(42, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(225, 62);
            this.label4.TabIndex = 12;
            this.label4.Text = "Reports ";
            // 
            // monthPicker
            // 
            this.monthPicker.CustomFormat = "MMMM yyyy";
            this.monthPicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.monthPicker.Location = new System.Drawing.Point(322, 581);
            this.monthPicker.Name = "monthPicker";
            this.monthPicker.ShowUpDown = true;
            this.monthPicker.Size = new System.Drawing.Size(362, 26);
            this.monthPicker.TabIndex = 13;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Count";
            this.columnHeader1.Width = 150;
            // 
            // ReportsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.ClientSize = new System.Drawing.Size(1822, 929);
            this.Controls.Add(this.monthPicker);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.backBtn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.userComboBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.citiList);
            this.Controls.Add(this.numOfCitiesBtn);
            this.Controls.Add(this.currentApptDVG);
            this.Controls.Add(this.numOfApptList);
            this.Name = "ReportsForm";
            this.Text = "Reports";
            ((System.ComponentModel.ISupportInitialize)(this.currentApptDVG)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListView numOfApptList;
        private MySql.Data.MySqlClient.MySqlCommand mySqlCommand1;
        private System.Windows.Forms.DataGridView currentApptDVG;
        private System.Windows.Forms.Button numOfCitiesBtn;
        private System.Windows.Forms.ListView citiList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox userComboBox;
        private System.Windows.Forms.Label label3;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button backBtn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker monthPicker;
        private System.Windows.Forms.ColumnHeader columnHeader1;
    }
}