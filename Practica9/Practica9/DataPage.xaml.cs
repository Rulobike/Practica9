using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

//referencias necesarias
using Microsoft.WindowsAzure.MobileServices;
using System.Collections.ObjectModel;

namespace Practica9
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DataPage : ContentPage
    {
        public ObservableCollection<_13090341> Items { get; set; }
        public static MobileServiceClient Cliente;
        public static IMobileServiceTable<_13090341> Tabla;
        public DataPage()
        {
            InitializeComponent();
        }
        private async void LeerTabla()
        {
            IEnumerable<_13090341> items = await Tabla.Where(_13090341 => _13090341.Deleted == false).ToEnumerableAsync();
            Items = new ObservableCollection<_13090341>(items);
            BindingContext = this;
        }
        private async void Handle_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;
            await Navigation.PushAsync(new SelectedPage(e.SelectedItem as _13090341));
        }
    }
}