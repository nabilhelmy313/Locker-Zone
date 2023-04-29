using LockerZone.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LockerZone.Application.Interfaces.Services
{
    public interface IFeedbackService
    {
        Task<ServiceResponse<int>> AddNewMessage(FeedbackMessageDto feedbackMessageDto);
    }
}
