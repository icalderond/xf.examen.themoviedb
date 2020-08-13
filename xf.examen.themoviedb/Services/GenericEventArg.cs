using System;
namespace xf.examen.themoviedb.Services
{
    public class GenericEventArg<T> : EventArgs
    {
        public T Results { get; private set; }
        public GenericEventArg(T results)
        {
            Results = results;
        }
    }
}
