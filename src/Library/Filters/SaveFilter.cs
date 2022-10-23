using System;
using System.Drawing;
using CompAndDel;

namespace CompAndDel.Filters
{
    public class SaveFilter : IFilter
    {
        /// <summary>
        /// Un filtro que guarda la imagen que se le pasa.
        /// </summary>
        /// <param name="image">La imagen que va a ser guardada.</param>
        /// <returns>La misma imagen recibida.</returns>          
    
        PictureProvider provider = new PictureProvider();
    
        public IPicture Filter(IPicture image)
        {
            IPicture result = image.Clone();

            provider.SavePicture(result, @"ImageInTheProcess.jpg");

            return result;
        }
    }
}