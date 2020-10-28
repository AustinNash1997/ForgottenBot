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

            await ReplyAsync($"{user} has been banned! :hammer: Get out of here! We don't want you here!");
            await guildUser.SendMessageAsync(":hammer: You have received the BAN HAMMER :hammer:  ");
            await Context.Guild.AddBanAsync(guildUser);
        }

        [Command("help ban")]
        [RequireUserPermission(GuildPermission.BanMembers)]
        public async Task HelpBan()
        {
            EmbedBuilder embedBuilder = new EmbedBuilder()
                .WithTitle("BAN")
                .WithDescription("Ban a naughty user")
                .AddField("How To Use", "`Ban {user} ")
                .AddField("User", "This is the user you want to BAN. Make sure to mention them using @User")
                .AddField("Example", "`Ban @member");

            await ReplyAsync("", false, embedBuilder.Build());
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
