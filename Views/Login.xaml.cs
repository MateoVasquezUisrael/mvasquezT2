

namespace mvasquezT2.Views;

public partial class Login : ContentPage
{
    private string[] users = { "Carlos", "Ana", "Jose" };
    private string[] passwords = { "carlos123", "ana123", "jose123" };
    public Login()
	{
		InitializeComponent();
	}

    private async void loginButton_Pressed(object sender, EventArgs e)
    {
        string user = emailInput.Text;
        string pass = passInput.Text;

        for (int i = 0; i < users.Length; i++)
        {
            if (users[i] == user && passwords[i] == pass)
            {
                await Navigation.PushAsync(new Notas(user, pass));
                return;
            }
        }

        await DisplayAlertAsync("Error", "Usuario o contraseña incorrectos", "OK");
    }
}