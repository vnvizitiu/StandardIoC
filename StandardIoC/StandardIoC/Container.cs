namespace StandardIoC
{
    using System;
    
    public class Container
    {
        public T Resolve<T>()
        {
            return Activator.CreateInstance<T>();
        }
    }
}