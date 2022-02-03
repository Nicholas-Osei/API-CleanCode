using System;
using Core_Application_Domain.Interfaces;
using Core_Application_Domain.Model;
using MediatR;

namespace Core_Application_Domain.CQRS.Command
{
	public class AddPlayerCommand: IRequest<Player>
	{
		public Player PlayerToAdd { get; set; }
        public class AddPlayerHandler : IRequestHandler<AddPlayerCommand, Player>
        {
            private readonly IPlayerRepository repo;

            public AddPlayerHandler(IPlayerRepository repo)
            {
                this.repo = repo;
            }
            public async Task<Player> Handle(AddPlayerCommand request, CancellationToken cancellationToken)
            {
                return await repo.Add(request.PlayerToAdd);
            }
        }
    }
}

