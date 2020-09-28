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
        public async Task PromoteAsync(SocketUser user, [Remainder] string role)
        {
            IGuildUser guildUser;
            IRole guildRole;
            SocketRole moderator = Context.Guild.Roles.FirstOrDefault(x => x.Name.ToUpper() == "MODERATOR");
            SocketRole admin = Context.Guild.Roles.FirstOrDefault(x => x.Name.ToUpper() == "ADMIN");
            Util utility = new Util();

            if ((Context.User as SocketGuildUser).Roles.Contains(moderator) || (Context.User as SocketGuildUser).Roles.Contains(admin))
            {
                if (user != null && role != string.Empty)
                {
                    guildUser = FindUser(user) as IGuildUser;
                    guildRole = FindRole(role);

                    if (guildRole != null)
                    {
                        if ((guildRole != (moderator as IRole) && guildRole != (admin as IRole)) || (Context.Guild.Owner == Context.User))
                        {
                            await guildUser.AddRoleAsync(guildRole);

                            EmbedBuilder builder = new EmbedBuilder();
                            builder.AddField("User Promotion", $"{user} has been promoted to the {role} role! __**Congratulations {utility.UserOrNick(user)}!!**__")
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
                            await ReplyAsync("You cannot assign this role.");
                        }
                    }
                    else
                    {
                        await ReplyAsync($"Role: {role} was not found.");
                    }
                }
                else
                {
                    await ReplyAsync($"Please enter the username you wish to promote followed by the role.");
                }
            }
            else
            {
                await ReplyAsync(Context.User + utility.NoPermisison());
            }
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
