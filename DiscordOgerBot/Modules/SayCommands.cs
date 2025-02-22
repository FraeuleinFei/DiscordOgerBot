﻿using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using DiscordOgerBot.Controller;

namespace DiscordOgerBot.Modules
{
    public class SayCommands : ModuleBase<SocketCommandContext>
    {
        [Command("say")]
        public async Task SendCommand([Remainder]string message)
        {
            if(!(Context.User is SocketGuildUser user)) return;
            if (!user.GuildPermissions.KickMembers && user.Id != 386989432148066306)
            {
                await Context.Channel.SendMessageAsync($"{user.Mention} Auf dich hör ich ned du Spaggn, ich hab Mussig an!!");
                return;
            }

            if (Context.Message.ReferencedMessage != null)
            {
                await Context.Message.ReferencedMessage.ReplyAsync(message);
                await Context.Message.DeleteAsync();
            }
            else
            {
                await Context.Message.DeleteAsync();
                await Context.Channel.SendMessageAsync(message);
            }
        }

        [Command("status")]
        [RequireOwner]
        public async Task SetBotStatus([Remainder] string status)
        {
            await OgerBot.Client.SetGameAsync(status, type: ActivityType.Watching);
        }
    }
}
