using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Interactivity;
using DSharpPlus.Interactivity.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AternosBot.Commands
{
    public class ServerCommands : BaseCommandModule
    {
        [Command("serverstart")]
        [Aliases("startserver", "start")]
        [Description("Starts the Aternos Server")]
        public async Task StartMessage(CommandContext ctx)
        {
            InteractivityExtension interactivity = ctx.Client.GetInteractivity();
            DateTimeOffset dto = new DateTimeOffset(DateTime.UtcNow);
            string unixTime = dto.ToUnixTimeSeconds().ToString();

            await ctx.Message.RespondAsync("Server Starting...");
            //Thread.Sleep(6000);
            //await ctx.Message.RespondAsync($"Server Started on {DateTime.Now.ToString("M")} - " +
            //                               $"<t:{unixTime}:t> {ctx.Member.Mention}");
        }
    }
}
