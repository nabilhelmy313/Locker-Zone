using LockerZone.Domain.Dtos;
using LockerZone.Domain.Dtos.Locker;

namespace LockerZone.Application.Interfaces.Services
{
    public interface ILockerService
    {
        public Task<ServiceResponse<GetLockerDto>> GetLockers();
        public Task<ServiceResponse<int>> AddLocker(AddLockerDto addLockerDto);
        public Task<ServiceResponse<int>> EditLocker(EditLockerDto editLockerDto);
        public Task<ServiceResponse<int>> DeleteLocker(Guid id);
    }
}
