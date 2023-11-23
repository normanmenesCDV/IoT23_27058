using System.Net;
using System.Text.Json;
using Lab2.Function;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using Azure;
using System.Runtime.Serialization;

namespace CdvAzure.Function
{
    public class PeopleFn
    {
        private readonly ILogger _logger;

        private readonly PeopleServices peopleServices;

        public PeopleFn(ILoggerFactory loggerFactory,

        PeopleServices peopleServices)
        {
            _logger = loggerFactory.CreateLogger<PeopleFn>();
            this.peopleServices = peopleServices;
        }

        [Function("PeopleFn")]
        public HttpResponseData Run([HttpTrigger(AuthorizationLevel.Function, "get", "post", "put", "delete")] HttpRequestData req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            var response = req.CreateResponse(HttpStatusCode.OK);

            switch (req.Method)
            {
                case "POST":
                    {
                        var reader = new StreamReader(req.Body, System.Text.Encoding.UTF8);
                        var json = reader.ReadToEnd();
                        var person = JsonSerializer.Deserialize<PersonDTO>(json);
                        var people = peopleServices.Add(
                            new PersonDTO
                            {
                                FirstName = person.FirstName,
                                LastName = person.LastName
                            }
                        );
                        response.WriteAsJsonAsync(people);
                        break;
                    }
                case "PUT":
                    {
                        var reader = new StreamReader(req.Body, System.Text.Encoding.UTF8);
                        var json = reader.ReadToEnd();
                        var person = JsonSerializer.Deserialize<PersonDTO>(json);
                        var people = peopleServices.Update(
                            new PersonDTO
                            {
                                Id = person.Id,
                                FirstName = person.FirstName,
                                LastName = person.LastName
                            }
                        );
                        response.WriteAsJsonAsync(people);
                        break;
                    }
                case "GET":
                    {
                        var people = peopleServices.Get();
                        response.WriteAsJsonAsync(people);
                        break;
                    }
                case "DELETE":
                    {
                        var reader = new StreamReader(req.Body, System.Text.Encoding.UTF8);
                        var json = reader.ReadToEnd();
                        var person = JsonSerializer.Deserialize<PersonDTO>(json);
                        var success = peopleServices.Delete((int)person.Id);
                        response.WriteAsJsonAsync(success);
                        break;
                    }
            }
            return response;
        }
    }
}
