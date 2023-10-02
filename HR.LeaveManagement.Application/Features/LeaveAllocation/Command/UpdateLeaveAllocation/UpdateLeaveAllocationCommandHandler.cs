using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Logging;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Exceptions;
using HR.LeaveManagement.Application.Features.LeaveType.Commands.UpdateLeaveType;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveAllocation.Command.UpdateLeaveAllocation
{
    public class UpdateLeaveAllocationCommandHandler : IRequestHandler<UpdateLeaveAllocationCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private readonly IAppLogger<UpdateLeaveAllocationCommandHandler> _logger;

        public UpdateLeaveAllocationCommandHandler(IMapper mapper, ILeaveAllocationRepository leaveAllocationRepository, IAppLogger<UpdateLeaveAllocationCommandHandler> logger)
        {
            this._mapper = mapper;
            this._leaveAllocationRepository = leaveAllocationRepository;
            this._logger = logger;
        }

        public async Task<Unit> Handle(UpdateLeaveAllocationCommand request, CancellationToken cancellationToken)
        {
            // Validate Incoming Data
            var validator = new UpdateLeaveAllocationCommandValidator(_leaveAllocationRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
            {
                _logger.LogWarning("Validation error in update request fo {0} - {1}", nameof(LeaveType), request.Id);
                throw new BadRequestExceptions("Invalid Leave Type", validationResult);
            }

            // Convert to Domain Entity Object
            var leaveAllocationUpdate = _mapper.Map<Domain.LeaveAllocation>(request);

            // Add to Database
            await _leaveAllocationRepository.UpdateAsync(leaveAllocationUpdate);

            // Return Record ID
            return Unit.Value;
        }
    }
}