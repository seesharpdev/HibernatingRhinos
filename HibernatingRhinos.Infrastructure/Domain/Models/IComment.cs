using System;

namespace HibernatingRhinos.Infrastructure.Domain.Models
{
    /// <summary>
    /// The comment contract.
    /// </summary>
    public interface IComment
    {
        string VideoId { get; set; }
        string Author { get; set; }
        string Text { get; set; }
        DateTime Published { get; set; }
    }
}
