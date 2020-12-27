using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;              

namespace Aurora.Clases.Datos
{
    internal class Folio:BaseDatos
    {
        public static int getFolio()
        {
            int result = 0;
            using (SqlConnection cn = new SqlConnection(StringConexion()))
            {
                cn.Open();
                SqlCommand cd = new SqlCommand(PA.FOLIO, cn);
                cd.CommandType = CommandType.StoredProcedure;
                result = Convert.ToInt16(cd.ExecuteScalar());
            }
            return result;
        }
    }
}
