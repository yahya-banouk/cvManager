using cvManager.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Net;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace cvManager.Repositories
{
    public class CondidateRepository : RepositoryBase, ICondidatRepository
    {
        public void Add(CondidatModel condidatModel)
        {
            if(condidatModel != null)
            {
                using (var connection = GetConnection())
                using (var command = new SqlCommand())
                {

                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = "INSERT INTO condidat VALUES (@name,@lastname,@age,@email,@level,@experience,@profission)";
                    command.Parameters.Add("@name", System.Data.SqlDbType.NVarChar).Value = condidatModel.Name;
                    command.Parameters.Add("@lastname", System.Data.SqlDbType.NVarChar).Value = condidatModel.LastName;
                    command.Parameters.Add("@age", System.Data.SqlDbType.NVarChar).Value = condidatModel.Age;
                    command.Parameters.Add("@email", System.Data.SqlDbType.NVarChar).Value = condidatModel.Email;
                    command.Parameters.Add("@level", System.Data.SqlDbType.NVarChar).Value = condidatModel.Level;
                    command.Parameters.Add("@experience", System.Data.SqlDbType.NVarChar).Value = condidatModel.Experience;
                    command.Parameters.Add("@profission", System.Data.SqlDbType.NVarChar).Value = condidatModel.Profession;
                    //Execution
                    command.ExecuteScalar();

                }
            }
            else
            {

            }
            
        }

        public void Edit(CondidatModel condidatModel)
        {
            throw new NotImplementedException();
        }

        public List<CondidatModel> GetAll()
        {
            List<CondidatModel> list;
            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {

                connection.Open();
                command.Connection = connection;
                command.CommandText = "Select * from condidat";
                ;
                //Execution
                list = (List<CondidatModel>)command.ExecuteScalar();
                return list;

            }
        }

        public CondidatModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<CondidatModel> GetByLevel(string level)
        {
            throw new NotImplementedException();
        }

        public List<CondidatModel> GetByProfession(string profession)
        {
            throw new NotImplementedException();
        }

        public List<CondidatModel> GetByUsername(string name)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}
