using System;
using System.Collections.Generic;
using System.Data.OleDb;

namespace WindowsFormsApp8
{
    public class UpFile
    {
        public string GetFileNumber()
        {
            return FileNumber;
        }

        public void SetFileNumber(string a)
        {
            FileNumber = a;
        }
        public string GetFileTitle()
        {
            return FileTitle; ;
        }

        public void SetFileTitle(string a)
        {
            FileTitle = a;
        }
        public string GetFileContent()
        {
            return FileContent; 
        }

        public void SetFileContent(string a)
        {
            FileContent = a;
        }
        public string GetFFixContent()
        {
            return FFixContent;
        }

        public void SetFFixContent(string a)
        {
            FFixContent = a;
        }
        public String GetUpT()
        {
            return UpT;
        }

        public void SetUpT(String a)
        {
            UpT = a;
        }
        public String GetUpD()
        {
            return UpD;
        }

        public void SetUpD(String a)
        {
            UpD = a;
        }
        public String GetFileStatus()
        {
            return FileStatus;
        }

        public void SetFileStatus(String a)
        {
            FileStatus = a;
        }

        public List<string> retrieveAllFile()
        {
            List<string> lstSSN = new List<string>();


            /**********************************************************************************/
            DBConnect dbconn = new DBConnect();
            dbconn.ConnectDB();
            /***********************************************************************************/
            UpFile q = new UpFile();
            try
            {
                dbconn.getCmd().CommandText = "SELECT FileNumber from FileData WHERE Status='" + GetFileStatus() + "'" + " order by FileNumber";
                dbconn.getCmd().CommandType = System.Data.CommandType.Text;
                dbconn.getConn().Open();

                OleDbDataReader reader = dbconn.getCmd().ExecuteReader();
                while (reader.Read())
                {
                    lstSSN.Add(reader["FileNumber"].ToString());
                    
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


        public UpFile Retrieveq(string num)
        {
            DBConnect dbconn = new DBConnect();
            dbconn.ConnectDB();
            UpFile objq = new UpFile();

            try
            {

                dbconn.getCmd().CommandText = "SELECT * from FileData WHERE FileNumber = '" + num + "'";
                dbconn.getCmd().CommandType = System.Data.CommandType.Text;
                dbconn.getConn().Open();

                OleDbDataReader reader = dbconn.getCmd().ExecuteReader();
                while (reader.Read())
                {
                    objq.SetFileNumber(reader["FileNumber"].ToString());
                    objq.SetFileTitle(reader["Title"].ToString());
                    objq.SetFileContent(reader["Content"].ToString());
                    objq.SetFileStatus(reader["Status"].ToString());
                    objq.SetFFixContent(reader["FixContent"].ToString());
                    objq.SetUpD(reader["FileDate"].ToString());
                    objq.SetUpT(reader["UpTime"].ToString());


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
            return objq;
        }
        public bool InsertUpFile(UpFile objUpFile)
        {
            Boolean tf = false;

            DBConnect dbconn = new DBConnect();
            dbconn.ConnectDB();
           
            
            try
            {
                Random r1 = new Random();
               
                // 注意 :  字串要用單引號  ' ',  數字欄位不需要單引號
                dbconn.getCmd().CommandText = "INSERT INTO FileData(FileNumber,Title,Content,FixContent,FileDate,UpTime,Status) VALUES('"+r1.Next(100000,999999) + "','" + objUpFile.GetFileTitle() + "','" + objUpFile.GetFileContent()+"','無" + "','" + objUpFile.GetUpD() + "','" + objUpFile.GetUpT()+"','0"+"')";
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

        public bool UpfdateFileInfo(UpFile objUpFile)
        {
            Boolean tf = false;

            DBConnect dbconn = new DBConnect();
            dbconn.ConnectDB();

            try
            {
                // 注意 :  字串要用單引號  ' ',  數字欄位不需要單引號
                dbconn.getCmd().CommandText = "Update FileData SET  Content='" + objUpFile.GetFileContent()+"',Title='"+objUpFile.GetFileTitle()  + "',Status='" + objUpFile.GetFileStatus()+ "'  WHERE FileNumber= '" + objUpFile.GetFileNumber() + "'";
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
        public bool UpfdateUpFile(UpFile objUpFile)
        {
            Boolean tf = false;

            DBConnect dbconn = new DBConnect();
            dbconn.ConnectDB();

            try
            {
                // 注意 :  字串要用單引號  ' ',  數字欄位不需要單引號
                dbconn.getCmd().CommandText = "Update FileData SET  FixContent='" + objUpFile.GetFFixContent() + "',Status='" + objUpFile.GetFileStatus() + "'  WHERE FileNumber= '" + objUpFile.GetFileNumber() + "'";
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
        public bool DeleteFile(string num)
        {
            Boolean tf = false;

            DBConnect dbconn = new DBConnect();
            dbconn.ConnectDB();

            try
            {
                // 注意 :  字串要用單引號  ' ',  數字欄位不需要單引號
                dbconn.getCmd().CommandText = "DELETE FROM FileData WHERE FileNumber = '" + num + "'";
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

    
        private string FileTitle,FileNumber,FileStatus,FFixContent;
        private string FileContent,UpT;
        private String UpD;

    }
}