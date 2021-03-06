﻿using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using Autofac.Integration.WebApi;
using SocialSlider.Core.Interfaces;
using SocialSlider.Core.Servants;

namespace SocialSlider.Api.App_Start
{
    public class AutofacConfig
    {
        private const string AutofacConfigSection = "autofac";

        public static void RegisterDependencies()
        {
            var builder = new ContainerBuilder();
            
            Assembly executingAssembly = Assembly.GetExecutingAssembly();            
            builder.RegisterApiControllers(executingAssembly);
            builder.RegisterType<ImageServant>().As<IImageServant>().InstancePerRequest();


            var container = builder.Build();
            
            System.Web.Http.GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}