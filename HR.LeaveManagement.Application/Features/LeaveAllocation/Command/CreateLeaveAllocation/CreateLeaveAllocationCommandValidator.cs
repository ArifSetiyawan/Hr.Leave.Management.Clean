using FluentValidation;
using HR.LeaveManagement.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveAllocation.Command.CreateLeaveAllocation
{
    public class CreateLeaveAllocationCommandValidator : AbstractValidator<CreateLeaveAllocationCommand>
    {
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;

        public CreateLeaveAllocationCommandValidator(ILeaveAllocationRepository leaveAllocationRepository)
        {
            //RuleFor(p => p.)
            //    .NotEmpty().WithMessage("{PropertyName} is Required")
            //    .NotNull()
            //    .MaximumLength(70).WithMessage("{PropertyName} must be fewer than 70 characters");

            //RuleFor(p => p.NumberOfDays)
            //    .GreaterThan(1).WithMessage("{PropertyName} cannot exceed 100")
            //    .LessThan(100).WithMessage("{PropertyName} cannot be less than 1");

            //RuleFor(q => q)
            //    .MustAsync(LeaveTypeNameUnique)
            //    .WithMessage("Leave Type Name Is Already Exist");

            this._leaveAllocationRepository = leaveAllocationRepository;
        }
    }
}