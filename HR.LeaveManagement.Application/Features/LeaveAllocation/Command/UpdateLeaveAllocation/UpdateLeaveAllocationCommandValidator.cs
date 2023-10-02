using FluentValidation;
using HR.LeaveManagement.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveAllocation.Command.UpdateLeaveAllocation
{
    public class UpdateLeaveAllocationCommandValidator : AbstractValidator<UpdateLeaveAllocationCommand>
    {
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;

        public UpdateLeaveAllocationCommandValidator(ILeaveAllocationRepository leaveAllocationRepository)
        {
            //RuleFor(p => p.Id)
            //    .NotNull()
            //    .MustAsync(LeaveTypeMustExists);
            //RuleFor(p => p.Name)
            //     .NotEmpty().WithMessage("{PropertyName} is Required")
            //     .NotNull()
            //     .MaximumLength(70).WithMessage("{PropertyName} must be fewer than 70 characters");

            //RuleFor(p => p.DefaultDays)
            //    .GreaterThan(1).WithMessage("{PropertyName} cannot exceed 100")
            //    .LessThan(100).WithMessage("{PropertyName} cannot be less than 1");

            //RuleFor(q => q)
            //    .MustAsync(LeaveTypeNameUnique)
            //    .WithMessage("Leave Type Name Is Already Exist");

            this._leaveAllocationRepository = leaveAllocationRepository;
        }

        private async Task<bool> LeaveAllocationMustExists(int id, CancellationToken cancellationToken)
        {
            var leaveAllocation = await _leaveAllocationRepository.GetByIdAsync(id);
            return leaveAllocation != null;
        }

        //private Task<bool> LeaveAllocationNameUnique(UpdateLeaveAllocationCommand command, CancellationToken cancellationToken)
        //{
        //    return _leaveAllocationRepository.IsLeaveTypeUnique(command.Name);
        //}
    }
}