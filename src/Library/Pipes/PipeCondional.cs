using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CompAndDel;
using CompAndDel.Filters;

namespace CompAndDel.Pipes
{
    public class PipeConditional : IPipe
    {
        public IPipe Next { get; }
        public IFilter FilterIfTrue { get; }
        public IFilter FilterIfFalse { get; }

        public PipeConditional(IFilter filterIfTrue, IFilter filterIfFalse, IPipe nextPipe) 
        {
            this.FilterIfTrue = filterIfTrue;
            this.FilterIfFalse = filterIfFalse;
            this.Next = nextPipe;
        }
        public IPicture Send(IPicture picture)
        {
            FilterConditional filterConditional = new FilterConditional();
            filterConditional.Filter(picture);
            if(filterConditional.HasFace)
            {
                picture = this.FilterIfTrue.Filter(picture);
            } 
            else
            {
                picture = this.FilterIfFalse.Filter(picture);
            }
            return this.Next.Send(picture);
        }
    }
}