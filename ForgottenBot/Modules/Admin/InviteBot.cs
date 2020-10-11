using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ForgottenBot.Modules.Admin
{
    public class InviteBot : ModuleBase<SocketCommandContext>
    {
        [Command("invite")]
        [RequireUserPermission(Discord.GuildPermission.Administrator)]
        public async Task InviteBotAsync()
        {
            await Context.Message.DeleteAsync();
            await ReplyAsync("https://discord.com/api/oauth2/authorize?client_id=504049492908048415&permissions=8&scope=bot");
        }
    }
}
