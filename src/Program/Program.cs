using System;
using CompAndDel.Pipes;
using CompAndDel.Filters;

namespace CompAndDel
{
    class Program
    {
        static void Main(string[] args)
        {
            PictureProvider p = new PictureProvider();

            IPicture pic = p.GetPicture("matrix.png");

            FilterGreyscale filterGreyscale = new FilterGreyscale();
            FilterNegative filterNegative = new FilterNegative();
            FilterPostTwitter filterPostTwitter = new FilterPostTwitter();

            PipeNull pipeNull = new PipeNull();
            PipeConditional pipeSerialConditional = new PipeConditional(filterPostTwitter, filterNegative, pipeNull);

            pic = pipeSerialConditional.Send(pic);

            Persist(pic, "imagenFiltrada.jpg");
            
        }

        public static void Persist(IPicture image, string pathToPersist)
        {
            PictureProvider provider = new PictureProvider();
            provider.SavePicture(image,pathToPersist);
        }
    }
}
