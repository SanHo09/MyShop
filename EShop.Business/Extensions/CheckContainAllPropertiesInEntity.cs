using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EShop.Business.Extensions
{
    public static class CheckContainAllPropertiesInEntity
    {
        public static bool Filter<TEntity>(TEntity entity, string contain) 
        {
            return entity.GetType()
                    .GetProperties()
                    .Where(x => x.PropertyType == typeof(string))
                    .Select(x => (string)x.GetValue(entity, null))
                    .Where(x => x != null)
                    .Any(x => x.IndexOf(contain, StringComparison.CurrentCultureIgnoreCase) >= 0);
        }
    }
}