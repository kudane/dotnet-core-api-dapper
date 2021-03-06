﻿namespace Backend.Repository.Interfaces.Base
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Threading.Tasks;

    public interface IBaseRepository<TEntity>
    {
        bool CreateOrFailed(TEntity entitie, out long identity);

        bool UpdateOrFailed(TEntity entitie);

        bool DeleteOrFailed(TEntity entitie);

        IEnumerable<TEntity> SelectAll();

        Task<TEntity> GetOrNullAsync(int key);

        Task<TAction> DbActionAsync<TAction>(Func<IDbConnection, Task<TAction>> action);
    }
}
