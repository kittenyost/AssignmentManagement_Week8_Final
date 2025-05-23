
using System.Net;
using System.Net.Http.Json;
using AssignmentManagement.Core;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Xunit;

namespace AssignmentManagement.ApiTests
{
    public class AssignmentApiTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public AssignmentApiTests(WebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task CanCreateAssignment()
        {
            var assignment = new Assignment(
                "Test Assignment",
                "This is a test assignment.",
                DateTime.Today.AddDays(7),
                AssignmentPriority.Medium,
                "Integration test notes"
            );

            var response = await _client.PostAsJsonAsync("/api/assignment", assignment);
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        }

        [Fact]
        public async Task CanGetAllAssignments()
        {
            var assignment = new Assignment(
                "Test2 Assignment",
                "Second test assignment.",
                DateTime.Today.AddDays(3),
                AssignmentPriority.High,
                "Second test notes"
            );

            await _client.PostAsJsonAsync("/api/assignment", assignment);

            var response = await _client.GetAsync("/api/assignment");
            response.EnsureSuccessStatusCode();

            var assignments = await response.Content.ReadFromJsonAsync<List<Assignment>>();
            Assert.Contains(assignments, a => a.Title == "Test2 Assignment");
        }
    }
}
