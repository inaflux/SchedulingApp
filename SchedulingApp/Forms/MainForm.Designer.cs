namespace SchedulingApp
{
    partial class MainForm
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
            this.customersDGV = new System.Windows.Forms.DataGridView();
            this.deleteBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.addBtn = new System.Windows.Forms.Button();
            this.editBtn = new System.Windows.Forms.Button();
            this.scheduleBtn = new System.Windows.Forms.Button();
            this.reportsBtn = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.mySqlCommand1 = new MySql.Data.MySqlClient.MySqlCommand();
            this.mySqlCommand2 = new MySql.Data.MySqlClient.MySqlCommand();
            this.allViewRadioBtn = new System.Windows.Forms.RadioButton();
            this.weekViewRadioBtn = new System.Windows.Forms.RadioButton();
            this.monthViewRadioBtn = new System.Windows.Forms.RadioButton();
            this.calendarDGV = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.customersDGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.calendarDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // customersDGV
            // 
            this.customersDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.customersDGV.GridColor = System.Drawing.SystemColors.ControlText;
            this.customersDGV.Location = new System.Drawing.Point(13, 167);
            this.customersDGV.Name = "customersDGV";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.MediumTurquoise;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.customersDGV.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.customersDGV.RowHeadersWidth = 62;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Crimson;
            this.customersDGV.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.customersDGV.RowTemplate.Height = 28;
            this.customersDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.customersDGV.Size = new System.Drawing.Size(1125, 476);
            this.customersDGV.TabIndex = 0;
            this.customersDGV.VirtualMode = true;
            // 
            // deleteBtn
            // 
            this.deleteBtn.BackColor = System.Drawing.Color.DarkSlateGray;
            this.deleteBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.deleteBtn.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteBtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.deleteBtn.Location = new System.Drawing.Point(462, 95);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(193, 56);
            this.deleteBtn.TabIndex = 5;
            this.deleteBtn.Text = "Delete Customer";
            this.deleteBtn.UseVisualStyleBackColor = false;
            this.deleteBtn.Click += new System.EventHandler(this.deleteBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Roboto", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(334, 43);
            this.label1.TabIndex = 6;
            this.label1.Text = "Customer Records";
            // 
            // addBtn
            // 
            this.addBtn.BackColor = System.Drawing.Color.DarkSlateGray;
            this.addBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.addBtn.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addBtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.addBtn.Location = new System.Drawing.Point(13, 95);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(193, 56);
            this.addBtn.TabIndex = 8;
            this.addBtn.Text = "Add Customer";
            this.addBtn.UseVisualStyleBackColor = false;
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // editBtn
            // 
            this.editBtn.BackColor = System.Drawing.Color.DarkSlateGray;
            this.editBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.editBtn.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editBtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.editBtn.Location = new System.Drawing.Point(238, 95);
            this.editBtn.Name = "editBtn";
            this.editBtn.Size = new System.Drawing.Size(193, 56);
            this.editBtn.TabIndex = 9;
            this.editBtn.Text = "Edit Customer";
            this.editBtn.UseVisualStyleBackColor = false;
            this.editBtn.Click += new System.EventHandler(this.editBtn_Click);
            // 
            // scheduleBtn
            // 
            this.scheduleBtn.BackColor = System.Drawing.Color.DarkSlateGray;
            this.scheduleBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.scheduleBtn.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scheduleBtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.scheduleBtn.Location = new System.Drawing.Point(695, 95);
            this.scheduleBtn.Name = "scheduleBtn";
            this.scheduleBtn.Size = new System.Drawing.Size(211, 56);
            this.scheduleBtn.TabIndex = 10;
            this.scheduleBtn.Text = "Schedule Appointment";
            this.scheduleBtn.UseVisualStyleBackColor = false;
            this.scheduleBtn.Click += new System.EventHandler(this.scheduleBtn_Click);
            // 
            // reportsBtn
            // 
            this.reportsBtn.BackColor = System.Drawing.Color.DarkSlateGray;
            this.reportsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.reportsBtn.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reportsBtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.reportsBtn.Location = new System.Drawing.Point(945, 95);
            this.reportsBtn.Name = "reportsBtn";
            this.reportsBtn.Size = new System.Drawing.Size(193, 56);
            this.reportsBtn.TabIndex = 11;
            this.reportsBtn.Text = "Generate Reports";
            this.reportsBtn.UseVisualStyleBackColor = false;
            this.reportsBtn.Click += new System.EventHandler(this.reportsBtn_Click);
            // 
            // exitButton
            // 
            this.exitButton.BackColor = System.Drawing.Color.DarkSlateGray;
            this.exitButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.exitButton.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.exitButton.Location = new System.Drawing.Point(1040, 925);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(98, 50);
            this.exitButton.TabIndex = 21;
            this.exitButton.Text = "EXIT";
            this.exitButton.UseVisualStyleBackColor = false;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // mySqlCommand1
            // 
            this.mySqlCommand1.CacheAge = 0;
            this.mySqlCommand1.Connection = null;
            this.mySqlCommand1.EnableCaching = false;
            this.mySqlCommand1.Transaction = null;
            // 
            // mySqlCommand2
            // 
            this.mySqlCommand2.CacheAge = 0;
            this.mySqlCommand2.Connection = null;
            this.mySqlCommand2.EnableCaching = false;
            this.mySqlCommand2.Transaction = null;
            // 
            // allViewRadioBtn
            // 
            this.allViewRadioBtn.AutoSize = true;
            this.allViewRadioBtn.Location = new System.Drawing.Point(26, 744);
            this.allViewRadioBtn.Name = "allViewRadioBtn";
            this.allViewRadioBtn.Size = new System.Drawing.Size(206, 26);
            this.allViewRadioBtn.TabIndex = 25;
            this.allViewRadioBtn.TabStop = true;
            this.allViewRadioBtn.Text = "All Appointment View";
            this.allViewRadioBtn.UseVisualStyleBackColor = true;
            // 
            // weekViewRadioBtn
            // 
            this.weekViewRadioBtn.AutoSize = true;
            this.weekViewRadioBtn.Location = new System.Drawing.Point(26, 796);
            this.weekViewRadioBtn.Name = "weekViewRadioBtn";
            this.weekViewRadioBtn.Size = new System.Drawing.Size(187, 26);
            this.weekViewRadioBtn.TabIndex = 26;
            this.weekViewRadioBtn.TabStop = true;
            this.weekViewRadioBtn.Text = "Current Week View";
            this.weekViewRadioBtn.UseVisualStyleBackColor = true;
            // 
            // monthViewRadioBtn
            // 
            this.monthViewRadioBtn.AutoSize = true;
            this.monthViewRadioBtn.Location = new System.Drawing.Point(26, 852);
            this.monthViewRadioBtn.Name = "monthViewRadioBtn";
            this.monthViewRadioBtn.Size = new System.Drawing.Size(194, 26);
            this.monthViewRadioBtn.TabIndex = 27;
            this.monthViewRadioBtn.TabStop = true;
            this.monthViewRadioBtn.Text = "Current Month View";
            this.monthViewRadioBtn.UseVisualStyleBackColor = true;
            // 
            // calendarDGV
            // 
            this.calendarDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.calendarDGV.Location = new System.Drawing.Point(286, 659);
            this.calendarDGV.Name = "calendarDGV";
            this.calendarDGV.RowHeadersWidth = 62;
            this.calendarDGV.RowTemplate.Height = 28;
            this.calendarDGV.Size = new System.Drawing.Size(852, 251);
            this.calendarDGV.TabIndex = 28;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Roboto", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(18, 659);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(262, 43);
            this.label2.TabIndex = 29;
            this.label2.Text = "Calendar View";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.ClientSize = new System.Drawing.Size(1170, 987);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.calendarDGV);
            this.Controls.Add(this.monthViewRadioBtn);
            this.Controls.Add(this.weekViewRadioBtn);
            this.Controls.Add(this.allViewRadioBtn);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.reportsBtn);
            this.Controls.Add(this.scheduleBtn);
            this.Controls.Add(this.editBtn);
            this.Controls.Add(this.addBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.deleteBtn);
            this.Controls.Add(this.customersDGV);
            this.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Name = "MainForm";
            this.Text = "Main Form";
            ((System.ComponentModel.ISupportInitialize)(this.customersDGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.calendarDGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView customersDGV;
        private System.Windows.Forms.Button deleteBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.Button editBtn;
        private System.Windows.Forms.Button scheduleBtn;
        private System.Windows.Forms.Button reportsBtn;
        private System.Windows.Forms.Button exitButton;
        private MySql.Data.MySqlClient.MySqlCommand mySqlCommand1;
        private MySql.Data.MySqlClient.MySqlCommand mySqlCommand2;
        private System.Windows.Forms.RadioButton allViewRadioBtn;
        private System.Windows.Forms.RadioButton weekViewRadioBtn;
        private System.Windows.Forms.RadioButton monthViewRadioBtn;
        private System.Windows.Forms.DataGridView calendarDGV;
        private System.Windows.Forms.Label label2;
    }
}

