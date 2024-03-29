﻿using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForgottenBot.Modules.Admin
{
    public class DisconnectAll : ModuleBase<SocketCommandContext>
    {
        [Command("disconnectAll")]
        [Alias("dcAll", "disconnectChannel")]
        [RequireUserPermission(Discord.GuildPermission.BanMembers)]
        public async Task DisconnectAllAsync()
        {
            List<SocketGuildUser> users = Context.Guild.VoiceChannels.Where(x => x.Users.Contains(Context.User)).FirstOrDefault().Users.ToList();

            if (users.Count > 0)
            {
                foreach (SocketGuildUser user in users)
                {
                    await user.ModifyAsync(x => x.Channel = null);
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
