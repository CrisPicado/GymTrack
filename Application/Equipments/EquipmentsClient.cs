using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Domain.Equipments;
using System.Text.Json;
using AutoMapper;
using Microsoft.Extensions.Options;
using Domain.Configuration;
using Shared;
using Application.Equipments;
using Application.Clients;
using Domain.Clients;

namespace Application.Equipments
{
    public class EquipmentsClient : IEquipmentsClient
    {
        private readonly List<EndpointConfiguration> _endpoints;
        private readonly HttpClient _client;
        private readonly IMapper _mapper;


        public EquipmentsClient(IOptions<List<EndpointConfiguration>> options, HttpClient client, IMapper mapper)
        {
            _endpoints = options.Value.Where
                (w => w.Name.Equals("DefaultApi", StringComparison.OrdinalIgnoreCase)).FirstOrDefault().Endpoints.ToList();
            _client = client;
            _mapper = mapper;
        }

        public async Task<List<EquipmentDTO>> List()
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };

            var content = await _client.GetStringAsync(_endpoints.Where(w => w.Name.Equals("Equipments", StringComparison.OrdinalIgnoreCase)).FirstOrDefault().Uri);
            var equipments = JsonSerializer.Deserialize<List<Equipment>>(content, options);

            return _mapper.Map<List<EquipmentDTO>>(equipments);
        }

        public async Task<Result> Create(CreateEquipments createEquipments)
        {
            var content = new StringContent(JsonSerializer.Serialize(createEquipments), Encoding.UTF8, "application/json");
            var result = await _client.PostAsync(_endpoints.Where(w => w.Name.Equals("Equipments", StringComparison.OrdinalIgnoreCase)).FirstOrDefault().Uri, content);
            return result.StatusCode == System.Net.HttpStatusCode.Created
                ? Result.Success()
                : Result.Failure(EquipmentsErrors.NotCreated());
        }

        public async Task<Result> Update(UpdateEquipments updateEquipments)
        {
            var content = new StringContent(JsonSerializer.Serialize(updateEquipments), Encoding.UTF8, "application/json");
            var result = await _client.PutAsync
                (_endpoints.Where(w => w.Name.Equals("Equipments", StringComparison.OrdinalIgnoreCase)).FirstOrDefault().Uri, content);
            return result.StatusCode == System.Net.HttpStatusCode.Accepted
                ? Result.Success()
                : Result.Failure(EquipmentsErrors.NotUpdated());
        }

        public async Task<Result<Equipment>> Get(int id)
        {
            var content = await _client.GetStringAsync
                (_endpoints.Where(w => w.Name.Equals("Equipments", StringComparison.OrdinalIgnoreCase)).FirstOrDefault().Uri + "/" + id);
            var equipments = JsonSerializer.Deserialize<Equipment>(content);

            return Result.Success(equipments);
        }

        public async Task<Result> Delete(int id)
        {
            var result = await _client.DeleteAsync
                (_endpoints.Where(w => w.Name.Equals("Equipments", StringComparison.OrdinalIgnoreCase)).FirstOrDefault().Uri + "/" + id);
            return result.IsSuccessStatusCode
                ? Result.Success()
                : Result.Failure(EquipmentsErrors.NotDeleted());
        }

    }
}
