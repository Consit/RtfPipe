using RtfPipe.Model;
using RtfPipe.Tokens;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;

namespace RtfPipe
{
  public class RtfHtmlSettings : HtmlWriterSettings
  {
    public Action<int, XmlWriter> AttachmentRenderer { get; set; }
    public Dictionary<ElementType, HtmlTag> ElementTags { get; } = new Dictionary<ElementType, HtmlTag>()
    {
      { ElementType.Cell, HtmlTag.Td },
      { ElementType.Document, HtmlTag.Div },
      { ElementType.List, HtmlTag.Ul },
      { ElementType.ListItem, HtmlTag.Li },
      { ElementType.OrderedList, HtmlTag.Ol },
      { ElementType.Paragraph, HtmlTag.P },
      { ElementType.Row, HtmlTag.Tr },
      { ElementType.Section, HtmlTag.Div },
      { ElementType.Table, HtmlTag.Table },
    };
    public Func<Picture, string> ImageUriGetter { get; set; }

    public RtfHtmlSettings()
    {
      AttachmentRenderer = RenderAttachment;
      ImageUriGetter = DataUri;
    }

    private static string DataUri(Picture picture)
    {
#if NETFULL
      if (picture.Type is EmfBlip || picture.Type is WmMetafile)
      {
        using (var source = new MemoryStream(picture.Bytes))
        using (var dest = new MemoryStream())
        {
          var bmp = new System.Drawing.Bitmap(source);
          bmp.Save(dest, System.Drawing.Imaging.ImageFormat.Png);
          return "data:image/png;base64," + Convert.ToBase64String(dest.ToArray());
        }
      }
#endif
      return "data:" + picture.MimeType() + ";base64," + Convert.ToBase64String(picture.Bytes);
    }

    private static void RenderAttachment(int index, XmlWriter writer)
    {
      writer.WriteStartElement("span");
      writer.WriteAttributeString("data-index", index.ToString());
      writer.WriteEndElement();
    }
  }
}
