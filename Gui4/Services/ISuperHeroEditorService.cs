using Gui4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gui4.Services
{
    public interface ISuperHeroEditorService
    {
        bool? Closed { get; set; }
        void Create(SuperHero superHero);
    }
}
