using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using zasylogicWeb.Models;

namespace zasylogicWeb.Controllers
{
    public class AtencionClienteController : Controller
    {
        HttpClientHandler _ClientHandler = new HttpClientHandler();

        AtencionCliente _oAtencionCliente = new AtencionCliente();
        List<AtencionCliente> _oAtencionClientes = new List<AtencionCliente>();

        public AtencionClienteController()
        {
            _ClientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, SslPolicyErrors) => { return true; };
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<List<AtencionCliente>> GetAllAtencionCliente()
        {
            _oAtencionClientes = new List<AtencionCliente>();

            using (var httpClient = new HttpClient(_ClientHandler))
            {
                using (var response = await httpClient.GetAsync("http://localhost:64154/Api/AtencionCliente/"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    _oAtencionClientes = JsonConvert.DeserializeObject<List<AtencionCliente>>(apiResponse);
                }
            }

            return _oAtencionClientes;
        }

        [HttpPost]
        public async Task<AtencionCliente> AddUpdateAtencionClientes(AtencionCliente atencionCliente)
        {
            _oAtencionCliente = new AtencionCliente();


            using (var httpClient = new HttpClient(_ClientHandler))
            {
                string apiResponse = "";
                StringContent content = new StringContent(JsonConvert.SerializeObject(atencionCliente), Encoding.UTF8, "application/json");
                using (var response = await httpClient.PostAsync("http://localhost:64154/Api/AtencionCliente/", content))
                {
                    apiResponse = await response.Content.ReadAsStringAsync();
                }

                _oAtencionCliente = JsonConvert.DeserializeObject<AtencionCliente>(apiResponse);

            }

            return _oAtencionCliente;
        }
    }
}
