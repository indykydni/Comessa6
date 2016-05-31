using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Comessa6.DataAccessLayer
{  
  public class ComessaDB
  {
    private static MySqlConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings[0].ConnectionString);


  }
}