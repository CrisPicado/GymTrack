using Application.Coaches;
using AutoMapper;
using Domain.Coaches;
using Domain.Equipments;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Equipments
{
    public class EquipmentsService : IEquipmentsService

    {
        private readonly IEquipmentsRepository _repository;
        private readonly IMapper _mapper;

        public EquipmentsService(IEquipmentsRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Result<IList<Equipment>> List()
        {
            return Result.Success<IList<Equipment>>(_repository.GetAll());
        }
        public Result<Equipment> Get(int id)
        {
            var equipment = _repository.Get(e => e.Id == id);

            if (equipment == null)
            {
                return Result.Failure<Equipment>(EquipmentsErrors.NotFound());
            }

            return Result.Success(equipment);
        }

        public Result Create(CreateEquipments createEquiments)
        {
            var equipment = _mapper.Map<CreateEquipments, Equipment>(createEquiments);
            _repository.Insert(Equipment.Create(0, equipment));
            _repository.Save();
            return Result.Success();
        }

        public Result Update(UpdateEquipments updateEquiments)
        {
            var result = Get(updateEquiments.Id);
            if (result.IsFailure)
            {
                return Result.Failure(result.Error);
            }

            var equipment = result.Value;
            _mapper.Map<UpdateEquipments, Equipment>(updateEquiments, equipment);
            _repository.Update(equipment);
            _repository.Save();
            return Result.Success();
        }

        public Result Delete(int id)
        {
            var result = Get(id);
            if (result.IsFailure)
            {
                return Result.Failure(result.Error);
            }

            var equipment = result.Value;
            _repository.Delete(equipment);
            _repository.Save();
            return Result.Success();
        }



    }
}
