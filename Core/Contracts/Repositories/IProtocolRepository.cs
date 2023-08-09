﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Contracts.Repositories
{
    public interface IProtocolRepository : IGenericRepository<IApplicationDbContext, Protocol>
    {
    }
}
