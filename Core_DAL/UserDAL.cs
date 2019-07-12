using Npgsql;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Options;
using Core_DAL_Interfaces;
using Core_Domain;

namespace Core_DAL
{
    public class UserDAL: IUserDAL
    {
        #region provate variables
        private IOptions<AppSettingsModel> appSettings;

        private readonly string strGetUsersQuery = @"select first_name FirstName,last_name LastName,user_id UserId from security.user_account";
        #endregion
        public UserDAL(IOptions<AppSettingsModel> Appstns)
        {
            this.appSettings = Appstns;
        }
        public List<User> GetUsers()
        {
            // TODO: Need to make it generic
            var dbConnectionString = appSettings.Value.DefaultConnection;
            NpgsqlConnection conn = new NpgsqlConnection(dbConnectionString.ToString());

            conn.Open();
            PetaPoco.Database db = new PetaPoco.Database(conn);

            List<User> userslst = db.Query<User>(strGetUsersQuery).ToList();
            conn.Close();
            return userslst;

        }
    }
}
