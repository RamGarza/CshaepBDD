using System;
using System.Collections.Generic;
using System.Text;



namespace CshaepBDD.Base
{
	class Conexion
	{
		SqlConnection con;
		public conexion()
        {
			con = new SqlConnection("Server=localhost\\;Database=Northwind;integrated security=true");
        }
		public SqlConnection Conectar()
        {
            try
            {
                con.Open();
                return con;
            }catch(Exception e)
            {

                return null
            }
        }
	}
}
