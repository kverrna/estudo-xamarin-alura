using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Input;
using TestDrive.Models;
using TestDrive.Services;
using Xamarin.Forms;

namespace TestDrive.ViewModels
{
  public class LoginModelView : BaseViewModel
  {
    public bool AguardeLogin { get { return _aguadeLogin; } set { _aguadeLogin = value; OnPropertyChanged();} }
    private bool _aguadeLogin { get; set; }
    private string _usuario;
    private string _senha;
    public string Usuario { get { return _usuario; } set { _usuario = value; ((Command)EntrarCommand).ChangeCanExecute(); } }//Para avisar o botao que a propriedade está valida
    public string Senha { get { return _senha; } set { _senha = value; ((Command)EntrarCommand).ChangeCanExecute(); } }
    public ICommand EntrarCommand { get; private set; }
    public LoginModelView()
    {
      this.EntrarCommand = Entrar();
    }

    public Command Entrar()
    {
      return new Command(async() =>
      {
        AguardeLogin = true;
        var loginService = new LoginService();
        var login = new Login()
        {
          Email = _usuario,
          Senha = _senha
        };

        await loginService.FazerLogin(login);
        AguardeLogin = false;
      }, () =>
       {
         return !string.IsNullOrEmpty(_usuario) && !string.IsNullOrEmpty(_senha);
       });
    }



  }
}
