using System;
namespace MasterQ.Helpers
{
    public interface IFSocket
    {      
        void SendMessage(string argText, string ip, int port);

        //void receiveCallback(string recive);
    }
}
