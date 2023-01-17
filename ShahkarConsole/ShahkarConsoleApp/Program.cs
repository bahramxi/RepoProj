// See https://aka.ms/new-console-template for more information
using RestSharp;
using ShahkarConsoleApp;
using System.Net.Http;
using System.Reflection;
using System;
using Newtonsoft.Json;
using System.Text;
using System.IO;
using System.Linq;

static void GetShahkarApi()
{

    string[] lines = File.ReadAllLines(@"Records.txt");
    //string[] lines = File.ReadAllLines(@"D:\ReadDataFromFile\Records.txt");
    var seprateText = lines.Select(x => x.Split(","));
    
    var resultMap = seprateText.Select(x => new PersonData { NationalNo = x[0], MobileNo = x[1]});

    foreach (var item in resultMap)
    {


        HttpClient httpClient = new HttpClient();
        var token = "eyJhbGciOiJSUzI1NiIsImtpZCI6IjZCN0FDQzUyMDMwNUJGREI0RjcyNTJEQUVCMjE3N0NDMDkxRkFBRTFSUzI1NiIsInR5cCI6ImF0K2p3dCIsIng1dCI6ImEzck1VZ01Gdjl0UGNsTGE2eUYzekFrZnF1RSJ9.eyJuYmYiOjE2NzM5NTIxNjQsImV4cCI6MTY3Mzk1OTM2NCwiaXNzIjoibnVsbCIsImNsaWVudF9pZCI6ImJhaHJhbWkiLCJqdGkiOiI5QTFDQzAzQzYwRjFGQzBCQkVEREU0MUIwMTBGRjYyOSIsImlhdCI6MTY3Mzk1MjE2NCwic2NvcGUiOlsia246cHVyY2hhc2U6cG9zdCIsInJiOmJpbGwtcGhvbmU6Z2V0Iiwic29hOnNoYWhrYXItdmVyaWZpY2F0aW9uOnBvc3QiXX0.PW5IG2Gu32BTgYGq8gSPCnSvd_p6GCDp_vvYCXv1bJOukgVX3FIM4UC3fyC9ftPlf1cgZgGByzrtL7C7ZqS7JK_xtCm0czPwJ8o1yzC1fw6-l6MCtWV_P85DAjQ2M-fnyxzcQwbm7kzPmxG5koDfzeOIFyj4ddBUgoXdNBmn8GG_fnnKDUvqurLZKJ_E6OWbLO8aAztf8TtWQ1quWZXyv1c3y7Yp8YEe39BCQaJvqK8L9jRh3al7FtoJafaN9tQ-D5oHINi-Hcs3O8IvwCvhFZnWKcVJxxjxwabfc7nsUNAGTUblpMvOOmUGCD-4foeqcRJ9thF3sCA5BpoYl0nREw";
        httpClient.DefaultRequestHeaders.Clear();
        httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
        var jsonData = JsonConvert.SerializeObject(item);
        var dataContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
        var response =httpClient.PostAsync("http://localhost:98/api/1.0/ShahkarVerification", dataContent).Result;
        var finalResult = response.Content.ReadAsStringAsync();
        Console.WriteLine(item.NationalNo+ " "+ item.MobileNo +" "+finalResult.Result);

    }
}
GetShahkarApi();
Console.ReadKey();