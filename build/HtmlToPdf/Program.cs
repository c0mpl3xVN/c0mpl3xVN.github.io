using System;
using RestSharp;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace HtmlToPdf
{
    class Program
    {
        static void Main(string[] args)
        {
            string PATH = "./";
            string FILENAME = "TuanAnhHoang_CV.pdf";

            RestClient client = new RestClient("http://localhost:4040/api/tunnels");
            RestRequest request = new RestRequest(Method.GET);
            RestResponse response = (RestResponse)client.Execute(request);

            dynamic response_tunnels = JsonConvert.DeserializeObject(response.Content);
            string url = response_tunnels.tunnels[0].public_url + "/docs/";
            Console.WriteLine("URL Tunnel is: " + url + Environment.NewLine);
            Console.WriteLine("Convert to PDF from: " + url + Environment.NewLine);

            HtmlToPdf htmlToPdf = new HtmlToPdf();
            byte[] pdf = htmlToPdf.GetPdf(url);

            System.IO.File.WriteAllBytes(PATH + FILENAME, pdf);
        }
    }
}
