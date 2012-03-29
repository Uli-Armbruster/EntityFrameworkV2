using System;

namespace UAR.UI.Contracts
{
    public interface IViewModelFactory
    {
        T CreateScoped<T>() where T : class, IDisposable;
        T CreateScoped<T>(object args) where T : class, IDisposable;

        T Create<T>() where T : class;
        T Create<T>(object args) where T : class;
    }
}