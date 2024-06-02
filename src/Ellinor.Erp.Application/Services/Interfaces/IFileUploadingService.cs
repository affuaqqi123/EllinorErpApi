
using Ellinor.Erp.Shared.DTOs;

namespace Ellinor.Erp.Application.Services.Interfaces
{
    public interface IFileUploadingService
    {
        Task UploadImageAsync(FileDTO fileDTO);
    }
}
