using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;



using Microsoft.WindowsAzure.MobileServices;
using System.Collections.ObjectModel;
namespace Practica9
{
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<_13090341> Items { get; set; }
        public static MobileServiceClient Cliente;
        public static IMobileServiceTable<_13090341> Tabla;
        public MainPage()
        {
            InitializeComponent();
            Cliente = new MobileServiceClient(AzureConnection.AzureURL);
            Tabla = Cliente.GetTable<_13090341>();
            LeerTabla();
        }
        async void Handle_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;
            await Navigation.PushModalAsync(new SelectedPage(e.SelectedItem as _13090341));
        }

        private void Boton_Insertar(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new InsertPage());
        }

        private async void LeerTabla()
        {
            IEnumerable<_13090341> elementos = await Tabla.ToEnumerableAsync();
            Items = new ObservableCollection<_13090341>(elementos);
            BindingContext = this;
        }

        private void Boton_Undeleted(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new UDelete());
          
        }
    }
}
