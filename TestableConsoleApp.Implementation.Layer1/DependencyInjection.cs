using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestableConsoleApp.Implementation.Layer1
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddLayer1(this IServiceCollection services) {

            return services;
        }
    }
}
