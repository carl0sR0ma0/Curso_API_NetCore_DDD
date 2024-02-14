namespace Domain.Configuration
{
    public class DbSettings
    {
        public string DATABASE { get; set; } = string.Empty;
        public string DB_CONNECTION_PG { get; set; } = string.Empty;
        public string DB_CONNECTION_SS { get; set; } = string.Empty;
        public string Migration { get; set; } = string.Empty;
    }
}
