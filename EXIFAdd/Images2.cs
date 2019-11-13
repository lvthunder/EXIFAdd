using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.Reflection;
using System.IO;

namespace EXIFAdd
{
    public static class Images2
    {
        /// <summary>  
        /// Some of the EXIF values for setting. To expand use complete list of EXIF values http://www.exiv2.org/tags.html  
        /// </summary>  
        public enum MetaProperty
        {
            Title = 40091,
            Comment = 40092,
            Author = 40093,
            Keywords = 40094,
            Subject = 40095,
            Copyright = 33432,
            Software = 11,
            DateTime = 36867
        }

        /// <summary>  
        /// Sets the meta value of the bitmap. Complete list of EXIF values http://www.exiv2.org/tags.html  
        /// </summary>  
        /// <param name="SourceBitmap">Bitmap to which changes will be applied to</param>  
        /// <param name="property">Property enum value containing the id of the property to be changed</param> /// <param name="value">Value of the proeprty to be set</param>  
        /// <returns>Returns updated bitmap</returns>  
        public static Bitmap SetMetaValue(this Bitmap SourceBitmap, MetaProperty property, string value)
        {
            PropertyItem prop = SourceBitmap.PropertyItems[0];
            int iLen = value.Length + 1;
            byte[] bTxt = new Byte[iLen];
            for (int i = 0; i < iLen - 1; i++)
                bTxt[i] = (byte)value[i];
            bTxt[iLen - 1] = 0x00;
            prop.Id = (int)property;
            prop.Type = 2;
            prop.Value = bTxt;
            prop.Len = iLen;
            return SourceBitmap;
        }
        /// <summary>  
        /// Returns meta value from the bitmap  
        /// </summary>  
        /// <param name="SourceBitmap">Bitmap to which changes will be applied to</param>  
        /// <param name="property">Property enum value containing the id of the property to be changed</param>  
        /// <returns>Returns value of the bitmap meta property</returns>  
      //  public static string GetMetaValue(this Bitmap SourceBitmap, MetaProperty property)
      //  {
      //      PropertyItem[] propItems = SourceBitmap.PropertyItems;
      //      var prop = propItems.FirstOrDefault(p => p.Id == (int)property);
      //      if (prop != null)
      //      {
      //          return Encoding.UTF8.GetString(prop.Value);
      //      }
      //      else
      //      {
      //          return null;
      //      }
      //  }

    }
}
