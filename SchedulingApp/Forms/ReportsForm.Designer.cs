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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.typeComboBox = new System.Windows.Forms.ComboBox();
            this.dateComboBox = new System.Windows.Forms.ComboBox();
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
            ((System.ComponentModel.ISupportInitialize)(this.currentApptDVG)).BeginInit();
            this.SuspendLayout();
            // 
            // typeComboBox
            // 
            this.typeComboBox.FormattingEnabled = true;
            this.typeComboBox.Location = new System.Drawing.Point(840, 147);
            this.typeComboBox.Name = "typeComboBox";
            this.typeComboBox.Size = new System.Drawing.Size(362, 28);
            this.typeComboBox.TabIndex = 0;
            // 
            // dateComboBox
            // 
            this.dateComboBox.FormattingEnabled = true;
            this.dateComboBox.Location = new System.Drawing.Point(840, 196);
            this.dateComboBox.Name = "dateComboBox";
            this.dateComboBox.Size = new System.Drawing.Size(362, 28);
            this.dateComboBox.TabIndex = 1;
            // 
            // numOfApptList
            // 
            this.numOfApptList.HideSelection = false;
            this.numOfApptList.Location = new System.Drawing.Point(840, 260);
            this.numOfApptList.Name = "numOfApptList";
            this.numOfApptList.Size = new System.Drawing.Size(362, 211);
            this.numOfApptList.TabIndex = 2;
            this.numOfApptList.UseCompatibleStateImageBehavior = false;
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
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.currentApptDVG.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.currentApptDVG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.currentApptDVG.DefaultCellStyle = dataGridViewCellStyle4;
            this.currentApptDVG.Location = new System.Drawing.Point(52, 221);
            this.currentApptDVG.Name = "currentApptDVG";
            this.currentApptDVG.RowHeadersWidth = 62;
            this.currentApptDVG.RowTemplate.Height = 28;
            this.currentApptDVG.Size = new System.Drawing.Size(559, 250);
            this.currentApptDVG.TabIndex = 4;
            // 
            // numOfCitiesBtn
            // 
            this.numOfCitiesBtn.BackColor = System.Drawing.Color.DarkSlateGray;
            this.numOfCitiesBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.numOfCitiesBtn.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numOfCitiesBtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.numOfCitiesBtn.Location = new System.Drawing.Point(1497, 159);
            this.numOfCitiesBtn.Name = "numOfCitiesBtn";
            this.numOfCitiesBtn.Size = new System.Drawing.Size(441, 77);
            this.numOfCitiesBtn.TabIndex = 5;
            this.numOfCitiesBtn.Text = "Generate";
            this.numOfCitiesBtn.UseVisualStyleBackColor = false;
            // 
            // citiList
            // 
            this.citiList.HideSelection = false;
            this.citiList.Location = new System.Drawing.Point(1497, 289);
            this.citiList.Name = "citiList";
            this.citiList.Size = new System.Drawing.Size(441, 182);
            this.citiList.TabIndex = 6;
            this.citiList.UseCompatibleStateImageBehavior = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(47, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(597, 29);
            this.label1.TabIndex = 7;
            this.label1.Text = "Choose user to display their current Appointments";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(835, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(471, 29);
            this.label2.TabIndex = 8;
            this.label2.Text = "Number of appointment types by month";
            // 
            // userComboBox
            // 
            this.userComboBox.FormattingEnabled = true;
            this.userComboBox.Location = new System.Drawing.Point(52, 147);
            this.userComboBox.Name = "userComboBox";
            this.userComboBox.Size = new System.Drawing.Size(559, 28);
            this.userComboBox.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(1483, 91);
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
            this.backBtn.Location = new System.Drawing.Point(1809, 509);
            this.backBtn.Name = "backBtn";
            this.backBtn.Size = new System.Drawing.Size(129, 51);
            this.backBtn.TabIndex = 11;
            this.backBtn.Text = "Back";
            this.backBtn.UseVisualStyleBackColor = false;
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
            // ReportsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.ClientSize = new System.Drawing.Size(1970, 582);
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
            this.Controls.Add(this.dateComboBox);
            this.Controls.Add(this.typeComboBox);
            this.Name = "ReportsForm";
            this.Text = "Reports";
            ((System.ComponentModel.ISupportInitialize)(this.currentApptDVG)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox typeComboBox;
        private System.Windows.Forms.ComboBox dateComboBox;
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
    }
}