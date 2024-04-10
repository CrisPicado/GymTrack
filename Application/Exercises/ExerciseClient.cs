using AutoMapper;
using Domain.Configuration;
using Domain.Exercises;
using Microsoft.Extensions.Options;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Application.Exercises
{
    public class ExerciseClient : IExerciseClient
    {
        private readonly List<EndpointConfiguration> _endpoints;
        private readonly HttpClient _client;
        private readonly IMapper _mapper;


        public ExerciseClient(IOptions<List<EndpointConfiguration>> options, HttpClient client, IMapper mapper)
        {
            _endpoints = options.Value
                .FirstOrDefault(w => w.Name.Equals("DefaultApi", StringComparison.OrdinalIgnoreCase))
                ?.Endpoints
                .ToList();
            _client = client;
            _mapper = mapper;
        }

        public async Task<List<ExerciseDTO>> List()
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };

            var content = await _client.GetStringAsync(_endpoints
                .FirstOrDefault(w => w.Name.Equals("Exercises", StringComparison.OrdinalIgnoreCase))
                ?.Uri);
            var exercises = JsonSerializer.Deserialize<List<Exercise>>(content,options);

            return _mapper.Map<List<ExerciseDTO>>(exercises);
        }

        public async Task<Result> Create(CreateExercise createExercise)
        {
            var content = new StringContent(JsonSerializer.Serialize(createExercise),Encoding.UTF8, "application/json");
            var result = await _client.PostAsync(_endpoints
                .FirstOrDefault(w => w.Name.Equals("Exercises", StringComparison.OrdinalIgnoreCase))
                ?.Uri, content);
            return result.StatusCode == System.Net.HttpStatusCode.Created
                ? Result.Success()
                : Result.Failure(ExerciseErrors.NotCreated());
        }

        public async Task<Result> Update(UpdateExercise updateExercise)
        {
            var content = new StringContent(JsonSerializer.Serialize(updateExercise),Encoding.UTF8, "application/json");
            var result = await _client.PutAsync(_endpoints
                .FirstOrDefault(w => w.Name.Equals("Exercises", StringComparison.OrdinalIgnoreCase))
                ?.Uri, content);
            return result.StatusCode == System.Net.HttpStatusCode.Accepted
                ? Result.Success()
                : Result.Failure(ExerciseErrors.NotUpdated());
        }

        public async Task<Result<Exercise>> Get(int id)
        {
            var content = await _client.GetStringAsync(_endpoints
                .FirstOrDefault(w => w.Name.Equals("Exercises", StringComparison.OrdinalIgnoreCase))
                ?.Uri + "/" + id);
            var exercise = JsonSerializer.Deserialize<Exercise>(content);

            return Result.Success(exercise);
        }

        public async Task<Result> Delete(int id)
        {
            var result = await _client.DeleteAsync(_endpoints
                .FirstOrDefault(w=>w.Name.Equals("Exercises",StringComparison.OrdinalIgnoreCase))
                ?.Uri + "/" + id);
            return result.IsSuccessStatusCode
                ? Result.Success()
                : Result.Failure(ExerciseErrors.NotDeleted());
        }
    }
}
