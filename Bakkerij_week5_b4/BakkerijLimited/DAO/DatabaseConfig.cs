namespace BakkerijLimited.DAO
{
    public static class DatabaseConfig
    {
        // SQL Server verbindingstring voor de BakkerijTestDb database met SQLServer in Docker container
        /*
        public const string ConnectionString =
            "Server=localhost,1433;" +
            "Database=BakkerijTestDb;" +
            "User Id=bakkerij_app_user;" +
            "Password=AppUser_Strong!Passw0rd;" +
            "TrustServerCertificate=True;";
        */

        // SQL Server verbindingstring voor de BakkerijTestDb database met LocalDB SQL Server met Windows user
        // Check de juiste Server naam via SQL Server Management Studio 
        /*
        public const string ConnectionString =
            "Server=NBBRU45771\\MSSQLSERVER2022;" +
            "Database=BakkerijTestDb;" +
            "Integrated Security=True;" +
            "TrustServerCertificate=True;";
        */

        // MySQL verbindingstring voorbeeld voor de BakkerijTestDb database
        public const string ConnectionString =
            "Server=localhost;" +
            "Port=3306;" +
            "Database=BakkerijTestDb;" +
            "User Id=bakkerij_app_user;" +
            "Password=AppUser_Strong!Passw0rd;";

    }
}
