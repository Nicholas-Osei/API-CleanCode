using System;
using Core_Application_Domain.Model;

namespace Core_Application_Domain.CQRS.Query
{
	public class GetAllPlayersVM
	{
		public int Id { get; set; }
		public string? Naam { get; set; }
		public string? Club { get; set; }
		public string? Image { get; set; }
		public DateTime? Age { get; set; }
		public Children? child { get; set; }
	}
}

