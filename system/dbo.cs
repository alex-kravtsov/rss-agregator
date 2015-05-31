using System.Collections;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace PRO6 {

    namespace System {

        public class pro6Dbo {

            private MySqlConnection _connection = null;
            private static pro6Dbo _instance = null;
            
            public MySqlDataReader doSelect(string query){
                MySqlCommand command = new MySqlCommand(query, this._connection);
                return command.ExecuteReader();
            }
            
            public void init(string connectionString){
                if(this._connection == null){
                    this._connection = new MySqlConnection(connectionString);
                    this._connection.Open();
                }
            }
            
            public static pro6Dbo getInstance(){
                if(pro6Dbo._instance == null) pro6Dbo._instance = new pro6Dbo();
                return pro6Dbo._instance;
            }

            private pro6Dbo(){
            }
            
        }
        
    }
    
}