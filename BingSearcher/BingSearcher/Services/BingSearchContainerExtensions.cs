using System;
using System.Collections.Generic;
using System.Data.Services.Client;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bing {
    public static class BingSearchContainerExtensions {
        public static Task<IEnumerable<T>> ExecuteAsync<T>(this DataServiceQuery<T> query) {
            return Task.Factory.FromAsync<IEnumerable<T>>(query.BeginExecute, query.EndExecute, null);
        }
    }
}
