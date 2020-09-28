using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForgottenBot.Modules.Admin
{
    public class ClearScreen : ModuleBase<SocketCommandContext>
    {
        [Command("clear", RunMode = RunMode.Async)]
        [Summary("Clear an amount of messages in the channel")]
        [RequireBotPermission(GuildPermission.ManageMessages)]
        [RequireUserPermission(GuildPermission.ManageMessages)]
        [Alias("cls", "clr", "purge")]
        public async Task ClearMessageAsync([Remainder] int numberOfMessages = 5)
        {
            if (numberOfMessages > 50)
            {
                numberOfMessages = 50;
            }
            await Context.Message.DeleteAsync();

            IAsyncEnumerable<IMessage> messagesToDelete = Context.Channel.GetMessagesAsync(numberOfMessages).Flatten();
            await messagesToDelete.ForEachAsync(x => Context.Channel.DeleteMessageAsync(x.Id).Wait(200));
        }
    }
}
