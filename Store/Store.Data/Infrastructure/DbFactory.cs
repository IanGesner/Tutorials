using Store.Data.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        StoreDbContext dbContext;

        public StoreDbContext Init()
        {
            return dbContext ?? (dbContext = new StoreDbContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}
