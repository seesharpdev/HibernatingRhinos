using System;
using HibernatingRhinos.Infrastructure.Domain.Models;

namespace HibernatingRhinos.Domain.Models
{
    /// <summary>
    /// The webinar entity implementation.
    /// </summary>
    public class Webinar : IWebinar
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public DateTime Published { get; set; }
    }
}
