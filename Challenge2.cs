using System;
using RestSharp;
using Newtonsoft.Json;

namespace ThoughtWorks
{
    class Challenge2 : BaseApi
    {

        
        private dynamic Elem { get; set; }

        private int ElemCount { get; set; }
        private IRestResponse GetResponse { get; set; }

        public Challenge2(string url) : base(url)
        {
            this.ClientUrl = url;
            this.Client = new RestClient("https://http-hunt.thoughtworks-labs.net");
            this.GetResponse = GetChallenge("/challenge/input");
            this.Elem = JsonConvert.DeserializeObject(GetResponse.Content);
            this.ElemCount = GetCountCurrentProduct();
        }
        private IRestResponse GetChallenge(string getUrl)
        {
            //create request
            var request = new RestRequest(getUrl, Method.GET);
            //add header to request
            request.AddHeader("userId", "PaTfYqm50");
            //add contenttype to request
            request.AddHeader("Content-Type", "application/json");
            return Client.Execute(request);
            // ElemCount = ((Newtonsoft.Json.Linq.JContainer)JsonConvert.DeserializeObject(response.Content)).Count;

            ////execute the request to client
            //return client.Execute(request);
        }

        public IRestResponse PostChallenge(string postUrl)
        {
            //create request
            var request = new RestRequest(postUrl, Method.POST);
            //add header to request
            request.AddHeader("userId", "PaTfYqm50");
            //add contenttype to request
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(new { output = new { count = ElemCount } });
            //execute the request to client
            return Client.Execute(request);
        }

        public int GetCountCurrentProduct()
        {
            int count=0;

            foreach (var el in Elem)
            {
                if ((el.endDate.Value == null || DateTime.Parse(el.endDate.Value) >= DateTime.Today) &&
                         (DateTime.Parse(el.startDate.Value) <= DateTime.Today))
                {
                    count++;
                }
            }

            return count;
        }
    }
}