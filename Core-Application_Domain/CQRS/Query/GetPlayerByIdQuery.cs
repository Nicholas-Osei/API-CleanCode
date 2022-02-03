using System;
using Core_Application_Domain.Interfaces;
using Core_Application_Domain.Model;
using MediatR;

namespace Core_Application_Domain.CQRS.Query
{
	public class GetPlayerByIdQuery: IRequest<Player>
    {
        // Properties om querie te kunnen afhandelen, hier een id
        public int Id { get; set; }
        public class GetPlayerByIdQueryHandler : IRequestHandler<GetPlayerByIdQuery, Player>
        {
            private readonly IPlayerRepository repo;

            public GetPlayerByIdQueryHandler(IPlayerRepository repo)
            {
                this.repo = repo;
            }
            public async Task<Player> Handle(GetPlayerByIdQuery request, CancellationToken cancellationToken)
            {
                var player = await repo.Get(request.Id);
                if (player == null)
                {
                    throw new KeyNotFoundException("Student not found");
                }
                return player;
            }
        }
    }
}

