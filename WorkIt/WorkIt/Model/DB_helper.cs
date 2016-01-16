using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkIt.Model
{
    class DB_helper
    {
        public static string connectionString = ""; //WorkIt.Properties.Settings.Default.connectionString;
        public static SqlConnection con = new SqlConnection(connectionString);

        /// <summary>
        /// To Execute queries which returns result set (table / relation)
        /// </summary>
        /// <param name="query">the query string</param>
        /// <returns></returns>
        public  DataTable ExecuteDataTable(string query)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataAdapter tableAdapter = new SqlDataAdapter(cmd);
                //tableAdapter.SelectCommand = cmd;
                DataTable dt = new DataTable();
                tableAdapter.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        /// <summary>
        /// To Execute update / insert / delete queries
        /// </summary>
        /// <param name="query">the query string</param>
        public  void ExecuteNonQuery(string query)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        /// <summary>
        /// To Execute queries which return scalar value
        /// </summary>
        /// <param name="query">the query string</param>
        public  object ExecuteScalar(string query)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd = new SqlCommand(query, con);
                return cmd.ExecuteScalar();
            }
            catch
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }
    }
}
