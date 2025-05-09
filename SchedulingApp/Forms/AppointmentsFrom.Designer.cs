namespace SchedulingApp
{
    partial class AppointmentsFrom
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
            this.label6 = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.saveBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.endTimeTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.startTimeTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.apptTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.userIDTextBox = new System.Windows.Forms.TextBox();
            this.appointmentsDGV = new System.Windows.Forms.DataGridView();
            this.editBtn = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.appointmentsDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.label6.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(979, 51);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(256, 29);
            this.label6.TabIndex = 14;
            this.label6.Text = "List of Appointments";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(314, 110);
            this.nameTextBox.Multiline = true;
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(331, 39);
            this.nameTextBox.TabIndex = 19;
            // 
            // cancelBtn
            // 
            this.cancelBtn.BackColor = System.Drawing.Color.DarkSlateGray;
            this.cancelBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cancelBtn.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelBtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.cancelBtn.Location = new System.Drawing.Point(214, 543);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(87, 47);
            this.cancelBtn.TabIndex = 20;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = false;
            // 
            // saveBtn
            // 
            this.saveBtn.BackColor = System.Drawing.Color.DarkSlateGray;
            this.saveBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.saveBtn.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveBtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.saveBtn.Location = new System.Drawing.Point(85, 543);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(87, 47);
            this.saveBtn.TabIndex = 21;
            this.saveBtn.Text = "Save";
            this.saveBtn.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(69, 110);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(239, 34);
            this.label1.TabIndex = 22;
            this.label1.Text = "Customer Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(69, 369);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(148, 34);
            this.label2.TabIndex = 24;
            this.label2.Text = "End Time:";
            // 
            // endTimeTextBox
            // 
            this.endTimeTextBox.Location = new System.Drawing.Point(223, 369);
            this.endTimeTextBox.Multiline = true;
            this.endTimeTextBox.Name = "endTimeTextBox";
            this.endTimeTextBox.Size = new System.Drawing.Size(331, 39);
            this.endTimeTextBox.TabIndex = 23;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(69, 279);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(163, 34);
            this.label3.TabIndex = 26;
            this.label3.Text = "Start Time:";
            // 
            // startTimeTextBox
            // 
            this.startTimeTextBox.Location = new System.Drawing.Point(248, 279);
            this.startTimeTextBox.Multiline = true;
            this.startTimeTextBox.Name = "startTimeTextBox";
            this.startTimeTextBox.Size = new System.Drawing.Size(331, 39);
            this.startTimeTextBox.TabIndex = 25;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(69, 189);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(266, 34);
            this.label4.TabIndex = 28;
            this.label4.Text = "Appointment Type:";
            // 
            // apptTextBox
            // 
            this.apptTextBox.Location = new System.Drawing.Point(341, 189);
            this.apptTextBox.Multiline = true;
            this.apptTextBox.Name = "apptTextBox";
            this.apptTextBox.Size = new System.Drawing.Size(331, 39);
            this.apptTextBox.TabIndex = 27;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(69, 450);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(119, 34);
            this.label5.TabIndex = 30;
            this.label5.Text = "User ID:";
            // 
            // userIDTextBox
            // 
            this.userIDTextBox.Location = new System.Drawing.Point(214, 445);
            this.userIDTextBox.Multiline = true;
            this.userIDTextBox.Name = "userIDTextBox";
            this.userIDTextBox.Size = new System.Drawing.Size(331, 39);
            this.userIDTextBox.TabIndex = 29;
            // 
            // appointmentsDGV
            // 
            this.appointmentsDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.appointmentsDGV.Location = new System.Drawing.Point(749, 110);
            this.appointmentsDGV.Name = "appointmentsDGV";
            this.appointmentsDGV.RowHeadersWidth = 62;
            this.appointmentsDGV.RowTemplate.Height = 28;
            this.appointmentsDGV.Size = new System.Drawing.Size(689, 374);
            this.appointmentsDGV.TabIndex = 31;
            // 
            // editBtn
            // 
            this.editBtn.BackColor = System.Drawing.Color.DarkSlateGray;
            this.editBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.editBtn.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editBtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.editBtn.Location = new System.Drawing.Point(1351, 507);
            this.editBtn.Name = "editBtn";
            this.editBtn.Size = new System.Drawing.Size(87, 47);
            this.editBtn.TabIndex = 32;
            this.editBtn.Text = "Edit ";
            this.editBtn.UseVisualStyleBackColor = false;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.label7.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label7.Location = new System.Drawing.Point(136, 27);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(373, 38);
            this.label7.TabIndex = 33;
            this.label7.Text = "Appointment Scheduler";
            // 
            // AppointmentsFrom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.ClientSize = new System.Drawing.Size(1504, 606);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.editBtn);
            this.Controls.Add(this.appointmentsDGV);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.userIDTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.apptTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.startTimeTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.endTimeTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.label6);
            this.Name = "AppointmentsFrom";
            this.Text = "Schedule an Appointment ";
            ((System.ComponentModel.ISupportInitialize)(this.appointmentsDGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox endTimeTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox startTimeTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox apptTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox userIDTextBox;
        private System.Windows.Forms.DataGridView appointmentsDGV;
        private System.Windows.Forms.Button editBtn;
        private System.Windows.Forms.Label label7;
    }
}