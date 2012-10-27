using MvcContrib.TestHelper;
using NUnit.Framework;
using PeerCentral.Domain;
using PeerCentral.WebClient.Controllers;
using PeerCentral.WebClient.Views.Home;
using Rhino.Mocks;

namespace PeerCentral.WebClient.UnitTests.Controllers
{
    public class HomeControllerTests 
    {
        private HomeController _controller;
        private TestControllerBuilder _builder;
        private IRuntimeSession _runtimeSession;

        [SetUp]
        public void Setup()
        {
            this._builder = new TestControllerBuilder();
            this._runtimeSession = MockRepository.GenerateMock<IRuntimeSession>();
            this._controller = _builder.CreateController<HomeController>(this._runtimeSession);
        }

        [Test]
        public void WhenLoggedIn_Index_ShouldRenderUsersDashboard()
        {
            // Given
            A_user_is_logged_in(1, "Mal");

            // When
            var result = this._controller.Index();

            // Then
            var viewmodel = result.AssertViewRendered()
                                    .ForView("Dashboard")
                                    .WithViewData<DashboardViewModel>();

            Assert.That(viewmodel.CurrentUser.Id, Is.EqualTo(1));
            Assert.That(viewmodel.CurrentUser.Name, Is.EqualTo("Mal"));
        }

        [Test]
        public void WhenNotLoggedIn_Index_ShouldRenderHomeView()
        {
            // Given
            No_user_is_logged_in();

            // When
            var result = this._controller.Index();

            // Then
            result.AssertViewRendered().ForView("Home");
        }

        private void A_user_is_logged_in(int? id, string name)
        {
            var user = MockRepository.GenerateMock<IUser>();

            user.Stub(u => u.Id).Return(id);
            user.Stub(u => u.Name).Return(name);

            this._runtimeSession.Stub(s => s.GetCurrentUser()).Return(user);
            this._runtimeSession.Stub(s => s.IsAuthenticated).Return(true);
        }

        private void No_user_is_logged_in()
        {
            this._runtimeSession.Stub(s => s.IsAuthenticated).Return(false);
        }
    }
}