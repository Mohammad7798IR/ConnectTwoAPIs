using CallTestAppApi.DTOs;
using CallTestAppApi.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;


namespace CallTestAppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {

        private const string PostAddress = "http://localhost:5256/api/User/SignUp";
        private const string GetAddress = "http://localhost:5256/api/User/GetAllUsers";

        [HttpPost]
        [Route("TestPost")]
        public async Task<IActionResult> Post(SignUpDTO signUpDTO)
        {
            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(PostAddress);

                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetDepartments using HttpClient  
                HttpResponseMessage Res = await client.PostAsync(PostAddress, JsonContent.Create(signUpDTO));

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    return Ok(Res.Content);

                }

            }
            return Ok();
        }

        [HttpGet]
        [Route("TestGet")]
        public async Task<IActionResult> Get()
        {
            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri(PostAddress);

                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                HttpResponseMessage Res = await client.GetAsync(GetAddress);


                if (Res.IsSuccessStatusCode)
                {

                    var stream = await Res.Content.ReadAsStringAsync();
          
                    var apiResponse = JsonConvert.DeserializeObject<List<ApplicationUser>>(stream);

                    return Ok(apiResponse);

                }

            }
            return Ok();

        }
    }
}
