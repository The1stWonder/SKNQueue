using System;
namespace MasterQ.Helpers
{
    public interface IFNotification
    {
        void SendNotification(string act, string body);
    }
}
