using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.Reflection;
using System.IO;

namespace EXIFAdd
{
    class Images
    {
        public class clsReadMetaData
        {

            public ImageMetadata ReadEXIFMetadata(string filepath)
            {
                FileStream fs = new FileStream(filepath, FileMode.Open, FileAccess.Read);
                Image image__1 = Image.FromStream(fs);
                PropertyItem[] imagePropertyItems = image__1.PropertyItems;
                ImageMetadata imageMetadata = new ImageMetadata();
                foreach (PropertyItem pi in imagePropertyItems)
                {
                    switch ((EXIFProperty)pi.Id)
                    {
                        case EXIFProperty.Title:
                            imageMetadata.Title = Encoding.Unicode.GetString(pi.Value);
                            //imageMetadata.Title = Encoding.UTF32.GetString(pi.Value)
                            break;
                        case EXIFProperty.Author:
                            imageMetadata.Author = Encoding.Unicode.GetString(pi.Value);
                            //imageMetadata.Author = Encoding.UTF8.GetString(pi.Value)
                            break;
                        case EXIFProperty.Keywords:
                            imageMetadata.Keywords = Encoding.Unicode.GetString(pi.Value);
                            //imageMetadata.Keywords = Encoding.UTF8.GetString(pi.Value)
                            break;
                        case EXIFProperty.Comments:
                            imageMetadata.Comments = Encoding.Unicode.GetString(pi.Value);
                            //imageMetadata.Comments = Encoding.UTF8.GetString(pi.Value)
                            break;
                        default:
                            break;
                    }
                }
                fs.Close();
                return imageMetadata;
            }
            public void SaveEXIFMetadata(Image image, ImageMetadata metadata, string filepath)
            {
                SaveEXIFMetadataProperty(image, EXIFProperty.Title, metadata.Title, filepath);
                SaveEXIFMetadataProperty(image, EXIFProperty.Author, metadata.Author, filepath);
                SaveEXIFMetadataProperty(image, EXIFProperty.Keywords, metadata.Keywords, filepath);
                SaveEXIFMetadataProperty(image, EXIFProperty.Comments, metadata.Comments, filepath);
            }
            private void SaveEXIFMetadataProperty(Image image, EXIFProperty property, string propertyValue, string filepath)
            {
                PropertyItem propertyItem = CreatePropertyItem();
                propertyItem.Id = Convert.ToInt32(property);
                // Type=1 means Array of Bytes.
                propertyItem.Type = 2;
                propertyItem.Len = propertyValue.Length;
                //propertyItem.Value = Encoding.Unicode.GetBytes(propertyValue)
                propertyItem.Value = Encoding.UTF8.GetBytes(propertyValue);
                image.SetPropertyItem(propertyItem);
                image.Save(filepath);
            }
            private PropertyItem CreatePropertyItem()
            {
                System.Reflection.ConstructorInfo ci = typeof(PropertyItem).GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public, null, new Type[0], null);
                return (PropertyItem)ci.Invoke(null);
            }
        }
        public enum EXIFProperty
        {
            Title = 40091,
            Author = 40093,
            Keywords = 40094,
            Comments = 40092
        }
        public class ImageMetadata
        {
            private string _title = string.Empty;
            private string _author = string.Empty;
            private string _keywords = string.Empty;
            private string _comments = string.Empty;
            public ImageMetadata()
            {
                this._title = string.Empty;
                this._author = string.Empty;
                this._keywords = string.Empty;
                this._comments = string.Empty;
            }
            public ImageMetadata(string title, string author, string keywords, string comments)
            {
                this._title = title;
                this._author = author;
                this._keywords = keywords;
                this._comments = comments;
            }
            public string Title
            {
                get
                {
                    return this._title;
                }
                set
                {
                    this._title = value;
                }
            }
            public string Author
            {
                get
                {
                    return this._author;
                }
                set
                {
                    this._author = value;
                }
            }
            public string Keywords
            {
                get
                {
                    return this._keywords;
                }
                set
                {
                    this._keywords = value;
                }
            }
            public string Comments
            {
                get
                {
                    return this._comments;
                }
                set
                {
                    this._comments = value;
                }
            }
        }
    }
}
