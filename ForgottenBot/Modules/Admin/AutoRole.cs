using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Discord;

namespace ForgottenBot.Modules.Admin
{
    public class AutoRole : ModuleBase<SocketCommandContext>
    {
        [Command("autorole")]
        [Alias("ar")]
        [RequireUserPermission(Discord.GuildPermission.Administrator)]
        public async Task AutoRoleAsync(SocketRole autoRole)
        {
            List<string> fileText = File.ReadAllLines(@"E:\DiscordBot\Bot Config\autoroles.txt").ToList();
            string serverID = Context.Guild.Id.ToString();
            bool roleAlreadyfound = false;

            foreach (string line in fileText)
            {
                string[] splitRecord = line.Split('`');
                if(splitRecord.Count() > 1)
                {
                    if(splitRecord[0] == serverID)
                    {
                        roleAlreadyfound = true;

                        SocketRole foundRole = Context.Guild.GetRole(ulong.Parse(splitRecord[1]));

                        await ReplyAsync($"This server already uses {foundRole.Name} as the default");
                    }
                }
            }

            if(!roleAlreadyfound)
            {
                StreamWriter writer = new StreamWriter(@"E:\DiscordBot\Bot Config\autoroles.txt", true);

                writer.WriteLine($"{serverID}`{autoRole.Id}");

                writer.Flush();
                writer.Close();
            }
            await ReplyAsync($"{autoRole.Name} added as a default");
            await Context.Message.DeleteAsync();
        }

        [Command("help autorole")]
        [Alias("help addautorole", "help ar")]
        [RequireUserPermission(GuildPermission.Administrator)]
        public async Task HelpAutoRole()
        {
            EmbedBuilder embedBuilder = new EmbedBuilder()
                .WithTitle("Auto Role")
                .WithDescription("Add a default role other than \"everyone\"")
                .AddField("How To Use", "`AutoRole {Role}")
                .AddField("Role", "This is the role you would like to set as the default")
                .AddField("Example", "`AutoRole @members");

            await ReplyAsync("", false, embedBuilder.Build());
        }
    }
}
