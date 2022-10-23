using System;
using System.Drawing;
using CompAndDel;
using CognitiveCoreUCU;

namespace CompAndDel.Filters
{
    public class FilterConditional : IFilter
    {
        /// <summary>
        /// Un filtro que guarda la imagen que se le pasa.
        /// </summary>
        /// <param name="image">La imagen que va a ser guardada.</param>
        /// <returns>La misma imagen recibida.</returns>  

        public bool HasFace { get; private set; }
    
        CognitiveFace cognitiveFace = new CognitiveFace();
    
        public IPicture Filter(IPicture image)
        {
            IPicture result = image.Clone();

            cognitiveFace.Recognize(@"ImageInTheProcess.jpg");
            this.HasFace = cognitiveFace.FaceFound;

            return result;
        }
    }
}