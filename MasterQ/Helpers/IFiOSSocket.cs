using System;
namespace MasterQ.Helpers
{
    public interface IFiOSSocket
    {
        void SendMessage(string argText, string ip, int port);
    }
}
