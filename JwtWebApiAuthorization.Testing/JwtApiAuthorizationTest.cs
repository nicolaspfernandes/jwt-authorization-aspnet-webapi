namespace JwtWebApiAuthorization.Testing {

    using Token;
    using Filters;

    using NUnit.Framework;

    /// <summary>
    /// JwtApiAuthorizationTest class, created for test the authorization method with JWT. Check thae 
    /// </summary>
    [TestFixture]
    public class JwtApiAuthorizationTest {
        
        [TestCase(Roles.Common, true, TestName = "Check Anonymous Request For Common Users.")]
        [TestCase(Roles.Superuser, true, TestName = "Check Anonymous Request For Superusers.")]
        [TestCase(Roles.Anonymous, true, TestName = "Check Anonymous Request For Anonymous Users.")]
        [TestCase(Roles.Administrator, true, TestName = "Check Anonymous Request For Administrators.")]
        public void TestRequestsWithAnonymousPermission(Roles roleForToken, bool expectedResult) {

            var hasAuthorization = CheckPermissionAgainstRoles(roleForToken);
            Assert.AreEqual(hasAuthorization, expectedResult);
        }

        [TestCase(Roles.Common, true, TestName = "Check Common Request For Common Users.")]
        [TestCase(Roles.Superuser, true, TestName = "Check Common Request For Superusers.")]
        [TestCase(Roles.Anonymous, false, TestName = "Check Common Request For Anonymous Users.")]
        [TestCase(Roles.Administrator, true, TestName = "Check Common Request For Administrators.")]
        public void TestPermissionForCommonRequests(Roles roleForToken, bool expectedResult) {

            var hasAuthorization = CheckPermissionAgainstRoles(roleForToken, Roles.Common, Roles.Superuser, Roles.Administrator);
            Assert.AreEqual(hasAuthorization, expectedResult);
        }

        [TestCase(Roles.Common, false, TestName = "Check Superuser Request For Common Users.")]
        [TestCase(Roles.Superuser, true, TestName = "Check Superuser Request For Superusers.")]
        [TestCase(Roles.Anonymous, false, TestName = "Check Superuser Request For Anonymous Users.")]
        [TestCase(Roles.Administrator, true, TestName = "Check Superuser Request For Administrators.")]
        public void TestPermissionForSuperuserRequests(Roles roleForToken, bool expectedResult) {

            var hasAuthorization = CheckPermissionAgainstRoles(roleForToken, Roles.Superuser, Roles.Administrator);
            Assert.AreEqual(hasAuthorization, expectedResult);
        }

        [TestCase(Roles.Common, false, TestName = "Check Administrator Request For Common Users.")]
        [TestCase(Roles.Superuser, false, TestName = "Check Administrator Request For Superusers.")]
        [TestCase(Roles.Anonymous, false, TestName = "Check Administrator Request For Anonymous Users.")]
        [TestCase(Roles.Administrator, true, TestName = "Check Administrator Request For Administrators.")]
        public void TestPermissionForAdministratorRequests(Roles roleForToken, bool expectedResult) {

            var hasAuthorization = CheckPermissionAgainstRoles(roleForToken, Roles.Administrator);
            Assert.AreEqual(hasAuthorization, expectedResult);
        }

        private bool CheckPermissionAgainstRoles(Roles roleForToken, params Roles[] rolesForTesting) {

            var authorizationAttribute = new JwtApiAuthorization(rolesForTesting);
            var authorizationToken = new AccessToken { Role = roleForToken }.ToTokenString();

            return authorizationAttribute.CheckAccessTokenAgainstRoles(authorizationToken);
        }
    }
}
