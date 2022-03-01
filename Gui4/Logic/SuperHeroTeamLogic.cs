using Gui4.Helpers;
using Gui4.Models;
using Gui4.Services;
using Microsoft.Toolkit.Mvvm.Messaging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gui4.Logic
{
    public class SuperHeroTeamLogic : ISuperHeroTeamLogic
    {
        IList<SuperHero> superHeroes;
        IList<SuperHero> superHeroTeam;
        IMessenger messenger;
        ISuperHeroEditorService editorService;


        public SuperHeroTeamLogic(IMessenger messenger, ISuperHeroEditorService editorService)
        {
            this.messenger = messenger;
            this.editorService = editorService;
        }

        public int AllCost
        {
            get
            {
                return superHeroTeam.Count == 0 ? 0 : superHeroTeam.Sum(t => t.Cost);
            }
        }

        public double AVGPower
        {
            get
            {
                return Math.Round(superHeroTeam.Count == 0 ? 0 : superHeroTeam.Average(t => t.Power), 2);
            }
        }

        public double AVGSpeed
        {
            get
            {
                return Math.Round(superHeroTeam.Count == 0 ? 0 : superHeroTeam.Average(t => t.Speed), 2);
            }
        }

        public void SetupCollections(IList<SuperHero> superHeroes, IList<SuperHero> superHeroTeam)
        {
            if (File.Exists("kaga.json"))
            {
                var superHeroesJSON = JsonConvert.DeserializeObject<IList<SuperHero>>(File.ReadAllText("kaga.json"));
                this.superHeroes = superHeroesJSON;
                this.superHeroTeam = superHeroTeam;
            }



            ;
            
        }

        public void AddToTeam(SuperHero superHero)
        {
            superHeroTeam.Add(superHero.GetCopy());
            messenger.Send("Superhero added", "SuperHeroInfo");
        }

        public void RemoveFromTeam(SuperHero superHero)
        {
            superHeroTeam.Remove(superHero);
            messenger.Send("Superhero removed", "SuperHeroInfo");
        }

        public void CreateSuperHero()
        {

            SuperHero superHero = new SuperHero() { Type="",Power=0 ,Karma=KarmaEnum.Neutral , Speed =0, };
            superHeroes.Add(superHero);
            editorService.Create(superHero);
            messenger.Send("Superhero created", "SuperHeroInfo");
        }
    }
}
