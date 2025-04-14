using Integrador.Application.Interfaces;
using Integrador.Infrastructure.Configuration;
using Integrador.Presentation.Composition;
using Integrador.Presentation.Localization;

using System.Globalization;
using System.Resources;

namespace Integrador.Presentation.Views
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            ConfigureCulture();
            ApplyLocalization();
        }

        private static void ConfigureCulture()
        {
            var culture = AppConfigReader.GetSetting("DefaultCulture") ?? "es";
            Thread.CurrentThread.CurrentCulture = new CultureInfo(culture);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(culture);
        }

        private void ApplyLocalization()
        {
            this.Text = Resources.TitleLogin;
            lblUsername.Text = Resources.Username;
            lblPassword.Text = Resources.Password;
            btnLogin.Text = Resources.Login;
        }

        private void ButtonLogin_Click(object sender, EventArgs e)
        {
            var authService = AppServices.Get<IAuthService>();

            if (authService.Login(txtUsername.Text, txtPassword.Text))
            {
                Session.CurrentUser = authService.GetCurrentUser();
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Credenciales inválidas");
            }
        }
    }
}
