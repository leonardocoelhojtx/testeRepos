﻿using Private.Data.Context;
using Private.Domain.Entities;
using Private.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Private.Data.Repository
{
    public class PersonRepositoryReadOnly : BaseRepository<PersonEntity>, IPersonRepositoryReadOnly
    {
        public PersonRepositoryReadOnly(PrivateApiContext context) : base(context)
        {

        }
    }
}
