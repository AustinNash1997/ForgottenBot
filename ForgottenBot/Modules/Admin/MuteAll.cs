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
    public class MuteAll : ModuleBase<SocketCommandContext>
    {
        [Command("muteall")]
        [Alias("muteeveryone", "mutechannel")]
        [RequireUserPermission(Discord.GuildPermission.MuteMembers)]
        public async Task MuteAllAsync()
        {
            SocketGuildUser guildUser = (SocketGuildUser)Context.User;
            List<SocketGuildUser> users = guildUser.VoiceChannel.Users.ToList();

            if(users.Count > 0)
            {
                foreach (SocketGuildUser user in users)
                {
                    user.ModifyAsync(x => x.Mute = true).RunSynchronously();//.GetAwaiter().GetResult();
                }
            }
            else
            {
                await ReplyAsync("I'm sorry, I could not find the users in your Voice Channel...");
            }
            await Context.Message.DeleteAsync();
        }

        [Command("help muteall")]
        [Alias("help muteeveryone", "help mutechannel")]
        [RequireUserPermission(GuildPermission.MuteMembers)]
        public async Task HelpMuteAll()
        {
            EmbedBuilder embedBuilder = new EmbedBuilder()
                .WithTitle("Mute All")
                .WithDescription("Mutes everyone in the Voice Channel")
                .AddField("How To Use", "`muteall")
                .AddField("Example", "`muteall");

            await ReplyAsync("", false, embedBuilder.Build());
        }
    }
}
