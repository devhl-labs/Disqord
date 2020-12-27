using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Disqord.Bot.Prefixes;
using Disqord.Rest;
using Disqord.Sharding;

namespace Disqord.Bot.Sharding
{
    public partial class DiscordBotSharder : DiscordBotBase, IDiscordSharder
    {
        public IReadOnlyList<Shard> Shards => (_client as DiscordSharder).Shards;

        public DiscordBotSharder(Func<CachedGuild[], Task<CachedGuild[]>> sortGuilds, TokenType tokenType, string token, IPrefixProvider prefixProvider, DiscordBotSharderConfiguration configuration = null)
            : base(new DiscordSharder(sortGuilds, tokenType, token, configuration ??= new DiscordBotSharderConfiguration()), prefixProvider, configuration)
        { }

        public DiscordBotSharder(Func<CachedGuild[], Task<CachedGuild[]>> sortGuilds, RestDiscordClient restClient, IPrefixProvider prefixProvider, DiscordBotSharderConfiguration configuration = null)
            : base(new DiscordSharder(sortGuilds, restClient, configuration ??= new DiscordBotSharderConfiguration()), prefixProvider, configuration)
        { }

        public int GetShardId(Snowflake guildId)
            => (_client as DiscordSharder).GetShardId(guildId);
    }
}