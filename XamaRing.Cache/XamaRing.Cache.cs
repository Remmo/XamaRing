using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using XLabs.Caching;
using XLabs.Ioc;

namespace XamaRing
{
	public static class Cache
	{
        private static ISimpleCache _cacheService;

        public static ISimpleCache CacheService
        {
            get
            {
                if (_cacheService == null)
                    _cacheService = Resolver.Resolve<ISimpleCache>();
                return _cacheService;
            }
            set { _cacheService = value; }
        }
	}
}
