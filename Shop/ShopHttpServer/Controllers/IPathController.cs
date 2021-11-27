namespace Shop.ShopHttpServer.Controllers
{
    public interface IPathController
    {
        string Path { get; }
        void AddPath(string path);
        string FindPath(string path);
    }
}
