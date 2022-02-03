using System;
using System.Text.Json.Serialization;

namespace Core_Application_Domain.Model
{
	public class Player
	{
        public int Id { get; set; }
        public string Naam { get; set; }
        public string Club { get; set; }
        public string Image { get; set; }
        public DateTime Birth { get; set; }
        public  Children child { get; set; }
    }
}

