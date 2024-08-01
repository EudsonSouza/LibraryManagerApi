﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.Core.Interfaces.Repositories
{
    public interface IAuthorRepository : IBaseRepository<Author>
    {
        bool ExistsByName(string name);
    }
}
