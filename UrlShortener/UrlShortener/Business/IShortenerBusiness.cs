using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UrlShortener.Repositories.Model;

namespace UrlShortener.Business
{
    public interface IShortenerBusiness
    {
        public string Add(string full);
        public Shortener GetByShortener(string shortener);
    }
}
