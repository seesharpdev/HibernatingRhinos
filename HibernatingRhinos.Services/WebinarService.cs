using System.Collections.Generic;

using Google.GData.YouTube;
using Google.GData.Client;

using HibernatingRhinos.Domain.Models;

namespace HibernatingRhinos.Services
{
    /// <summary>
    /// The WebinarService implementation.
    /// </summary>
    public class WebinarService
    {
        private readonly string _uri;
        
        public WebinarService()
	    {
            _uri = "http://gdata.youtube.com/feeds/api/users/HibernatingRhinos/uploads";
	    }

        /// <summary>
        /// Returns a list of webinars.
        /// </summary>
        /// <returns>A generic collection of webinars.</returns>
        public IList<Webinar> GetWebinars()
        {
            var webinars = LoadWebinars();

            return webinars;
        }

        private IList<Webinar> LoadWebinars()
        {
            var service = new YouTubeService("HibernatingRhinosExercise");
            var query = new FeedQuery(_uri);
            var webinars = new List<Webinar>();

            AtomFeed result = service.Query(query);
            if (result != null)
            {
                webinars = ParseAtomFeed(result);
            }

            return webinars;
        }

        private static List<Webinar> ParseAtomFeed(AtomFeed atomFeed)
        {
            IEnumerable<AtomEntry> atomEntryCollection = atomFeed.Entries;
            var webinars = new List<Webinar>();

            foreach (var item in atomEntryCollection)
            {
                var entry = (YouTubeEntry) item;
                var webinar = new Webinar
                {
                    Id = entry.VideoId,
                    Title = entry.Title.Text,
                    Summary = entry.Summary.Text,
                    Published = entry.Published
                };

                webinars.Add(webinar);
            }

            return webinars;
        }
    }
}
