using MediatR;
using Ellinor.Erp.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ellinor.Erp.Application.Features.Queries.GetComplaintsByStoreId
{
    public class GetAllComplaintByStoreIdQuery : IRequest<List<CustomersComplaintDto>>
    {
        public string? StoreLocationId { get; set; }
    }
}