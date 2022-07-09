using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using PhiloAlterEgo.Core.Services;

namespace PhiloAlterEgo.Commands
{
    public class AdminCommands : BaseCommandModule
    {
        private readonly IGuildService _guildService;

        public AdminCommands(IGuildService guildService)
        {
            _guildService = guildService;
        }

        [Command("addguild")]
        [RequireOwner]
        [Hidden]
        public async Task GetOrCreateGuildAsync(CommandContext ctx, ulong guildId)
        {
            if (ctx.Channel.Id != 995352151738028154)
            {
                await ctx.Channel.SendMessageAsync($"> Wrong channel for this command!").ConfigureAwait(false);

                return;
            }    

            await ctx.TriggerTypingAsync().ConfigureAwait(false);

            await ctx.Channel.SendMessageAsync("> Doing ...").ConfigureAwait(false);

            await ctx.TriggerTypingAsync().ConfigureAwait(false);

            var result = await _guildService.Get(guildId);

            if (result != null)
            {
                await ctx.Channel.SendMessageAsync($"> Guild **{guildId}** exists in database!").ConfigureAwait(false);

                return;
            }

            try
            {
                DiscordGuild discordGuild = await ctx.Client.GetGuildAsync(guildId);

                result = await _guildService.Create(guildId, discordGuild.Name);
            }
            catch
            {
                result = await _guildService.Create(guildId, "FAKE_GUILD");
            }

            await ctx.Channel.SendMessageAsync($"> Guild **{result.GuildName}, {result.Id}** was added!").ConfigureAwait(false);
        }

        [Command("deleteguild")]
        [RequireOwner]
        [Hidden]
        public async Task DeleteGuildAsync(CommandContext ctx, ulong guildId)
        {
            if (ctx.Channel.Id != 995352151738028154)
            {
                await ctx.Channel.SendMessageAsync($"> Wrong channel for this command!").ConfigureAwait(false);

                return;
            }

            await ctx.TriggerTypingAsync().ConfigureAwait(false);

            await ctx.Channel.SendMessageAsync("> Doing ...").ConfigureAwait(false);

            await ctx.TriggerTypingAsync().ConfigureAwait(false);

            var result = await _guildService.Delete(guildId);

            if (result == null)
            {
                await ctx.Channel.SendMessageAsync($"> Guild **{guildId}** does not exists in database!").ConfigureAwait(false);

                return;
            }

            var guildName = result.GuildName == string.Empty ? "FAKE_GUILD" : result.GuildName;

            await ctx.Channel.SendMessageAsync($"> Guild **{guildName}, {result.Id}** was deleted!").ConfigureAwait(false);
        }
    }
}
