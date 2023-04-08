using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LockerZone.Application.Services
{
    public class ServiceBase
    {
        public Guid UserId { get; set; }
        protected async Task<ServiceResponse<T>> LogError<T>(Exception ex, T data)
        {
            return new ServiceResponse<T> { Success = false, Data = data, Message = ex.Message };
        }
       
    }
}
