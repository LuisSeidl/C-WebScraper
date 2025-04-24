using HtmlAgilityPack;
using Microsoft.Playwright;
using System.Runtime.CompilerServices;


// add url here
string url = "https://www.bstn.com/eu_de/r/adidas-adizero-evo-sl-jp7149-0320233";


using var playwright = await Playwright.CreateAsync();
await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false });

var page = await browser.NewPageAsync();
await page.GotoAsync(url);


try
{
    var response = page.ContentAsync().Result;


    string folderPath = Path.Combine(Directory.GetCurrentDirectory(), "Data");
    string filePath = Path.Combine(folderPath, "BSTN.html");

    Directory.CreateDirectory(folderPath);

    File.WriteAllText(filePath, response);

}
catch (Exception ex)
{
    Console.WriteLine($"Error occurred: {ex.Message}");
}




