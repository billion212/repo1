using System;
using System.Collections.Generic;
using System.Data.OleDb;

namespace WindowsFormsApp8
{
    public class Account
    {
        public void setACID(string a)
        {
            ACID = a;
        }
        public string getACID()
        {
            return ACID;
        }

       
        public void setACPA(string a)
        {
           ACPA = a;
        }
        public string getACPA()
        {
            return ACPA;
        }
        public void setACname(string a)
        {
            ACname = a;
        }
        public string getACname()
        {
            return ACname;
        }
        public void setACtype(string a)
        {
            ACtype = a;
        }
        public string getACtype()
        {
            return ACtype;
        }
        public void setACMP(string a)
        {
            ACMP = a;
        }
        public string getACMP()
        {
            return ACMP;
        }
        public void setACg(string a)
        {
            ACg = a;
        }
        public string getACg()
        {
            return ACg;
        }
        public List<string> retrieveAllFile()
        {
            List<string> lstSSN = new List<string>();


            /**********************************************************************************/
            DBConnect dbconn = new DBConnect();
            dbconn.ConnectDB();
            /***********************************************************************************/
            Account q = new Account();
            try
            {
                dbconn.getCmd().CommandText = "SELECT membername from AccountData"+ " order by membername";
                dbconn.getCmd().CommandType = System.Data.CommandType.Text;
                dbconn.getConn().Open();

                OleDbDataReader reader = dbconn.getCmd().ExecuteReader();
                while (reader.Read())
                {
                    lstSSN.Add(reader["membername"].ToString());

                }


                return lstSSN;
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                if (dbconn.getConn() != null)
                {
                    dbconn.getConn().Close();
                }
            }



        }
        public bool UpfdateACInfo(Account obj)
        {
            Boolean tf = false;

            DBConnect dbconn = new DBConnect();
            dbconn.ConnectDB();

            try
            {
                // 注意 :  字串要用單引號  ' ',  數字欄位不需要單引號
                dbconn.getCmd().CommandText = "Update AccountData SET  mobilephone='" + obj.getACMP() + "',Pass='" + obj.getACPA()  + "'  WHERE accountId= '" + obj.getACID() + "'";
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

        public Account Retrieveac(string acin)
        {
            DBConnect dbconn = new DBConnect();
            dbconn.ConnectDB();
            Account objacin = new Account();

            try
            {
               
                dbconn.getCmd().CommandText = "SELECT * from AccountData WHERE accountId = '" + acin+ "'";
                dbconn.getCmd().CommandType = System.Data.CommandType.Text;
                dbconn.getConn().Open();

                OleDbDataReader reader = dbconn.getCmd().ExecuteReader();
                while (reader.Read())
                {
                    objacin.setACID(reader["accountId"].ToString());
                    objacin.setACPA(reader["Pass"].ToString());
                    objacin.setACtype(reader["type"].ToString());
                    objacin.setACname(reader["membername"].ToString());
                    objacin.setACMP(reader["mobilephone"].ToString());
                    objacin.setACg(reader["gender"].ToString());
                }
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
            }
            return objacin;
        }
        public Account RetrieveFN(string na)
        {
            DBConnect dbconn = new DBConnect();
            dbconn.ConnectDB();
            Account objacin = new Account();

            try
            {

                dbconn.getCmd().CommandText = "SELECT * from AccountData WHERE membername = '" + na + "'";
                dbconn.getCmd().CommandType = System.Data.CommandType.Text;
                dbconn.getConn().Open();

                OleDbDataReader reader = dbconn.getCmd().ExecuteReader();
                while (reader.Read())
                {
                    
                    objacin.setACMP(reader["mobilephone"].ToString());
                    objacin.setACtype(reader["type"].ToString());
                }
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
            }
            return objacin;
        }
        public bool Insertf(Account a)
        {
            Boolean tf = false;

            DBConnect dbconn = new DBConnect();
            dbconn.ConnectDB();


            try
            {
                

                // 注意 :  字串要用單引號  ' ',  數字欄位不需要單引號
                dbconn.getCmd().CommandText = "INSERT INTO AccountData(accountId,Pass,type,membername,mobilephone,gender) VALUES('" + a.getACID()+ "','" + a.getACPA()+"','" + a.getACtype()+"','" + a.getACname() + "','" + a.getACMP() + "','" + a.getACg() + "')";
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

       
        private string ACID, ACPA, ACname,ACtype,ACMP,ACg;

        

    }
}