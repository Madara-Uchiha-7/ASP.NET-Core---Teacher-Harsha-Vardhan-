using _159._Http_Client___Part_1_2_3.ServiceContracts;
using System.Text.Json;

namespace _159._Http_Client___Part_1_2_3.Services
{
    public class FinnhubService : IFinnhubService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        // In the constructor we have to inject IHttpClientFactory.
        // For that, above we have created a property _httpClientFactory.
        // This interface is implemented by a predefined class called 
        // DefaultHttpClientFactory.
        // So what is the difference between HttpClient and IHttpClientFactory?
        /// <summary>
        /// The IHttpClientFactory is an interface.
        /// Which is used to create an instance of HttpClient class.
        /// So instead of you create your own instance of HttpClient.
        /// You are going to take the support of this HttpClientFactory.
        /// So what's the benefit of that?
        /// The benefit here is that.
        /// As soon as your task is done. I mean reading the response is completed.
        /// The HttpClientFactory takes the responsibility of.
        /// Disposing or closing the connection with the server.
        /// If you are going to create HtppClient manually then you have to close the
        /// server connection manually also.
        /// As soon as you would like to make HTTP request.
        /// You have to ask _httpClientFactory which is done in "GetStockPriceQuote()"
        /// </summary>
        /// <param name="httpClientFactory"></param>
        public FinnhubService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<Dictionary<String, object>?> GetStockPriceQuote(string stockSymbol)
        {
            // CreateClient creates and returns an object of HttpClient class automatically.
            // We need to keep it in using block, because as soon as our using
            // block closes the connection with the server will be closed automatically.
            using (HttpClient httpClient = _httpClientFactory.CreateClient())
            {
                // We use httpClient to make the http request.
                // To make the http request We have a predefined
                // class called HttpRequestMessage.
                // Its from System.Net.Http.HttpRequestMessage
                // So this class is used to create a new request To any particular URL.
                // It has properties such as request URI.
                // That contains your actual URL to which you want to send request.
                // But the string value directly not allowed.
                // You have to convert the same into a new instance of URI class object.
                // After that you are going to specify the method of the request.
                // It can be Get, Post, Put, Delete, Connect etc
                // Also optionally you can add Request Headers
                HttpRequestMessage httpRequestMessage = new HttpRequestMessage()
                {
                    // You will see "/api/" under below URl
                    // This is the path of the web service. It begins with API because they are
                    // an online web service. It is not mandatory though to begin 
                    // the web service URLs with "api" 
                    // v1 is the version i.e. they can add v2 in future.
                    // AAPL is the stock name, you can get stock names from Google.
                    // This AAPL will come form "stockSymbol"
                    // The token should not be written like this
                    // Its better to do write it in Secrets.
                    // To enable the user secretes, right click on the solution,
                    // Click on Open in terminal.
                    // Make sure that you are in the solutions folder.
                    // dotnet user-secrets init --project YourProjectName
                    // This will create the id which will be present on your solution file(double click on it to check)
                    // I am not going to add because mine is somehow not working.
                    // Then use
                    // dotnet  user-secrets set "key" "value" --project Project_Name
                    // Value here will be your token 
                    // Then in our constructor add "IConfiguration" and other part you know 
                    // because we have already done it in the last lecture.
                    
                    RequestUri = new Uri($"https://finnhub.io/api/v1/quote?symbol={stockSymbol}&token=d9i8tf1r01qjmfdca5kgd9i8tf1r01qjmfdca5l0"),
                    Method = HttpMethod.Get
                    //Headers = new Dictionary<string, string>() { key and value } 
                };

                // In order to send the request,
                // we use httpClient
                HttpResponseMessage httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);

                // httpResponseMessage response object includes with the response body response headers
                // as well. In order to actually read the response body, you have to call the content stream.
                // Content property represents the response body.
                // And you can read the same as a stream by using read as a stream method.
                Stream stream = httpResponseMessage.Content.ReadAsStream(); 

                StreamReader streamReader = new StreamReader(stream);
                string response = streamReader.ReadToEnd();

                Dictionary<string, object> responseDictionary = 
                JsonSerializer.Deserialize<Dictionary<string, object>>(response);

                // Lets add the interface for this service.
                // Add a new Folder in this Project and in that project add the class.
                // ServiceContracts -> IFinnhubService.cs
                // Then we implemented this interface into this class.

                if (responseDictionary == null)
                    throw new InvalidOperationException("No Response from finnhub server");

                if (responseDictionary.ContainsKey("Error"))
                    throw new InvalidOperationException(Convert.ToString(responseDictionary["Error"]));

                return responseDictionary;
            }
        }
    }
}
