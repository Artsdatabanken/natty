using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Forms_dev3;

namespace RødlisteKlassifiserer
{
    public static class DataConnection
    {
        public static readonly RødlistedeNaturtyperKlassifiseringContainer Context =
            new RødlistedeNaturtyperKlassifiseringContainer();

        public static T AddIfNotExists<T>(this DbSet<T> dbSet, T entity, Expression<Func<T, bool>> predicate = null)
            where T : class, new()
        {
            if (!dbSet.Any()) return dbSet.Add(entity);

            var existingRows = dbSet.Where(predicate);
            if (!existingRows.Any()) return dbSet.Add(entity);

            Context.Entry(existingRows.First()).State = EntityState.Unchanged;
            return existingRows.First();
        }
    }
}