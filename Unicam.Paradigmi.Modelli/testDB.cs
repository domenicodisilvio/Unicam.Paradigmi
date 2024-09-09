using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicam.Paradigmi.Modelli.Context;
using Unicam.Paradigmi.Modelli.Entities;

namespace Unicam.Paradigmi.Modelli
{
    public class testDB
    {
        public MyDbContext dbContext { get; set; }

        public testDB()
        {
            dbContext = new MyDbContext();
        }


        public void addBook()
        {
            var connectionString = "Server=localhost; Database=LibreriaParadigmi; User Id=paradigmi; Password=paradigmi;";

            using (var connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    var command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandText = "INSERT INTO Libri(ISBN,Nome,Autore,DataDiPubblicazione,Editore,nomeCategoria) VALUES(@ISBN,@Nome,@Autore,@DataDiPubblicazione,@Editore,@nomeCategoria);";
                    command.Parameters.AddWithValue("@ISBN", "123-456-789");
                    command.Parameters.AddWithValue("@Nome", "Il signore degli anelli");
                    command.Parameters.AddWithValue("@Autore", "Tolkien");
                    command.Parameters.AddWithValue("@DataDiPubblicazione", "1954-07-29");
                    command.Parameters.AddWithValue("@Editore", "Boh");
                    command.Parameters.AddWithValue("@nomeCategoria", "Fantasy");
                    command.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    Console.WriteLine($"Errore SQL: {ex.Message}");
                }
            }
        }


    }
}
