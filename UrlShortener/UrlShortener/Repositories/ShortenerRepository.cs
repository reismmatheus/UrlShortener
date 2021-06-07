using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UrlShortener.Context;
using UrlShortener.Repositories.Model;

namespace UrlShortener.Repositories
{
    public class ShortenerRepository : IShortenerRepository
    {
        private readonly ShortenerContext _context;
        public ShortenerRepository(ShortenerContext context)
        {
            _context = context;
        }

        public string Add(Shortener shortener)
        {
            _context.Shorteners.Add(shortener);
            _context.SaveChanges();
            return shortener.Shortened.ToString();
        }

        public Shortener GetByShortener(string shortener)
        {
            return _context.Shorteners.FirstOrDefault(x => x.Shortened == shortener && x.ExpirateDate < DateTime.Now);
        }
    }
}
