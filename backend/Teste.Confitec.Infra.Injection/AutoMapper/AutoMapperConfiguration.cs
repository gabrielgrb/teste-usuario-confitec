using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Teste.Confitec.Infra.Injection.AutoMapper
{
    public static class AutoMapperConfiguration
    {
        private static object _thisLock = new object();
        private static bool _initialized = false;

        public static IEnumerable<Type> GetAutoMapperProfiles()
        {
            var result = new List<Type>
            {
                typeof(MappingProfile),
            };
            return result;
        }

        public static void Initialize()
        {
            lock (_thisLock)
            {
                if (!_initialized)
                {
                    Mapper.Initialize((cfg) =>
                    {
                        cfg.AddProfiles(GetAutoMapperProfiles());
                    });

                    _initialized = true;
                }
            }
        }
    }
}
