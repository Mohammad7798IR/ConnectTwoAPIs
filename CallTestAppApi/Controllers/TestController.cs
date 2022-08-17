using CallTestAppApi.DTOs;
using CallTestAppApi.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using System.Net.Http.Headers;


namespace CallTestAppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {

        #region Fields

        private const string PostAddress = "http://localhost:56234/api/User/SignUp";
        private const string GetAddress = "http://localhost:56234/api/User/GetAll";



        #endregion

        #region Method [s]

        [HttpPost]
        [Route("TestPost")]
        public async Task<IActionResult> Post(SignUpDTO signUpDTO)
        {
            var clientRest = new RestClient(PostAddress);

            var clientRequest = new RestRequest().AddJsonBody(signUpDTO);

            clientRequest.AddHeader("Accept", "application/json");
            clientRequest.AddHeader("Id", Guid.NewGuid().ToString());


            var response = await clientRest.PostAsync(clientRequest);

            return Ok(response);

        }

        [HttpGet]
        [Route("TestGet")]
        public async Task<IActionResult> Get()
        {

            var clientRest = new RestClient(GetAddress);

            var clientRequest = new RestRequest();

            clientRequest.AddHeader("Accept", "application/json");
            clientRequest.AddHeader("Id", Guid.NewGuid().ToString());


            var response = await clientRest.GetAsync<List<ApplicationUser>>(clientRequest);


            return Ok(response);

        }

        #endregion

    }
}
