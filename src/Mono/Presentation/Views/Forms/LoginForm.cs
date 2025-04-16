using Integrador.Application.Authorization;

using System.ComponentModel;

namespace Integrador.Presentation.Views;

public partial class LoginForm : Form
{
    private readonly IAuthorizationService _authorizationService;
    private readonly IUserRepository _userRepository;

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public User? LoggedUser { get; private set; }

    public LoginForm(IAuthorizationService authorizationService, IUserRepository userRepository)
    {
        InitializeComponent();
        _authorizationService = authorizationService;
        _userRepository = userRepository;
    }

    private void ButtonLogin_Click(object sender, EventArgs e)
    {
        var username = txtUsername.Text.Trim();
        var password = txtPassword.Text;

        var user = _userRepository.GetByUsername(username);

        if (user == null || user.PasswordHash != PasswordHasher.Hash(password))
        {
            MessageBox.Show("Usuario o contraseña incorrectos.");
            return;
        }

        LoggedUser = user;
        DialogResult = DialogResult.OK;
        Close();
    }
}
