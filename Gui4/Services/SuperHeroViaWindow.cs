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
        public void Edit(SuperHero superHero)
        {
            //new SuperHeroEditorWindow(superHero).ShowDialog();
        }
    }
}
