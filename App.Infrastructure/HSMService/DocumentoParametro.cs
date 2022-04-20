// Decompiled with JetBrains decompiler
// Type: App.Infrastructure.HSMService.DocumentoParametro
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
  [DataContract(Name = "DocumentoParametro", Namespace = "http://www.e-sign.cl/")]
  [Serializable]
  public class DocumentoParametro : IExtensibleDataObject, INotifyPropertyChanged
  {
    [NonSerialized]
    private ExtensionDataObject extensionDataField;
    [OptionalField]
    private string DocumentoField;
    [OptionalField]
    private string NombreDocumentoField;
    [OptionalField]
    private string MetaDataField;

    [Browsable(false)]
    public ExtensionDataObject ExtensionData
    {
      get => this.extensionDataField;
      set => this.extensionDataField = value;
    }

    [DataMember(EmitDefaultValue = false)]
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

    [DataMember(EmitDefaultValue = false)]
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

    [DataMember(EmitDefaultValue = false, Order = 2)]
    public string MetaData
    {
      get => this.MetaDataField;
      set
      {
        if ((object) this.MetaDataField == (object) value)
          return;
        this.MetaDataField = value;
        this.RaisePropertyChanged(nameof (MetaData));
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
