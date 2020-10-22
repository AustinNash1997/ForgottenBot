using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
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

            ITextChannel channel = (ITextChannel)Context.Channel;

            channel.DeleteMessagesAsync(messagesToDelete.ToEnumerable()).GetAwaiter().GetResult();
            //await messagesToDelete.ForEachAsync(x => Context.Channel.DeleteMessageAsync(x.Id).Wait(100));
        }

        [Command("help clear")]
        [Alias("help cls", "help clr", "help purge")]
        [RequireUserPermission(GuildPermission.ManageMessages)]
        public async Task HelpBan()
        {
            EmbedBuilder embedBuilder = new EmbedBuilder()
                .WithTitle("Clear Screen")
                .WithDescription("Ban a naughty user")
                .AddField("How To Use", "`Ban {user} ")
                .AddField("Count", "This is the number of messages you wish to remove")
                .AddField("Example", "`clear 25 \r\n`purge 25 \r\n`cls 25 \r\n`clr 25");

            await ReplyAsync("", false, embedBuilder.Build());
        }
    }
}
