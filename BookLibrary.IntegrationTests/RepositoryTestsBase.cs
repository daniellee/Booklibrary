using NUnit.Framework;
using Raven.Client.Document;

namespace BookLibrary.IntegrationTests
{
	public class RepositoryTestsBase
	{
		protected DocumentStore documentStore;

		[TestFixtureSetUp]
		public void SetupAllTests()
		{
			documentStore = new DocumentStore { ConnectionStringName = "RavenDB" };
			documentStore.Initialize();
		}

		[TestFixtureTearDown]
		public void TearDownAllTests()
		{
			documentStore.Dispose();
		}
	}
}