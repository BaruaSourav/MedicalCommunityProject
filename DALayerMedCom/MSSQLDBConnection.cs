using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DALayerMedCom
{
   public static class MSSQLDBConnection
    {
        public static SqlConnection con = new SqlConnection(@"Data Source = COMPUDE\ORIIPC; Initial Catalog = MediyardDB; Persist Security Info=True;User ID = sa; Password=***********;MultipleActiveResultSets=True;Application Name = EntityFramework");


    }
}
