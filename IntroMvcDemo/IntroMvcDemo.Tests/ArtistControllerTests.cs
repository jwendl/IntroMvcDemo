using IntroMvcDemo.Controllers;
using IntroMvcDemo.DataAccess.Interfaces;
using IntroMvcDemo.DataAccess.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace IntroMvcDemo.Tests
{
    [TestClass]
    public class ArtistControllerTests
    {
        [TestMethod]
        public async Task ArtistController_TestItemLookup()
        {
            var expected = new Artist()
            {
                Id = 1,
                Name = "Test Artist",
                Albums = new List<Album>()
                {
                    new Album() { Id = 1, Name = "Test Album", ArtistId = 1 }
                }
            };

            var artistRepository = Substitute.For<IDataRepository<Artist>>();
            artistRepository.FindOneAsync(Arg.Any<Expression<Func<Artist, bool>>>(), Arg.Any<Expression<Func<Artist, object>>>()).Returns(expected);

            var artistController = new ArtistController(artistRepository);
            var actionResult = await artistController.Item(1) as ViewResult;

            var actual = actionResult.Model as Artist;
            Assert.AreEqual(expected.Name, actual.Name);
            Assert.AreEqual(expected.Albums.Count, actual.Albums.Count);
        }
    }
}
