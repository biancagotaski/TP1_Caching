using System.Collections.Generic;
using FirstApplication.Domain;
using System.Data;
using System.Data.SqlClient;

namespace FirstApplication.Repository
{

    public class ListaRepository
    {
        SqlConnection connection;

        public IEnumerable<Pessoa> GetAllPessoas()
        {
            var connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\FirstApplicationDB.mdf;Integrated Security=True";

            using (connection = new SqlConnection(connectionString))
            {
                var commandText = "SELECT * FROM Pessoa";
                var selectCommand = new SqlCommand(commandText, connection);

                Pessoa pessoa = null;
                var pessoas = new List<Pessoa>();

                try
                {
                    connection.Open();

                    using (var reader = selectCommand.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        while (reader.Read())
                        {
                            pessoa = new Pessoa();
                            pessoa.Id = (int)reader["Id"];
                            pessoa.Nome = reader["Nome"].ToString();
                            pessoa.Sobrenome = reader["Sobrenome"].ToString();
                            pessoa.Email = reader["Email"].ToString();

                            pessoas.Add(pessoa);
                        }

                    }
                }
                finally
                {

                    connection.Close();
                }

                return pessoas;
            }
        }

        public void CreatePessoa(Pessoa pessoa)
        {
            var connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\FirstApplicationDB.mdf;Integrated Security=True";

            using (var connection = new SqlConnection(connectionString))
            {
                var commandText = "INSERT INTO Pessoa (Nome, Sobrenome, Email) VALUES (@Nome, @Sobrenome, @Email)";
                var insertCommand = new SqlCommand(commandText, connection);
                insertCommand.Parameters.AddWithValue("@Nome", pessoa.Nome);
                insertCommand.Parameters.AddWithValue("@Sobrenome", pessoa.Sobrenome);
                insertCommand.Parameters.AddWithValue("@Email", pessoa.Email);
                try
                {
                    connection.Open();
                    insertCommand.ExecuteNonQuery();
                }
                finally
                {

                    connection.Close();
                }
            }
        }


    }
}