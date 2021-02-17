using System.Threading.Tasks;

namespace NaturKultur.MinaSidor
{
    internal interface INaturKulturMinaSidorLoginClient
    {
        void Dispose();
        Task<bool> TryAuthenticateAsync(string username, string password);
    }
}