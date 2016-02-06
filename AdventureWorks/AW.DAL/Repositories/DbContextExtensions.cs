﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AW.DAL.Repositories {
    public static class DbContextExtensions {
        public static ObjectContext ToObjectContext(this DbContext dbContext) {
            return (dbContext as IObjectContextAdapter).ObjectContext;
        }
    }
}
