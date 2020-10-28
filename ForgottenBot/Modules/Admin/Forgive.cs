using Discord;
using Discord.Commands;
using Discord.Rest;
using Discord.WebSocket;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace ForgottenBot.Modules.Admin
{
    public class Forgive : ModuleBase<SocketCommandContext>
    {
        /// <summary>
        /// Remove a ban
        /// </summary>
        /// <param name="user">User to be forgiven</param>
        [Command("forgive")]
        [Alias("unban")]
        [RequireUserPermission(GuildPermission.BanMembers)]
        public async Task UnBanAsync(string user)
        {
            IGuildUser guildUser;

            List<RestBan> bans = Context.Guild.GetBansAsync().GetAwaiter().GetResult().ToList();

            RestBan foundUser = bans.FirstOrDefault(x => x.User.Username.ToLower().Trim() == user.ToLower().Trim());
            if(foundUser != null)
            {
                guildUser = Context.Guild.Users.FirstOrDefault(x => x.Id == foundUser.User.Id);

                if (guildUser != null)
                {
                    await Context.Guild.RemoveBanAsync(guildUser);
                    await ReplyAsync($"*sigh* I guess we forgive you {guildUser.Username}....");
                }
                else
                {
                    await ReplyAsync("I count not find the user, are you sure they are banned?");
                }
            }
            else
            {
                await ReplyAsync("I could not find that user on the ban list.");
            }

            await Context.Message.DeleteAsync();
            
        }
    }
}
