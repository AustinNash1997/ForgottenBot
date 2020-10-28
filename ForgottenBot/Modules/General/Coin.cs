using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForgottenBot.Modules.General
{
    public class Coin : ModuleBase<SocketCommandContext>
    {
        [Command("Coin")]
        [Alias("flip","coin flip","toss a coin")]
        public async Task FlipCoinAsync()
        {
            List<string> options = new List<string>() { "Heads", "Tails", "Heads", "Tails", "Heads", "Tails", "Edge" };
            await Context.Message.DeleteAsync();

            //Shuffle the list 3 times to ensure complete random results.
            Utility.Shuffle.ShuffleList(options);
            Utility.Shuffle.ShuffleList(options);
            Utility.Shuffle.ShuffleList(options);

            await ReplyAsync($"The coin landed on {options[1]}");
        }
    }
}
