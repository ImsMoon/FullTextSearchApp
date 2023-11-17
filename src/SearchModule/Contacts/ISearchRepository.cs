using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SearchModule.Models;

namespace SearchModule.Contacts
{
    public interface ISearchRepository
    {
        Task<IReadOnlyList<User>> SearchUserInfo(string serchText,CancellationToken cancellationToken = default);
    }
}