using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ForgottenBot.Utility;

namespace ForgottenBot.Modules.General
{
    class TeamGeneration : ModuleBase<SocketCommandContext>
    {
        Util util = new Util();

        [Command("teams")]
        [RequireBotPermission(GuildPermission.MoveMembers)]
        public async Task ScrimAsync()
        {
            EmbedBuilder teamEmbed = new EmbedBuilder();
            SocketVoiceChannel socketVoiceChannel = Context.Guild.VoiceChannels.Where(x => x.Users.Contains(Context.User)).SingleOrDefault();

            List<SocketGuildUser> allPlayers = socketVoiceChannel.Users.ToList();
            List<SocketGuildUser> teamOne = new List<SocketGuildUser>();
            List<SocketGuildUser> teamTwo = new List<SocketGuildUser>();

            allPlayers.ShuffleList();

            StringBuilder teamOneNames = new StringBuilder();
            StringBuilder teamTwoNames = new StringBuilder();

            int teamMax = (allPlayers.Count / 2);

            if (allPlayers.Count % 2 != 0)
            {
                teamMax++;
                teamEmbed.AddField("WARNING", "Teams do not have equal members");
            }

            teamEmbed.WithTitle("🏆🏆 Teams 🏆🏆");

            foreach (SocketGuildUser player in allPlayers)
            {
                Random random = new Random();
                int number = random.Next(0, 4);

                if (number <= 2 && teamOne.Count < teamMax)
                {
                    teamOne.Add(player);
                    teamOneNames.AppendLine(util.UserOrNick(player));
                }
                else if (number >= 2 && teamTwo.Count < teamMax)
                {
                    teamTwo.Add(player);
                    teamTwoNames.AppendLine(util.UserOrNick(player));
                }
                else if (teamOne.Count < teamMax)
                {
                    teamOne.Add(player);
                    teamOneNames.AppendLine(util.UserOrNick(player));
                }
                else if (teamTwo.Count < teamMax)
                {
                    teamTwo.Add(player);
                    teamTwoNames.AppendLine(util.UserOrNick(player));
                }
            }

            teamEmbed.AddField("Team One", teamOneNames)
                        .AddField("Team Two", teamTwoNames);

            await ReplyAsync("", false, teamEmbed.Build());
            await Context.Message.DeleteAsync();
            //Context.Guild.CreateVoiceChannelAsync("Team One");
            //Context.Guild.CreateVoiceChannelAsync("Team Two");

        }
    }
}
