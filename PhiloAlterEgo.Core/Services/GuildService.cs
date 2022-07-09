using Microsoft.EntityFrameworkCore;
using PhiloAlterEgo.DAL.Data;
using PhiloAlterEgo.DAL.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhiloAlterEgo.Core.Services
{
    public interface IGuildService
    {
        Task<Guild> Get(ulong guildId);
        Task<Guild> Create(ulong guildId, string guildName);
        Task<Guild> Delete(ulong guildId);

    }

    public class GuildService : IGuildService
    {
        private readonly DbContextOptions<DataContext> _options;

        public GuildService(DbContextOptions<DataContext> options)
        {
            _options = options;
        }

        public async Task<Guild> Get(ulong guildId)
        {
            using var context = new DataContext(_options);

            var guild = await context.Guilds.SingleOrDefaultAsync(g => g.Id == guildId);

            return guild;
        }
        public async Task<Guild> Create(ulong guildId, string guildName)
        {
            using var context = new DataContext(_options);

            var guild = new Guild()
            {
                Id = guildId,
                GuildName = guildName,
                Kingdoms = new List<Kingdom>()
            };

            context.Add(guild);

            await context.SaveChangesAsync().ConfigureAwait(false);

            return guild;
        }
        public async Task<Guild> Delete(ulong guildId)
        {
            using var context = new DataContext(_options);

            var guild = await context.Guilds.SingleOrDefaultAsync(g => g.Id == guildId);

            if (guild == null)
                return guild;

            context.Remove(guild);

            await context.SaveChangesAsync().ConfigureAwait(false);

            return guild;
        }
    }
}
