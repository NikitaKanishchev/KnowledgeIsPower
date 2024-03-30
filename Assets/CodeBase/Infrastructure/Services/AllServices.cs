namespace CodeBase.Infrastructure.Services
{
    public class AllServices
    {
        private static AllServices _instance;
        public static AllServices Cantainer => _instance ?? (_instance = new AllServices());

        public void RegisterSingle<TService>(TService implemintation) where TService : IService =>
            Implementation<TService>.ServiceInstance = implemintation;

        public TService Single<TService>() where TService : IService =>
            Implementation<TService>.ServiceInstance;


        private static class Implementation<TService> where TService : IService
        {
            public static TService ServiceInstance;
        }
    }
}