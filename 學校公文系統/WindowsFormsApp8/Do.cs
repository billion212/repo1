using System;
using System.Collections.Generic;
using System.Data.OleDb;

namespace WindowsFormsApp8
{
    public class Do
    {
        public string GetACAC()
        {
            return ACAC;
        }

        public void SetACAC(string a)
        {
            ACAC = a;
        }
        public string GetACPA()
        {
            return ACPA;
        }

        public void SetACPA(string a)
        {
            ACPA= a;
        }

        

       
        public bool InsertAC(Do objac)
        {
            Boolean tf = false;

            DBConnect dbconn = new DBConnect();
            dbconn.ConnectDB();


            try
            {
               

                // 注意 :  字串要用單引號  ' ',  數字欄位不需要單引號
                dbconn.getCmd().CommandText = "INSERT INTO AccountTest(accountId,password) VALUES('" + objac.GetACAC() + "','" + objac.GetACPA() + "')";
                dbconn.getCmd().CommandType = System.Data.CommandType.Text;
                dbconn.getConn().Open();
                dbconn.getCmd().ExecuteNonQuery();
                tf = true;

            }
            catch (Exception e)
            {
                System.Console.WriteLine("Error message :" + e.ToString());
            }
            finally
            {
                if (dbconn.getConn() != null)
                {
                    dbconn.getConn().Close();
                }
            };

            return tf;
        }

       


        private string ACAC, ACPA;

    }
}