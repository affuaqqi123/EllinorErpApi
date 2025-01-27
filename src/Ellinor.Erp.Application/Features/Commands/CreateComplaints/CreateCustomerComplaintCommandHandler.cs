﻿using Ellinor.Erp.Domain.Core;
using MediatR;
using Ellinor.Erp.Domain.Entities;
using Ellinor.Erp.Domain.Repositories.Interfaces;
using Ellinor.Erp.Shared.DTOs;

namespace Ellinor.Erp.Application.Features.Commands.CreateComplaints
{
    public class CreateCustomerComplaintCommandHandler : IRequestHandler<CreateCustomerComplaintCommand, int>
    {
        private readonly IGenericInterface _complaintRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateCustomerComplaintCommandHandler(IGenericInterface repository, IUnitOfWork unitofWork)
        {
            _complaintRepository = repository;
            _unitOfWork = unitofWork;
        }

        public async Task<int> Handle(CreateCustomerComplaintCommand request, CancellationToken cancellationToken)
        {
            var post = new CustomerComplaint(request.EmployeeId, request.EmployeeName, request.FirstName, request.SurName, request.MobileNumber, request.Email, request.CustomerAddress1, request.CustomerAddress2, request.City, request.Postalcode, request.Sku, request.BrandName, request.OrderNo, request.ComplaintCategoryId, request.StoreLocationId, request.DateofPurchase, request.DateofComplaint, request.FaultDetectionDate, request.NatureOfComplaint, request.RemedyRequestedByCustomer, request.ProductImagesId, request.Comments, request.CreatedBy, request.UpdatedBy, request.CreationDate, request.ModificationDate);

           await _complaintRepository.AddRecordAsync(post);

            _unitOfWork.Commit();

            return post.Id;

           
        }


    }
}
