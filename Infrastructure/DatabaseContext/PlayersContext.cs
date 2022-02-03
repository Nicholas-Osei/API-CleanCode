using System;
using Core_Application_Domain.Model;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure.DatabaseContext
{
	public class PlayersContext:DbContext
	{
		public PlayersContext(DbContextOptions<PlayersContext> options):base(options)
		{
		}

		public DbSet<Player> Players { get; set; }
		public DbSet<Children> GetChildrens { get; set; }

	}
}

