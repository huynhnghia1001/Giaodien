
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLKHODevExpress.Model
{
    public class UnitModel
    {
        private readonly string _connectionString = "Data Source=PMQLKho.db";

        
        public int Id { get; set; }
        public string DisplayName { get; set; }




        public List<UnitModel> GetAllDataItems()
        {
            var dataItems = new List<UnitModel>();

            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();

                using (var command = new SQLiteCommand("SELECT * FROM Unit", connection))
                {
                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        var id = reader.GetInt32(0);
                        var name = reader.GetString(1);

                        dataItems.Add(new UnitModel
                        {
                            Id = id,
                            DisplayName = name
                        });
                    }
                }

                connection.Close();
            }

            return dataItems;
        }
    }
}
