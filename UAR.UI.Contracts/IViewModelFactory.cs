using System;

namespace UAR.UI.Contracts
{
    public interface IViewModelFactory
    {
        T Create<T>() where T : class, IDisposable;
    }
}