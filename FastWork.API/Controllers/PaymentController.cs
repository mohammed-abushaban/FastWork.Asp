using Microsoft.AspNetCore.Mvc;
using System;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FastWork.API.Controllers
{
    public class PaymentController : Controller
    {
        // You can get test token from this page  https://myfatoorah.readme.io/docs/test-token
        static string token = "rLtt6JWvbUHDDhsZnfpAhpYk4dxYDQkbcPTyGaKp2TYqQgG7FGZ5Th_WD53Oq8Ebz6A53njUoo1w3pjU1D4vs_ZMqFiz_j0urb_BH9Oq9VZoKFoJEDAbRZepGcQanImyYrry7Kt6MnMdgfG5jn4HngWoRdKduNNyP4kzcp3mRv7x00ahkm9LAK7ZRieg7k1PDAnBIOG3EyVSJ5kK4WLMvYr7sCwHbHcu4A5WwelxYK0GMJy37bNAarSJDFQsJ2ZvJjvMDmfWwDVFEVe_5tOomfVNt6bOg9mexbGjMrnHBnKnZR1vQbBtQieDlQepzTZMuQrSuKn-t5XZM7V6fCW7oP-uXGX-sMOajeX65JOf6XVpk29DP6ro8WTAflCDANC193yof8-f5_EYY-3hXhJj7RBXmizDpneEQDSaSz5sFk0sV5qPcARJ9zGG73vuGFyenjPPmtDtXtpx35A-BVcOSBYVIWe9kndG3nclfefjKEuZ3m4jL9Gg1h2JBvmXSMYiZtp9MR5I6pvbvylU_PP5xJFSjVTIz7IQSjcVGO41npnwIxRXNRxFOdIUHn0tjQ-7LwvEcTXyPsHXcMD8WtgBh-wxR8aKX7WPSsT1O8d8reb2aR7K3rkV3K82K_0OgawImEpwSvp9MNKynEAJQS6ZHe_J_l77652xwPNxMRTMASk1ZsJL-9n7_JXijWEJ0AyJJCxbGWuDxKpKFbqlc2RGxuY4zXUJsJALJJpo48ae2dTGXZuKvQh1TEWatWApm_WBG-awJ8iiQLMS3hw-I7a4yD1qLZspHOUjo1sPKqHj9fbx_wzOPIsOP_bil-xFWuUFn2SxPD7tqS5Zj-bllMXsYaImIZVTJiJtR-oJo3Cgxgh4478QKN8YxiXahsuM4WN52vgqjwK2XUje_tmvNG4bYCtgUUued0rCFJU4503OvqDVoyXzJerowGnuRTexd-ZRZEi17spiiFk3Ssm9qH5hJZ8tMKwdQ4k-9zwPtMJ3qK5qXp98N4_obcfgd-1MS0ZfNOQqjXONS-vnOBkX1ncjpZ4vzzF4P7to7ZhcgE96jltWOEBvqsNyznIbo3Qn2mXoRplGzuvPqEp8jBw_l7-0mP--YvRFPsU0ezMnqNN9AjMUwZp7vXY-GGx3UiNwEPkBiiULXac-6MNB3fruzF8Pz3IQKsEvE4TUFgHcwMeStLlreW-JklbJhAM6ammCuGwJYX3lMDFxo987Ygz3b10soII-GPcgs2rORgjvAsmcsWnnQ-KZNfGPSYRjsURueT6AHeuSQ";
        static string baseURL = "https://apitest.myfatoorah.com";

        static async Task Main(string[] args)
        {
            var intiateResponse = await InitiatePayment().ConfigureAwait(false);
            Console.WriteLine("Initiate Payment Response :");
            Console.WriteLine(intiateResponse);

            var executeResponse = await ExecutePayment().ConfigureAwait(false);
            Console.WriteLine("Execute Payment Response :");
            Console.WriteLine(executeResponse);

            Console.ReadLine();
        }

        public static async Task<string> InitiatePayment()
        {
            //CreateInitiatePaymentDto dto
            var intiatePaymentRequest = new
            {
                InvoiceAmount = 100,
                CurrencyIso = "kwd"
            };

            var intitateRequestJSON = JsonConvert.SerializeObject(intiatePaymentRequest);
            return await PerformRequest(intitateRequestJSON, "InitiatePayment").ConfigureAwait(false);

        }

        public static async Task<string> ExecutePayment()
        {
            //CreatePaymentDto dto
            //var executePaymentRequest = new
            //{
            //    //required fields
            //    PaymentMethodId = dto.PaymentMethodId,
            //    InvoiceValue = dto.InvoiceValue,
            //    CallBackUrl = dto.CallBackUrl,
            //    ErrorUrl = dto.ErrorUrl,
            //    //optional fields 
            //    CustomerName = dto.CustomerName,
            //    DisplayCurrencyIso = dto.DisplayCurrencyIso,
            //    MobileCountryCode = dto.MobileCountryCode,
            //    CustomerMobile = dto.CustomerMobile,
            //    CustomerEmail = dto.CustomerEmail,
            //    Language = "En",
            //    CustomerReference = "",
            //    CustomerCivilId = "",
            //    UserDefinedField = "",
            //    ExpiryDate = DateTime.Now.AddYears(1),
            //    // to add suppliers
            //    Suppliers = new[] {
            //            new {
            //              SupplierCode = 1, InvoiceShare = 1000, ProposedShare = 500
            //            }
            //     }

            //};

            var executePaymentRequest = new
            {
                //required fields
                PaymentMethodId = "20",
                InvoiceValue = 1000,
                CallBackUrl = "https://example.com/callback",
                ErrorUrl = "https://example.com/error",
                //optional fields 
                CustomerName = "Customer Name",
                DisplayCurrencyIso = "KWD",
                MobileCountryCode = "965",
                CustomerMobile = "12345678",
                CustomerEmail = "email@example.com",
                Language = "En",
                CustomerReference = "",
                CustomerCivilId = "",
                UserDefinedField = "",
                ExpiryDate = DateTime.Now.AddYears(1),
                // to add suppliers
                Suppliers = new[] {
                        new {
                          SupplierCode = 1, InvoiceShare = 1000, ProposedShare = 500
                        }
                 }

            };
            var executeRequestJSON = JsonConvert.SerializeObject(executePaymentRequest);
            return await PerformRequest(executeRequestJSON, "ExecutePayment").ConfigureAwait(false);
        }
        public static async Task<string> PerformRequest(string requestJSON, string endPoint)
        {
            string url = baseURL + $"/v2/{endPoint}";
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var httpContent = new StringContent(requestJSON, System.Text.Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync(url, httpContent).ConfigureAwait(false);
            string response = string.Empty;
            if (!responseMessage.IsSuccessStatusCode)
            {
                response = JsonConvert.SerializeObject(new
                {
                    IsSuccess = false,
                    Message = responseMessage.StatusCode.ToString()
                });
            }
            else
            {
                response = await responseMessage.Content.ReadAsStringAsync();
            }

            return response;
        }
    }
}
