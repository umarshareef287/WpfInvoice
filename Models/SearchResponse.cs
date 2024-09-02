using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    class SearchResponse
    {
    }


    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Context
    {
        public string title { get; set; }
    }

    public class CseImage
    {
        public string src { get; set; }
    }

    public class CseThumbnail
    {
        public string src { get; set; }
        public string width { get; set; }
        public string height { get; set; }
    }

    public class Item
    {
        public string kind { get; set; }
        public string title { get; set; }
        public string htmlTitle { get; set; }
        public string link { get; set; }
        public string displayLink { get; set; }
        public string snippet { get; set; }
        public string htmlSnippet { get; set; }
        public string formattedUrl { get; set; }
        public string htmlFormattedUrl { get; set; }
        public Pagemap pagemap { get; set; }
        public string mime { get; set; }
        public string fileFormat { get; set; }
    }

    public class Metatag
    {
        [JsonProperty("og:image")]
        public string ogimage { get; set; }

        [JsonProperty("og:type")]
        public string ogtype { get; set; }

        [JsonProperty("twitter:card")]
        public string twittercard { get; set; }

        [JsonProperty("twitter:title")]
        public string twittertitle { get; set; }
        public string clientsideingraphs { get; set; }

        [JsonProperty("al:ios:app_name")]
        public string aliosapp_name { get; set; }

        [JsonProperty("linkedin:pagetag")]
        public string linkedinpagetag { get; set; }

        [JsonProperty("og:title")]
        public string ogtitle { get; set; }

        [JsonProperty("al:android:package")]
        public string alandroidpackage { get; set; }
        public string pagekey { get; set; }
        public string bingbot { get; set; }
        public string locale { get; set; }

        [JsonProperty("al:ios:url")]
        public string aliosurl { get; set; }

        [JsonProperty("og:description")]
        public string ogdescription { get; set; }

        [JsonProperty("al:ios:app_store_id")]
        public string aliosapp_store_id { get; set; }

        [JsonProperty("twitter:image")]
        public string twitterimage { get; set; }

        [JsonProperty("al:android:url")]
        public string alandroidurl { get; set; }

        [JsonProperty("twitter:site")]
        public string twittersite { get; set; }
        public string viewport { get; set; }

        [JsonProperty("twitter:description")]
        public string twitterdescription { get; set; }

        [JsonProperty("og:url")]
        public string ogurl { get; set; }

        [JsonProperty("al:android:app_name")]
        public string alandroidapp_name { get; set; }
        public string template { get; set; }

        [JsonProperty("web-speech-cognitive-services")]
        public string webspeechcognitiveservices { get; set; }

        [JsonProperty("twitter:url")]
        public string twitterurl { get; set; }

        [JsonProperty("cas-exp-at")]
        public string casexpat { get; set; }

        [JsonProperty("oc-version")]
        public string ocversion { get; set; }

        [JsonProperty("botframework-directlinespeech")]
        public string botframeworkdirectlinespeech { get; set; }

        [JsonProperty("awa-canvastype")]
        public string awacanvastype { get; set; }

        [JsonProperty("botframework-directlinespeech:version")]
        public string botframeworkdirectlinespeechversion { get; set; }

        [JsonProperty("awa-istented")]
        public string awaistented { get; set; }

        [JsonProperty("awa-cms")]
        public string awacms { get; set; }

        [JsonProperty("awa-enabledfeatures")]
        public string awaenabledfeatures { get; set; }

        [JsonProperty("botframework-webchat:api")]
        public string botframeworkwebchatapi { get; set; }

        [JsonProperty("botframework-webchat:bundle:variant")]
        public string botframeworkwebchatbundlevariant { get; set; }

        [JsonProperty("awa-market")]
        public string awamarket { get; set; }

        [JsonProperty("botframework-webchat:core")]
        public string botframeworkwebchatcore { get; set; }

        [JsonProperty("botframework-webchat:component")]
        public string botframeworkwebchatcomponent { get; set; }

        [JsonProperty("awa-pagetype")]
        public string awapagetype { get; set; }

        [JsonProperty("botframework-webchat:core:version")]
        public string botframeworkwebchatcoreversion { get; set; }

        [JsonProperty("botframework-webchat:bundle:version")]
        public string botframeworkwebchatbundleversion { get; set; }

        [JsonProperty("botframework-webchat:ui:version")]
        public string botframeworkwebchatuiversion { get; set; }

        [JsonProperty("botframework-webchat:bundle")]
        public string botframeworkwebchatbundle { get; set; }

        [JsonProperty("react-scroll-to-bottom:version")]
        public string reactscrolltobottomversion { get; set; }

        [JsonProperty("react-film")]
        public string reactfilm { get; set; }

        [JsonProperty("cas-exp-visitor")]
        public string casexpvisitor { get; set; }
        public string keyword { get; set; }

        [JsonProperty("article:section")]
        public string articlesection { get; set; }

        [JsonProperty("article:published_time")]
        public DateTime? articlepublished_time { get; set; }

        [JsonProperty("theme-color")]
        public string themecolor { get; set; }

        [JsonProperty("msvalidate.01")]
        public string msvalidate01 { get; set; }

        [JsonProperty("article:author")]
        public string articleauthor { get; set; }

        [JsonProperty("article:tag")]
        public string articletag { get; set; }

        [JsonProperty("article:modified_time")]
        public DateTime? articlemodified_time { get; set; }
        public string schema { get; set; }

        [JsonProperty("ms.author")]
        public string msauthor { get; set; }

        [JsonProperty("ms.topic")]
        public string mstopic { get; set; }
        public string page_type { get; set; }
        public string document_id { get; set; }
        public string feedback_product_url { get; set; }

        [JsonProperty("ms.date")]
        public string msdate { get; set; }
        public string recommendations { get; set; }
        public string depot_name { get; set; }

        [JsonProperty("ms.service")]
        public string msservice { get; set; }
        public string github_feedback_content_git_url { get; set; }

        [JsonProperty("adobe-target")]
        public string adobetarget { get; set; }
        public string word_count { get; set; }
        public string updated_at { get; set; }
        public string original_content_git_url { get; set; }
        public string scope { get; set; }
        public string spproducts { get; set; }
        public string feedback_help_link_url { get; set; }
        public string pdf_url_template { get; set; }

        [JsonProperty("og:image:alt")]
        public string ogimagealt { get; set; }
        public string git_commit_id { get; set; }
        public string manager { get; set; }
        public string persistent_id { get; set; }
        public string author { get; set; }

        [JsonProperty("ms.suite")]
        public string mssuite { get; set; }
        public string services { get; set; }

        [JsonProperty("color-scheme")]
        public string colorscheme { get; set; }
        public string feedback_system { get; set; }
        public string recommendation_types { get; set; }
        public string site_name { get; set; }
        public string learn_banner_products { get; set; }
        public string breadcrumb_path { get; set; }
        public string document_version_independent_id { get; set; }

        [JsonProperty("permissioned-type")]
        public string permissionedtype { get; set; }
        public string cmproducts { get; set; }
        public string feedback_help_link_type { get; set; }
        public string uhfheaderid { get; set; }
        public string toc_rel { get; set; }
        public string gitcommit { get; set; }
        public string creator { get; set; }
        public string creationdate { get; set; }
        public string subject { get; set; }
        public string producer { get; set; }
        public string title { get; set; }

        [JsonProperty("og:site_name")]
        public string ogsite_name { get; set; }

        [JsonProperty("msapplication-tileimage")]
        public string msapplicationtileimage { get; set; }

        [JsonProperty("og:image:secure_url")]
        public string ogimagesecure_url { get; set; }

        [JsonProperty("og:locale")]
        public string oglocale { get; set; }
        public string image { get; set; }

        [JsonProperty("csrf-param")]
        public string csrfparam { get; set; }

        [JsonProperty("twitter:creator")]
        public string twittercreator { get; set; }

        [JsonProperty("csrf-token")]
        public string csrftoken { get; set; }
    }

    public class NextPage
    {
        public string title { get; set; }
        public string totalResults { get; set; }
        public string searchTerms { get; set; }
        public int count { get; set; }
        public int startIndex { get; set; }
        public string inputEncoding { get; set; }
        public string outputEncoding { get; set; }
        public string safe { get; set; }
        public string cx { get; set; }
    }

    public class Organization
    {
        public string name { get; set; }
        public string logo { get; set; }
        public string url { get; set; }
    }

    public class Pagemap
    {
        public List<CseThumbnail> cse_thumbnail { get; set; }
        public List<Metatag> metatags { get; set; }
        public List<CseImage> cse_image { get; set; }
        public List<Organization> organization { get; set; }
    }

    public class Queries
    {
        public List<Request> request { get; set; }
        public List<NextPage> nextPage { get; set; }
    }

    public class Request
    {
        public string title { get; set; }
        public string totalResults { get; set; }
        public string searchTerms { get; set; }
        public int count { get; set; }
        public int startIndex { get; set; }
        public string inputEncoding { get; set; }
        public string outputEncoding { get; set; }
        public string safe { get; set; }
        public string cx { get; set; }
    }

    public class SearchResultDTO
    {
        public string kind { get; set; }
        public Url url { get; set; }
        public Queries queries { get; set; }
        public Context context { get; set; }
        public SearchInformation searchInformation { get; set; }
        public List<Item> items { get; set; }
    }

    public class SearchInformation
    {
        public double searchTime { get; set; }
        public string formattedSearchTime { get; set; }
        public string totalResults { get; set; }
        public string formattedTotalResults { get; set; }
    }

    public class Url
    {
        public string type { get; set; }
        public string template { get; set; }
    }


}
