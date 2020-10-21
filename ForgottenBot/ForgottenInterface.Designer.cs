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
            this.bgwForgotten = new System.ComponentModel.BackgroundWorker();
            this.cboChannels = new System.Windows.Forms.ComboBox();
            this.lblServers = new System.Windows.Forms.Label();
            this.lblChannels = new System.Windows.Forms.Label();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnLoadServers = new System.Windows.Forms.Button();
            this.cboServers = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // bgwForgotten
            // 
            this.bgwForgotten.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwForgotten_DoWork);
            // 
            // cboChannels
            // 
            this.cboChannels.FormattingEnabled = true;
            this.cboChannels.Location = new System.Drawing.Point(81, 86);
            this.cboChannels.Name = "cboChannels";
            this.cboChannels.Size = new System.Drawing.Size(210, 21);
            this.cboChannels.TabIndex = 1;
            // 
            // lblServers
            // 
            this.lblServers.AutoSize = true;
            this.lblServers.Location = new System.Drawing.Point(12, 47);
            this.lblServers.Name = "lblServers";
            this.lblServers.Size = new System.Drawing.Size(46, 13);
            this.lblServers.TabIndex = 2;
            this.lblServers.Text = "Servers:";
            // 
            // lblChannels
            // 
            this.lblChannels.AutoSize = true;
            this.lblChannels.Location = new System.Drawing.Point(12, 89);
            this.lblChannels.Name = "lblChannels";
            this.lblChannels.Size = new System.Drawing.Size(51, 13);
            this.lblChannels.TabIndex = 3;
            this.lblChannels.Text = "Channels";
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(297, 44);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(214, 63);
            this.txtMessage.TabIndex = 4;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(297, 113);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(214, 23);
            this.btnSubmit.TabIndex = 5;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // btnLoadServers
            // 
            this.btnLoadServers.Location = new System.Drawing.Point(175, 113);
            this.btnLoadServers.Name = "btnLoadServers";
            this.btnLoadServers.Size = new System.Drawing.Size(116, 23);
            this.btnLoadServers.TabIndex = 6;
            this.btnLoadServers.Text = "Load Servers";
            this.btnLoadServers.UseVisualStyleBackColor = true;
            this.btnLoadServers.Click += new System.EventHandler(this.btnLoadServers_Click);
            // 
            // cboServers
            // 
            this.cboServers.FormattingEnabled = true;
            this.cboServers.Location = new System.Drawing.Point(81, 44);
            this.cboServers.Name = "cboServers";
            this.cboServers.Size = new System.Drawing.Size(210, 21);
            this.cboServers.TabIndex = 0;
            this.cboServers.SelectedIndexChanged += new System.EventHandler(this.cboServers_SelectedIndexChanged);
            // 
            // ForgottenInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(522, 150);
            this.Controls.Add(this.btnLoadServers);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.lblChannels);
            this.Controls.Add(this.lblServers);
            this.Controls.Add(this.cboChannels);
            this.Controls.Add(this.cboServers);
            this.Name = "ForgottenInterface";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.ForgottenInterface_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.ComponentModel.BackgroundWorker bgwForgotten;
        private System.Windows.Forms.ComboBox cboChannels;
        private System.Windows.Forms.Label lblServers;
        private System.Windows.Forms.Label lblChannels;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnLoadServers;
        private System.Windows.Forms.ComboBox cboServers;
    }
}

