using AutoMapper;
using Domain.Configuration;
using Domain.Routines;
using Microsoft.Extensions.Options;
using Shared;
using System.Text;
using System.Text.Json;

namespace Application.Routines
{
    public class RoutineClient : IRoutineClient
    {
        private readonly List<EndpointConfiguration> _endpoints;
        private readonly HttpClient _client;
        private readonly IMapper _mapper;

        public RoutineClient(IOptions<List<EndpointConfiguration>> options, HttpClient client, IMapper mapper)
        {
            _endpoints = options.Value
                .Where(w => w.Name.Equals("DefaultApi", StringComparison.OrdinalIgnoreCase))
                .FirstOrDefault().Endpoints.ToList();
            _client = client;
            _mapper = mapper;
        }

        public async Task<List<RoutineDTO>> List()
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var content = await _client.GetStringAsync(_endpoints.Where(w=>w.Name.Equals("Routines",StringComparison.OrdinalIgnoreCase)).FirstOrDefault().Uri);
            var routines = JsonSerializer.Deserialize<List<RoutineDTO>>(content, options);

            return  _mapper.Map<List<RoutineDTO>>(routines);
        }

        public async Task<List<RoutineDTO>> GetRoutinesForClient(string email)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            try
            {
                var endpoint = _endpoints
                    .Where(w => w.Name.Equals("Routines", StringComparison.OrdinalIgnoreCase))
                    .FirstOrDefault();
                var apiUrl = endpoint.Uri + "/ClientRoutines/" + email;

                var content = await _client.GetStringAsync(apiUrl);


                var routines = JsonSerializer.Deserialize<List<RoutineDTO>>(content, options);

                return _mapper.Map<List<RoutineDTO>>(routines);
            }
            catch (HttpRequestException ex)
            {
                return new List<RoutineDTO>();
            }

        }


        public async Task<Result> Create(CreateRoutine createRoutine)
        {
            var content = new StringContent(JsonSerializer.Serialize(createRoutine), Encoding.UTF8, "application/json");
            var result = await _client.PostAsync(_endpoints.Where(w => w.Name.Equals("Routines", StringComparison.OrdinalIgnoreCase)).FirstOrDefault().Uri, content);
            return result.StatusCode == System.Net.HttpStatusCode.Created
                ? Result.Success()
                : Result.Failure(RoutineErrors.NotCreated());
        }


        public async Task<Result> Update(UpdateRoutine updateRoutine)
        {
            var content = new StringContent(JsonSerializer.Serialize(updateRoutine), Encoding.UTF8, "application/json");
            var result = await _client.PutAsync(_endpoints.Where(w => w.Name.Equals("Routines", StringComparison.OrdinalIgnoreCase)).FirstOrDefault().Uri, content);
            return result.StatusCode == System.Net.HttpStatusCode.Accepted
                ? Result.Success()
                : Result.Failure(RoutineErrors.NotUpdated());
        }


        public async Task<Result<Routine>> Get(int id)
        {
            var content = await _client.GetStringAsync(_endpoints.Where(w => w.Name.Equals("Routines", StringComparison.OrdinalIgnoreCase)).FirstOrDefault().Uri + "/" + id);
            var routine = JsonSerializer.Deserialize<Routine>(content);

            return Result.Success(routine);
        }

        public async Task<Result> Delete(int id)
        {
            var result = await _client.DeleteAsync
                (_endpoints.Where(w => w.Name.Equals("Routines", StringComparison.OrdinalIgnoreCase)).FirstOrDefault().Uri + "/" + id);
            return result.IsSuccessStatusCode
                ? Result.Success()
                : Result.Failure(RoutineErrors.NotDeleted());
        }

       

    }
}
