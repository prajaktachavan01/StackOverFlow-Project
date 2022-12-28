﻿using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace StackOverFlowProject
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Scripts/bootstrap").Include("~/Scripts/ jquery - 3.6.1.js", "~/Scripts/umd/popper.js", "~/Scripts/bootstrap.js"));
            bundles.Add(new StyleBundle("~/Styles/bootstrap").Include("~/Content/bootstrap.css"));
            bundles.Add(new StyleBundle("~/Styles/site").Include("~/Content/Style.css"));
            BundleTable.EnableOptimizations = true;
        }
    }
}