using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tutbot.Modules
{
    public class Commands : ModuleBase<SocketCommandContext>
    {
        [Command("ping")]
        public async Task Ping()
        {
            await ReplyAsync("Pong");
        }
        [Command("ban")]
        public async Task Ban(Discord.IGuildUser user = null, [Remainder] string reason = null)
        {
            if (user == null) {
                await ReplyAsync("Please specify a user!"); return;
            }
            if (reason == null) reason = "Not Specified";

            await Context.Guild.AddBanAsync(user, 0, reason);


            var EmbedBuilder = new EmbedBuilder()
                .WithDescription($":white_check)mark: {user.Mention} was banned\n **Reason** {reason}")
                .WithFooter(footer => 
                { 
                    footer
                        .WithText("User Ban Log")
                        .WithIconUrl("C:\\Users\\berna\\Pictures"); 
                });
        }
    }
}
