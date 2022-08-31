using cvManager.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace cvManager.Repositories
{
    public class UserRepository : RepositoryBase, IUserRepository
    {
        public void Add(UserModel userModel)
        {
            throw new NotImplementedException();
        }

        public bool AuthenticationUser(NetworkCredential credential)
        {

            bool validUser;
            using (var connection = GetConnection())
            using ( var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText="select * from [user] where username=@username and [password]=@password";
                command.Parameters.Add("@username", System.Data.SqlDbType.NVarChar).Value=credential.UserName;
                command.Parameters.Add("@password", System.Data.SqlDbType.NVarChar).Value=credential.Password;
                validUser=command.ExecuteScalar()==null ? false : true;
                
            }
                return validUser;
        }

        public void Edit(UserModel userModel)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserModel> GetByAll()
        {
            throw new NotImplementedException();
        }

        public UserModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public UserModel GetByUsername(string username)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}
