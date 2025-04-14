using Integrador.Application.Interfaces;
using Integrador.Presentation.Composition;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Integrador.Presentation.Views
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
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
