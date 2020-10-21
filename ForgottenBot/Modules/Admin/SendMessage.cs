using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForgottenBot.Modules.Admin
{
    public class SendMessage : ModuleBase<SocketCommandContext>
    {
        [Command("sendMessage")]
        [Alias("sm","send")]
        [RequireUserPermission(GuildPermission.Administrator)]
        public async Task SendMessageAsync(SocketChannel channelToSend, [Remainder] string textToSend)
        {
            if(channelToSend != null)
            {
                if(!string.IsNullOrEmpty(textToSend))
                {
                    ITextChannel textChannel = (ITextChannel)channelToSend;
                    await textChannel.SendMessageAsync(textToSend);
                }
            }
        }
    }
}
