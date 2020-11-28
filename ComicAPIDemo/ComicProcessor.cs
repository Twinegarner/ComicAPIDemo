using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ComicAPIDemo
{
   
    public class ComicProcessor
    {
        //property
        public int MaxComicNumber { get; set; }

        //we want to async so we dont have to depend on the website speed
        public static async Task<ComicModel> LoadComic(int comicNumber = 0)
        {
            string url = "";
            //handle the url to find a comic givin a number 
            if(comicNumber > 0)
            {
                url = $"https://xkcd.com/{ comicNumber }/info.0.json";
            }
            else
            {
                url = "https://xkcd.com/info.0.json";
            }
            //open up a call and wait for response NOTE will close after 
            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url)) 
            {
                //if successful read data 
                if (response.IsSuccessStatusCode)
                {
                    //only get the props we care about img and num 
                    ComicModel comic = await response.Content.ReadAsAsync<ComicModel>();
                    

                    return comic;
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
