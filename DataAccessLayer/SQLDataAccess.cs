using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public static class SQLDataAccess
    {
        //Execute select command
        public static DataTable ExecuteSelectCommand(SqlCommand command)
        {
            // The DataTable to be returned
            DataTable table;
            // Execute the command making sure the connection gets closed in the end 
            try
            {
                // Open the data connection
                command.Connection.Open();
                // Execute the command and save the results in a DataTable
                SqlDataReader reader = command.ExecuteReader();
                table = new DataTable();
                table.Load(reader);
                // Close the reader
                reader.Close();

            }
            catch (Exception ex)
            {
                //Utilities.LogError(ex);
                throw ex;
            }
            finally
            {
                // Close the connection
                command.Connection.Close();
            }
            return table;
        }

        public static async Task<DataTable> ExecuteSelectCommandAsync(SqlCommand command)
        {
            // The DataTable to be returned
            DataTable table;
            // Execute the command making sure the connection gets closed in the end 
            try
            {
                // Open the data connection
                command.Connection.Open();
                // Execute the command and save the results in a DataTable
                SqlDataReader reader = await command.ExecuteReaderAsync();
                table = new DataTable();
                table.Load(reader);
                // Close the reader
                reader.Close();

            }
            catch (Exception ex)
            {
                //Utilities.LogError(ex);
                throw ex;
            }
            finally
            {
                // Close the connection
                command.Connection.Close();
            }
            return table;
        }

        //Execute DataSet
        public static DataSet ExecuteDataset(SqlCommand command)
        {
            // Dataset to be returned
            DataSet dsReturn = new DataSet();

            // Execute the command making sure the connection gets closed in the end
            try
            {
                // Open the data connection
                command.Connection.Open();
                // Execute the command and save the results in a DataTable
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.SelectCommand.CommandTimeout = 0;
                adapter.Fill(dsReturn);
            }
            catch (Exception ex)
            {
                //Utilities.LogError(ex);
                throw ex;
            }
            finally
            {
                // Close the connection
                command.Connection.Close();
            }
            return dsReturn;
        }

        public static async Task<DataSet> ExecuteDatasetAsync(SqlCommand command)
        {
            // Dataset to be returned
            DataSet dsReturn = new DataSet();

            // Execute the command making sure the connection gets closed in the end
            try
            {
                return await Task<DataSet>.Factory.StartNew(() =>
                {

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dsReturn);

                    }
                    return dsReturn;
                });
            }
            catch (Exception ex)
            {
                //Utilities.LogError(ex);
                throw ex;
            }
            finally
            {
                // Close the connection
                command.Connection.Close();
            }
            //return dsReturn;
        }

        // execute an update, delete, or insert command
        // and return the number of affected rows
        public static int ExecuteNonQuery(SqlCommand command)
        {
            // The number of affected rows
            int affectedRows = -1;
            // Execute the command making sure the connection gets closed in the end
            try
            {
                // Open the connection of the command
                command.Connection.Open();
                // Execute the command and get the number of affected rows
                affectedRows = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                // Log eventual errors and rethrow them
                //Utilities.LogError(ex);
                throw ex;
            }
            finally
            {
                // Close the connection
                command.Connection.Close();
            }
            // return the number of affected rows
            return affectedRows;
        }

        public static async Task<int> ExecuteNonQueryAsync(SqlCommand command)
        {
            // The number of affected rows
            int affectedRows = -1;
            // Execute the command making sure the connection gets closed in the end
            try
            {
                // Open the connection of the command
                await command.Connection.OpenAsync();
                // Execute the command and get the number of affected rows
                affectedRows = await command.ExecuteNonQueryAsync();
            }
            catch (Exception ex)
            {
                // Log eventual errors and rethrow them
                //Utilities.LogError(ex);
                throw ex;
            }
            finally
            {
                // Close the connection
                command.Connection.Close();
            }
            // return the number of affected rows
            return affectedRows;
        }

        public static SqlCommand CreateCommand()
        {
            // Obtain the database provider name
            string dataProviderName = ApplicationConfiguration.DbProviderName;
            // Obtain the database connection string
            string connectionString = ApplicationConfiguration.DbConnectionString;

            // Obtain a database specific connection object
            SqlConnection conn = new SqlConnection();
            // Set the connection string
            conn.ConnectionString = connectionString;
            // Create a database specific command object
            SqlCommand comm = conn.CreateCommand();
            //Timeout
            comm.CommandTimeout = 0;
            // Set the command type to stored procedure
            comm.CommandType = CommandType.StoredProcedure;
            // Return the initialized command object
            return comm;
        }

        public static SqlCommand CreateCommand(string commandText)
        {
            SqlCommand comm = CreateCommand();
            // Set the command Text
            comm.CommandText = commandText;
            // Return the initialized command object
            return comm;
        }


        /// <summary>
        /// Add Parameter Without Size to Database Command
        /// </summary>
        /// <param name="Command">Database Command</param>
        /// <param name="DBParameterName">Database Parameter Name</param>
        /// <param name="Value">Value of Parameter</param>
        /// <param name="DBtype">Type of Parameter</param>
        public static void AddParameter(this SqlCommand Command, string DBParameterName, object Value, SqlDbType DBtype)
        {
            SqlParameter param = Command.CreateParameter();
            param.ParameterName = DBParameterName;
            param.Value = Value;
            param.SqlDbType = DBtype;
            Command.Parameters.Add(param);
        }


        /// <summary>
        /// Add Parameter With Size to Database Command
        /// </summary>
        /// <param name="Command">Database Command</param>
        /// <param name="DBParameterName">Database Parameter Name</param>
        /// <param name="Value">Value of Parameter</param>
        /// <param name="DBtype">Type of Parameter</param>
        /// <param name="Size">Size of Parameter</param>
        public static void AddParameter(this SqlCommand Command, string DBParameterName, object Value, SqlDbType DBtype, int Size)
        {
            SqlParameter param = Command.CreateParameter();
            param.ParameterName = DBParameterName;
            param.Value = Value;
            param.SqlDbType = DBtype;
            param.Size = Size;
            Command.Parameters.Add(param);
        }
    }
}
