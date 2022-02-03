using System;
using AutoMapper;
using Core_Application_Domain.CQRS.Command;
using Core_Application_Domain.CQRS.Query;
using Core_Application_Domain.Model;

namespace Core_Application_Domain.Mappings
{
	public class mappings: Profile
	{
		public mappings()
		{
			CreateMap<AddPlayerCommand, Player>().ReverseMap();
			//CreateMap<Player, GetAllPlayersVM>().ReverseMap();
			CreateMap<Player, GetAllPlayersVM>()
				.ForMember(a => a.Age, vm => vm.MapFrom(s => DateTime.Now.Subtract(s.Birth).Days));
		}
	}
}

