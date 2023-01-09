namespace DMX_Artnet
{
    partial class Form_Main
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.Btn_Close = new System.Windows.Forms.Button();
            this.Label_Title = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.List_Serial = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Text_IPAddress = new System.Windows.Forms.TextBox();
            this.Btn_Start = new System.Windows.Forms.Button();
            this.Btn_Stop = new System.Windows.Forms.Button();
            this.RichText_Logs = new System.Windows.Forms.RichTextBox();
            this.Label_DMXReceived = new System.Windows.Forms.Label();
            this.Label_PollReceived = new System.Windows.Forms.Label();
            this.Checkbox_DMXPacketLogs = new System.Windows.Forms.CheckBox();
            this.Checkbox_PollPacketLogs = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // Btn_Close
            // 
            this.Btn_Close.FlatAppearance.BorderSize = 0;
            this.Btn_Close.FlatAppearance.MouseOverBackColor = System.Drawing.Color.RoyalBlue;
            this.Btn_Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Close.Font = new System.Drawing.Font("Marlett", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Close.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.Btn_Close.Location = new System.Drawing.Point(1135, 1);
            this.Btn_Close.Name = "Btn_Close";
            this.Btn_Close.Size = new System.Drawing.Size(75, 23);
            this.Btn_Close.TabIndex = 3;
            this.Btn_Close.Text = "X";
            this.Btn_Close.UseVisualStyleBackColor = true;
            this.Btn_Close.Click += new System.EventHandler(this.Btn_Close_Click);
            // 
            // Label_Title
            // 
            this.Label_Title.AutoSize = true;
            this.Label_Title.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_Title.ForeColor = System.Drawing.SystemColors.Menu;
            this.Label_Title.Location = new System.Drawing.Point(12, 1);
            this.Label_Title.Name = "Label_Title";
            this.Label_Title.Size = new System.Drawing.Size(185, 18);
            this.Label_Title.TabIndex = 6;
            this.Label_Title.Text = "DMX from ArtNet Adapter";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label1.Location = new System.Drawing.Point(18, 189);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Port série";
            // 
            // List_Serial
            // 
            this.List_Serial.FormattingEnabled = true;
            this.List_Serial.Location = new System.Drawing.Point(109, 186);
            this.List_Serial.Name = "List_Serial";
            this.List_Serial.Size = new System.Drawing.Size(291, 21);
            this.List_Serial.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label2.Location = new System.Drawing.Point(18, 162);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Adresse IP";
            // 
            // Text_IPAddress
            // 
            this.Text_IPAddress.Location = new System.Drawing.Point(109, 160);
            this.Text_IPAddress.Name = "Text_IPAddress";
            this.Text_IPAddress.Size = new System.Drawing.Size(291, 20);
            this.Text_IPAddress.TabIndex = 12;
            this.Text_IPAddress.Text = "192.168.1.44";
            // 
            // Btn_Start
            // 
            this.Btn_Start.Location = new System.Drawing.Point(109, 230);
            this.Btn_Start.Name = "Btn_Start";
            this.Btn_Start.Size = new System.Drawing.Size(75, 23);
            this.Btn_Start.TabIndex = 13;
            this.Btn_Start.Text = "Start";
            this.Btn_Start.UseVisualStyleBackColor = true;
            this.Btn_Start.Click += new System.EventHandler(this.Btn_Start_Click);
            // 
            // Btn_Stop
            // 
            this.Btn_Stop.Enabled = false;
            this.Btn_Stop.Location = new System.Drawing.Point(190, 230);
            this.Btn_Stop.Name = "Btn_Stop";
            this.Btn_Stop.Size = new System.Drawing.Size(75, 23);
            this.Btn_Stop.TabIndex = 14;
            this.Btn_Stop.Text = "Stop";
            this.Btn_Stop.UseVisualStyleBackColor = true;
            this.Btn_Stop.Click += new System.EventHandler(this.Btn_Stop_Click);
            // 
            // RichText_Logs
            // 
            this.RichText_Logs.BackColor = System.Drawing.Color.RoyalBlue;
            this.RichText_Logs.Location = new System.Drawing.Point(499, 61);
            this.RichText_Logs.Name = "RichText_Logs";
            this.RichText_Logs.Size = new System.Drawing.Size(697, 377);
            this.RichText_Logs.TabIndex = 15;
            this.RichText_Logs.Text = "";
            // 
            // Label_DMXReceived
            // 
            this.Label_DMXReceived.AutoSize = true;
            this.Label_DMXReceived.BackColor = System.Drawing.Color.RoyalBlue;
            this.Label_DMXReceived.Location = new System.Drawing.Point(13, 425);
            this.Label_DMXReceived.Name = "Label_DMXReceived";
            this.Label_DMXReceived.Size = new System.Drawing.Size(80, 13);
            this.Label_DMXReceived.TabIndex = 16;
            this.Label_DMXReceived.Text = "DMX Received";
            // 
            // Label_PollReceived
            // 
            this.Label_PollReceived.AutoSize = true;
            this.Label_PollReceived.BackColor = System.Drawing.Color.RoyalBlue;
            this.Label_PollReceived.Location = new System.Drawing.Point(99, 425);
            this.Label_PollReceived.Name = "Label_PollReceived";
            this.Label_PollReceived.Size = new System.Drawing.Size(73, 13);
            this.Label_PollReceived.TabIndex = 17;
            this.Label_PollReceived.Text = "Poll Received";
            // 
            // Checkbox_DMXPacketLogs
            // 
            this.Checkbox_DMXPacketLogs.AutoSize = true;
            this.Checkbox_DMXPacketLogs.Checked = true;
            this.Checkbox_DMXPacketLogs.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Checkbox_DMXPacketLogs.Location = new System.Drawing.Point(499, 38);
            this.Checkbox_DMXPacketLogs.Name = "Checkbox_DMXPacketLogs";
            this.Checkbox_DMXPacketLogs.Size = new System.Drawing.Size(92, 17);
            this.Checkbox_DMXPacketLogs.TabIndex = 18;
            this.Checkbox_DMXPacketLogs.Text = "DMX Packets";
            this.Checkbox_DMXPacketLogs.UseVisualStyleBackColor = true;
            // 
            // Checkbox_PollPacketLogs
            // 
            this.Checkbox_PollPacketLogs.AutoSize = true;
            this.Checkbox_PollPacketLogs.Checked = true;
            this.Checkbox_PollPacketLogs.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Checkbox_PollPacketLogs.Location = new System.Drawing.Point(597, 38);
            this.Checkbox_PollPacketLogs.Name = "Checkbox_PollPacketLogs";
            this.Checkbox_PollPacketLogs.Size = new System.Drawing.Size(85, 17);
            this.Checkbox_PollPacketLogs.TabIndex = 19;
            this.Checkbox_PollPacketLogs.Text = "Poll Packets";
            this.Checkbox_PollPacketLogs.UseVisualStyleBackColor = true;
            // 
            // Form_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MidnightBlue;
            this.ClientSize = new System.Drawing.Size(1208, 450);
            this.Controls.Add(this.Checkbox_PollPacketLogs);
            this.Controls.Add(this.Checkbox_DMXPacketLogs);
            this.Controls.Add(this.Label_PollReceived);
            this.Controls.Add(this.Label_DMXReceived);
            this.Controls.Add(this.RichText_Logs);
            this.Controls.Add(this.Btn_Stop);
            this.Controls.Add(this.Btn_Start);
            this.Controls.Add(this.Text_IPAddress);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.List_Serial);
            this.Controls.Add(this.Label_Title);
            this.Controls.Add(this.Btn_Close);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form_Main";
            this.Text = "Form_Main";
            this.Load += new System.EventHandler(this.Form_Main_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form_Main_MouseDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Btn_Close;
        private System.Windows.Forms.Label Label_Title;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox List_Serial;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Text_IPAddress;
        private System.Windows.Forms.Button Btn_Start;
        private System.Windows.Forms.Button Btn_Stop;
        private System.Windows.Forms.RichTextBox RichText_Logs;
        private System.Windows.Forms.Label Label_DMXReceived;
        private System.Windows.Forms.Label Label_PollReceived;
        private System.Windows.Forms.CheckBox Checkbox_DMXPacketLogs;
        private System.Windows.Forms.CheckBox Checkbox_PollPacketLogs;
    }
}

