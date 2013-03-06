using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;

using HibernatingRhinos.Models;
using Google.GData.YouTube;
using Google.GData.Extensions;
using Google.GData.Client;

namespace HibernatingRhinos.Services
{
    /// <summary>
    /// The WebinarService implementation.
    /// </summary>
    public class WebinarService
    {
        private string _uri;
        
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
            var webinars = LoadWebinarsFromYoutube();

            return webinars;
        }

        private IList<Webinar> LoadWebinarsFromYoutube()
        {
            var webinars = new List<Webinar>();

            try
            {
                YouTubeService service = new YouTubeService("HibernatingRhinosExercise");
                FeedQuery query = new FeedQuery(_uri);
                AtomFeed result = service.Query(query);

                if (result != null)
                {
                    webinars = ParseFeed(result.Entries);
                }
            }
            catch (System.Net.WebException)
            {
                throw;
            }

            return webinars;
        }

        private List<Webinar> ParseFeed(AtomEntryCollection atomEntryCollection)
        {
            var webinars = new List<Webinar>();

            foreach (var item in atomEntryCollection)
            {
                var webinar = new Webinar
                {
                    Id = ((Google.GData.YouTube.YouTubeEntry)(item)).VideoId,
                    Name = item.Title.Text,
                    Description = item.Summary.Text,
                    DateCreated = item.Published
                };

                webinars.Add(webinar);
            }

            return webinars;
        }
    }
}
