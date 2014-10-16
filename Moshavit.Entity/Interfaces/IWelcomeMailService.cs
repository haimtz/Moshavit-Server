namespace Moshavit.Entity.Interfaces
{
    public interface IWelcomeMailService
    {
        /// <summary>
        /// Send welcome message to a new user
        /// </summary>
        /// <param name="email">new user email</param>
        /// <param name="userName">User name</param>
        void SendWelcome(string email, string userName);
    }
}
