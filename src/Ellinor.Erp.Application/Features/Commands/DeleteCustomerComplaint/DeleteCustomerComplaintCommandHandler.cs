using MediatR;
using Ellinor.Erp.Application.Exception;
using Ellinor.Erp.Domain.Core;
using Ellinor.Erp.Domain.Entities;
using Ellinor.Erp.Domain.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ellinor.Erp.Application.Features.Commands.DeleteCustomerComplaint
{
    public class DeleteCustomerComplaintCommandHandler : IRequestHandler<DeleteCustomerComplaintCommand, bool>
    {
        private readonly IGenericInterface _complaintRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteCustomerComplaintCommandHandler(IGenericInterface repository, IUnitOfWork unitofWork)
        {
            _complaintRepository = repository;
            _unitOfWork = unitofWork;
        }

        public async Task<bool> Handle(DeleteCustomerComplaintCommand request, CancellationToken cancellationToken)
        {
            var complaint = await _complaintRepository.FindRecordByIdAsync(request.Id);
            if (complaint == null) return false;

            await _complaintRepository.RemoveRecordAsync(request.Id);

            _unitOfWork.Commit();
         
            return true;
             
        }

    }
}
