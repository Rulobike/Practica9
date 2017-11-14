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
        private MobileServiceUser usuario;
        public MainPage()
        {
            InitializeComponent();
            Cliente = new MobileServiceClient(AzureConnection.AzureURL);
            Tabla = Cliente.GetTable<_13090341>();
            // LeerTabla();
        }
        async void Handle_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;
            await Navigation.PushModalAsync(new SelectedPage(e.SelectedItem as _13090341));
        }

        private void Boton_Insertar(object sender, EventArgs e)
        {
            Navigation.PushAsync(new InsertPage());
        }

        private async void LeerTabla()
        {
            IEnumerable<_13090341> elementos = await Tabla.ToEnumerableAsync();
            Items = new ObservableCollection<_13090341>(elementos);
            BindingContext = this;
            Lista.ItemsSource = Items;
        }

        private async void Boton_Undeleted(object sender, EventArgs e)
        {
            IEnumerable<_13090341> elementos = await Tabla.IncludeDeleted().Where(_13090341 => _13090341.Deleted == true).ToEnumerableAsync();
            Items = new ObservableCollection<_13090341>(elementos);
            BindingContext = this;
            Lista.ItemsSource = Items;
            // Navigation.PushModalAsync(new UDelete(usuario));

        }

        private async void Login(object sender, EventArgs e)
        {
            try
            {
                usuario = await App.Authenticator.Authenticate();
                if (App.Authenticator != null)
                {
                    if (usuario != null)
                    {
                        await DisplayAlert("Usuario Autenticado", usuario.UserId, "Ok");
                        LeerTabla();
                        Registros_E.IsVisible = true;
                        Insertar_R.IsVisible = true;
                        inicio_sesion.IsVisible = false;

                    }
                    if (usuario == null)
                    {
                        Registros_E.IsVisible = false;
                        Insertar_R.IsVisible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error de Autenticacion", ex.Message, "Ok");
            }
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (usuario != null)
            {
                LeerTabla();
            }
        }
    }
}
