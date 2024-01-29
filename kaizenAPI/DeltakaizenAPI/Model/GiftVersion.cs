using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class GiftVersion
    {
        public Guid? GiftVersionId { get; set; }
        public string? Version { get; set; }
        public Guid? UserId { get; set; }
        public IFormFile? GiftCataloguePath { get; set; }
    }
}
