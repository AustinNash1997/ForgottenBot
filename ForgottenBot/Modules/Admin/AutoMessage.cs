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
        [RequireUserPermission(Discord.GuildPermission.Administrator)]
        public async Task AutoMessageAsync(int count, [Remainder] string message)
        {
            string fileToRead = @"E:\DiscordBot\Bot Config\autochat.txt";
            List<string> fileText = File.ReadAllLines(fileToRead).ToList();
            string serverID = Context.Guild.Id.ToString();

            StreamWriter writer = new StreamWriter(fileToRead, true);

            writer.WriteLine($"{serverID}`{count}`{Context.Channel.Id}`{message}");

            writer.Flush();
            writer.Close();

            await ReplyAsync($"{message} added to send every {count} messages");
            await Context.Message.DeleteAsync();
        }
    }
}
