using CTPH_CoreServiceAgent;
using System;
using Xunit;

namespace CTPH_CoreServiceAgentTest
{
    public class AdminServiceAgentTest
    {
        [Fact]
        public void GetElementos()
        {
            AdminServiceAgent adminServiceAgent = new AdminServiceAgent("https://localhost:44355/api/Admin");

            var result = adminServiceAgent.GetElementos();

            Assert.NotNull(result);
        }
    }
}
