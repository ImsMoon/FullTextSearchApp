using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SearchModule.Models;

namespace SearchModule.Contacts
{
    public interface ISqlHandler
    {
        Task<IReadOnlyList<User>> SearchInfo(string serchText, CancellationToken cancellationToken=default);
    }
}