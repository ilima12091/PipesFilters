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

            IPicture pic = p.GetPicture("gonzalo.jpg");

            FilterGreyscale filterGreyscale = new FilterGreyscale();
            FilterNegative filterNegative = new FilterNegative();
            FilterStoreImage filterStoreGreyScaleImage = new FilterStoreImage("GonzaloGreyScaleImageFilter.jpg");
            FilterPostTwitter filterPostTwitter = new FilterPostTwitter();

            PipeNull pipeNull = new PipeNull();
            PipeSerial pipeSerialPostToTwitter = new PipeSerial(filterPostTwitter, pipeNull);
            PipeSerial pipeSerialNegative = new PipeSerial(filterNegative, pipeSerialPostToTwitter);
            PipeSerial pipeSerialStoreGreyScaleImage = new PipeSerial(filterStoreGreyScaleImage, pipeSerialNegative);
            PipeSerial pipeSerialGreyScale = new PipeSerial(filterGreyscale, pipeSerialStoreGreyScaleImage);

            pic = pipeSerialGreyScale.Send(pic);

            Persist(pic, "gonzaloFiltrado.jpg");
        }

        public static void Persist(IPicture image, string pathToPersist)
        {
            PictureProvider provider = new PictureProvider();
            provider.SavePicture(image,pathToPersist);
        }
    }
}
