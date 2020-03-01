using System;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace cw1
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            //int tmp1 = 2;
            //double tmp2 = 2.0;
            //float tmp3 = 3.0f;

            //string tmp4 = "Ala ma kota";
            //bool tmp5 = true;
            //string tmp6 = "i psa";

            //string path = @"C:\Users\s17489\Desktop\cw1";
            ////Ctrl + K + C
            ////Ctrl + K + U trzymam ctrl i k

            //Person newPersone = new Person {FirstName = "Matuesz" };

            //var tmp10 = "Kaszanka";
            //var tmp11 = string.Empty;

            //Console.WriteLine($"{tmp4} {tmp6}");
            var url = args.Length > 0 ? args[0] : "https://www.pja.edu.pl";
            //var url = "https://www.pja.edu.pl";
            using (var httpClient = new HttpClient())
            {
                using (var respons = await httpClient.GetAsync(url))
                {
                    if (respons.IsSuccessStatusCode)
                    {
                        var htmlContent = await respons.Content.ReadAsStringAsync();

                        var regex = new Regex("[a-z]+[a-z0-9]*@[a-z0-9]+\\.[a-z]+\\.[a-z]+", RegexOptions.IgnoreCase);

                        var matches = regex.Matches(htmlContent);

                        foreach (var match in matches)
                        {
                            Console.WriteLine(match.ToString());
                        }

                    }
                }
            }
                // httppost dodaj do baz
                // put zkutalziowanie calego w bazie
                // http put/patch pojedyyncze 
                // http delete - wywalimy 
               

            //2xx
            //4xx- zleeee
            //5xx - bledy serwera 

            

        }
    }
}
