using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UrlShortener.Repositories.Model
{
    public class Shortener
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ExpirateDate { get; set; }
        [MinLength(5)]
        [MaxLength(10)]
        [RegularExpression(@"^[A-Za-z0-9_-]*$")]
        public string Shortened { get; set; }
        public string Full { get; set; }
    }
}
