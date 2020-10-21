﻿using Discord.Commands;
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
                    user.ModifyAsync(x => x.Mute = true).GetAwaiter().GetResult();
                }
            }
            else
            {
                await ReplyAsync("I'm sorry, I could not find the users in your Voice Channel...");
            }
            await Context.Message.DeleteAsync();
        }
    }
}
