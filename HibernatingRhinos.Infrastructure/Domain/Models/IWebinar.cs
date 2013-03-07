using System;

namespace HibernatingRhinos.Infrastructure.Domain.Models
{
    /// <summary>
    /// The webinar entity contract.
    /// </summary>
    public interface IWebinar
    {
        string Id { get; set; }
        string Title { get; set; }
        string Summary { get; set; }
        DateTime Published { get; set; }
    }
}