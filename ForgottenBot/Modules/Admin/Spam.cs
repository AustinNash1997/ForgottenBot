using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System.Threading;
using System.Threading.Tasks;

namespace ForgottenBot.Modules.Admin
{
    public class Spam : ModuleBase<SocketCommandContext>
    {
        [Command("spam")]
        [RequireUserPermission(GuildPermission.Administrator)]
        public async Task SpamAsync(SocketUser user, [Remainder] string spam)
        {

            SocketUser spamUser = user;
            int count = 25;

            if (Context.User != Context.Guild.Owner)
            {
                spamUser = Context.User;
            }

            for (int i = 0; i < count; i++)
            {
                Thread.Sleep(1500);
                await spamUser.SendMessageAsync(spam, true);
            }

            await Context.Message.DeleteAsync();
            await ReplyAsync($"{ user } has been spammed with {spam}");
        }
    }
}
