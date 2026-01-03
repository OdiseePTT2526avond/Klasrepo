using BakkerijLimited.DAO;
using Microsoft.Data.SqlClient;
using System.Data;

namespace BakkerijLimited.Tests.DAO
{
    [TestFixture]
    public class DatabaseConnectionTests
    {
        [Test]
        public void CanOpenDatabaseConnection()
        {
            using var connection = new SqlConnection(DatabaseConfig.ConnectionString);
            connection.Open();

            Assert.That(connection.State, Is.EqualTo(ConnectionState.Open));
        }

        [Test]
        public void CanExecuteSimpleQuery()
        {
            using var connection = new SqlConnection(DatabaseConfig.ConnectionString);
            connection.Open();

            using var command = new SqlCommand("SELECT 1", connection);
            var resultObj = command.ExecuteScalar();

            Assert.That(resultObj, Is.Not.Null);
            Assert.That(Convert.ToInt32(resultObj), Is.EqualTo(1));
        }
    }
}
