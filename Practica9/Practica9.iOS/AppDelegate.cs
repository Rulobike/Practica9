using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;


using Microsoft.WindowsAzure.MobileServices;
using System.Threading.Tasks;
namespace Practica9.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        private MobileServiceUser usuario;
        public async Task<MobileServiceUser> Authenticate()
        {
            var message = string.Empty;
            try
            {
                usuario = await Practica9.DataPage.Cliente.LoginAsync(UIApplication.SharedApplication.KeyWindow.RootViewController, MobileServiceAuthenticationProvider.MicrosoftAccount, "tesh.azurewebsites.net");
                if (usuario != null)
                {
                    message = string.Format("Usuario autenticado {0}.", usuario.UserId);
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
            IUIAlertViewDelegate iUIAlert = null;
            UIAlertView avAlert = new UIAlertView("Resultado de Autenticacion", message,iUIAlert, "Ok", null);
            avAlert.Show();
            return usuario;
        }

        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();
            App.Init((ISQLAzure)this);
            LoadApplication(new App());
  
            return base.FinishedLaunching(app, options);
        }
    }
}
