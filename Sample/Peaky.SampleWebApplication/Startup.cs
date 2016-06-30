﻿using System;
using System.Web.Http;
using Microsoft.Owin;
using Owin;
using Peaky.SampleWebApplication;

[assembly: OwinStartup(typeof (Startup))]

namespace Peaky.SampleWebApplication
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();
            config.MapTestRoutes(testUiScriptUrl: "http://localhost:8080/app/peaky.js",
                testUiLibraryUrls: new[]
                                   {
                                       "http://localhost:8080/app/vendors.js"
                                   },
                configureTargets: RegisterTargets,
                styleSheetUrls: new[]
                                {
                                    "http://localhost:8080/content/peaky.css",
                                    "http://localhost:8080/content/css/font-awesome.min.css",
                                    "http://localhost:8080/content/Highlight/atelier-lakeside.dark.css"
                                });

            config.EnsureInitialized();
            app.UseWebApi(config);
        }

        private void RegisterTargets(TestTargetRegistry targets)
        {
            targets.Add("prod", "bing", new Uri("https://bing.com"))
                   .Add("prod", "microsoft", new Uri("https://microsoft.com"));
        }
    }
}