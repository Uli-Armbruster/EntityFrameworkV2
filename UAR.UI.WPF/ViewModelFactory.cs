using System;

using Castle.MicroKernel.Lifestyle;
using Castle.Windsor;

namespace UAR.UI.WPF
{
    public class ViewModelFactory : IViewModelFactory
    {
        readonly IWindsorContainer _container;

        public ViewModelFactory(IWindsorContainer container)
        {
            _container = container;
        }

        public T Create<T>() where T : class, IDisposable
        {
            var scope = _container.BeginScope();
            return _container.Resolve<T>(new { scope});
        }
    }
}