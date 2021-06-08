using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UrlShortener.Business;
using UrlShortener.Repositories.Model;

namespace UrlShortener.Controllers
{
    [ApiController]
    [Route("")]
    public class ShortenerController : Controller
    {
        private readonly ILogger<ShortenerController> _logger;
        private readonly IShortenerBusiness _shortenerBusiness;

        public ShortenerController(ILogger<ShortenerController> logger, IShortenerBusiness shortenerBusiness)
        {
            _logger = logger;
            _shortenerBusiness = shortenerBusiness;
        }
        [HttpGet("{shortener}")]
        public IActionResult GetByShortener(string shortener)
        {
            var url = _shortenerBusiness.GetByShortener(shortener);
            if (url == null)
            {
                return NotFound();
            }
            return Ok(new { newUrl = url.Full });
        }


        [HttpPost("{full}")]
        public IActionResult Create(string full)
        {
            var insert = _shortenerBusiness.Add(full);

            if(string.IsNullOrEmpty(insert))
            {
                return BadRequest();
            }

            return Ok(insert);
        }
    }
}
