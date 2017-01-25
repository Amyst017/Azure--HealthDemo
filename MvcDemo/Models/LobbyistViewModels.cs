using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcDemo.Models
{
    
    public class LobbyistViewModels
    {
        public int Id {get;set;}

        [Display(ResourceType = typeof(Resources.Strings), Name = "lobbyDisplayName")]
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Display(ResourceType = typeof(Resources.Strings), Name="lobbyDisplayType")]
        [Required(ErrorMessage = "Organisation is required")]        
        public string Type { get; set; }

        [Display(ResourceType = typeof(Resources.Strings), Name = "lobbyDisplayRegistered")]
        public bool IsRegistered { get; set; }
	}
}