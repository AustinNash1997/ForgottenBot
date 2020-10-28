namespace ForgottenBot
{
    partial class ForgottenInterface
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ForgottenInterface));
            this.bgwForgotten = new System.ComponentModel.BackgroundWorker();
            this.cboChannels = new System.Windows.Forms.ComboBox();
            this.lblServers = new System.Windows.Forms.Label();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnLoadServers = new System.Windows.Forms.Button();
            this.cboServers = new System.Windows.Forms.ComboBox();
            this.cboVoiceChannels = new System.Windows.Forms.ComboBox();
            this.btnMuteAll = new System.Windows.Forms.Button();
            this.btnUnMute = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // bgwForgotten
            // 
            this.bgwForgotten.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwForgotten_DoWork);
            // 
            // cboChannels
            // 
            this.cboChannels.BackColor = System.Drawing.Color.DarkGray;
            this.cboChannels.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboChannels.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboChannels.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboChannels.FormattingEnabled = true;
            this.cboChannels.Location = new System.Drawing.Point(6, 19);
            this.cboChannels.Name = "cboChannels";
            this.cboChannels.Size = new System.Drawing.Size(361, 24);
            this.cboChannels.TabIndex = 1;
            // 
            // lblServers
            // 
            this.lblServers.AutoSize = true;
            this.lblServers.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblServers.Location = new System.Drawing.Point(12, 46);
            this.lblServers.Name = "lblServers";
            this.lblServers.Size = new System.Drawing.Size(61, 17);
            this.lblServers.TabIndex = 2;
            this.lblServers.Text = "Servers:";
            // 
            // txtMessage
            // 
            this.txtMessage.BackColor = System.Drawing.Color.Silver;
            this.txtMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMessage.Location = new System.Drawing.Point(6, 49);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(361, 126);
            this.txtMessage.TabIndex = 4;
            // 
            // btnSubmit
            // 
            this.btnSubmit.BackColor = System.Drawing.Color.Transparent;
            this.btnSubmit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSubmit.BackgroundImage")));
            this.btnSubmit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSubmit.FlatAppearance.BorderSize = 0;
            this.btnSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubmit.ForeColor = System.Drawing.SystemColors.Highlight;
            this.btnSubmit.Location = new System.Drawing.Point(338, 204);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(29, 24);
            this.btnSubmit.TabIndex = 5;
            this.btnSubmit.UseVisualStyleBackColor = false;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // btnLoadServers
            // 
            this.btnLoadServers.BackColor = System.Drawing.Color.Transparent;
            this.btnLoadServers.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnLoadServers.BackgroundImage")));
            this.btnLoadServers.FlatAppearance.BorderSize = 0;
            this.btnLoadServers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoadServers.ForeColor = System.Drawing.Color.Transparent;
            this.btnLoadServers.Location = new System.Drawing.Point(353, 31);
            this.btnLoadServers.Name = "btnLoadServers";
            this.btnLoadServers.Size = new System.Drawing.Size(35, 35);
            this.btnLoadServers.TabIndex = 6;
            this.btnLoadServers.UseVisualStyleBackColor = false;
            this.btnLoadServers.Click += new System.EventHandler(this.btnLoadServers_Click);
            // 
            // cboServers
            // 
            this.cboServers.BackColor = System.Drawing.Color.DarkGray;
            this.cboServers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboServers.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboServers.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboServers.FormattingEnabled = true;
            this.cboServers.Location = new System.Drawing.Point(81, 41);
            this.cboServers.Name = "cboServers";
            this.cboServers.Size = new System.Drawing.Size(266, 24);
            this.cboServers.TabIndex = 0;
            this.cboServers.SelectedIndexChanged += new System.EventHandler(this.cboServers_SelectedIndexChanged);
            // 
            // cboVoiceChannels
            // 
            this.cboVoiceChannels.BackColor = System.Drawing.Color.DarkGray;
            this.cboVoiceChannels.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboVoiceChannels.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboVoiceChannels.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboVoiceChannels.FormattingEnabled = true;
            this.cboVoiceChannels.Location = new System.Drawing.Point(6, 34);
            this.cboVoiceChannels.Name = "cboVoiceChannels";
            this.cboVoiceChannels.Size = new System.Drawing.Size(364, 24);
            this.cboVoiceChannels.TabIndex = 7;
            // 
            // btnMuteAll
            // 
            this.btnMuteAll.BackColor = System.Drawing.Color.Transparent;
            this.btnMuteAll.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMuteAll.BackgroundImage")));
            this.btnMuteAll.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnMuteAll.FlatAppearance.BorderSize = 0;
            this.btnMuteAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMuteAll.ForeColor = System.Drawing.SystemColors.Highlight;
            this.btnMuteAll.Location = new System.Drawing.Point(6, 107);
            this.btnMuteAll.Name = "btnMuteAll";
            this.btnMuteAll.Size = new System.Drawing.Size(46, 44);
            this.btnMuteAll.TabIndex = 8;
            this.btnMuteAll.UseVisualStyleBackColor = false;
            this.btnMuteAll.Click += new System.EventHandler(this.btnMuteAll_Click);
            // 
            // btnUnMute
            // 
            this.btnUnMute.BackColor = System.Drawing.Color.Transparent;
            this.btnUnMute.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnUnMute.BackgroundImage")));
            this.btnUnMute.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnUnMute.FlatAppearance.BorderSize = 0;
            this.btnUnMute.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUnMute.ForeColor = System.Drawing.SystemColors.Highlight;
            this.btnUnMute.Location = new System.Drawing.Point(49, 105);
            this.btnUnMute.Name = "btnUnMute";
            this.btnUnMute.Size = new System.Drawing.Size(46, 44);
            this.btnUnMute.TabIndex = 9;
            this.btnUnMute.UseVisualStyleBackColor = false;
            this.btnUnMute.Click += new System.EventHandler(this.btnUnMute_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 29);
            this.label1.TabIndex = 10;
            this.label1.Text = "CHRIS BOT";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Gray;
            this.groupBox1.Controls.Add(this.cboChannels);
            this.groupBox1.Controls.Add(this.txtMessage);
            this.groupBox1.Controls.Add(this.btnSubmit);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBox1.Font = new System.Drawing.Font("MV Boli", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.Desktop;
            this.groupBox1.Location = new System.Drawing.Point(15, 84);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(373, 234);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Text Channels";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Gray;
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.btnUnMute);
            this.groupBox2.Controls.Add(this.cboVoiceChannels);
            this.groupBox2.Controls.Add(this.btnMuteAll);
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBox2.Font = new System.Drawing.Font("MV Boli", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.SystemColors.Desktop;
            this.groupBox2.Location = new System.Drawing.Point(12, 324);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(376, 155);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Voice Channels";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.button1.Location = new System.Drawing.Point(323, 107);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(47, 42);
            this.button1.TabIndex = 10;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ForgottenInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(401, 491);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnLoadServers);
            this.Controls.Add(this.lblServers);
            this.Controls.Add(this.cboServers);
            this.MaximizeBox = false;
            this.Name = "ForgottenInterface";
            this.Text = "Chris Bot";
            this.Load += new System.EventHandler(this.ForgottenInterface_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.ComponentModel.BackgroundWorker bgwForgotten;
        private System.Windows.Forms.ComboBox cboChannels;
        private System.Windows.Forms.Label lblServers;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnLoadServers;
        private System.Windows.Forms.ComboBox cboServers;
        private System.Windows.Forms.ComboBox cboVoiceChannels;
        private System.Windows.Forms.Button btnMuteAll;
        private System.Windows.Forms.Button btnUnMute;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button1;
    }
}

