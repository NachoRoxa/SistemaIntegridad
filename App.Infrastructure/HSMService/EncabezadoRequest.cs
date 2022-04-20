// Decompiled with JetBrains decompiler
// Type: App.Infrastructure.HSMService.EncabezadoRequest
// Assembly: App.Infrastructure, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7D12F3AE-788C-4496-85EF-A6E23743B789
// Assembly location: C:\Users\IROCHA\source\repos\Integridad\sintegridadweb\bin\App.Infrastructure.dll

using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace App.Infrastructure.HSMService
{
  [DebuggerStepThrough]
  [GeneratedCode("System.Runtime.Serialization", "4.0.0.0")]
  [DataContract(Name = "EncabezadoRequest", Namespace = "http://www.e-sign.cl/")]
  [Serializable]
  public class EncabezadoRequest : IExtensibleDataObject, INotifyPropertyChanged
  {
    [NonSerialized]
    private ExtensionDataObject extensionDataField;
    [OptionalField]
    private string UserField;
    [OptionalField]
    private string PasswordField;
    [OptionalField]
    private string TipoIntercambioField;
    [OptionalField]
    private string NombreConfiguracionField;
    [OptionalField]
    private string FormatoDocumentoField;
    [OptionalField]
    private string RespuestaEsperadaField;

    [Browsable(false)]
    public ExtensionDataObject ExtensionData
    {
      get => this.extensionDataField;
      set => this.extensionDataField = value;
    }

    [DataMember(EmitDefaultValue = false)]
    public string User
    {
      get => this.UserField;
      set
      {
        if ((object) this.UserField == (object) value)
          return;
        this.UserField = value;
        this.RaisePropertyChanged(nameof (User));
      }
    }

    [DataMember(EmitDefaultValue = false, Order = 1)]
    public string Password
    {
      get => this.PasswordField;
      set
      {
        if ((object) this.PasswordField == (object) value)
          return;
        this.PasswordField = value;
        this.RaisePropertyChanged(nameof (Password));
      }
    }

    [DataMember(EmitDefaultValue = false, Order = 2)]
    public string TipoIntercambio
    {
      get => this.TipoIntercambioField;
      set
      {
        if ((object) this.TipoIntercambioField == (object) value)
          return;
        this.TipoIntercambioField = value;
        this.RaisePropertyChanged(nameof (TipoIntercambio));
      }
    }

    [DataMember(EmitDefaultValue = false, Order = 3)]
    public string NombreConfiguracion
    {
      get => this.NombreConfiguracionField;
      set
      {
        if ((object) this.NombreConfiguracionField == (object) value)
          return;
        this.NombreConfiguracionField = value;
        this.RaisePropertyChanged(nameof (NombreConfiguracion));
      }
    }

    [DataMember(EmitDefaultValue = false, Order = 4)]
    public string FormatoDocumento
    {
      get => this.FormatoDocumentoField;
      set
      {
        if ((object) this.FormatoDocumentoField == (object) value)
          return;
        this.FormatoDocumentoField = value;
        this.RaisePropertyChanged(nameof (FormatoDocumento));
      }
    }

    [DataMember(EmitDefaultValue = false, Order = 5)]
    public string RespuestaEsperada
    {
      get => this.RespuestaEsperadaField;
      set
      {
        if ((object) this.RespuestaEsperadaField == (object) value)
          return;
        this.RespuestaEsperadaField = value;
        this.RaisePropertyChanged(nameof (RespuestaEsperada));
      }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected void RaisePropertyChanged(string propertyName)
    {
      PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
      if (propertyChanged == null)
        return;
      propertyChanged((object) this, new PropertyChangedEventArgs(propertyName));
    }
  }
}
