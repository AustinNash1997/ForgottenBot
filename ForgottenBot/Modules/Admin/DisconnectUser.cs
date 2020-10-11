using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForgottenBot.Modules.Admin
{
    public class DisconnectUser : ModuleBase<SocketCommandContext>
    {
        [Command("disconnect")]
        [Alias("disconnectUser", "dc")]
        [RequireUserPermission(Discord.GuildPermission.BanMembers)]
        public async Task DisconnectUserAsync(SocketUser userToDC)
        {
            SocketGuildUser user = Context.Guild.VoiceChannels.Where(x => x.Users.Contains(userToDC)).FirstOrDefault().Users.FirstOrDefault(x=>x.Username == userToDC.Username);

            if (user.Username != null)
            {
                await user.ModifyAsync(x => x.Channel = null);
            }
            else
            {
                await ReplyAsync("I'm sorry, I could not find the users in your Voice Channel...");
            }
            await Context.Message.DeleteAsync();
        }
    }
}
