using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LBCFUBL.Services
{
    public class ServiceSingleton<T> where T : class, new()
    {
        ServiceSingleton() { }

        class SingletonFactory
        {
            static SingletonFactory() { }
            internal static T instance = new T();
        }

        public static T Instance
        {
            get { return SingletonFactory.instance; }
        }
    }
}