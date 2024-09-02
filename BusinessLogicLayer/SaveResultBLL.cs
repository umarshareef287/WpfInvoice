using DataAccessLayer;
using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{

    public class SaveResultBLL
    {
        public static bool SaveSearchedData(List<GridResultDTO> lstGridInfo)
        {
            DataTable dtsearch = BulkResources.CreateEmptyDataTable();
            for(int i=0;i<lstGridInfo.Count;i++)
            {
                DataRow drowResultItem = dtsearch.NewRow();
                drowResultItem["Id"] = i + 1;
                drowResultItem["WebTitle"] = lstGridInfo[i].WebTitle;
                drowResultItem["WebAddress"] = lstGridInfo[i].WebAddress;
                drowResultItem["SearchDescription"] = lstGridInfo[i].SearchDescription;

                dtsearch.Rows.Add(drowResultItem);
                
            }
            try
            {
                SaveBulkData(dtsearch);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            return false;
        }

        public static DataSet SaveBulkData(DataTable dtSearchResults)
        {
            try
            {
                System.Data.SqlClient.SqlCommand comm = SQLDataAccess.CreateCommand("SaveBulkResults");
                comm.AddParameter("@searchResults", dtSearchResults, System.Data.SqlDbType.Structured);

                DataSet dsetReturn = SQLDataAccess.ExecuteDataset(comm);
                return dsetReturn;
            }
            catch (Exception exc)
            {
                string message = exc.Message;
            }
            return new DataSet();
        }
    }
}
