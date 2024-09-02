using NLog;
using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public static class GenericDataAccess
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        // creates and prepares a new DbCommand object on a new connection
        public static DbCommand CreateCommand()
        {
            // Obtain the database provider name
            string dataProviderName = ApplicationConfiguration.DbProviderName;
            // Obtain the database connection string
            string connectionString = ApplicationConfiguration.DbConnectionString;
            // Create a new data provider factory
            DbProviderFactory factory = DbProviderFactories.
            GetFactory(dataProviderName);
            // Obtain a database specific connection object
            DbConnection conn = factory.CreateConnection();
            // Set the connection string
            conn.ConnectionString = connectionString;
            // Create a database specific command object
            DbCommand comm = conn.CreateCommand();
            comm.CommandTimeout = 0;
            // Set the command type to stored procedure
            comm.CommandType = CommandType.StoredProcedure;
            // Return the initialized command object
            return comm;
        }

        public static DbCommand CreateCommand(string commandText)
        {
            DbCommand comm = CreateCommand();
            // Set the command Text
            comm.CommandText = commandText;
            // Return the initialized command object
            return comm;
        }

        public static DataTable ExecuteSelectCommand(DbCommand command)
        {
            // The DataTable to be returned
            DataTable table;
            // Execute the command making sure the connection gets closed in the end 
            try
            {
                // Open the data connection
                command.Connection.Open();
                // Execute the command and save the results in a DataTable
                DbDataReader reader = command.ExecuteReader();
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

        public static async Task<DataTable> ExecuteSelectCommandAsync(DbCommand command)
        {
            // The DataTable to be returned
            DataTable table;
            // Execute the command making sure the connection gets closed in the end 
            try
            {
                // Open the data connection
                command.Connection.Open();
                // Execute the command and save the results in a DataTable
                DbDataReader reader = await command.ExecuteReaderAsync();
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

        public static string ExecuteScalar(DbCommand command)
        {
            // The value to be returned
            string value = "";
            // Execute the command making sure the connection gets closed in the end
            try
            {
                // Open the connection of the command
                command.Connection.Open();
                // Execute the command and get the number of affected rows
                value = command.ExecuteScalar().ToString();
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
            // return the result
            return value;
        }

        public static string ExecuteScalarDevice(DbCommand command)
        {
            // The value to be returned
            string value = string.Empty;
            // Execute the command making sure the connection gets closed in the end
            try
            {
                // Open the connection of the command
                command.Connection.Open();
                // Execute the command and get the number of affected rows
                var result = command.ExecuteScalar();
                if (result != null)
                {
                    value = result.ToString();
                }
                else
                {
                    value = "1";
                }
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
            // return the result
            return value;
        }


        public static async Task<string> ExecuteScalarAsync(DbCommand command)
        {
            // The value to be returned
            string value = "";
            // Execute the command making sure the connection gets closed in the end
            try
            {
                // Open the connection of the command
                command.Connection.Open();
                // Execute the command and get the number of affected rows
                var valAsync = await command.ExecuteScalarAsync();
                value = valAsync.ToString();
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
            // return the result
            return value;
        }

        // execute an update, delete, or insert command
        // and return the number of affected rows
        public static int ExecuteNonQuery(DbCommand command)
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

        public static async Task<int> ExecuteNonQueryAsync(DbCommand command)
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

        // executes a command and returns the results as a DataSet object
        public static DataSet ExecuteDataset(DbCommand command)
        {
            // Dataset to be returned
            DataSet dsReturn = new DataSet();

            // Execute the command making sure the connection gets closed in the end
            try
            {
                // Obtain the database provider name
                string dataProviderName = ApplicationConfiguration.DbProviderName;
                DbProviderFactory factory = DbProviderFactories.GetFactory(dataProviderName);

                // Create new data adapter
                DbDataAdapter adapter = factory.CreateDataAdapter();
                adapter.SelectCommand = command;
                adapter.SelectCommand.CommandTimeout = 0;
                adapter.Fill(dsReturn);
            }
            catch (SqlException sqlexc)
            {

                logger.Error(sqlexc);
                logger.Error("SP:" + command.CommandText);
                logger.Error("Parameters:");
                for (int i = 0; i < command.Parameters.Count; i++)
                {
                    logger.Error(command.Parameters[i].ParameterName + ":" + command.Parameters[i].Value);
                }
                throw sqlexc;
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

        /// <summary>
        /// Add Parameter With Size to Database Command
        /// </summary>
        /// <param name="Command">Database Command</param>
        /// <param name="DBParameterName">Database Parameter Name</param>
        /// <param name="Value">Value of Parameter</param>
        /// <param name="DBtype">Type of Parameter</param>
        /// <param name="Size">Size of Parameter</param>
        public static void AddParameter(this DbCommand Command, string DBParameterName, object Value, DbType DBtype, int Size)
        {
            DbParameter param = Command.CreateParameter();
            param.ParameterName = DBParameterName;
            param.Value = Value;
            param.DbType = DBtype;
            param.Size = Size;
            Command.Parameters.Add(param);
        }

        /// <summary>
        /// Add Parameter Without Size to Database Command
        /// </summary>
        /// <param name="Command">Database Command</param>
        /// <param name="DBParameterName">Database Parameter Name</param>
        /// <param name="Value">Value of Parameter</param>
        /// <param name="DBtype">Type of Parameter</param>
        public static void AddParameter(this DbCommand Command, string DBParameterName, object Value, DbType DBtype)
        {
            DbParameter param = Command.CreateParameter();
            param.ParameterName = DBParameterName;
            param.Value = Value;
            param.DbType = DBtype;
            Command.Parameters.Add(param);
        }
    }

}
