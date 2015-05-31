using System;
using System.IO;
using System.Drawing;

namespace PRO6 {

    namespace System {

        public static class pro6Utilites {

            public static Image ImageCreateFromBase64(string base64String){
                byte[] image_content = Convert.FromBase64String(base64String);
                MemoryStream stream = new MemoryStream(image_content);
                return Image.FromStream(stream);
            }

        }
    }

}
