using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using MvcContrib.TestHelper;
using NUnit.Framework;
using PeerCentral.Domain;
using PeerCentral.WebClient.Controllers;
using PeerCentral.WebClient.Models;
using Rhino.Mocks;

namespace PeerCentral.WebClient.UnitTests.Controllers
{
    public class SessionControllerTest
    {
        private IQueryable<User> _expected;
        private SessionController _controller;
        private TestControllerBuilder _builder;
        private IRepository<User> _repository;

        [SetUp]
        public void Setup()
        {
            this._builder = new TestControllerBuilder();
            this._expected = Enumerable.Range(1, 10).Select(i => MockRepository.GenerateMock<User>()).AsQueryable();
            this._repository = MockRepository.GenerateMock<IRepository<User>>();
            this._repository.Stub(r => r.All()).Return(this._expected);

            this._controller = _builder.CreateController<SessionController>(this._repository);
        }

        [Test]
         public void New_Should_Return_A_List_Of_Users()
         {
             // arrange

             // act
             var result = _controller.New();

             // assert
             var actual = result.AssertResultIs<ViewResult>().WithViewData<IEnumerable<User>>();

             Assert.That(actual, Is.EqualTo(this._expected));
         }
    }
}