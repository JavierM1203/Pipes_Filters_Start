using System;
using System.Drawing;
using CompAndDel;
using TwitterUCU;

namespace CompAndDel.Filters
{
    public class TwitterFilter : IFilter
    {
        /// <summary>
        /// Un filtro que publica en twiter la imagen que se le pasa.
        /// </summary>
        /// <param name="image">La imagen que va a ser publicada.</param>
        /// <returns>La misma imagen recibida.</returns>          
        TwitterImage twitter = new TwitterImage();
    
        public IPicture Filter(IPicture image)
        {
            IPicture result = image.Clone();

            Console.WriteLine(twitter.PublishToTwitter("Imagen transformada", @"ImageInTheProcess.jpg"));

            return result;
        }
    }
}