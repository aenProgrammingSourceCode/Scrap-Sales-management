﻿using alamapp.Infrastructure.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.Infrastructure.UnitOfWorks
{
   public interface IUnitOfWorkRepository
    {
       void PersistCreationOf(IAggregateRoot entity);
       void PersistUpdateOf(IAggregateRoot entity);
       void PersistDeletionOf(IAggregateRoot entity);
    }
}
