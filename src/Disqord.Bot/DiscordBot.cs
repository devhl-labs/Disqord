using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Disqord.Bot.Prefixes;
using Disqord.Rest;

namespace Disqord.Bot
{
    public class DiscordBot : DiscordBotBase
    {
        public DiscordBot(RestDiscordClient restClient, IPrefixProvider prefixProvider, Func<CachedGuild[], Task<CachedGuild[]>> sortGuilds, DiscordBotConfiguration configuration = null)
            : base(new DiscordClient(restClient, sortGuilds, configuration ??= new DiscordBotConfiguration()), prefixProvider, configuration)
        { }

        public DiscordBot(TokenType tokenType, string token, IPrefixProvider prefixProvider, Func<CachedGuild[], Task<CachedGuild[]>> sortGuilds, DiscordBotConfiguration configuration = null)
            : base(new DiscordClient(tokenType, token, sortGuilds, configuration ??= new DiscordBotConfiguration()), prefixProvider, configuration)
        { }
    }
}