using Discord;
using Discord.Commands;
using Discord.WebSocket;
using ForgottenBot.Models;
using ForgottenBot.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace ForgottenBot.Modules.Admin
{
    public class DisplayAutoMessages : ModuleBase<SocketCommandContext>
    {
        [Command("DisplayAutoMessages")]
        [Alias("dam","displaymessages")]
        [RequireUserPermission(GuildPermission.Administrator)]
        public async Task DisplayAutoMessagesASync()
        {
            List<AutoMessageModel> autoMessages = BotExecution.autoMessages.Where(x=> x.ServerID == Context.Guild.Id).ToList();

            foreach (AutoMessageModel item in autoMessages)
            {
                int messageIndex = 0;
                SocketChannel channel = Context.Guild.GetChannel(item.ChannelID);
                int breakCount = 0; 
                List<String> messages = item.Messages;
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.AppendLine($@"__Auto Messages for **{channel}** every **{item.MessageCount}** messages__");
                foreach (string message in messages)
                {
                    stringBuilder.AppendLine($"{messageIndex} - {message}");
                    messageIndex++;
                    breakCount++;
                    if (breakCount > 20)
                    {
                        await ReplyAsync(stringBuilder.ToString());
                        stringBuilder = new StringBuilder();
                        breakCount = 0;
                    }
                }
                if(stringBuilder.ToString().Length > 0)
                {
                    await ReplyAsync(stringBuilder.ToString());

                }
            }

        }

        [Command("help displayautomessage")]
        [Alias("help dam", "help displaymessages")]
        public async Task HelpDisplayMessagesAsync()
        {
            EmbedBuilder embedBuilder = new EmbedBuilder()
                .WithTitle("Display Auto Message")
                .WithDescription("Displays all auto messages for a Server")
                .AddField("How To Use", "`DisplayAutoMessages")
                .AddField("Example", "`DisplayAutoMessages\r\n`DisplayMessages\r\n`dam");

            await ReplyAsync("", false, embedBuilder.Build());
        }
    }
}
