using System;
using System.Dynamic;
using System.Reflection.Metadata.Ecma335;
using RestSharp;
using Newtonsoft.Json;

namespace ThoughtWorks
{
    class Program
    {

        #region challenge1

    
       
        static void Main_Challenge1(string[] args)
        {
            Challenge1 chl_Obj = new Challenge1("https://http-hunt.thoughtworks-labs.net");
            var response = chl_Obj.PostChallenge("/challenge/output");       
        }
        #endregion


        #region challenge2

        static void Main_Challenge2(string[] args)
        {
            Challenge2 chlObj = new Challenge2("https://http-hunt.thoughtworks-labs.net");
            var response = chlObj.PostChallenge("/challenge/output");
;        }

        #endregion



        #region challenge3

        static void Main_Challenge3(string[] args)
        {
             Challenge3 chlObj = new Challenge3("https://http-hunt.thoughtworks-labs.net");
             var response = chlObj.PostChallenge("/challenge/output");
        }

        #endregion

        #region challenge4

        static void Main(string[] args)
        {
            Challenge4 chlObj = new Challenge4("https://http-hunt.thoughtworks-labs.net");
            var response = chlObj.PostChallenge("/challenge/output");
        }

        #endregion

    }





}
