namespace BakkerijLimited.DAO
{
    public static class DatabaseConfig
    {
        public const string ConnectionString =
            "Server=localhost,1433;" +
            "Database=BakkerijTestDb;" +
            "User Id=bakkerij_app_user;" +
            "Password=AppUser_Strong!Passw0rd;" +
            "TrustServerCertificate=True;";
    }
}
