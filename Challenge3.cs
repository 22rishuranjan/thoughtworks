using System;
using RestSharp;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace ThoughtWorks
{
    class Challenge3 : BaseApi
    {
        private dynamic Elem { get; set; }
        private int ElemCount { get; set; }
        private IRestResponse GetResponse { get; set; }

        //  Private Dictionary<object, object> dict = new Dictionary<object, object>();
        private Dictionary<object, object> GetCategory{ get; set; } 

        public Challenge3(string url) : base(url)
        {
            this.GetResponse = GetChallenge("/challenge/input");
            this.Elem = JsonConvert.DeserializeObject(GetResponse.Content);
            this.GetCategory = new Dictionary<object, object>();
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

            request.AddParameter("application/json", JsonConvert.SerializeObject(new { output = GetCategory }), ParameterType.RequestBody);

            // request.AddJsonBody(new { output = JsonConvert.SerializeObject(GetCategory) });
         
            //execute the request to client
            return Client.Execute(request);
        }

        public int GetCountCurrentProduct()
        {
            int count = 0;
            foreach (var el in Elem)
            {
                if ((el.endDate.Value == null || DateTime.Parse(el.endDate.Value) >= DateTime.Today) &&
                         ( DateTime.Parse(el.startDate.Value) <= DateTime.Today))

                {
                    ModifiyCategoryDictnory(el.category.Value);
                    count++;
                }
            }
            return count;
        }

        private void ModifiyCategoryDictnory(object key)
        {

            if (GetCategory.ContainsKey(key))
            {
                GetCategory[key] = (int)GetCategory[key] + 1;
            }
            else
            {
                GetCategory.Add(key, 1);
            }
 
        }
    }
}