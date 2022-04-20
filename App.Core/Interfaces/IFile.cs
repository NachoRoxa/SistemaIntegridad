// Decompiled with JetBrains decompiler
// Type: App.Core.Interfaces.IFile
// Assembly: App.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1BF6F6E1-2696-4F22-9AA9-802440B37AD4
// Assembly location: C:\Users\IROCHA\source\repos\Integridad\sintegridadweb\bin\App.Core.dll

using App.Core.Entities.DTO;

namespace App.Core.Interfaces
{
  public interface IFile
  {
    FileMetadata BynaryToText(byte[] content);

    byte[] CreateQR(string id);

    byte[] CreateBarCode(string code);
  }
}
