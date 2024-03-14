using CarBook.Application.Features.Mediator.Commands.FooterAdressCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.FooterAdressHandlers.Write
{
    public class UpdateFooterAdressCommandHandler : IRequestHandler<UpdateFooterAdressCommand>
    {
        private readonly IRepository<FooterAdress> _repository;

        public UpdateFooterAdressCommandHandler(IRepository<FooterAdress> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateFooterAdressCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.FooterAdressId);

            value.Adress = request.Adress;
            value.Phone = request.Phone;
            value.Description = request.Description;
            value.Email = request.Email;

            await _repository.UpdateAsync(value);
        }
    }
}
