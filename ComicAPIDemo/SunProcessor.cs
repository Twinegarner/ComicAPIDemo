using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ComicAPIDemo
{
    public class SunProcessor
    {
        public static async Task<SunModel> LoadSunInformation()
        {
            string url = "https://api.sunrise-sunset.org/json?lat=37.9735&lng=122.5311&date=today";
            
            //open up a call and wait for response NOTE will close after 
            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                //if successful read data 
                if (response.IsSuccessStatusCode)
                {
                    //only get the props we care about sun set and rise just get results 
                    SunResultModel result = await response.Content.ReadAsAsync<SunResultModel>();


                    return result.Results;
                }
                else
                {
                    //throw if there is a problem 
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}
