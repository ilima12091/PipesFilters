using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using CompAndDel;
using System.Diagnostics;
using CognitiveCoreUCU;

namespace CompAndDel.Filters
{   
    public class FilterConditional : IFilter
    {
        public bool HasFace { get; private set; }

        public IPicture Filter(IPicture image)
        {
            this.Persist(image, "ImageToSearchFace.jpg");
            CognitiveFace cog = new CognitiveFace("620e818a46524ceb92628cde08068242", false);
            cog.Recognize("ImageToSearchFace.jpg");
            this.HasFace = cog.FaceFound;
            return image;
        }
        private void Persist(IPicture image, string pathToPersist)
        {
            PictureProvider provider = new PictureProvider();
            provider.SavePicture(image,pathToPersist);
        }
    }
    
}