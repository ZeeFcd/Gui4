using Gui4.Models;
using System.Collections.Generic;

namespace Gui4.Logic
{
    public interface ISuperHeroTeamLogic
    {
        int AllCost { get; }
        double AVGPower { get; }
        double AVGSpeed { get; }

        void AddToTeam(SuperHero superHero);
        void RemoveFromTeam(SuperHero superHero);
        void EditSuperHero(SuperHero superHero);
        void SetupCollections(IList<SuperHero> superHeroes, IList<SuperHero> superHeroTeam);
    }
}