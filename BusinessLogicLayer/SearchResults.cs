using DataAccessLayer;
using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;

namespace BusinessLogicLayer
{
    public class SearchResults
    {
        public static List<GridResultDTO> LoadSearchHistory()
        {
            DbCommand comm = GenericDataAccess.CreateCommand("LoadSearchHistory");
            DataTable dtableResults = GenericDataAccess.ExecuteSelectCommand(comm);
            List<GridResultDTO> lstDepartments = new List<GridResultDTO>();
            for (int i = 0; i < dtableResults.Rows.Count; i++)
            {
                lstDepartments.Add(new GridResultDTO
                {
                    Id = i+1,
                    WebTitle = dtableResults.Rows[i]["WebTitle"] != DBNull.Value ? dtableResults.Rows[i]["WebTitle"].ToString() : string.Empty,
                    WebAddress = dtableResults.Rows[i]["WebAddress"] != DBNull.Value ? dtableResults.Rows[i]["WebAddress"].ToString() : string.Empty,
                    SearchDescription = dtableResults.Rows[i]["SearchDescription"] != DBNull.Value ? dtableResults.Rows[i]["SearchDescription"].ToString() : string.Empty
                });
            }
            return lstDepartments;
            
        }

        
    }
}
