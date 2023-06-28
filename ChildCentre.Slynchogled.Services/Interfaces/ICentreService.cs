using ChildCentre.Slynchogled.Data.Models;

namespace ChildCentre.Slynchogled.Services.Interfaces
{
    public interface ICentreService
    {
        void SignInClient(int childId, int childNumber, bool withParent, DateTime signedIn);

        void SignOutClient(int childNumber, DateTime signedOut);

        ActiveChild GetActiveClient(int number);

        List<ActiveChild> GetActiveClients();

        List<Child> GetInactiveClients();
    }
}