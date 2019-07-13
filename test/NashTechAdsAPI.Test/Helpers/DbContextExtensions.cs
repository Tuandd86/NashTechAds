using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace NashTechAdsAPI.Test.Helpers
{
    public static class DbContextExtensions
    {
        public static void DetachAll(this DbContext context)
        {
            var changedEntriesCopy = context.ChangeTracker.Entries().ToList();

            foreach (var entry in changedEntriesCopy)
            {
                entry.State = EntityState.Detached;
            }
        }
    }
}
