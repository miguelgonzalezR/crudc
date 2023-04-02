using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Crud
{
    class Conexion
    {
        public static SqlConnection Conetar()
        {
            SqlConnection cn = new SqlConnection("SERVER=Miguel; DATABASE=crudc; integrated security=true;");
            cn.Open();
            return cn;
        }
    }
}
