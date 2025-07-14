using System.Data;
using Microsoft.Data.SqlClient;
using PhysioApp.Data;
using PhysioApp.Models;

namespace PhysioApp.Repository
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        private readonly DbHelper _dbHelper;
        public UserRepository(IConfiguration configuration, DbHelper dbHelper) : base(configuration)
        {
            _dbHelper = dbHelper;
        }

        public async Task<string> AddUsers(Users user)
        {
            string UserSerialNo = "";
            string[] parameterNames = { "UserId", "UserName", "UserSerialNo", "Password", "UserRole" };

            object[] Values = { user.UserId, user.UserName, user.UserSerialNo, user.Password, user.UserRole };

            string Sp = "AddUsers";
            var data = await _dbHelper.ExecuteScalarAsync(Sp, parameterNames, Values);
            if (data != null)
            {
                UserSerialNo = Convert.ToString(data);
            }
            return UserSerialNo;

        }

        public async Task<int> EditUsers(Users user)
        {
            string[] parameterNames = { "UserId", "UserName", "UserSerialNo", "Password", "UserRole" };

            object[] Values = { user.UserId, user.UserName, user.UserSerialNo, user.Password, user.UserRole };

            string Sp = "AddUsers";
            var data = await _dbHelper.ExecuteScalarAsync(Sp, parameterNames, Values);
            int RecordAfected = 0;
            if (data != null)
            {
                RecordAfected = Convert.ToInt32(data);
            }
            return RecordAfected;

        }

        public async Task<List<Users>> GetAllUsers()
        {
            string[] parameterNames = { };

            object[] Values = { };

            string Sp = "GetAllUsers";

            DataSet result = await _dbHelper.ExecuteDataSetAsync(Sp, parameterNames, Values);

            List<Users> users = new();

            for (int i = 0; i < result.Tables[0].Rows.Count; i++)
            {
                Users user = new();
                user.UserId = Convert.ToInt32(result.Tables[0].Rows[i]["UserId"]);
                user.UserName = Convert.ToString(result.Tables[0].Rows[i]["UserName"]);
                user.UserSerialNo = Convert.ToString(result.Tables[0].Rows[i]["UserSerialNo"]);
                user.Password = Convert.ToString(result.Tables[0].Rows[i]["Password"]);
                user.UserRole = Convert.ToString(result.Tables[0].Rows[i]["UserRole"]);
                users.Add(user);
            }
            return users;
        }

        public async Task<Users> GetUserById(int userId)
        {
            string[] parameterNames = { "UserId" };

            object[] Values = { userId };

            string Sp = "GetUserById";

            DataSet result = await _dbHelper.ExecuteDataSetAsync(Sp, parameterNames, Values);
            Users user = new();
            user.UserId = Convert.ToInt32(result.Tables[0].Rows[0]["UserId"]);
            user.UserName = Convert.ToString(result.Tables[0].Rows[0]["UserName"]);
            user.UserSerialNo = Convert.ToString(result.Tables[0].Rows[0]["UserSerialNo"]);
            user.Password = Convert.ToString(result.Tables[0].Rows[0]["Password"]);
            user.UserRole = Convert.ToString(result.Tables[0].Rows[0]["UserRole"]);
            return user;

        }
    }
}
