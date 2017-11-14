using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using Android.Service.Notification;
namespace Practica9.Droid
{
    [Activity(Label = "Practica9", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        private MobileServiceUser usuario;

        public async Task<MobileServiceUser> Authenticate()
        {
            var message = string.Empty;
            try
            
            {
                usuario = await Practica9.MainPage.Cliente.LoginAsync(this, MobileServiceAuthenticationProvider.MicrosoftAccount, "tesh.azurewebsites.net");
                if (usuario != null)
                {
                    message = string.Format("Usuario Autenticado {0}.", usuario.UserId);
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
            AlertDialog.Builder builder = new AlertDialog.Builder(this);
            builder.SetMessage(message);
            builder.SetTitle("Resultado De Autenticacion");
            builder.Create().Show();
            return usuario;
        }

        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            Practica9.App.Init((ISQLAzure)this);
            LoadApplication(new App());
        }
    }
}

