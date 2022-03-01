using Gui4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gui4.Services
{
    class SuperHeroViaWindow : ISuperHeroEditorService
    {
        public bool? Closed { get; set; }
        public void Create(SuperHero superHero)
        {
            
           Closed = new CreateSuperHero(superHero).ShowDialog();

        }
    }
}
