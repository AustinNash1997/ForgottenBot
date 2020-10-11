﻿using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForgottenBot.Modules.Admin
{
    public class UnMuteUser : ModuleBase<SocketCommandContext>
    {
        [Command("unmuteuser")]
        [Alias("unmute", "speak")]
        [RequireUserPermission(Discord.GuildPermission.MuteMembers)]
        public async Task UnMuteUserAsync(SocketUser userToMute)
        {
            SocketGuildUser user = Context.Guild.VoiceChannels.Where(x => x.Users.Contains(Context.User)).FirstOrDefault().Users.FirstOrDefault(x=> x.Username == userToMute.Username);

            if(!string.IsNullOrEmpty(user.Username))
            {
                await user.ModifyAsync(x => x.Mute = false);
            }
            else
            {
                await ReplyAsync($"I'm sorry, I could not find {userToMute.Username} connected to a channel");
            }
            await Context.Message.DeleteAsync();
        }
    }
}
