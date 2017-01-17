using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcDemo.Models
{
    
    public class LobbyistViewModels
    {
        public int Id {get;set;}
        public string Name { get; set; }
        public string Type { get; set; }
        public bool IsRegistered { get; set; }
	}
}