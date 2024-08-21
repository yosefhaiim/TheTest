
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using HttpClient client = new();
using HttpClient post = new();

Console.OutputEncoding = Encoding.UTF8;

post.DefaultRequestHeaders.Accept.Clear();
post.DefaultRequestHeaders.Accept.Add(
    new MediaTypeWithQualityHeaderValue("application/json")
    );


client.DefaultRequestHeaders.Accept.Clear();
client.DefaultRequestHeaders.Accept.Add(
    new MediaTypeWithQualityHeaderValue("application/json")
    );


await request(client, post);
static async Task request(HttpClient client, Dictionary<string, string> post)
{
    
    post.Clear();
    Console.WriteLine("enter the option you want: 1. for get all, 2. for create new");
    string input = Console.ReadLine();
    if (input == "1")
    {
        string getAll = await client.GetStringAsync($"https://fakestoreapi.com/carts");
        Console.WriteLine(getAll);
    }
    else if (input == "2")
    {
        Console.WriteLine("Enter the User Id");
        string userId = Console.ReadLine();
        DateTime date = DateTime.Now;

        Console.WriteLine("Enter the Id prodact");
        string products = Console.ReadLine();

        Console.WriteLine("Enter the quentity");
        string quentity = Console.ReadLine();

        post = new Dictionary<string, string>();
        post["UserId"] = userId;
        post["product"] = products;
        post["quentity"] = quentity;

        string createNew = await client.PostAsync($"https://fakestoreapi.com/carts", post);
    }
    
    //HebDate hd = JsonSerializer.Deserialize<HebDate>(s);
    //Console.WriteLine($"{hd.hd} {hd.hm} {hd.hy}, {string.Join(",", hd.events)} - {hd.hebrew}");
    //Console.WriteLine();
}