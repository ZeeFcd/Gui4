using Gui4.Models;
using Gui4.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Gui4
{
    /// <summary>
    /// Interaction logic for CreateSuperHero.xaml
    /// </summary>
    public partial class CreateSuperHero : Window
    {
        bool closedByButton;
        public CreateSuperHero(SuperHero superhero)
        {
            InitializeComponent();
            closedByButton = false;
            var vm = new CreateSuperHeroViewModel();
            vm.Setup(superhero);
            this.DataContext = vm;
        }

        private void Vm_CreateddDone(object? sender, EventArgs e)
        {
            this.DialogResult = true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in stack.Children)
            {
                if (item is TextBox t)
                {
                    t.GetBindingExpression(TextBox.TextProperty).UpdateSource();
                }
            }
            closedByButton = true;
            this.DialogResult = true;

        }
                
    }
}
