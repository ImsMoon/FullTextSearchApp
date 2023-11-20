using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SearchModule.Contacts;

namespace SearchModule.Controllers
{
    [ApiController]
    [Route("api/search")]
    public class SearchController : ControllerBase
    {
        private readonly ISearchRepository _repository;

        public SearchController(ISearchRepository repository)
        {
            this._repository = repository;
        }

        [HttpGet("get/{searchText}")]
        public async Task<IActionResult> SearchUserInfo([FromRoute]string searchText)
        {
            if(!string.IsNullOrEmpty(searchText))
            {
                var result = await _repository.SearchUserInfo(searchText);
                return Ok(result);
            }
            return BadRequest();
        }
    }
}