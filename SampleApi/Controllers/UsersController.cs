using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SampleApi.Models;
using MySql.Data.MySqlClient;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SampleApi.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        [HttpGet]
        public List<UserModel> Get() {
            List<UserModel> users = new List<UserModel>();

            string connString = "Server=localhost;Database=webapi_sample;Uid=root;Pwd=root";
            var connection = new MySqlConnection(connString);
            MySqlCommand query = new MySqlCommand();
            query.Connection = connection;
            connection.Open();

            // MARK: Query builder
            query.CommandText = "Select id, name From users";

            MySqlDataReader reader = query.ExecuteReader();

            while (reader.Read()) {
                int id;
                Int32.TryParse(reader["id"].ToString(),out id);
                string name = reader["name"].ToString();

                UserModel user = new UserModel { id = id, name = name };
                users.Add(user);
            }
            connection.Close();
            return users;
        }

        [HttpGet("{id}")]
        public UserModel GetUser(int id) {

            string connString = "Server=localhost;Database=webapi_sample;Uid=root;Pwd=root";
            var connection = new MySqlConnection(connString);
            MySqlCommand query = new MySqlCommand();
            query.Connection = connection;
            connection.Open();

            // MARK: Query builder
            query.CommandText = "Select id, name From users where id = @id";
            query.Parameters.Add("@id", MySqlDbType.Int32).Value = id;

            MySqlDataReader reader = query.ExecuteReader();

            if (reader.Read()) {
                int idReader;
                Int32.TryParse(reader["id"].ToString(), out idReader);
                string name = reader["name"].ToString();

                UserModel user = new UserModel { id = idReader, name = name };

                connection.Close();
                return user;
            } else {
                connection.Close();
                return null;
            }
        }
    }
}
