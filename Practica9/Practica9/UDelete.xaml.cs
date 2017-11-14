using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Practica9
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UDelete : ContentPage
    {
        public ObservableCollection<_13090341> Items { get; set; }
        public static MobileServiceClient Cliente;
        public MobileServiceUser usuario;
        public static IMobileServiceTable<_13090341> Tabla;

        public UDelete(MobileServiceUser user)
        {
            InitializeComponent();
            usuario = user;
            LeerTabla();
            Cliente = new MobileServiceClient(AzureConnection.AzureURL);
            Tabla = Cliente.GetTable<_13090341>();
           // Deleted();
        }
        private async void LeerTabla()
        {
            if (usuario != null)
            {
                IEnumerable<_13090341> elementos = await MainPage.Tabla.IncludeDeleted().Where(_13090341 => _13090341.Deleted == true).ToEnumerableAsync();
                Items = new ObservableCollection<_13090341>(elementos);
                BindingContext = this;
                Lista.ItemsSource = Items;
            }
            else
            {
                await DisplayAlert("ERROR", usuario.UserId, "ok");
            }
        }
            private async void Handle_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;
            await Navigation.PushModalAsync(new SelectedPage(e.SelectedItem as _13090341));
        }
    }
}