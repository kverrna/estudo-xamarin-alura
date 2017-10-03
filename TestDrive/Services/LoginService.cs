using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TestDrive.Models;
using Xamarin.Forms;

namespace TestDrive.Services
{
  public class LoginService
  {

    public LoginService()
    {
    }
    public async Task FazerLogin(Login login)
    {

      using (var cliente = new HttpClient())
      {
        var camposFormulario = new FormUrlEncodedContent(new[]{
            new KeyValuePair<string,string>("email",login.Email),
            new KeyValuePair<string,string>("senha",login.Senha)
        });

        cliente.BaseAddress = new Uri("https://aluracar.herokuapp.com");
        HttpResponseMessage resultado = null;
        try
        {
           resultado = await cliente.PostAsync("/login", camposFormulario);
        }
        catch
        {
          MessagingCenter.Send<LoginException>(new LoginException("Ocorreu um erro de comunicação com o Servidor.\nPor favor verifica sua internet."), "FalhaLogin");
        }

        if (resultado.IsSuccessStatusCode)
        {
          var conteudoResultado=await resultado.Content.ReadAsStringAsync();
          var resultadoLogin = JsonConvert.DeserializeObject<ResultadoLogin>(conteudoResultado);
          MessagingCenter.Send<Usuario>(resultadoLogin.usuario, "SucessoLogin"); 
        }
        else
          MessagingCenter.Send<LoginException>(new LoginException("Usuario ou senha Incorretos"), "FalhaLogin");
      }


    }
  }
  class LoginException : Exception
  {
    public LoginException(string msg) : base(msg) { }
  }
}
