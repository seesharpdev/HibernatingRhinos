using System;

using HibernatingRhinos.Infrastructure.Domain.Models;

namespace HibernatingRhinos.Domain.Models
{
    public class Comment : IComment
    {
        public string VideoId { get; set; }
        public string Author { get; set; }
        public string Text { get; set; }
        public DateTime Published { get; set; }
    }
}
