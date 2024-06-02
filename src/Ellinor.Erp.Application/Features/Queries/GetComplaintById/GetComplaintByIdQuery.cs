using MediatR;
using Ellinor.Erp.Shared.DTOs;

namespace Ellinor.Erp.Application.Features.Queries.GetComplaint;

public class GetComplaintByIdQuery : IRequest<CustomersComplaintDto>
{
   public int Id { get; set; }
}