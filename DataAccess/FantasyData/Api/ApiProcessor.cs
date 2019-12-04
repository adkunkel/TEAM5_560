using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace FantasyData.Api
{
    public class ApiProcessor
    {
        /// <summary>
        /// This static async class awaits a response from the 
        /// apiAsyncClient and reads in the response as the specified type.
        /// </summary>
        /// <param name="url">Website Address</param>
        /// <returns>Player information list</returns>
        public static async Task<ApiModel> LoadInformation(string url)
        {
            using (HttpResponseMessage response = await ApiAssistant.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    ApiModel model = await response.Content.ReadAsAsync<ApiModel>();
                    return ApiModel;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}
