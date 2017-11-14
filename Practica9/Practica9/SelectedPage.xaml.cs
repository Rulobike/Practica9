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
    public partial class SelectedPage : ContentPage
    {
        public SelectedPage(object SelectedItem)
        {
            var dato = SelectedItem as _13090341;
            BindingContext = dato;
            InitializeComponent();
        }
        private async void Actualizar_Clicked(object sender, EventArgs e)
        {
            var datos = new _13090341
            {
                Matricula = Entry_Matricula.Text,
                Nombre = Entry_Nombre.Text,
                Apellidos = Entry_Apellidos.Text,
                Direccion = Entry_Direccion.Text,
                Telefono = Entry_Telefono.Text,
                Carrera = Entry_Carrera.Text,
                Semestre = Entry_Semestre.Text,
                Correo = Entry_Correo.Text,
                Github = Entry_Github.Text

            };
            await MainPage.Tabla.UpdateAsync(datos);
            await Navigation.PopModalAsync();
        }
        private async void Eliminar_Clicked(object sender, EventArgs e)
        {
            var datos = new _13090341
            {
                Matricula = Entry_Matricula.Text,
            };
            await MainPage.Tabla.DeleteAsync(datos);
            await Navigation.PopModalAsync();
            //await Navigation.PushModalAsync(new MainPage());

        }

        private async void Recuperar_Clicked(object sender, EventArgs e)
        {
                var datos = new _13090341
                {
                    Matricula = Entry_Matricula.Text,
                };
                await MainPage.Tabla.UndeleteAsync(datos);
                await Navigation.PopModalAsync();
            

            }
        }
    }