using Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using BusinessLogicLayer;
namespace Assignments
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<GridResultDTO> lstGridInfo = new List<GridResultDTO>();
        public MainWindow()
        {
            InitializeComponent();

            SearchResultsDataGrid.AutoGenerateColumns = true;
            
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string searchQuery = SearchQueryTextBox.Text.Trim();
            if(searchQuery.Length>3)
            {
                searchDataAsync(searchQuery);
            }
            else
            {
                MessageBox.Show("search textshould be atleast 3 characters long");
            }
            
        }

        private async Task<string> searchDataAsync(String searchText)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://www.googleapis.com");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage responseMessage = await client.GetAsync("/customsearch/v1?key=AIzaSyAjriMPojkNh6Z6WJh9cst-vVKyOLNUhFo&cx=657883eaef1eb4215&q=" + searchText);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = responseMessage.Content.ReadAsStringAsync().Result;
                    var Response = JObject.Parse(responseData);

                    var responseObj = JsonConvert.DeserializeObject<SearchResultDTO>(responseData);
                    
                    int i = 0;
                    if(responseObj.items.Count>0)
                    {
                        foreach(var resultItem in responseObj.items)
                        {
                            i++;
                            GridResultDTO _thisItem = new GridResultDTO();
                            _thisItem.Id = i;
                            _thisItem.WebTitle = resultItem.title;
                            _thisItem.WebAddress = resultItem.formattedUrl;
                            _thisItem.SearchDescription = resultItem.snippet;

                            lstGridInfo.Add(_thisItem);
                        }
                    }

                    SearchResultsDataGrid.ItemsSource = lstGridInfo;
                    SearchResultsDataGrid.Items.Refresh();
                    
                }

            }

            return "";
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            lstGridInfo = null;
            SearchResultsDataGrid.ItemsSource = null;
            SearchResultsDataGrid.Items.Refresh();
        }

        private void HistoryButton_Click(object sender, RoutedEventArgs e)
        {
            
            lstGridInfo = BusinessLogicLayer.SearchResults.LoadSearchHistory();
            SearchResultsDataGrid.ItemsSource = lstGridInfo;
            SearchResultsDataGrid.Items.Refresh();

            lstGridInfo = null;
        }

        private void SaveSearchResult_Click(object sender, RoutedEventArgs e)
        {
            if(lstGridInfo.Count>0)
            {
                bool saved = BusinessLogicLayer.SaveResultBLL.SaveSearchedData(lstGridInfo);
                if(saved)
                {
                    MessageBox.Show("Search result saved successfully");

                    lstGridInfo = null;
                }
            }
            else
            {
                MessageBox.Show("No search result available to save in history");
            }
        }
    }
}
