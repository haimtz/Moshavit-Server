namespace Moshavit.Entity.Interfaces
{
    public interface IForgotPasswordService
    {
        /// <summary>
        /// Send the password to user by email
        /// </summary>
        /// <param name="email"></param>
        void SendPassword(string email);
    }
}
