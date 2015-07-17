using System;
using System.IO;
using System.Net;
using System.Text;

namespace BookRepo.Helpers
{
    public class ImageConverter
    {
        public String ConvertImageUrlToBase64(String url)
        {
            StringBuilder sb = new StringBuilder();

            Byte[] _byte = GetImage(url);

            sb.Append(Convert.ToBase64String(_byte, 0, _byte.Length));

            return sb.ToString();
        }

        private static byte[] GetImage(string url)
        {
            byte[] buf;

            try
            {
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);

                HttpWebResponse response = (HttpWebResponse)req.GetResponse();
                Stream stream = response.GetResponseStream();

                using (BinaryReader br = new BinaryReader(stream))
                {
                    int len = (int)(response.ContentLength);
                    buf = br.ReadBytes(len);
                    br.Close();
                }

                if (stream != null) stream.Close();
                response.Close();
            }
            catch (Exception)
            {
                buf = null;
            }

            return (buf);
        }
    }
}