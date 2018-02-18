using System;
using UI.Framework.PageObjects;

namespace UI.Framework.Base
{
    public class Browser
    {
        public object Driver { get; private set; }

        public T GetPage<T>() where T : BasePage
        {
            return (T)Activator.CreateInstance(typeof(T), Driver);
        }
    }
}
