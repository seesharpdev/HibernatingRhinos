using System;
using System.Collections.Generic;

using FluentAssertions;
using NUnit.Framework;

using HibernatingRhinos.Domain.Models;

namespace HibernatingRhinos.Services.Specs
{
    [TestFixture]
    public class WebinarServiceSpecs
    {
        [Test]
        public void When_getting_a_list_of_webinars_it_should_not_throw()
        {
            // Arrange
            var service = new WebinarService();

            // Act
            Action action = () => service.GetWebinars();

            // Assert
            action.ShouldNotThrow();
        }

        [Test]
        public void When_getting_a_list_of_webinars_it_should_return()
        {
            // Arrange
            var service = new WebinarService();

            // Act
            Func<IEnumerable<Webinar>> method = service.GetWebinars;
            var webinars = method.Invoke();

            // Assert
            webinars.Should().NotBeNull();
        }
        
        [Test]
        public void When_querying_videos_it_should_not_throw()
        {
            // Arrange
            var service = new WebinarService();
            var keyword = "Raven";
            // Act
            Action method = () => service.FindWebinars(keyword);

            // Assert
            method.ShouldNotThrow();
        }

        [Test]
        public void When_querying_videos_it_should_succeed()
        {
            // Arrange
            var service = new WebinarService();
            var keyword = "Raven";
            
            // Act
            Func<IList<Webinar>> method = () => service.FindWebinars(keyword);
            var webinars = method.Invoke();

            // Assert
            webinars.Count.Should().BeGreaterOrEqualTo(1);
        }
    }
}
