using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Practica9
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InsertPage : ContentPage
    {
        public InsertPage()
        {
            InitializeComponent();

        }

        private async void Boton_Insertar(object sender, EventArgs e)
        {
             var datos = new _13090341
            {
                Nombre = Entry_Nombre.Text,
                Apellidos = Entry_Apellidos.Text,
                Direccion = Entry_Direccion.Text,
                Telefono = Entry_Telefono.Text,
                Carrera = Entry_Carrera.Text,
                Semestre = Entry_Semestre.Text,
                Correo = Entry_Correo.Text,
                Github = Entry_Github.Text
            };
            await MainPage.Tabla.InsertAsync(datos);
            await Navigation.PopAsync();
           // await Navigation.PushModalAsync(new MainPage());
        }
    }
}