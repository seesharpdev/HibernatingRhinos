using System;

using FluentAssertions;
using NUnit.Framework;
using HibernatingRhinos.Models;
using System.Collections.Generic;

namespace HibernatingRhinos.Services.Specs
{
    [TestFixture]
    public class WebinarServiceSpecs
    {
        [Test]
        [Ignore]
        public void When_getting_a_list_of_webinars_it_should_not_throw()
        {
            // Arrange
            var service = new WebinarService();

            // Act
            Action action = () =>
            {
                service.GetWebinars();
            };

            // Assert
            action.ShouldNotThrow();
        }

        [Test]
        public void When_getting_a_list_of_webinars_it_should_succeed()
        {
            // Arrange
            var service = new WebinarService();

            // Act
            Func<IList<Webinar>> method = () =>
            {
                return service.GetWebinars();
            };
            
            var webinars = method.Invoke();

            // Assert
            webinars.Should().NotBeNull();
        }

    }
}
