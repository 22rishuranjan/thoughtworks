using System;
using RestSharp;
using Newtonsoft.Json;

namespace ThoughtWorks
{
    class BaseApi
    {
        protected string ClientUrl { get; set; }
        protected RestClient Client { get; set; }

        public BaseApi(string url)
        {
            this.ClientUrl = url;
            this.Client = new RestClient("https://http-hunt.thoughtworks-labs.net");
            //this.GetResponse = GetChallenge("/challenge/input");
            //this.ElemCount = ((Newtonsoft.Json.Linq.JContainer)JsonConvert.DeserializeObject(GetResponse.Content)).Count;
        }




    }
}
