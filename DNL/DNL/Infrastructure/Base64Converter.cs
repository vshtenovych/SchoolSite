using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DNL.Infrastructure
{
    public static class Base64Converter
    {
        public static async Task<string> ImgToBase64String(IFormFile image)
        {
            if (image == null)
                return "";
            using (var memoryStream = new MemoryStream())
            {
                await image.CopyToAsync(memoryStream);
                return Convert.ToBase64String(memoryStream.ToArray());
            }
        }
    }
}
