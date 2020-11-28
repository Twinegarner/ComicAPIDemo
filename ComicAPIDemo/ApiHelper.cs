using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;


//This class helps find the API
namespace ComicAPIDemo
{
    public static class ApiHelper
    {
        //we want to set up a one time port so the use of static is needed
        public static HttpClient ApiClient { get; set; }
        //set up the api client
        public static void InitializeClient()
        {
            ApiClient = new HttpClient();
            //no need for base address
            //ApiClient.BaseAddress = new Uri("");
            ApiClient.DefaultRequestHeaders.Accept.Clear();
            //adds a header for json file-> just give me json
            ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        }

    }
}
