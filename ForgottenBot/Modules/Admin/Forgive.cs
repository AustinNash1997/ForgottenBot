using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System.Linq;
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
        [RequireUserPermission(GuildPermission.BanMembers)]
        public async Task UnBanAsync(SocketUser user)
        {
            IGuildUser guildUser = FindUser(user) as IGuildUser;

            await Context.Guild.RemoveBanAsync(guildUser);
        }

        /// <summary>
        /// Find a user using a mention
        /// </summary>
        /// <param name="user">User being mentioned</param>
        /// <returns>The found user.</returns>
        public SocketUser FindUser(SocketUser user)
        {
            return Context.Guild.Users.SingleOrDefault(x => x.Id == user.Id);
        }
    }
}
