using LockerZone.Application.Interfaces.Repositories;
using LockerZone.Application.Interfaces.Services;
using LockerZone.Domain.Dtos;
using LockerZone.Domain.Entities;

namespace LockerZone.Application.Services
{
    public class FeedbackService:ServiceBase, IFeedbackService
    {
        private readonly IUnitOfWork _unitOfWork;

        public FeedbackService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ServiceResponse<int>> AddNewMessage(FeedbackMessageDto feedbackMessageDto)
        {
			try
			{
                var map = _unitOfWork.Mapper.Map<FeedbackMessage>(feedbackMessageDto);
                _unitOfWork.FeebackRepository.Create(map);
                var commit=await _unitOfWork.CommitAsync();
                return new ServiceResponse<int>
                {
                    Data = commit,
                    Success= true,
                    Message = "Message Added Successfuly"
                };
            }
			catch (Exception ex)
			{
                return new ServiceResponse<int>
                {
                    Data = 0,
                    Message = ex.Message
                };
			}
        }
    }
}
