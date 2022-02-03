using System;
using Core_Application_Domain.Interfaces;
using Core_Application_Domain.Model;
using MediatR;
using AspNetCoreHero.Results;
namespace Core_Application_Domain.CQRS.Command
{
	public class DeletePlayerCommand:IRequest<Result<int>>
	{
        public int Id { get; set; }
        public class DeletePlayerHandler : IRequestHandler<DeletePlayerCommand, Result<int>>
        {
            private readonly IPlayerRepository repo;
           

            public DeletePlayerHandler(IPlayerRepository repo)
            {
                this.repo = repo;
            }
            public async Task<Result<int>> Handle(DeletePlayerCommand request, CancellationToken cancellationToken)
            {
                var PlayerToDelete = await repo.Get(request.Id);
                if (PlayerToDelete == null)
                {
                    throw new KeyNotFoundException("The specified player was ot found");
                }
                else
                {
                    await repo.Delete(PlayerToDelete);
                    return Result<int>.Success(PlayerToDelete.Id);
                }
;               
            }
        }
    }
}

