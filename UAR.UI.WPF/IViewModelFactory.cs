using System;

namespace UAR.UI.WPF
{
    public interface IViewModelFactory
    {
        T Create<T>() where T : class, IDisposable;
    }
}