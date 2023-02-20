using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Interactivity;
using DSharpPlus.Interactivity.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

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
            ProcessStartInfo startInfo = new ProcessStartInfo();
            bool serverIsUp = false;

            await ctx.Message.RespondAsync("Server Starting...");
            startInfo.FileName = @""; // path to python.exe
            startInfo.Arguments = "CallAPI.py";
            startInfo.UseShellExecute = false;
            startInfo.CreateNoWindow = true;
            startInfo.RedirectStandardOutput = true;
            startInfo.RedirectStandardError = true;
            string errors = String.Empty;

            using (var process = Process.Start(startInfo))
            {
                errors = process.StandardError.ReadToEnd();
                serverIsUp = Convert.ToBoolean(process.StandardOutput.ReadToEnd().ToLower());
            }

            if (errors != String.Empty)
            {
                await ctx.Message.RespondAsync($"{errors}");
            }

            if (serverIsUp)
            {
                await ctx.Message.RespondAsync($"Server Started on {DateTime.Now.ToString("M")} - " +
                                           $"<t:{unixTime}:t> {ctx.Member.Mention}");
            }
        }
    }
}
