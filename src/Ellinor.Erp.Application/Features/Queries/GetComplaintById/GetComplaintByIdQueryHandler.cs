﻿using MediatR;
using Ellinor.Erp.Application.Features.Commands;
using Ellinor.Erp.Domain.Core;
using Ellinor.Erp.Domain.Repositories.Interfaces;
using Ellinor.Erp.Shared.DTOs;



namespace Ellinor.Erp.Application.Features.Queries.GetComplaint;

public class GetComplaintByIdQueryHandler : IRequestHandler<GetComplaintByIdQuery, CustomersComplaintDto>
{
    private readonly IGenericInterface _complaintRepository;
    private readonly IUnitOfWork _unitOfWork;

    public GetComplaintByIdQueryHandler(IGenericInterface repository, IUnitOfWork unitofWork)
    {
        _complaintRepository = repository;
   _unitOfWork = unitofWork;
        
    }

    public async Task<CustomersComplaintDto> Handle(GetComplaintByIdQuery query, CancellationToken cancellationToken)
    {
      
        var complaints = await _complaintRepository.FindRecordByIdAsync(query.Id);
        if (complaints == null) return null;

        return new CustomersComplaintDto()
        {
            Id = complaints.Id,
            EmployeeId = complaints.EmployeeID,
            EmployeeName = complaints.EmployeeName,
            FirstName = complaints.FirstName,
            SurName = complaints.SurName,
            MobileNumber = complaints.MobileNumber,
            Email = complaints.Email,
            CustomerAddress1 = complaints.CustomerAddress1,
            CustomerAddress2 = complaints.CustomerAddress2,
            City = complaints.City,
            Postalcode = complaints.Postalcode,
            Sku = complaints.Sku,
            BrandName = complaints.BrandName,
            OrderNo = complaints.OrderNo,
            ComplaintCategoryId = complaints.ComplaintCategoryId,
            StoreLocationId = complaints.StoreLocationId,
            DateofPurchase = complaints.DateofPurchase,
            FaultDetectionDate = complaints.FaultDetectionDate,
            NatureOfComplaint = complaints.NatureOfComplaint,
            RemedyRequestedByCustomer = complaints.RemedyRequestedByCustomer,
            ProductImagesId = complaints.ProductImagesId,
            Comments = complaints.Comments,
            CreatedBy = complaints.CreatedBy,
            UpdatedBy = complaints.UpdatedBy,
            CreationDate = complaints.CreationDate,
            ModificationDate = complaints.ModificationDate
        };

    }
}