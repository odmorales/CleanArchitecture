﻿using AutoMapper;
using CleanArchitecture.Aplication.Contracts.Persistence;
using CleanArchitecture.Aplication.Exceptions;
using CleanArchitecture.Domain;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Aplication.Features.Streamers.Commands.DeleteStreamer
{
    public class DeleteStreamerCommandHandler : IRequestHandler<DeleteStreamerCommand>
    {
        //private readonly IStreamerRepository _streamerRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<DeleteStreamerCommandHandler> _logger;

        public DeleteStreamerCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<DeleteStreamerCommandHandler> logger)
        {
            //_streamerRepository = streamerRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Unit> Handle(DeleteStreamerCommand request, CancellationToken cancellationToken)
        {
            //var streamerToDelete = await _streamerRepository.GetByIdAsync(request.Id);
            var streamerToDelete = await _unitOfWork.StreamerRepository.GetByIdAsync(request.Id);
            if (streamerToDelete == null)
            {
                _logger.LogError($"No se encontro el streamer id {request.Id}");
                throw new NotFoundException(name: nameof(Streamer), request.Id);
            }

            //await _streamerRepository.DeleteAsync(streamerToDelete);
            _unitOfWork.StreamerRepository.DeleteEntity(streamerToDelete);
            await _unitOfWork.Complete();

            _logger.LogInformation($"El {request.Id} fue eliminado con exito");

            return Unit.Value;
        }
    }
}
