using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForgottenBot.Utility
{
    public class Util : ModuleBase<SocketCommandContext>
    {
        const string NO_PERMISSION = ", you do not have permission to use this command!";

        /// <summary>
        /// Returns the Constant NO PERMISSION
        /// </summary>
        public string NoPermisison()
        {
            return NO_PERMISSION;
        }

        /// <summary>
        /// Find whether to use the username or nickname of a user.
        /// </summary>
        /// <param name="user">User in question</param>
        /// <returns>Username or nickname</returns>
        public string UserOrNick(SocketUser user)
        {
            string nameToReturn = (user as IGuildUser).Nickname;
            if (nameToReturn == null || nameToReturn == string.Empty)
            {
                nameToReturn = user.Username.ToString();
            }
            return nameToReturn;
        }
    }
}
