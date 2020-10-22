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
    public class UnMuteAll : ModuleBase<SocketCommandContext>
    {
        [Command("unmuteall")]
        [Alias("unmuteeveryone", "unmutechannel")]
        [RequireUserPermission(Discord.GuildPermission.MuteMembers)]
        public async Task UnMuteAllAsync()
        {
            SocketGuildUser guildUser = (SocketGuildUser)Context.User;
            List<SocketGuildUser> users = guildUser.VoiceChannel.Users.ToList();

            if (users.Count > 0)
            {
                foreach (SocketGuildUser user in users)
                {
                    user.ModifyAsync(x => x.Mute = false).RunSynchronously();//.GetAwaiter().GetResult();
                }
            }
            else
            {
                await ReplyAsync("I'm sorry, I could not find the users in your Voice Channel...");
            }
            await Context.Message.DeleteAsync();
        }

        [Command("help unmuteall")]
        [Alias("help unmuteeveryone", "help unmutechannel")]
        [RequireUserPermission(GuildPermission.MuteMembers)]
        public async Task HelpUnMuteAll()
        {
            EmbedBuilder embedBuilder = new EmbedBuilder()
                .WithTitle("Unmute All")
                .WithDescription("Unmutes everyone in the Voice Channel")
                .AddField("How To Use", "`unmuteall")
                .AddField("Example", "`unmuteall");

            await ReplyAsync("", false, embedBuilder.Build());
        }
    }
}
