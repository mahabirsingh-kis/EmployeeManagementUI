using EmployeeManagementUIApiClient;

namespace EmployeeManagementUI.Factory
{
    internal static class EmployeeManagementApiClientFactory
    {
        private static Uri apiUri;

        private static Lazy<ApiClient> restClient = new Lazy<ApiClient>(
          () => new ApiClient(apiUri),
          LazyThreadSafetyMode.ExecutionAndPublication);

        static EmployeeManagementApiClientFactory()
        {
            apiUri = new Uri("https://employemanagementapi.azurewebsites.net/api/");
        }

        public static ApiClient Instance
        {
            get
            {
                return restClient.Value;
            }
        }
    }
}
