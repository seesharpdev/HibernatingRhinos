using System;
using System.Collections.Generic;

using FluentAssertions;
using HibernatingRhinos.Infrastructure.Domain.Models;
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
        
    }
}
