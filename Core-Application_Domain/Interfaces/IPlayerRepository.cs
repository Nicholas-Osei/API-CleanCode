using System;
using Core_Application_Domain.Model;

namespace Core_Application_Domain.Interfaces
{
	public interface IPlayerRepository
	{
        Task<Player> Add(Player s);
        Task Delete(Player s);
        Task<Player> Get(int id);
        Task<IEnumerable<Player>> GetAll();
        Task<Player> Update(Player s);
    }
}

