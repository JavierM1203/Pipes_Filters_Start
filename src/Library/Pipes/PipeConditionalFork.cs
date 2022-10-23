using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CompAndDel;
using CompAndDel.Filters;



namespace CompAndDel.Pipes
{
    public class PipeConditionalFork : IPipe
    {
        IPipe next2Pipe;
        IPipe nextPipe;
        
        FilterConditional filterConditional;

        public bool HasFace { get; private set; }

        /// <summary>
        /// La cañería recibe una imagen, y la envia por una cañeria u otra dependiendo del resultado del filtro condicional.
        /// </summary>
        /// <param name="filterConditional">Tipo de filtro que se debe aplicar sobre la imagen.</param>
        /// <param name="nextPipe">cañeria a la cual se envia la imagen si la condicion es cierta</param>
        /// <param name="next2Pipe">cañeria a la cual se envia la imagen si la condicion es falsa</param>
        public PipeConditionalFork(IPipe nextPipe, IPipe next2Pipe, FilterConditional filterConditional) 
        {
            this.nextPipe = nextPipe;           
            this.next2Pipe = next2Pipe;
            this.filterConditional = filterConditional;
        }
        
        /// <summary>
        /// La cañería recibe una imagen, construye un duplicado de la misma, 
        /// y envía la original por una cañería y el duplicado por otra.
        /// </summary>
        /// <param name="picture">imagen a filtrar y enviar a las siguientes cañerías</param>
        public IPicture Send(IPicture picture)
        {
            picture = this.filterConditional.Filter(picture);

            if (this.filterConditional.HasFace)
            {
                return this.nextPipe.Send(picture);
            } 
            else 
            {
                return this.next2Pipe.Send(picture);
            }            
        }
    }
}