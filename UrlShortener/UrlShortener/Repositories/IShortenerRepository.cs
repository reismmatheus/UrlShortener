using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UrlShortener.Repositories.Model;

namespace UrlShortener.Repositories
{
    public interface IShortenerRepository
    {
        public string Add(Shortener shortener);
        public Shortener GetByShortener(string shortener);
    }
}
