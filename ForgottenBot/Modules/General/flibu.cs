using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;
using Discord.Commands;


namespace ForgottenBot.Modules.General
{
    public class flibu : ModuleBase<SocketCommandContext>
    {
        [Command("flibu")]
        [Alias("flibu flibu")]
        public async Task flibuAsync()
        {
            await Context.Message.DeleteAsync();
            await ReplyAsync("Flibu Flibu");
        }
    }
}
