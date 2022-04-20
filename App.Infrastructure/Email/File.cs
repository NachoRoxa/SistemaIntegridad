// Decompiled with JetBrains decompiler
// Type: App.Infrastructure.Email.File
// Assembly: App.Infrastructure, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7D12F3AE-788C-4496-85EF-A6E23743B789
// Assembly location: C:\Users\IROCHA\source\repos\Integridad\sintegridadweb\bin\App.Infrastructure.dll

using App.Core.Entities.DTO;
using App.Core.Interfaces;
using QRCoder;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using TikaOnDotNet.TextExtraction;
using Zen.Barcode;

namespace App.Infrastructure.Email
{
  public class File : IFile
  {
    public FileMetadata BynaryToText(byte[] content)
    {
      FileMetadata text = new FileMetadata();
      TextExtractionResult extractionResult = new TextExtractor().Extract(content);
      text.Text = !string.IsNullOrWhiteSpace(extractionResult.Text) ? extractionResult.Text.Trim() : (string) null;
      text.Metadata = extractionResult.Metadata.Any<KeyValuePair<string, string>>() ? string.Join<KeyValuePair<string, string>>(";", (IEnumerable<KeyValuePair<string, string>>) extractionResult.Metadata) : (string) null;
      text.Type = extractionResult.ContentType;
      return text;
    }

    public byte[] CreateQR(string id) => File.ImageToByte((Image) new QRCode(new QRCodeGenerator().CreateQrCode(id, QRCodeGenerator.ECCLevel.Q)).GetGraphic(20));

    public static byte[] ImageToByte(Image img)
    {
      using (MemoryStream memoryStream = new MemoryStream())
      {
        img.Save((Stream) memoryStream, ImageFormat.Png);
        return memoryStream.ToArray();
      }
    }

    public byte[] CreateBarCode(string code)
    {
      using (MemoryStream memoryStream = new MemoryStream())
      {
        BarcodeDrawFactory.Code39WithoutChecksum.Draw(code, 80).Save((Stream) memoryStream, ImageFormat.Jpeg);
        return memoryStream.ToArray();
      }
    }
  }
}
