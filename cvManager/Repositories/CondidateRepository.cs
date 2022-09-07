﻿using cvManager.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Net;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Data;

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
                    command.CommandText = "INSERT INTO condidate VALUES (@name,@lastname,@age,@email,@level,@experience,@profission)";
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
        private List<T> GetList<T>(IDataReader reader)
        {
            List<T> list = new List<T>();
            while (reader.Read())
            {
                var type = typeof(T);
                T obj=(T)Activator.CreateInstance(type);
                foreach (var prop in type.GetProperties())
                {
                    var PropTaype = prop.PropertyType;
                    prop.SetValue(obj,Convert.ChangeType(reader[prop.Name].ToString(),PropTaype));
                }
                list.Add(obj);

            }
            return list;
        }

        public void Edit(CondidatModel condidatModel)
        {
            
            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "UPDATE condidate SET Name=@Name, LastName=@Lastname, Age=@Age, Email=@Email, [Level]=@Level, Experience=@Experience , Profession=@Profession  WHERE Id=@Id";
                command.Parameters.Add("@Id", System.Data.SqlDbType.NVarChar).Value = condidatModel.Id;
                command.Parameters.Add("@Name", System.Data.SqlDbType.NVarChar).Value = condidatModel.Name;
                command.Parameters.Add("@Lastname", System.Data.SqlDbType.NVarChar).Value = condidatModel.LastName;
                command.Parameters.Add("@Age", System.Data.SqlDbType.NVarChar).Value = condidatModel.Age;
                command.Parameters.Add("@Email", System.Data.SqlDbType.NVarChar).Value = condidatModel.Email;
                command.Parameters.Add("@Level", System.Data.SqlDbType.NVarChar).Value = condidatModel.Level;
                command.Parameters.Add("@Experience", System.Data.SqlDbType.NVarChar).Value = condidatModel.Experience;
                command.Parameters.Add("@Profession", System.Data.SqlDbType.NVarChar).Value = condidatModel.Profession;


                command.ExecuteScalar();

            }
        }

        public List<CondidatModel> GetAll()
        {
            List<CondidatModel> list=null;
            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {

                connection.Open();
                command.Connection = connection;
                command.CommandText = "Select * from condidate";
                using (var reader = command.ExecuteReader())
                {
                    
                    list = GetList<CondidatModel>(reader);
                }
            }
            return list;
        }
          

        public List<CondidatModel> GetById(int id)
        {
            List<CondidatModel> list = null;
            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {

                connection.Open();
                command.Connection = connection;
                command.CommandText = "Select * from condidate where Id=@Id";
                command.Parameters.Add("@Id", System.Data.SqlDbType.NVarChar).Value = id;
                using (var reader = command.ExecuteReader())
                {

                    list = GetList<CondidatModel>(reader);
                }
            }
            return list;
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
            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "DELETE FROM condidate WHERE Id=@Id";
                command.Parameters.Add("@Id", System.Data.SqlDbType.NVarChar).Value = id;


               command.ExecuteScalar() ;

            }
        }

        public List<CondidatModel> GetByWhatever(string searchString)
        {
            List<CondidatModel> list = null;
            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {

                connection.Open();
                command.Connection = connection;
                command.CommandText = "Select * from condidate where (Name LIKE '%"+ searchString + "%' ) or (LastName LIKE '%"+ searchString + "%') or  (Email LIKE '%"+ searchString + "%') or ([Level] LIKE '%"+ searchString + "%') or (Profession LIKE '%"+ searchString + "%')";
                
                Console.WriteLine(command.CommandText);
                using (var reader = command.ExecuteReader())
                {

                    list = GetList<CondidatModel>(reader);
                }
            }
            return list;
        }
    }

        

        

       

        

        
    }
