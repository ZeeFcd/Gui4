using Gui4.Helpers;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gui4.Models
{
    public class SuperHero : ObservableObject
    {
        private string type;
        public string Type
        {
            get { return type; }
            set { SetProperty(ref type, value); }
        }

        private int power;
        public int Power
        {
            get { return power; }
            set { SetProperty(ref power, value); }
        }

        private int speed;
        public int Speed
        {
            get { return speed; }
            set { SetProperty(ref speed, value); }
        }

        private KarmaEnum karma;

        public KarmaEnum Karma
        {
            get { return karma; }
            set { SetProperty(ref karma, value); }
        }


        public int Cost
        {
            get
            {
                return speed * power;
            }
        }

        public SuperHero GetCopy()
        {
            return new SuperHero()
            {
                Type = this.Type,
                Power = this.Power,
                Speed = this.Speed,
                Karma=this.Karma
            };
        }



    }
}
