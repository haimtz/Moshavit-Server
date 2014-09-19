namespace Moshavit.Entity.Dto
{
    public class UserLoginDto
    {
        /// <summary>
        /// Identifier of user to log on to system
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Password to login
        /// </summary>
        public string Password { get; set; }
    }
}
