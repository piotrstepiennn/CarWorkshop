using AutoMapper;
using CarWorkshop.Application.ApplicationUser;
using CarWorkshop.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Application.CarWorkshop.Commands.CreateCarWorkshop
{
    public class CreateCarWorkshopCommandHandler : IRequestHandler<CreateCarWorkshopCommand>
    {
        private readonly ICarWorkshopRepository _carWorkshopRepository;
        private readonly IUserContext _userContext;

        public IMapper _mapper { get; }

        public CreateCarWorkshopCommandHandler (ICarWorkshopRepository carWorkshopRepository, IMapper mapper, IUserContext userContext)
        {
            _carWorkshopRepository = carWorkshopRepository;
            _mapper = mapper;
            _userContext = userContext;
        }

    public async Task<Unit> Handle(CreateCarWorkshopCommand request, CancellationToken cancellationToken)
        {
            var currentUser = _userContext.GetCurrentUser();
            
            if(currentUser == null || !currentUser.IsInRole("Owner"))
            {
                return Unit.Value;
            }

            var carWorkshop = _mapper.Map<Domain.Entities.CarWorkshop>(request);

            carWorkshop.EncodeName();
            carWorkshop.CreatedByID = currentUser.Id;


            await _carWorkshopRepository.Create(carWorkshop);
               
            

            return Unit.Value;
        }
    }
}
