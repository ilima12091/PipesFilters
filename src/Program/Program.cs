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
<<<<<<< HEAD
            IPicture pic = p.GetPicture("gonzalo.jpg");
=======
            IPicture pic = p.GetPicture("PathToImage.jpg");
>>>>>>> 6daa00f... Agrego el ejercicio 1
=======
            IPicture pic = p.GetPicture("gonzalo.jpg");
>>>>>>> c000639... Agrego los cambios para el ejericicio 2

            FilterGreyscale filterGreyscale = new FilterGreyscale();
            FilterNegative filterNegative = new FilterNegative();
            FilterStoreImage filterStoreGreyScaleImage = new FilterStoreImage("GonzaloGreyScaleImageFilter.jpg");

            PipeNull pipeNull = new PipeNull();
            PipeSerial pipeSerialNegative = new PipeSerial(filterNegative, pipeNull);
            PipeSerial pipeSerialStoreGreyScaleImage = new PipeSerial(filterStoreGreyScaleImage, pipeSerialNegative);
            PipeSerial pipeSerialGreyScale = new PipeSerial(filterGreyscale, pipeSerialStoreGreyScaleImage);

<<<<<<< HEAD
<<<<<<< HEAD
            pic = pipeSerialGreyScale.Send(pic);
            Persist(pic, "gonzaloFiltrado.jpg");
=======
            pic = pipeNull.Send(pipeSerialNegative.Send(pipeSerialGreyScale.Send(pic)));
            Persist(pic, "PathToFilteredImage.jpg");
>>>>>>> 6daa00f... Agrego el ejercicio 1
=======
            pic = pipeSerialGreyScale.Send(pic);

            Persist(pic, "gonzaloFiltrado.jpg");
>>>>>>> c000639... Agrego los cambios para el ejericicio 2
        }

        public static void Persist(IPicture image, string pathToPersist)
        {
            PictureProvider provider = new PictureProvider();
            provider.SavePicture(image,pathToPersist);
        }
    }
}
