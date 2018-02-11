using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;
using NLog;

namespace API.Framework
{
    public static class UserActions
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Method gets user by ID
        /// </summary>
        /// <param name="UserId">User ID</param>
        /// <returns>Object User</returns>
        public static User GetUser(int UserId)
        {
            User resUser = new User();

            WrapperAPI request = new WrapperAPI();
            IRestResponse response = request.GetRequest("users/" + UserId.ToString());

            if (response.ResponseStatus == ResponseStatus.Completed)
            {
                resUser = JsonConvert.DeserializeObject<User>(response.Content);
                logger.Info($"The user with {UserId} user ID was got successfully.");
            }
            else
            {
                logger.Error($"The user with {UserId} user ID was not got!");
            }

            return resUser;
        }

        /// <summary>
        /// Method gets list of Users
        /// </summary>
        /// <returns>List Users</returns>
        public static List<User> GetListUsers()
        {
            List<User> listUsers = new List<User>();
            WrapperAPI request = new WrapperAPI();

            IRestResponse response = request.GetRequest("users");

            if (response.ResponseStatus == ResponseStatus.Completed)
            {
                listUsers = JsonConvert.DeserializeObject<List<User>>(response.Content);
                logger.Info("The list of users was got successfully.");
            }
            else
            {
                logger.Error("The list of users was not got!");
            }

            return listUsers;
        }

        /// <summary>
        /// Method adds new User
        /// </summary>
        /// <param name="user">User object</param>
        /// <returns>True if user added successfully and False if not</returns>
        public static bool CreateUser(User user)
        {
            WrapperAPI request = new WrapperAPI();
            IRestResponse response = request.PostRequest("users", user);

            if (response.StatusCode.ToString() == "Created")
            {
                logger.Info($"The {user.Name} user was created successfully.");
                return true;
            }
            else
            {
                logger.Error($"The {user.Name} user was not created!");
                return false;
            }
        }

        /// <summary>
        /// Method deletes User
        /// </summary>
        /// <param name="userId">User ID</param>
        /// <returns>True if user deleted successfully and False if not</returns>
        public static bool DeleteUser(int userId)
        {
            WrapperAPI request = new WrapperAPI();
            IRestResponse response = request.GetRequest("users/" + userId.ToString());

            if (response.StatusCode.ToString() == "OK")
            {
                logger.Info($"The user with {userId} user ID was deleted successfully.");
                return true;
            }
            else
            {
                logger.Error($"The user with {userId} user ID was not deleted!");
                return false;
            }
        }
    }
}
