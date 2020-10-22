using Discord;
using Discord.Commands;
using Discord.WebSocket;
using ForgottenBot.Utility;
using System.Linq;
using System.Threading.Tasks;

namespace ForgottenBot.Modules.Admin
{
    public class Promote : ModuleBase<SocketCommandContext>
    {
        /// <summary>
        /// Promote a user to a new role!
        /// </summary>
        /// <param name="user">User getting the promotion</param>
        /// <param name="role">New role the user will get.</param>
        /// <returns>An Embed will be sent to congratulate the user.</returns>
        [Command("promote")]
        [RequireUserPermission(GuildPermission.Administrator)]
        public async Task PromoteAsync(SocketUser user, [Remainder] SocketRole role)
        {
            IGuildUser guildUser;
            SocketRole moderator = Context.Guild.Roles.FirstOrDefault(x => x.Name.ToUpper() == "MODERATOR");
            SocketRole admin = Context.Guild.Roles.FirstOrDefault(x => x.Permissions.Administrator);
            Util utility = new Util();

            if (user != null && role != null)
            {
                guildUser = FindUser(user) as IGuildUser;

                await guildUser.AddRoleAsync(role);

                EmbedBuilder builder = new EmbedBuilder();
                builder.AddField("User Promotion", $"{user} has been promoted to the {role.Name} role! __**Congratulations {utility.UserOrNick(user)}!!**__")
                    .WithTitle("Promotion Alert!")
                    .WithCurrentTimestamp()
                    .WithFooter($"Congrats to {user}")
                    .WithThumbnailUrl(user.GetAvatarUrl())
                    .WithColor(Color.LightOrange);

                await ReplyAsync("", false, builder.Build());
                await Context.Message.DeleteAsync();
            }
            else
            {
                await ReplyAsync($"Please enter the username you wish to promote followed by the role.");
            }
        }

        [Command("help promote")]
        [RequireUserPermission(GuildPermission.Administrator)]
        public async Task HelpPromoteAsync()
        {
            EmbedBuilder embedBuilder = new EmbedBuilder()
                .WithTitle("Promote")
                .WithDescription("Promotes a user to a role")
                .AddField("How To Use", "`promote {user} {role}")
                .AddField("User", "This is the user you want to promote. Make sure you mention them with @User.")
                .AddField("Role","This is the role you want to promote the user to. Make sure you mention it @Role.")
                .AddField("Example", "`Promote @Ritual @SugarDaddy");

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

        /// <summary>
        /// Finds the Role
        /// </summary>
        /// <param name="role">Name of the role to find.</param>
        /// <returns>Role that was found.</returns>
        public IRole FindRole(string role)
        {
            return Context.Guild.Roles.SingleOrDefault(x => x.Name.ToLower().Equals(role.ToLower()));
        }
    }
}
