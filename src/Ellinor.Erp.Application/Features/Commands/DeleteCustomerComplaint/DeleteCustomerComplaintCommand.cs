﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ellinor.Erp.Application.Features.Commands.DeleteCustomerComplaint
{
    public class DeleteCustomerComplaintCommand:IRequest<bool>
    {
        public int Id { get; set; }
    }
}
