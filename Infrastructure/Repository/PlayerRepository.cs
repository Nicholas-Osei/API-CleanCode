using System;
using Core_Application_Domain.Interfaces;
using Core_Application_Domain.Model;
using Infrastructure.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Infrastructure.Repository
{
	public class PlayerRepository:IPlayerRepository
	{
        PlayersContext ctxt;
        public PlayerRepository(PlayersContext _ctxt)
		{
            ctxt = _ctxt;
		}
        public async Task<IEnumerable<Player>> GetAll()
        {
            return await ctxt.Players.Include(c => c.child).ToListAsync();
        }

        public async Task<Player> Get(int id)
        {
            var player = await ctxt.Players.Include(c => c.child).SingleOrDefaultAsync(d => d.Id == id);
            return player;
        }

        public async Task<Player> Add(Player s)
        {
            await ctxt.Players.AddAsync(s);
            await ctxt.SaveChangesAsync();
            return s;
        }

        public async Task<Player> Update(Player s)
        {
            ctxt.Players.Update(s);
            await ctxt.SaveChangesAsync();
            return s;
        }

        //when returntype void, return Task
        public async Task Delete(Player s)
        {
            ctxt.Players.Remove(s);
            await ctxt.SaveChangesAsync();
        }
    }
}

