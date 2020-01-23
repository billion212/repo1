using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WindowsFormsApp8
{
    class DBConnect
    {

        private OleDbConnection conn;
        public OleDbConnection getConn()
        {
            return conn;
        }

        private OleDbCommand cmd;
        public OleDbCommand getCmd()
        {
            return cmd;
        }

        public void ConnectDB()
        {

            String strConn = "";

            /************  SQL Server DB*******************************************************/
            //  strConn = "Provider = sqloledb; Data Source = 10.10.6.174; Initial Catalog = imf3a;User Id = imf3a; Password = imf3a;";
            /*********************************************************************************/


            /************ Access DB *******************************************************/
            String myAccessDB = System.Environment.CurrentDirectory + "\\testdb.mdb";
            strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + myAccessDB + ";Persist Security Info = False; ";



            // 初始化連線資訊
            conn = new OleDbConnection(strConn);
            cmd = conn.CreateCommand();


        }

    }
}
