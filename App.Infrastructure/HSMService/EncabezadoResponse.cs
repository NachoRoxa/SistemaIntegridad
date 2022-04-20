// Decompiled with JetBrains decompiler
// Type: App.Infrastructure.HSMService.EncabezadoResponse
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
  [DataContract(Name = "EncabezadoResponse", Namespace = "http://www.e-sign.cl/")]
  [Serializable]
  public class EncabezadoResponse : IExtensibleDataObject, INotifyPropertyChanged
  {
    [NonSerialized]
    private ExtensionDataObject extensionDataField;
    [OptionalField]
    private string EstadoField;
    [OptionalField]
    private string ComentariosField;
    [OptionalField]
    private string FormatoDocumentoField;
    [OptionalField]
    private string NombreDocumentoField;
    [OptionalField]
    private string DocumentoField;

    [Browsable(false)]
    public ExtensionDataObject ExtensionData
    {
      get => this.extensionDataField;
      set => this.extensionDataField = value;
    }

    [DataMember(EmitDefaultValue = false)]
    public string Estado
    {
      get => this.EstadoField;
      set
      {
        if ((object) this.EstadoField == (object) value)
          return;
        this.EstadoField = value;
        this.RaisePropertyChanged(nameof (Estado));
      }
    }

    [DataMember(EmitDefaultValue = false, Order = 1)]
    public string Comentarios
    {
      get => this.ComentariosField;
      set
      {
        if ((object) this.ComentariosField == (object) value)
          return;
        this.ComentariosField = value;
        this.RaisePropertyChanged(nameof (Comentarios));
      }
    }

    [DataMember(EmitDefaultValue = false, Order = 2)]
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

    [DataMember(EmitDefaultValue = false, Order = 3)]
    public string NombreDocumento
    {
      get => this.NombreDocumentoField;
      set
      {
        if ((object) this.NombreDocumentoField == (object) value)
          return;
        this.NombreDocumentoField = value;
        this.RaisePropertyChanged(nameof (NombreDocumento));
      }
    }

    [DataMember(EmitDefaultValue = false, Order = 4)]
    public string Documento
    {
      get => this.DocumentoField;
      set
      {
        if ((object) this.DocumentoField == (object) value)
          return;
        this.DocumentoField = value;
        this.RaisePropertyChanged(nameof (Documento));
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
