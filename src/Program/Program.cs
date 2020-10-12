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
<<<<<<< HEAD
            IPicture pic = p.GetPicture("gonzalo.jpg");
=======
            IPicture pic = p.GetPicture("PathToImage.jpg");
>>>>>>> 6daa00f... Agrego el ejercicio 1

            FilterGreyscale filterGreyscale = new FilterGreyscale();
            FilterNegative filterNegative = new FilterNegative();

            PipeNull pipeNull = new PipeNull();
            PipeSerial pipeSerialNegative = new PipeSerial(filterNegative, pipeNull);
            PipeSerial pipeSerialGreyScale = new PipeSerial(filterGreyscale, pipeSerialNegative);

<<<<<<< HEAD
            pic = pipeSerialGreyScale.Send(pic);
            Persist(pic, "gonzaloFiltrado.jpg");
=======
            pic = pipeNull.Send(pipeSerialNegative.Send(pipeSerialGreyScale.Send(pic)));
            Persist(pic, "PathToFilteredImage.jpg");
>>>>>>> 6daa00f... Agrego el ejercicio 1
        }

        public static void Persist(IPicture image, string pathToPersist)
        {
            PictureProvider provider = new PictureProvider();
            provider.SavePicture(image,pathToPersist);
        }
    }
}
