namespace RentVideoSystem
{
    partial class Booking
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
            this.panel5 = new System.Windows.Forms.Panel();
            this.videoCB = new System.Windows.Forms.ComboBox();
            this.customerCB = new System.Windows.Forms.ComboBox();
            this.endDate = new System.Windows.Forms.DateTimePicker();
            this.startDate = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.saveBtn = new System.Windows.Forms.Button();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.White;
            this.panel5.Controls.Add(this.videoCB);
            this.panel5.Controls.Add(this.customerCB);
            this.panel5.Controls.Add(this.endDate);
            this.panel5.Controls.Add(this.startDate);
            this.panel5.Controls.Add(this.label5);
            this.panel5.Controls.Add(this.label4);
            this.panel5.Controls.Add(this.label3);
            this.panel5.Controls.Add(this.label2);
            this.panel5.Controls.Add(this.saveBtn);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.ForeColor = System.Drawing.Color.Gray;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(650, 350);
            this.panel5.TabIndex = 20;
            this.panel5.Tag = "603";
            // 
            // videoCB
            // 
            this.videoCB.BackColor = System.Drawing.Color.White;
            this.videoCB.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.videoCB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.videoCB.FormattingEnabled = true;
            this.videoCB.Location = new System.Drawing.Point(42, 181);
            this.videoCB.Name = "videoCB";
            this.videoCB.Size = new System.Drawing.Size(353, 40);
            this.videoCB.TabIndex = 33;
            this.videoCB.SelectedIndexChanged += new System.EventHandler(this.videoCB_SelectedIndexChanged);
            // 
            // customerCB
            // 
            this.customerCB.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.customerCB.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.customerCB.BackColor = System.Drawing.Color.White;
            this.customerCB.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customerCB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.customerCB.FormattingEnabled = true;
            this.customerCB.Location = new System.Drawing.Point(42, 79);
            this.customerCB.Name = "customerCB";
            this.customerCB.Size = new System.Drawing.Size(353, 40);
            this.customerCB.TabIndex = 33;
            this.customerCB.SelectedIndexChanged += new System.EventHandler(this.customerCB_SelectedIndexChanged);
            // 
            // endDate
            // 
            this.endDate.CalendarFont = new System.Drawing.Font("Segoe UI", 12F);
            this.endDate.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.endDate.CalendarTitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.endDate.CalendarTrailingForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.endDate.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.endDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.endDate.Location = new System.Drawing.Point(423, 180);
            this.endDate.Name = "endDate";
            this.endDate.Size = new System.Drawing.Size(183, 42);
            this.endDate.TabIndex = 31;
            // 
            // startDate
            // 
            this.startDate.CalendarFont = new System.Drawing.Font("Segoe UI", 12F);
            this.startDate.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.startDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.startDate.Location = new System.Drawing.Point(423, 79);
            this.startDate.Name = "startDate";
            this.startDate.Size = new System.Drawing.Size(184, 42);
            this.startDate.TabIndex = 30;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label5.Location = new System.Drawing.Point(423, 140);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(123, 32);
            this.label5.TabIndex = 14;
            this.label5.Text = "Due Date ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label4.Location = new System.Drawing.Point(423, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(167, 32);
            this.label4.TabIndex = 13;
            this.label4.Text = "Booking Date ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(42, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(189, 32);
            this.label3.TabIndex = 12;
            this.label3.Text = "Customer Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(42, 140);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 32);
            this.label2.TabIndex = 11;
            this.label2.Text = "Video Title";
            // 
            // saveBtn
            // 
            this.saveBtn.BackColor = System.Drawing.Color.Gray;
            this.saveBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.saveBtn.FlatAppearance.BorderSize = 0;
            this.saveBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveBtn.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveBtn.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.saveBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.saveBtn.Location = new System.Drawing.Point(184, 258);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(280, 51);
            this.saveBtn.TabIndex = 32;
            this.saveBtn.Text = "Save";
            this.saveBtn.UseVisualStyleBackColor = false;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // Booking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(650, 350);
            this.Controls.Add(this.panel5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Booking";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Booking";
            this.TopMost = true;
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.DateTimePicker endDate;
        private System.Windows.Forms.DateTimePicker startDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.ComboBox videoCB;
        private System.Windows.Forms.ComboBox customerCB;
    }
}