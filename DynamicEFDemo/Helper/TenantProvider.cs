namespace DynamicEFDemo.Helper
{
    public interface ITenantProvider
    {
        void SetTenant(string tenant);
        string GetConnectionString();
    }

    public class TenantProvider : ITenantProvider
    {
        private readonly IConfiguration _configuration;
        private string _currentTenant;

        public TenantProvider(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void SetTenant(string tenant)
        {
            _currentTenant = tenant;
        }

        public string GetConnectionString()
        {
            if (string.IsNullOrEmpty(_currentTenant))
            {
                throw new InvalidOperationException("Tenant has not been set.");
            }

            string? connectionString = _currentTenant switch
            {
                "DB1" => _configuration.GetConnectionString("DB1Connection"),
                "DB2" => _configuration.GetConnectionString("DB2Connection"),
                _ => throw new Exception($"Unknown tenant: {_currentTenant}")
            };

            if (connectionString == null)
            {
                throw new InvalidOperationException($"Connection string for tenant '{_currentTenant}' not found.");
            }

            return connectionString;
        }
    }
}
