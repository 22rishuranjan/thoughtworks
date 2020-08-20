using System;
using RestSharp;
using Newtonsoft.Json;

namespace ThoughtWorks
{
   class Challenge1 : BaseApi
{
    private int ElemCount { get; set; }
    private IRestResponse GetResponse { get; set; }

    public Challenge1(string url) : base(url)
    {
       
        this.GetResponse = GetChallenge("/challenge/input");
        this.ElemCount = ((Newtonsoft.Json.Linq.JContainer)JsonConvert.DeserializeObject(GetResponse.Content)).Count;
    }

    public IRestResponse GetChallenge(string getUrl)
    {
        //create request
        var request = new RestRequest(getUrl, Method.GET);

        //add header to request
        request.AddHeader("userId", "PaTfYqm50");

        //add contenttype to request
        request.AddHeader("Content-Type", "application/json");

        return Client.Execute(request);
        // ElemCount = ((Newtonsoft.Json.Linq.JContainer)JsonConvert.DeserializeObject(response.Content)).Count;

        ////execute the request to Client
        //return Client.Execute(request);
    }

    public IRestResponse PostChallenge(string postUrl, int count = 0)
    {
        //create request
        var request = new RestRequest(postUrl, Method.POST);
        //add header to request
        request.AddHeader("userId", "PaTfYqm50");
        //add contenttype to request
        request.AddHeader("Content-Type", "application/json");

        request.AddJsonBody(new { ElemCount });

        //execute the request to Client
        return Client.Execute(request);
    }
}
}