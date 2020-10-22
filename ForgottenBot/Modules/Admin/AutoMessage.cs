using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using ForgottenBot.Utility;
using Discord;

namespace ForgottenBot.Modules.Admin
{
    public class AutoMessage : ModuleBase<SocketCommandContext>
    {
        [Command("automessage")]
        [Alias("am", "addautomessage")]
        [RequireUserPermission(Discord.GuildPermission.Administrator)]
        public async Task AutoMessageAsync(int count, [Remainder] string message)
        {
            string fileToRead = $@"E:\DiscordBot\Bot Config\autochat\{Context.Guild.Id}.txt";
            string serverID = Context.Guild.Id.ToString();

            StreamWriter writer = new StreamWriter(fileToRead, true);

            writer.WriteLine($"{serverID}`{count}`{Context.Channel.Id}`{message}");

            writer.Flush();
            writer.Close();

            BotExecution.AddAutoMessage();

            await ReplyAsync($"{message} added to send every {count} messages");
            await Context.Message.DeleteAsync();
        }

        [Command("help automessage")]
        [Alias("help am", "help addautomessage")]
        [RequireUserPermission(GuildPermission.Administrator)]
        public async Task HelpAutoMessage()
        {
            EmbedBuilder embedBuilder = new EmbedBuilder()
                .WithTitle("Auto Message")
                .WithDescription("Adds an auto message")
                .AddField("How To Use", "`AutoMessage {Count} {Message}")
                .AddField("Count", "This is the message count for the message to appear")
                .AddField("Message", "This is the message that will be displayed.")
                .AddField("Example", "`AutoMessage 100 Why haven't you subbed to Chris Chronos yet?!?\r\n`am 100 WHY YOU NO SUB");

            await ReplyAsync("", false, embedBuilder.Build());
        }

    }
}
