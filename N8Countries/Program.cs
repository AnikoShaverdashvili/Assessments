using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using CountriesRESTApiApplication.Models;
using Newtonsoft.Json;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;

namespace CountriesRESTApiApplication
{
    class Program
    {
        //static async Task<IEnumerable<Country>> GetCountriesDataFromService()
        //{
        //    var uri = new Uri("https://restcountries.com/"); //links says:The server is temporarily unable to service your request due to maintenance downtime or capacity problems. Please try again later.
        //    var httpClient = new HttpClient()
        //    {
        //        BaseAddress = uri
        //    };

        //    var response = await httpClient.GetAsync("v3.1/all");

        //    if (!response.IsSuccessStatusCode)
        //    {
        //        throw new Exception("Response status code does not indicate success: " + (int)response.StatusCode + " (" + response.StatusCode.ToString() + ")");
        //    } // and im gettiing this error : Error getting countries data: Response status code does not indicate success: 503 (ServiceUnavailable)

        //    try
        //    {
        //        var responseString = await response.Content.ReadAsStringAsync();
        //        var countries = JsonConvert.DeserializeObject<IEnumerable<Country>>(responseString);
        //        return countries;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("Error parsing response as JSON: " + ex.Message);
        //    }
        //}

        static async Task<IEnumerable<Country>> GetCountriesDataFromService()
        {
            var uri = new Uri("https://restcountries.com/");
            var httpClient = new HttpClient()
            {
                BaseAddress = uri
            };

            // Add an Accept header for JSON format.
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await httpClient.GetAsync("v3.1/all");

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Response status code does not indicate success: " + (int)response.StatusCode + " (" + response.StatusCode.ToString() + ")");
            }

            // List data response.
            var responseString = await response.Content.ReadAsStringAsync();

            // Parse the response body.
            var countries = JsonConvert.DeserializeObject<IEnumerable<Country>>(responseString);
            return countries;
        }


        static void GenerateCountryDataFiles(IEnumerable<Country> countries)
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string directoryName = @"Countries data";
            string directoryFullPath = Path.Combine(desktopPath, directoryName);
            DirectoryInfo Directory = new DirectoryInfo(directoryFullPath);
            if (!Directory.Exists)
            {
                Directory.Create();
            }

            foreach (var country in countries)
            {
                var fileName = string.Concat(country.Name.Common, ".txt");
                using (StreamWriter streamWriter = new StreamWriter(Path.Combine(directoryFullPath, fileName), true))
                {
                    try
                    {
                        streamWriter.WriteLine($"region:{country.Region}");
                        streamWriter.WriteLine($"subregion:{country.SubRegion}");
                        streamWriter.WriteLine($"latng:{country.Coordinates.First()},{country.Coordinates.Last()}");
                        streamWriter.WriteLine($"population:{country.Population}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error getting countries data: {ex.Message}");
                    }
                }
            }
        }
        static async Task Main()
        {
            try
            {
                var countries = await GetCountriesDataFromService();
                if (countries.Any())
                {
                    GenerateCountryDataFiles(countries);
                    Console.WriteLine("Country data files generated successfully.");
                    Console.WriteLine($"Found {countries.Count()} countries.");
                }
                else
                {
                    Console.WriteLine("No country data found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting countries data: {ex.Message}");
            }
        }
    }
}
