namespace JwtWebApiAuthorization.Testing {

    using Token;
    using Controllers;

    using NUnit.Framework;
    
    /// <summary>
    /// TokenController test - Unit Tests for checking if tokens are created successfully for any kind of role.
    /// </summary>
    [TestFixture]
    public class TokenControllerTest {

        public TokenController TokenController { get; private set; }
        
        [SetUp]
        public void Setup() {
            TokenController = new TokenController();
        }
        
        [TestCase(Roles.Common, TestName = "Get Authorization Token with Common User")]
        [TestCase(Roles.Superuser, TestName = "Get Authorization Token with Superuser")]
        [TestCase(Roles.Anonymous, TestName = "Get Authorization Token with Anonymous User")]
        [TestCase(Roles.Administrator, TestName = "Get Authorization Token with Administrator")]
        public void GetTokenWithRole(Roles role) {

            var response = TokenController.Get(role);
            Assert.Multiple(() => {
                Assert.IsTrue(response.Success);
                Assert.IsNotNull(response.Data);
            });
        }

        [TearDown]
        public void Teardown() {
            TokenController.Dispose();
        }
    }
}
