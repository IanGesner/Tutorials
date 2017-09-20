using System;

namespace PluralSight.Moq.Code.Demo13
{
    public delegate void NotifySalesTeamDelegate(
                    string name,
                    bool broadCastToAllEmployees);

    public interface ICustomerRepository
    {
        void Save(Customer customer);
        //event EventHandler<NotifySalesTeamEventArgs> NotifySalesTeam;
        event NotifySalesTeamDelegate NotifySalesTeam;
//        event NotifySalesTeamDelegate NotifySalesTeam;
    }
}