using Integrador.Application.Interfaces;
using Integrador.Application.State;
using Integrador.Infrastructure.Configuration;
using Integrador.Infrastructure.Interfaces;
using Integrador.Presentation.Composition;
using Integrador.Presentation.Localization;

using System.Globalization;

namespace Integrador.Presentation.Views
{
    public partial class LoginForm : Form
    {
        private readonly ILogger _logger = AppServices.Get<ILogger>();
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
                var user = authService.GetCurrentUser();
                Session.CurrentUser = user;
                _logger.LogInformation($"User {user?.Username} logged in successfully.");
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
