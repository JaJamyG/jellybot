using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace JellyBot.core.Modules
{
    public class General : ModuleBase
    {
        [Command("ping")]
        public async Task Ping()
        {
            await Context.Channel.SendMessageAsync("pong!");
        }
        [Command("info")]
        public async Task Info()
        {
            var builder = new EmbedBuilder()
                .WithThumbnailUrl(Context.User.GetAvatarUrl() ?? Context.User.GetDefaultAvatarUrl())
                .WithDescription("In this message you can see some information about yourself!")
                .WithColor(new Color(33, 176, 252))
                .WithCurrentTimestamp();
            var embed = builder.Build();
            await Context.Channel.SendMessageAsync(null, false, embed);
        }
        [Command("purge")]
        public async Task Purge()
        {
            Console.WriteLine("Puring in progress");

            await Context.Message.DeleteAsync();

            Console.WriteLine("Purging Compleet");
        }
        [Command("anno")]
        public async Task Anno(string args = null)
        {
            var attachments = Context.Message.Attachments;
            if(Context.Message.Attachments.Count == 0)
            {
                await Context.Message.DeleteAsync();
                await ReplyAsync(args);
            }
            else
            {
                await Context.Message.DeleteAsync();
                string url = attachments.ElementAt(0).Url;
                await ReplyAsync(args + " " + url);
            }
        }
    }
}
