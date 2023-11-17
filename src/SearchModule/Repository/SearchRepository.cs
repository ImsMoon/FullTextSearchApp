using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SearchModule.Contacts;
using SearchModule.Models;

namespace SearchModule.Repository
{
    public class SearchRepository : ISearchRepository
    {
        private readonly ISqlHandler _sqlHandler;

        public SearchRepository(ISqlHandler sqlHandler)
        {
            _sqlHandler = sqlHandler;
        }

        public async Task<IReadOnlyList<User>> SearchUserInfo(string serchText,CancellationToken cancellationToken = default)
        {
            return await _sqlHandler.SearchInfo(serchText,cancellationToken);
        }
    }
}