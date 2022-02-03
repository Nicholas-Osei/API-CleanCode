using System;
using AutoMapper;
using Core_Application_Domain.Interfaces;
using MediatR;
using System.Linq;

namespace Core_Application_Domain.CQRS.Query
{
    public class GetAllPlayersQuery : IRequest<IEnumerable<GetAllPlayersVM>>
    {
        public class GetAllPlayersQueryHandler : IRequestHandler<GetAllPlayersQuery, IEnumerable<GetAllPlayersVM>>
        {
            private readonly IPlayerRepository repo;
            private readonly IMapper mapper;

            public GetAllPlayersQueryHandler(IPlayerRepository repo, IMapper mapper)
            {
                this.repo = repo;
                this.mapper = mapper;
            }

            public async Task<IEnumerable<GetAllPlayersVM>> Handle(GetAllPlayersQuery request, CancellationToken cancellationToken)
            {
                var players = await repo.GetAll();
                return mapper.Map<IEnumerable<GetAllPlayersVM>>(players);
            }
        }
    }
}

