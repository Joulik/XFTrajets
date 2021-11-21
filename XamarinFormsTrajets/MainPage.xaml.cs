using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarinFormsTrajets
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            collectionView.ItemsSource = await App.Database.GetTrajetsAsync();
        }

        async void OnButtonClicked(object sender, EventArgs e)
        {
            string direction="";
            if (RadioButtonAller.IsChecked)
                direction = "Aller";
            if (RadioButtonRetour.IsChecked)
                direction = "Retour";
            if (!string.IsNullOrWhiteSpace(transportEntry.Text))
            {
                await App.Database.SaveTrajetAsync(new Trajet
                {
                    Date = DateTime.Now,
                    Direction = direction,
                    Transport = transportEntry.Text,
                    Duree = int.Parse(dureeEntry.Text)
                });

                //directionEntry.Text = string.Empty;
                transportEntry.Text = string.Empty;
                dureeEntry.Text = string.Empty;

                collectionView.ItemsSource = await
                    App.Database.GetTrajetsAsync();
            }
        }
    }
}
