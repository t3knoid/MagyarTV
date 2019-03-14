using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagyarTV
{
    class SQLite
    {
        static string connectionFormat = "Data Source={0};Version=3; FailIfMissing=True; Foreign Keys=True;";
        static public SQLiteResult Select(string databasePath, string sql)
        {
            SQLiteResult sqliteResult = new SQLiteResult();
            try
            {
                string connectionString = String.Format(connectionFormat, databasePath);
                sqliteResult.connection = new SQLiteConnection(connectionString);
                sqliteResult.connection.Open();
                sqliteResult.command = new SQLiteCommand(sql, sqliteResult.connection);
                sqliteResult.reader = sqliteResult.command.ExecuteReader();
                sqliteResult.success = true;
            }
            catch (SQLiteException ex)
            {
                CloseConnection(sqliteResult);
                sqliteResult.success = false;
                System.Windows.Forms.MessageBox.Show(String.Format("Error in Select. {0}", ex.Message));
                sqliteResult.message = ex.Message;
                sqliteResult.stacktrace = ex.StackTrace;
            }

            return sqliteResult;
        }

        static public SQLiteResult Exec(string databasePath, string[] queryString)
        {
            SQLiteResult sqliteResult = new SQLiteResult();
            string currentquery = string.Empty;
            try
            {
                string connectionString = String.Format(connectionFormat, databasePath);
                sqliteResult.connection = new SQLiteConnection(connectionString);
                sqliteResult.command = new SQLiteCommand(sqliteResult.connection);
                sqliteResult.connection.Open();
                var transaction = sqliteResult.connection.BeginTransaction();
                foreach (string query in queryString)
                {
                    currentquery = query;
                    
                    sqliteResult.command.CommandText = query;
                    sqliteResult.command.ExecuteNonQuery();
                }
                transaction.Commit();
                sqliteResult.success = true;
            }
            catch (Exception ex)
            {
                CloseConnection(sqliteResult);
                sqliteResult.success = false;
                System.Windows.Forms.MessageBox.Show(String.Format("Error in query, {0}. {1}", currentquery, ex.Message));
                sqliteResult.message = String.Format("Error in query, {0}. {1}", currentquery, ex.Message);
                sqliteResult.stacktrace = ex.StackTrace;
            }
            return sqliteResult;
        }


        static public SQLiteResult Exec(string databasePath, string queryString)
        {
            SQLiteResult sqliteResult = new SQLiteResult();
            try
            {
                string connectionString = String.Format(connectionFormat, databasePath);
                sqliteResult.connection = new SQLiteConnection(connectionString);
                sqliteResult.connection.Open();
                sqliteResult.command = new SQLiteCommand(queryString, sqliteResult.connection);
                sqliteResult.command.Prepare();
                sqliteResult.command.ExecuteNonQuery();
                sqliteResult.success = true;
            }
            catch (Exception ex)
            {
                CloseConnection(sqliteResult);
                sqliteResult.success = false;
                System.Windows.Forms.MessageBox.Show(String.Format("Error in Select. {0}", ex.Message));
                sqliteResult.message = ex.Message;
                sqliteResult.stacktrace = ex.StackTrace;
            }
            return sqliteResult;
        }

        public static void CloseConnection(SQLiteResult sqliteResult)
        {
            if (sqliteResult.command != null)
            {
                sqliteResult.command.Dispose();
            }
            if (sqliteResult.connection != null)
            {
                sqliteResult.connection.Close();
            }
        }

        static public string GetData(SQLiteDataReader reader, string column)
        {
            switch (Type.GetTypeCode(reader.GetFieldType(reader.GetOrdinal(column))))
            {
                case TypeCode.Boolean:
                    return reader.GetBoolean(reader.GetOrdinal(column)).ToString();
                case TypeCode.Byte:
                    return reader.GetByte(reader.GetOrdinal(column)).ToString();
                case TypeCode.Char:
                    return reader.GetChar(reader.GetOrdinal(column)).ToString();
                case TypeCode.DateTime:
                    return reader.GetDateTime(reader.GetOrdinal(column)).ToString("yyyy/mm/dd HH:mm:ss");
                case TypeCode.Decimal:
                    return reader.GetDecimal(reader.GetOrdinal(column)).ToString();
                case TypeCode.Double:
                    return reader.GetDouble(reader.GetOrdinal(column)).ToString();
                case TypeCode.Int16:
                    return reader.GetInt16(reader.GetOrdinal(column)).ToString();
                case TypeCode.Int32:
                    return reader.GetInt32(reader.GetOrdinal(column)).ToString();
                case TypeCode.Int64:
                    return reader.GetInt64(reader.GetOrdinal(column)).ToString();
                case TypeCode.String:
                    return reader.GetString(reader.GetOrdinal(column));
                default:
                    return "";
            }
        }
    }

    public class SQLiteResult
    {
        public bool success;
        public SQLiteConnection connection;
        public SQLiteDataReader reader;
        public SQLiteCommand command;
        public string message;
        public string stacktrace;
    }
}
