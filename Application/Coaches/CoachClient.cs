using Application.Clients;
using AutoMapper;
using Domain.Clients;
using Domain.Coaches;
using Domain.Configuration;
using Microsoft.Extensions.Options;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Application.Coaches
{
    public class CoachClient : ICoachClient
    {
        private readonly List<EndpointConfiguration> _endpoints;
        private readonly HttpClient _client;
        private readonly IMapper _mapper;

        public CoachClient(IOptions<List<EndpointConfiguration>> options, HttpClient client, IMapper mapper)
        {
            _endpoints = options.Value
                .Where(w => w.Name.Equals("DefaultApi", StringComparison.OrdinalIgnoreCase))
                .FirstOrDefault().Endpoints.ToList();
            _client = client;
            _mapper = mapper;
        }

        public async Task<List<CoachDTO>> List()
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };

            var content = await _client.GetStringAsync(_endpoints.Where(w => w.Name.Equals("Coaches", StringComparison.OrdinalIgnoreCase)).FirstOrDefault().Uri);
            var coaches = JsonSerializer.Deserialize<List<Coach>>(content, options);

            return _mapper.Map<List<CoachDTO>>(coaches);
        }

        public async Task<Result> Create(CreateCoach createCoach)
        {
            var content = new StringContent(JsonSerializer.Serialize(createCoach), Encoding.UTF8, "application/json");
            var result = await _client.PostAsync(_endpoints.Where(w => w.Name.Equals("Coaches", StringComparison.OrdinalIgnoreCase)).FirstOrDefault().Uri, content);

            return result.StatusCode == System.Net.HttpStatusCode.Created
                ? Result.Success()
                : Result.Failure(CoachErrors.NotCreated());
        }

        public async Task<Result> Update(UpdateCoach updateCoach)
        {
            var content = new StringContent(JsonSerializer.Serialize(updateCoach), Encoding.UTF8, "application/json");
            var result = await _client.PutAsync
                (_endpoints.Where(w => w.Name.Equals("Coaches", StringComparison.OrdinalIgnoreCase)).FirstOrDefault().Uri, content);

            return result.StatusCode == System.Net.HttpStatusCode.Accepted
                ? Result.Success()
                : Result.Failure(CoachErrors.NotUpdated());
        }

        public async Task<Result<Coach>> Get(int id)
        {
            var content = await _client.GetStringAsync
                (_endpoints.Where(w => w.Name.Equals("Coaches", StringComparison.OrdinalIgnoreCase)).FirstOrDefault().Uri + "/" + id);
            var coach = JsonSerializer.Deserialize<Coach>(content);

            return Result.Success(coach);
        }

        public async Task<Result> Delete(int id)
        {
            var result = await _client.DeleteAsync
                (_endpoints.Where(w => w.Name.Equals("Coaches", StringComparison.OrdinalIgnoreCase)).FirstOrDefault().Uri + "/" + id);

            return result.IsSuccessStatusCode
                ? Result.Success()
                : Result.Failure(CoachErrors.NotDeleted());
        }
    }
}
