using System;
using System.Collections.Generic;
using TestDrive.Models;
using Xamarin.Forms;

namespace TestDrive.Views
{
  public partial class MasterDetailView : MasterDetailPage
  {
    private readonly Usuario _usuario;
    public MasterDetailView(Usuario usuario)
    {
      InitializeComponent();
      this._usuario = usuario;
      this.Master = new MasterView(usuario);
     // this.Detail = new ListagemView(); //via codigo
    }
  }
}
