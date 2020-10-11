using Discord;
using Discord.Commands;
using Discord.WebSocket;
using ForgottenBot.Utility;
using System.Linq;
using System.Threading.Tasks;

namespace ForgottenBot.Modules.Admin
{
    public class Ban : ModuleBase<SocketCommandContext>
    {
        Util utility = new Util();

        /// <summary>
        /// Bans a user
        /// </summary>
        /// <param name="user">User to be banned.</param>
        /// <returns>A message will be sent to the user.</returns>
        [Command("ban")]
        [RequireUserPermission(GuildPermission.BanMembers)]
        public async Task BanAsync(SocketUser user)
        {
            IGuildUser guildUser = FindUser(user) as IGuildUser;

            await ReplyAsync($"{user} has been banned! :hammer:");
            await guildUser.SendMessageAsync(":hammer: You have received the BAN HAMMER :hammer:  ");
            await Context.Guild.AddBanAsync(guildUser);
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
