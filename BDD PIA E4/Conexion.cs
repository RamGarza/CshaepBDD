using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace BDD_PIA_E4
{
    class Conexion
    {
        public static SqlConnection Conectar()
        {

            SqlConnection con = new SqlConnection("SERVER=DESKTOP-9CI765R;DATABASE=Consultorio;integrated security=true;");
            con.Open();
            return con;

        }
    }
}
