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
        public async Task SpamAsync(SocketUser user, int count, [Remainder] string spam)
        {

            SocketUser spamUser = user;
            if(count == 0)
            {
                count = 25;
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
