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
        public static IMobileServiceTable<_13090341> Tabla;
        public UDelete()
        {
            InitializeComponent();
            Cliente = new MobileServiceClient(AzureConnection.AzureURL);
            Tabla = Cliente.GetTable<_13090341>();
            Deleted();
        }

        private async void Deleted()
        {
            IEnumerable<_13090341> elementos = await Tabla.IncludeDeleted().ToEnumerableAsync();
            Items = new ObservableCollection<_13090341>(elementos);
            BindingContext = this;
            InitializeComponent();
        }


        private async void Handle_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;
            await Navigation.PushModalAsync(new SelectedPage(e.SelectedItem as _13090341));
        }
    }
}