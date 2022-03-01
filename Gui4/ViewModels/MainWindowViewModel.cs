using Gui4.Logic;
using Gui4.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using Microsoft.Toolkit.Mvvm.Input;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Gui4.ViewModels
{
    public class MainWindowViewModel : ObservableRecipient
    {
        ISuperHeroTeamLogic logic;
        public ObservableCollection<SuperHero> SuperHeroes { get; set; }
        public ObservableCollection<SuperHero> Team { get; set; }

        private SuperHero selectedFromSuperHeroes;

        public SuperHero SelectedFromSuperHeroes
        {
            get { return selectedFromSuperHeroes; }
            set
            {
                SetProperty(ref selectedFromSuperHeroes, value);
                (AddToTeamCommand as RelayCommand).NotifyCanExecuteChanged();
                (CreateSuperHeroCommand as RelayCommand).NotifyCanExecuteChanged();
            }
        }

        private SuperHero selectedFromTeam;

        public SuperHero SelectedFromTeam
        {
            get { return selectedFromTeam; }
            set
            {
                SetProperty(ref selectedFromTeam, value);
                (RemoveFromTeamCommand as RelayCommand).NotifyCanExecuteChanged();
            }
        }

        public ICommand AddToTeamCommand { get; set; }
        public ICommand RemoveFromTeamCommand { get; set; }
        public ICommand CreateSuperHeroCommand { get; set; }
        public ICommand SaveCommand { get; set; }


        public double AVGPower
        {
            get
            {
                return logic.AVGPower;
            }
        }

        public double AVGSpeed
        {
            get
            {
                return logic.AVGSpeed;
            }
        }

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }


        public MainWindowViewModel()
            : this(IsInDesignMode ? null : Ioc.Default.GetService<ISuperHeroTeamLogic>())
        {

        }

        public MainWindowViewModel(ISuperHeroTeamLogic logic)
        {
            this.logic = logic;
            
            Team = new ObservableCollection<SuperHero>();
            if (File.Exists("heroes.json"))
            {
                SuperHeroes = JsonConvert.DeserializeObject<ObservableCollection<SuperHero>>(File.ReadAllText("heroes.json"));
            }
            else
            {
                SuperHeroes = new ObservableCollection<SuperHero>();
            }

            logic.SetupCollections(SuperHeroes, Team);
            
            AddToTeamCommand = new RelayCommand(
                () => logic.AddToTeam(selectedFromSuperHeroes),
                () => selectedFromSuperHeroes != null
                );

            RemoveFromTeamCommand = new RelayCommand(
                () => logic.RemoveFromTeam(selectedFromTeam),
                () => selectedFromTeam != null
                );

            CreateSuperHeroCommand = new RelayCommand(
                () => logic.CreateSuperHero(),
                () => true
                );

            SaveCommand = new RelayCommand(
                () => logic.SaveHeroes(),
                () => SuperHeroes != null
                );


            Messenger.Register<MainWindowViewModel, string, string>(this, "SuperHeroInfo", (recipient, msg) =>
            {
                OnPropertyChanged("AVGPower");
                OnPropertyChanged("AVGSpeed");
            });
        }
    }
}