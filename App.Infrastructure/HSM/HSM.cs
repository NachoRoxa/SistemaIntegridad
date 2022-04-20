// Decompiled with JetBrains decompiler
// Type: App.Infrastructure.HSM.HSM
// Assembly: App.Infrastructure, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7D12F3AE-788C-4496-85EF-A6E23743B789
// Assembly location: C:\Users\IROCHA\source\repos\Integridad\sintegridadweb\bin\App.Infrastructure.dll

using App.Core.Interfaces;
using App.Infrastructure.FirmaElock;

namespace App.Infrastructure.HSM
{
  public class HSM : IHSM
  {
    public byte[] Sign(byte[] documento)
    {
      try
      {
        SignFileImplClient signFileImplClient = new SignFileImplClient();
        signFileResponse signFileResponse = new signFileResponse();
        signBase64EncodedResponse base64EncodedResponse = new signBase64EncodedResponse();
        byte[] inputfile = documento;
        return signFileImplClient.SignFile(inputfile, "Macarena Andrea Sánchez Fierro", "BOTTOM_EDGE_CENTER", "0", "Documento firmado electronicamente", "UNIDAD GESTION Y DESARROLLO DE PERSONAS", 10, 10, 100, 100).message;
      }
      catch (System.Exception ex)
      {
        throw new System.Exception("Error al firmar documento.");
      }
    }
  }
}
