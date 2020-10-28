using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;
using Discord.Commands;
using System.Security.Cryptography.X509Certificates;

namespace ForgottenBot.Modules.Admin
{
    public class Servers : ModuleBase<SocketCommandContext>
    {
        [Command("servers")]
        [RequireOwner]
        public async Task ServersAsync()
        {
            try
            {
                List<SocketGuild> guilds = Context.Client.Guilds.ToList();

                foreach (SocketGuild guild in guilds)
                {
                    EmbedBuilder embed = new EmbedBuilder()
                        .AddField("User Count", $"{guild.MemberCount}", true)
                        .AddField("Server Tier", $"{guild.PremiumTier}", true)
                        .WithTitle($"{guild.Name}")
                        .WithThumbnailUrl($"{guild.IconUrl}")
                        .AddField("Default Channel", $"{guild.DefaultChannel}");

                    await ReplyAsync("", false, embed.Build());
                }
            }
            catch (Exception)
            {
            }
        }

        [Command("server")]
        [RequireUserPermission(GuildPermission.Administrator)]
        public async Task ServerAsync()
        {
            try
            {
                SocketGuild guild = Context.Guild;

                SocketGuild fullGuild = Context.Client.GetGuild(guild.Id);

                EmbedBuilder embed = new EmbedBuilder()
                    .AddField("User Count", $"{fullGuild.MemberCount}", true)
                    .AddField("Server Tier", $"{fullGuild.PremiumTier}", true)
                    .WithTitle($"{fullGuild.Name}")
                    .WithThumbnailUrl($"{fullGuild.IconUrl}")
                    .AddField("Default Channel", $"{fullGuild.DefaultChannel}");

                foreach (SocketRole role in fullGuild.Roles.Where(x => x.Members.Count() > 0).OrderByDescending(x => x.Position))
                {
                    embed.AddField($"{role.Name}", $"User Count: {role.Members.Count()}" +
                        $"\r\n Position: {role.Position} " +
                        $"\r\n Administrator: {role.Permissions.Administrator}" +
                        $"\r\n Manage Server: {role.Permissions.ManageGuild}" +
                        $"\r\n Manage Roles: {role.Permissions.ManageRoles}" +
                        $"\r\n Can Ban: {role.Permissions.BanMembers}" +
                        $"\r\n Can Kick: {role.Permissions.KickMembers}", true);
                }

                await ReplyAsync("", false, embed.Build());
            }
            catch (Exception)
            {
            }
        }
    }
}
