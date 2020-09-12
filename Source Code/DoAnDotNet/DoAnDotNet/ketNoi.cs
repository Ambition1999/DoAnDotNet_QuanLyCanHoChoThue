using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DoAnDotNet
{
    
    class ketNoi
    {
        SqlConnection _consql;

        public SqlConnection consql
        {
            get { return _consql; }
            set { _consql = value; }
        }

        public ketNoi()
        {
            //consql = new SqlConnection("Data Source=DESKTOP-QQAOPGA\\SQLEXPRESS;Initial Catalog=QL_CanHo;User ID=sa;Password=sa2012");
            //consql = new SqlConnection("Data Source=BACHUTHEGIOI\\SQLEXPRESS;Initial Catalog=ql_Canho;User=sa;Password=len123");
            consql = new SqlConnection("Data Source=DESKTOP-HDFLNM1;Initial Catalog=QL_CANHO;Persist Security Info=True;User ID=sa2012; Password=sa");
        }
    }
}
