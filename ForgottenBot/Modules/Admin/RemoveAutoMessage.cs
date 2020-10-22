using Discord;
using Discord.Commands;
using Discord.WebSocket;
using ForgottenBot.Models;
using ForgottenBot.Utility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;


namespace ForgottenBot.Modules.Admin
{
    public class RemoveAutoMessage : ModuleBase<SocketCommandContext>
    {
        [Command("RemoveAutoMessage")]
        [Alias("ram","removemessage")]
        [RequireUserPermission(GuildPermission.Administrator)]
        public async Task RemoveAutoMessageAsync(SocketChannel channel, int count, int index)
        {
            string fileToReWrite = $@"E:\DiscordBot\Bot Config\autochat\{Context.Guild.Id}.txt";
            AutoMessageModel itemToRemove = BotExecution.autoMessages.FirstOrDefault(x => x.ServerID == Context.Guild.Id && x.ChannelID == channel.Id && x.MessageCount == count);

            if(itemToRemove != null)
            {
                BotExecution.autoMessages.Remove(itemToRemove);
                itemToRemove.Messages.Remove(itemToRemove.Messages[index]);

                if(itemToRemove.Messages.Count > 0)
                {
                    BotExecution.autoMessages.Add(itemToRemove);
                }

                StreamWriter writer = new StreamWriter(fileToReWrite);
                foreach (AutoMessageModel item in BotExecution.autoMessages.Where(x=> x.ServerID == Context.Guild.Id))
                {
                    string serverId = Context.Guild.Id.ToString();
                    string channelId = item.ChannelID.ToString();
                    string messageCount = item.MessageCount.ToString();
                    foreach (string message in item.Messages)
                    {
                        writer.WriteLine($"{serverId}`{messageCount}`{channelId}`{message}");
                    }
                }
                writer.Flush();
                writer.Close();

                await ReplyAsync("Item has been removed.");
            }
            else
            {
                await ReplyAsync("I could not find the item you wanted to remove.");
            }

        }

        [Command("help removeautomessage")]
        [Alias("help ram", "help removemessage")]
        [RequireUserPermission(GuildPermission.Administrator)]
        public async Task HelpRemoveAutoMessage()
        {
            EmbedBuilder embedBuilder = new EmbedBuilder()
                .WithTitle("Remove Auto Message")
                .WithDescription("Removes the desired auto message")
                .AddField("How To Use", "`RemoveAutoMessage {Channel} {Count} {Index}")
                .AddField("Channel", "Mention the channel by using #ChannelName")
                .AddField("Count", "This is the message count for the message to appear")
                .AddField("Index", "This is the index of the message, use `DisplayAutoMessages to find the index. Please note, all of the items will have their index changed if you remove a message")
                .AddField("Example", "`RemoveAutoMessage #General 100 0\r\n`RemoveMessage #General 100 0\r\n`ram #General 100 0");

            await ReplyAsync("", false, embedBuilder.Build());
        }

    }
}
