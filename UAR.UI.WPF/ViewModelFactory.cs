using System;
using System.Collections;
using System.Collections.Generic;

using Castle.Core;
using Castle.MicroKernel.Lifestyle;
using Castle.Windsor;

using UAR.UI.Contracts;

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
            return Create<T>(new object());
        }

        public T Create<T>(object args) where T : class, IDisposable
        {
            var scope = _container.BeginScope();
            var arg = PatchArgumentsWithScope<T>(args, scope);
            return _container.Resolve<T>(arg);
        }

        static Dictionary<string, object> PatchArgumentsWithScope<T>(object args, IDisposable scope) where T : class, IDisposable
        {
            var dict = (IDictionary) new ReflectionBasedDictionaryAdapter(args);
            
            var arg = new Dictionary<string, object> {{"scope", scope}};
            foreach (var key in dict.Keys)
            {
                arg.Add((string) key, dict[key]);
            }
            return arg;
        }
    }
}