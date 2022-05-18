using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace CshaepBDD
{
    class Class1
    {
        public static SqlConnection Conectar()
        {
            SqlConnection con = new SqlConnection("SERVER=.;DATABASE=Northwind;integrated security=true;");
            con.Open();
            return con;
        }
    }
}
