namespace E_Commerce_Website.Helpers
{
    public static class Constants
    {
        public static class APIEndpoints
        {
            public const string Login = "Authenticate/Login";            
            public const string Register = "Authenticate/Register";
            public const string Index = "Category/GetAllCategories";
            public const string Create = "Category/CreateCategory";
        }
        //public static class APIEndpoint
        //{
        //    public const string Register = "Authenticate/Register";
        //}
        public static class HttpNamedClients
        {
            public const string API = "API";
        }
        public static class Roles
        {
            public const string Admin = "Admin";
        }
    }
}
