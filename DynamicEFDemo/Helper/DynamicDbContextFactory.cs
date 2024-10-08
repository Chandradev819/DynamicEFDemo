using DynamicEFDemo.Model;

namespace DynamicEFDemo.Helper
{
    public class DynamicDbContextFactory
    {
        private readonly ITenantProvider _tenantProvider;

        public DynamicDbContextFactory(ITenantProvider tenantProvider)
        {
            _tenantProvider = tenantProvider;
        }

        public DynamicDbContext CreateDbContext()
        {
            var connectionString = _tenantProvider.GetConnectionString();
            return new DynamicDbContext(connectionString);
        }
    }

}
