using System;
using CompAndDel.Pipes;
using CompAndDel.Filters;

namespace CompAndDel
{
    class Program
    {
        static void Main(string[] args)
        {
            PictureProvider provider = new PictureProvider();
            IPicture picture = provider.GetPicture(@"beer.jpg");

            FilterNegative filterNegative = new FilterNegative();
            FilterGreyscale filterGreyscale = new FilterGreyscale();
            SaveFilter saveFilter = new SaveFilter();
            TwitterFilter twitterFilter = new TwitterFilter();
            FilterConditional filterConditional = new FilterConditional();

            PipeNull pipeNull = new PipeNull();

            PipeSerial pipeNegative = new PipeSerial(filterNegative, pipeNull);
            PipeSerial pipeTwitter = new PipeSerial(twitterFilter, pipeNull);

            PipeConditionalFork pipeConditionalFork = new PipeConditionalFork(pipeTwitter, pipeNegative, filterConditional);
            PipeSerial pipeSave = new PipeSerial(saveFilter, pipeConditionalFork);
            PipeSerial pipeGrey = new PipeSerial(filterGreyscale, pipeSave);


            IPicture finalImage = pipeGrey.Send(picture);
            provider.SavePicture(finalImage, @"FinalImage.jpg");
        }
    }
}
