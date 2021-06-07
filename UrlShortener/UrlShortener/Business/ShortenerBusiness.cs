using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrlShortener.Repositories;
using UrlShortener.Repositories.Model;

namespace UrlShortener.Business
{
    public class ShortenerBusiness : IShortenerBusiness
    {
        private readonly IShortenerRepository _shortenerRepository;
        public string Add(string full)
        {
            var shortener = new Shortener
            {
                Full = full,
                Shortened = GenerateShortenerCode(),
                CreateDate = DateTime.Now,
                ExpirateDate = DateTime.Now.AddDays(7)
            };
            return _shortenerRepository.Add(shortener);
        }

        public Shortener GetByShortener(string shortener)
        {
            return _shortenerRepository.GetByShortener(shortener);
        }

        private string GenerateShortenerCode()
        {
            var random = new Random();
            var length = random.Next(5, 10);
            var dictionaryString = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            StringBuilder resultStringBuilder = new StringBuilder();
            for (int i = 0; i < length; i++)
            {
                resultStringBuilder.Append(dictionaryString[random.Next(dictionaryString.Length)]);
            }
            return resultStringBuilder.ToString();
        }
    }
}
