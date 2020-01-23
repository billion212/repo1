using System;
using System.Collections.Generic;
using System.Data.OleDb;

namespace WindowsFormsApp8
{
    public class FileQ
    {
        public string GetFileTitle()
        {
            return FileTitle;
        }

        public void SetFileTitle(string a)
        {
            FileTitle = a;
        }
        public string GetFileNumber()
        {
            return FileNumber;
        }

        public void SetFileNumber(string a)
        {
            FileNumber = a;
        }


        public List<string> retrieveAllFile()
        {
            List<string> lstSSN = new List<string>();


            /**********************************************************************************/
            DBConnect dbconn = new DBConnect();
            dbconn.ConnectDB();
            /***********************************************************************************/

            try
            {
                dbconn.getCmd().CommandText = "SELECT FileNumber from FileData order by FileNumber";
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

       


        /* public bool UpfdateUpFile(UpFile objUpFile)
         {
             Boolean tf = false;

             DBConnect dbconn = new DBConnect();
             dbconn.ConnectDB();

             try
             {
                 // 注意 :  字串要用單引號  ' ',  數字欄位不需要單引號
                 dbconn.getCmd().CommandText = "Update UpFile SET  FacFirstName='" + objUpFile.GetFacFirstName() + "', FacLastName ='" + objUpFile.GetFacLastName() + "', FacCity = '" + objUpFile.GetFacCity() + "', FacDept = '" + objUpFile.GetFacDept() + "', FacSalary = " + objUpFile.GetFacSalary() + ", FacHireDate = '" + objUpFile.GetFacHireDate().ToLongDateString() + "'  WHERE FacSSN = '" + objUpFile.GetFacSSN() + "'";
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

         public bool DeleteFaculty(string paramFacSSN)
         {
             Boolean tf = false;

             DBConnect dbconn = new DBConnect();
             dbconn.ConnectDB();

             try
             {
                 // 注意 :  字串要用單引號  ' ',  數字欄位不需要單引號
                 dbconn.getCmd().CommandText = "DELETE FROM Faculty WHERE FacSSN = '" + paramFacSSN + "'";
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

     */
        private string FileTitle,FileContent,FileNumber;
        
    }
}