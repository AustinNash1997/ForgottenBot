using Discord;
using Discord.WebSocket;
using ForgottenBot.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace ForgottenBot
{
    public partial class ForgottenInterface : Form
    {
        BotExecution botExecution = new BotExecution();
        public ForgottenInterface()
        {
            InitializeComponent();
            bgwForgotten.RunWorkerAsync();
        }

        private void bgwForgotten_DoWork(object sender, DoWorkEventArgs e)
        {
            botExecution.RunBotAsync().GetAwaiter().GetResult();
        }

        private void ForgottenInterface_Load(object sender, EventArgs e)
        {
            
        }

        private void cboServers_SelectedIndexChanged(object sender, EventArgs e)
        {
            SocketGuild selectedServer = (SocketGuild)cboServers.SelectedItem;
            cboChannels.DataSource = null;
            cboChannels.DataSource = selectedServer.TextChannels.OrderBy(x => x.Position).ToList();

            cboVoiceChannels.DataSource = null;
            cboVoiceChannels.DataSource = selectedServer.VoiceChannels.OrderBy(x => x.Position).ToList();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if(cboChannels.SelectedItem != null)
            {
                ITextChannel selectedChannel = (ITextChannel)cboChannels.SelectedItem;
                selectedChannel.SendMessageAsync(txtMessage.Text).GetAwaiter().GetResult();
                txtMessage.Text = "";
            }
        }

        private void btnLoadServers_Click(object sender, EventArgs e)
        {
            cboServers.DataSource = null;
            cboServers.DataSource = botExecution.GetServers();
        }

        private void btnMuteAll_Click(object sender, EventArgs e)
        {
            SocketVoiceChannel voiceChannel = (SocketVoiceChannel)cboVoiceChannels.SelectedItem;
            
            if(voiceChannel != null)
            {
                List<SocketGuildUser> users = voiceChannel.Users.ToList();

                if (users.Count > 0)
                {
                    foreach (SocketGuildUser user in users)
                    {
                        IGuildUser user1 = (IGuildUser)user;
                        user1.ModifyAsync(x => x.Mute = true).GetAwaiter().GetResult();
                    }
                }
            }
        }

        private void btnUnMute_Click(object sender, EventArgs e)
        {
            SocketVoiceChannel voiceChannel = (SocketVoiceChannel)cboVoiceChannels.SelectedItem;
            
            if(voiceChannel != null)
            {
                List<SocketGuildUser> users = voiceChannel.Users.ToList();

                if (users.Count > 0)
                {
                    foreach (SocketGuildUser user in users)
                    {
                        IGuildUser user1 = (IGuildUser)user;
                        user1.ModifyAsync(x => x.Mute = false).GetAwaiter().GetResult();
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SocketVoiceChannel voiceChannel = (SocketVoiceChannel)cboVoiceChannels.SelectedItem;

            if (voiceChannel != null)
            {
                List<SocketGuildUser> users = voiceChannel.Users.ToList();

                if (users.Count > 0)
                {
                    foreach (SocketGuildUser user in users)
                    {
                        IGuildUser user1 = (IGuildUser)user;
                        user1.ModifyAsync(x => x.Channel = null).GetAwaiter().GetResult();
                    }
                }
            }
        }
    }
}
