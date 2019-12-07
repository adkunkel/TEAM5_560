using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace FantasyData.Api
{
    /// <summary>
    /// Static class to aid with api web requests.
    /// </summary>
    public static class ApiAssistant
    {
        /// <summary>
        /// HttpClient allows for get requests.
        /// </summary>
        public static HttpClient ApiClient { get; set; }

        /// <summary>
        /// Initialized within Manager.cs
        /// Creates a new ApiClient, clears the headers, and accepts JSON headers.
        /// </summary>
        public static void InitializeClient()
        {
            ApiClient = new HttpClient();
            ApiClient.DefaultRequestHeaders.Accept.Clear();
            ApiClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}

