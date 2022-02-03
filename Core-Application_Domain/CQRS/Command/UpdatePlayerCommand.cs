using System;
using AspNetCoreHero.Results;
using AutoMapper;
using Core_Application_Domain.CQRS.Query;
using Core_Application_Domain.Interfaces;
using Core_Application_Domain.Model;
using MediatR;

namespace Core_Application_Domain.CQRS.Command
{
	public class UpdatePlayerCommand: IRequest<GetAllPlayersVM>
    {
        public GetAllPlayersVM PlayerToUpdate { get; set; }
        public int ID { get; set; }

        public class UpdatePlayerHandler : IRequestHandler<UpdatePlayerCommand, GetAllPlayersVM>
        {
            private readonly IPlayerRepository repo;
            private readonly IMapper mapper;

            public UpdatePlayerHandler(IPlayerRepository repo, IMapper mapper)
            {
                this.repo = repo;
                this.mapper = mapper;
            }
            public async Task<GetAllPlayersVM> Handle(UpdatePlayerCommand request, CancellationToken cancellationToken)
            {
                var speler = await repo.Get(request.ID);
                if(speler == null)
                {
                    throw new KeyNotFoundException("The specified player was not found");
                }
                else
                {

                    speler.Club = request.PlayerToUpdate.Club ?? speler.Club;
                    speler.Naam = request.PlayerToUpdate.Naam ?? speler.Naam;
                    speler.Image = request.PlayerToUpdate.Image ?? speler.Image;
                    speler.Birth = request.PlayerToUpdate.Age ?? speler.Birth;
                    await repo.Update(speler);
                    return (mapper.Map<GetAllPlayersVM>(speler));
                }

            }
        }
    }
}

