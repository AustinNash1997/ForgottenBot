using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ForgottenBot.Utility
{
    class BotExecution
    {
        //Instantiate variables
        private DiscordSocketClient _client;
        private CommandService _commandService;
        private IServiceProvider _services;

        //Instantiate Constants
        public const string PREFIX = "`";
        public const string VERSION = "1.0.5";
        #region token no no no
        //bot token.. shhhhh
        private const string TOKEN = "NTA0MDQ5NDkyOTA4MDQ4NDE1.W85Gqw.zlB41Sd7-xdGdDQ3qV5C0qCSxiY";
        #endregion

        //Run the bot
        public async Task RunBotAsync()
        {
            _client = new DiscordSocketClient(); //Create a new client.
            _commandService = new CommandService(); //Create a new command service.

            //Create a service collection
            _services = new ServiceCollection()
                .AddSingleton(_client)
                .AddSingleton(_commandService)
                .BuildServiceProvider();

            //Event Subscriptions
            _client.Log += Log;
            _client.UserJoined += AnnounceUserJoined;
            // _client.UserVoiceStateUpdated += AutoChannel;

            await RegisterCommandsAsync();                  //Register commands.
            await _client.LoginAsync(TokenType.Bot, TOKEN); //Log in with token 
            await _client.StartAsync();                     //Start the client

            //Set the game status i.e "playing `help"
            await _client.SetGameAsync("a game | type `help!");

            await Task.Delay(-1); //Wait forever.
        }

        //Announce User Joined
        private async Task AnnounceUserJoined(SocketGuildUser user)
        {
            SocketGuild guild = user.Guild;                                             //Store the current server.
            SocketTextChannel channel = guild.DefaultChannel;                           //Store the current channel.
            SocketRole newRole = guild.Roles.FirstOrDefault(x => x.Name == "Newbies");  //Find role to assign new members

            await user.AddRoleAsync(newRole);                                           //Assign the new role.

            EmbedBuilder builder = new EmbedBuilder();                                  //Create an Embed builder.

            //Assign the builder a title and add feilds to it.
            builder.WithTitle("New User")

                .AddField("Welcome to the Server", $"We hope you enjoy the server {user.Mention}!")
                .AddField("Joined at", user.JoinedAt)
                .WithImageUrl(user.GetAvatarUrl())
                .WithColor(Color.DarkPurple);

            //Send the message to the default channel.
            await channel.SendMessageAsync("", false, builder.Build());
        }

        /// <summary>
        /// Log information
        /// </summary>
        private Task Log(LogMessage arg)
        {
            //Write a generic log to the console.
            Console.WriteLine(arg);
            return Task.CompletedTask;
        }

        /// <summary>
        /// Register commands
        /// </summary>
        public async Task RegisterCommandsAsync()
        {
            //subscribe to the event.
            _client.MessageReceived += HandleCommandAsync;
            await _commandService.AddModulesAsync(Assembly.GetEntryAssembly(), _services);
        }

        /// <summary>
        /// Handles the commands
        /// </summary>
        private async Task HandleCommandAsync(SocketMessage arg)
        {
            //Create a message. Or utilize the passed arguments.
            SocketUserMessage message = arg as SocketUserMessage;

            //Ignore any null messages or messages from bots.
            if (message is null || message.Author.IsBot) return;

            int argPos = 0;

            //Only repond to messages with the bot prefix.
            if (message.HasStringPrefix(PREFIX, ref argPos) || message.HasMentionPrefix(_client.CurrentUser, ref argPos))
            {
                SocketCommandContext context = new SocketCommandContext(_client, message);
                IResult result = await _commandService.ExecuteAsync(context, argPos, _services);

                //If there is an error, we will want to log it.
                if (!result.IsSuccess)
                {
                    await WriteErrorToLogAsync(message, result);
                    Console.WriteLine(result.ErrorReason);
                }
            }
            else if (message.Content.ToLower().Equals("raugh"))
            {
                SocketCommandContext context = new SocketCommandContext(_client, message);
                await context.Message.DeleteAsync();
                await context.Channel.SendFileAsync(@"../../Images/Raughs/raugh.jpg");
            }
            else if (message.Content.ToLower().Equals("raughs"))
            {
                SocketCommandContext context = new SocketCommandContext(_client, message);
                await context.Message.DeleteAsync();
                await context.Channel.SendFileAsync(@"../../Images/Raughs/raughs.jpg");
            }
        }

        /// <summary>
        /// Write the error to a file.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        private async Task WriteErrorToLogAsync(SocketUserMessage message, IResult result)
        {
            try
            {
                StreamWriter errorLog = new StreamWriter(@"../../Logs/ErrorLog.txt", true);
                await errorLog.WriteLineAsync($"{ DateTime.Now }:");
                await errorLog.WriteLineAsync($"Author: {message.Author}");
                await errorLog.WriteLineAsync($"Message: {message.Content}");
                await errorLog.WriteLineAsync($"Retult: {result.ErrorReason}");
                await errorLog.WriteLineAsync();
                await errorLog.FlushAsync();
                errorLog.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }
        }
    }
}
