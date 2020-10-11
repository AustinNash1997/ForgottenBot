using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;
using Discord.Commands;

namespace ForgottenBot.Modules.Admin
{
    public class Servers : ModuleBase<SocketCommandContext>
    {
        [Command("servers")]
        [RequireOwner]
        public async Task ServersAsync()
        {
            List<SocketGuild> guilds = Context.Client.Guilds.ToList();

            foreach (SocketGuild guild in guilds)
            {
                EmbedBuilder embed = new EmbedBuilder()
                    .AddField("User Count",$"{guild.Users.Count}", true)
                    .AddField("Server Tier",$"{guild.PremiumTier}", true)
                    .WithTitle($"{guild.Name}")
                    .WithThumbnailUrl($"{guild.Owner.GetAvatarUrl()}")
                    .AddField("Default Channel",$"{guild.DefaultChannel}")
                    .WithFooter($"Server Owner: {guild.Owner.Username}");

                await ReplyAsync("", false, embed.Build());
            }
        }
    }
}
