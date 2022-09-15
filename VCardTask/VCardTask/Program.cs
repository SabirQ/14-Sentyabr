
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Text.Json.Nodes;
using VCardTask.DAL;
using VCardTask.Models;


AppDbContext context = new AppDbContext();
Request:
HttpClient http = new HttpClient();

try
{
    var response = await http.GetAsync("https://randomuser.me/api?results=50");
    List<VCard> vcards = new List<VCard>();
    if (response.IsSuccessStatusCode)
    {
        string json = await response.Content.ReadAsStringAsync();
        var roots = JsonConvert.DeserializeObject<Root>(json);
        foreach (var item in roots.results)
        {
            VCard card = new VCard
            {
                Firstname = item.name.first,
                Lastname = item.name.last,
                Country = item.location.country,
                City = item.location.city,
                Email = item.email,
                Phone = item.phone
            };
            vcards.Add(card);
        }
        //NOTE: if you din not use BackUp file then run the codes below otherwise json objects already were inserted into database 100 VCards:
        await context.VCards.AddRangeAsync(vcards);
        await context.SaveChangesAsync();

    }
    else
    {
        Console.WriteLine("Respones are not successfull,Request has been sent again");
        goto Request;
    }
}
catch(HttpRequestException ex)
{
    Console.WriteLine("Host is not available,please try again later");
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}







