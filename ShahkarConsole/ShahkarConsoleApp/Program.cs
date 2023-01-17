// See https://aka.ms/new-console-template for more information
using RestSharp;
using ShahkarConsoleApp;
using System.Net.Http;
using System.Reflection;
using System;
using Newtonsoft.Json;
using System.Text;

static void GetShahkarApi()
{

    string[] lines = File.ReadAllLines(@"..\Records.txt");
    //string[] lines = File.ReadAllLines(@"D:\ReadDataFromFile\Records.txt");
    var seprateText = lines.Select(x => x.Split(","));
    
    var resultMap = seprateText.Select(x => new PersonData { NationalNo = x[0], MobileNo = x[1]});

    foreach (var item in resultMap)
    {


        HttpClient httpClient = new HttpClient();
        var token = "eyJhbGciOiJSUzI1NiIsImtpZCI6IjZCN0FDQzUyMDMwNUJGREI0RjcyNTJEQUVCMjE3N0NDMDkxRkFBRTFSUzI1NiIsInR5cCI6ImF0K2p3dCIsIng1dCI6ImEzck1VZ01Gdjl0UGNsTGE2eUYzekFrZnF1RSJ9.eyJuYmYiOjE2NzM5Mzc0OTksImV4cCI6MTY3Mzk0NDY5OSwiaXNzIjoibnVsbCIsImNsaWVudF9pZCI6ImJhaHJhbWkiLCJqdGkiOiI5MUI4QzI2NjJGRURDM0QzOUZFOEI2NzM3MjU5Q0JERSIsImlhdCI6MTY3MzkzNzQ5OSwic2NvcGUiOlsia246cHVyY2hhc2U6cG9zdCIsInJiOmJpbGwtcGhvbmU6Z2V0Iiwic29hOnNoYWhrYXItdmVyaWZpY2F0aW9uOnBvc3QiXX0.WzOh1UkHx7SGtRbrptxn6Klramjkdj51atZksH5Plg_fKnYT_p4q64dYCM7VN50vZXkQWoYvCUrip7OP1woY-SncQVNzhSu1o0zVnVtREUzNxnESspkY2BSRHleMXpzkxAPR4AjNSRYIKoIYQJYcpZDiFXkDmYa_eXyqk4HG0aTEaB62Zr7cDpHSkRtWvFO7Pso6KEqpmLwYoYCkrNJ792UkKi1P7Sl2jvl0Sf063kE5DNajaXn1gLzCXXoT9Kp5lrfuqKj1XBPjPdvUz5PoipCKSq_Gs_p3t0r4fiCgDb_YdQFo1ZwTlMUM_IQgLZsREFX7tsPECb262s9grNaihA";
        httpClient.DefaultRequestHeaders.Clear();
        httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
        var jsonData = JsonConvert.SerializeObject(item);
        var dataContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
        var response =httpClient.PostAsync("http://localhost:98/api/1.0/ShahkarVerification", dataContent);
        var result = response.Result;
        var finalResult = result.Content.ReadAsStringAsync();
        Console.WriteLine(finalResult);

    }
}
GetShahkarApi();
Console.ReadKey();