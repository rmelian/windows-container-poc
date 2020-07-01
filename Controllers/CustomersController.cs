using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;

namespace WindowsContainerPoc.Controllers
{

    public class Order 
    {
        public string orderId { get; set; }
        public string customerName { get; set; }
    }

    public class CustomersController : ApiController
    {
        private const string URL = "http://ab5513d3217024cb09946ce74efc2cd5-897789851.us-east-1.elb.amazonaws.com/api/orders";


        // GET: api/Customers
        public IHttpActionResult Get()
        {

            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync(URL).Result;
            if (response.IsSuccessStatusCode)
            {
                // Parse the response body.
                var orders = response.Content.ReadAsAsync<IEnumerable<Order>>().Result;  //Make sure to add a reference to System.Net.Http.Formatting.dll
                                
                return Ok(orders.Select(o => new { name = o.customerName }).ToList());
                
            }
            
            return Ok(response.ReasonPhrase);
        }
    }
}
