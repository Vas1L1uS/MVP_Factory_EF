using System;
using System.Collections.Generic;
using System.Data.Entity;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MVP_Factory_EF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Presenter _presenter;
        public Animal SelectedAnimal { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            _presenter = new Presenter();

            buttonAdd.Click += (sender, e) =>
            {
                _presenter.AddAnimal(textBoxAnimalType.Text, textBoxAnimalKind.Text);
                lvAnimals.ItemsSource = null;
                lvAnimals.ItemsSource = _presenter.AnimalsLocal;
            };

            buttonEdit.Click += (sender, e) =>
            {
                _presenter.EditAnimal(SelectedAnimal, textBoxAnimalType.Text, textBoxAnimalKind.Text);
                lvAnimals.ItemsSource = null;
                lvAnimals.ItemsSource = _presenter.AnimalsLocal;
            };

            buttonDelete.Click += (sender, e) =>
            {
                if (SelectedAnimal != null)
                {
                    _presenter.DeleteAnimal(SelectedAnimal);
                    lvAnimals.ItemsSource = null;
                    lvAnimals.ItemsSource = _presenter.AnimalsLocal;
                }
                return;
            };

            #region Load
            loadSQL.Click += (sender, e) =>
            {
                _presenter.Load(_presenter.Load_SQL);
                lvAnimals.ItemsSource = null;
                lvAnimals.ItemsSource = _presenter.AnimalsLocal;
            };

            loadXML.Click += (sender, e) =>
            {
                _presenter.Load(_presenter.Load_XML);
                lvAnimals.ItemsSource = null;
                lvAnimals.ItemsSource = _presenter.AnimalsLocal;
            };

            loadJSON.Click += (sender, e) =>
            {
                _presenter.Load(_presenter.Load_JSON);
                lvAnimals.ItemsSource = null;
                lvAnimals.ItemsSource = _presenter.AnimalsLocal;
            };
            #endregion
            #region Save
            saveSQL.Click += (sender, e) => _presenter.Save(_presenter.Save_SQL);
            saveXML.Click += (sender, e) => _presenter.Save(_presenter.Save_XML);
            saveJSON.Click += (sender, e) => _presenter.Save(_presenter.Save_JSON);
            #endregion
        }

        private void lvAnimals_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedAnimal = lvAnimals.SelectedItem as Animal;
            if (SelectedAnimal != null)
            {
                textBoxAnimalType.Text = SelectedAnimal.Type;
                textBoxAnimalKind.Text = SelectedAnimal.Kind;
            }
        }
    }
}
