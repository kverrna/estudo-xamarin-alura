using System;
using System.Windows.Input;
using TestDrive.Media;
using TestDrive.Models;
using Xamarin.Forms;

namespace TestDrive.ViewModels
{
  public class MasterViewModel:BaseViewModel
  {
    private readonly Usuario _usuario;
    private bool _editando;
    private ImageSource _fotoPerfil="user_64p.png";
    public ICommand EditarCommand { get; private set; }
    public ICommand SalvarCommand { get; private set; }
    public ICommand TirarFotoCommand { get; private set; }
    public bool Editando{ get { return _editando; }set { _editando = value; OnPropertyChanged();} }
    public String Nome { get { return _usuario.nome; } set { _usuario.nome = value; }}
    public String Email { get { return _usuario.email;}set { _usuario.email = value; } }
    public String DataNascimento { get { return _usuario.dataNascimento; } set { _usuario.dataNascimento = value; } }
    public String Telefone { get { return _usuario.telefone; } set { _usuario.telefone = value; } }
    public ImageSource FotoPerfil{ get { return _fotoPerfil; }private set { _fotoPerfil = value; }}

    public MasterViewModel(Usuario usuario)
    {
      _usuario = usuario;

      EditarCommand = new Command(()=>
      {
        Editando = true;
        MessagingCenter.Send<Usuario>(_usuario,"EditarPerfil");  
      });

      SalvarCommand = new Command(()=>
      {
        Editando = false;
      });

      TirarFotoCommand = new Command(()=>
      {
        DependencyService.Get<ICamera>().TirarFoto();
      });
    }
  }
}
