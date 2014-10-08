using System.Configuration;
using Moshavit.Entity;

namespace Moshavit.REST.Service.Settings
{
    public class ConnectionConfig : IConnection
    {
        public string DataConnection
        {
            get { return ConfigurationManager.ConnectionStrings["MoshavitDb"].ConnectionString; }
        }
    }
}