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

        [Command("help sendMessage")]
        [Alias("help sm", "help send")]
        [RequireUserPermission(GuildPermission.Administrator)]
        public async Task HelpSendMessage()
        {
            EmbedBuilder embedBuilder = new EmbedBuilder()
                .WithTitle("Send Message")
                .WithDescription("Sends a message")
                .AddField("How To Use", "`SendMessage {channel} {Message}")
                .AddField("Channel", "This is the channel you want the message to appear in. Make sure you mention the channel using #ChannelName")
                .AddField("Message", "This is the message that will be displayed.")
                .AddField("Example", "`SendMessage #General Why haven't you subbed to Chris Chronos yet?!?");

            await ReplyAsync("", false, embedBuilder.Build());
        }
    }
}
