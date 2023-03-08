using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;

namespace SL.Services
{
    /// <summary>
    /// Brinda una amplia gama de herramientas útiles relacionadas a SQL.
    /// </summary>
    public static class SqlHelper
    {
        readonly static string conString;

        static SqlHelper()
        {
            conString = @"Data Source=.\SQLEXPRESS;Integrated Security=True";
        }
        public static Int32 ExecuteNonQuery(String commandText,
            CommandType commandType, params SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(conString))
            {
                int returned = 0;

                conn.Open();

                foreach (var query in SplitSqlStatements(commandText))
                {
                    if (string.IsNullOrWhiteSpace(query)) continue;

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // There're three command types: StoredProcedure, Text, TableDirect. The TableDirect 
                        // type is only for OLE DB.  
                        cmd.CommandType = commandType;
                        cmd.Parameters.AddRange(parameters);

                        returned = cmd.ExecuteNonQuery();
                    }
                }

                return returned;
            }
        }

        /// <summary>
        /// Set the connection, command, and then execute the command and only return one value.
        /// </summary>
        public static Object ExecuteScalar(String commandText,
            CommandType commandType, params SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(conString))
            {
                using (SqlCommand cmd = new SqlCommand(commandText, conn))
                {
                    cmd.CommandType = commandType;
                    cmd.Parameters.AddRange(parameters);

                    conn.Open();
                    return cmd.ExecuteScalar();
                }
            }
        }

        /// <summary>
        /// Set the connection, command, and then execute the command with query and return the reader.
        /// </summary>
        public static SqlDataReader ExecuteReader(String commandText,
            CommandType commandType, params SqlParameter[] parameters)
        {
            SqlConnection conn = new SqlConnection(conString);
            string s = commandText;
            using (SqlCommand cmd = new SqlCommand(commandText, conn))
            {
                cmd.CommandType = commandType;
                cmd.Parameters.AddRange(parameters);

                conn.Open();
                // When using CommandBehavior.CloseConnection, the connection will be closed when the 
                // IDataReader is closed.
                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                return reader;
            }
        }

        private static IEnumerable<string> SplitSqlStatements(string sqlScript)
        {
            // Make line endings standard to match RegexOptions.Multiline
            sqlScript = Regex.Replace(sqlScript, @"(\r\n|\n\r|\n|\r)", "\n");

            // Split by "GO" statements
            var statements = Regex.Split(
                    sqlScript,
                    @"^[\t ]*GO[\t ]*\d*[\t ]*(?:--.*)?$",
                    RegexOptions.Multiline |
                    RegexOptions.IgnorePatternWhitespace |
                    RegexOptions.IgnoreCase);

            // Remove empties, trim, and return
            return statements
                .Where(x => !string.IsNullOrWhiteSpace(x))
                .Select(x => x.Trim(' ', '\n'));
        }
    }
}
