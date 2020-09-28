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

namespace ForgottenBot
{
    public partial class ForgottenInterface : Form
    {
        public ForgottenInterface()
        {
            InitializeComponent();
            bgwForgotten.RunWorkerAsync();
        }

        private void bgwForgotten_DoWork(object sender, DoWorkEventArgs e)
        {
            BotExecution botExecution = new BotExecution();
            botExecution.RunBotAsync().GetAwaiter().GetResult();
        }
    }
}
