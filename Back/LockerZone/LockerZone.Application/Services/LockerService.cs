using LockerZone.Application.Common;
using LockerZone.Application.Interfaces.Repositories;
using LockerZone.Application.Interfaces.Services;
using LockerZone.Application.Resources;
using LockerZone.Domain.Dtos;
using LockerZone.Domain.Dtos.Locker;
using LockerZone.Domain.Entities;

namespace LockerZone.Application.Services
{
    public class LockerService : ServiceBase, ILockerService
    {
        private readonly IUnitOfWork _unitOfWork;

        public LockerService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ServiceResponse<int>> AddLocker(AddLockerDto addLockerDto)
        {
            try
            {
                var map = _unitOfWork.Mapper.Map<Locker>(addLockerDto);
                _unitOfWork.LockerRepository.Create(map);
                var commit = await _unitOfWork.CommitAsync();
                return new ServiceResponse<int>
                {
                    Data = 1,
                    Success = true,
                    Message = CultureHelper.GetResourceMessage(Resource.ResourceManager, nameof(Resource.Added))
                };
            }
            catch (Exception ex)
            {

                return new ServiceResponse<int>
                {
                    Data = 0,
                    Message = ex.Message,
                    Success = false
                };
            }
        }

        public async Task<ServiceResponse<int>> EditLocker(EditLockerDto editLockerDto)
        {
            try
            {
                var locker = _unitOfWork.LockerRepository.FindByID(editLockerDto.Id);
                var map = _unitOfWork.Mapper.Map(editLockerDto, locker);
                var commit = await _unitOfWork.CommitAsync();
                return new ServiceResponse<int>
                {
                    Data = 1,
                    Success = true,
                    Message = CultureHelper.GetResourceMessage(Resource.ResourceManager, nameof(Resource.Added))
                };
            }
            catch (Exception ex)
            {
                return new ServiceResponse<int>
                {
                    Data = 0,
                    Success = false,
                    Message = ex.Message
                };
            }
        }
        public async Task<ServiceResponse<int>> DeleteLocker(Guid id)
        {
            try
            {
                _unitOfWork.LockerRepository.Delete(id);
                var commit = await _unitOfWork.CommitAsync();
                return new ServiceResponse<int>
                {
                    Data = commit,
                    Success = true,
                    Message = CultureHelper.GetResourceMessage(Resource.ResourceManager, nameof(Resource.DeletedSuccessfully))
                };
            }
            catch (Exception ex)
            {
                return new ServiceResponse<int>
                {
                    Data = 0,
                    Success = false,
                    Message = ex.Message
                };
            }
        }
        public async Task<ServiceResponse<GetLockerDto>> GetLockers()
        {
            try
            {
                var lockers = await _unitOfWork.LockerRepository.GetAllAsync();
                var map = _unitOfWork.Mapper.Map<GetLockerDto>(lockers);
                return new ServiceResponse<GetLockerDto>
                {
                    Data = map,
                    Success = true,
                    Message = CultureHelper.GetResourceMessage(Resource.ResourceManager, nameof(Resource.Added))

                };
            }
            catch (Exception ex)
            {
                return new ServiceResponse<GetLockerDto>
                {
                    Data = default!,
                    Success = false,
                    Message = ex.Message
                };
            }
        }
    }
}
