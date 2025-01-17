﻿using Autofac;
using SDK.DependencyInjection.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SDK.DependencyInjection.AutoFac
{
    public class AutofacContainerBuilder : ISdkContainerBuilder
    {
        ContainerBuilder _builder;

        public AutofacContainerBuilder(ContainerBuilder builder)
        {
            _builder = builder;
        }

        public void RegisterSingleton<T, Y>() where Y : T
        {
            _builder.RegisterType<Y>().As<T>().SingleInstance();
        }

        public void RegisterSingleton<T>(Func<ISdkContainer, T> func)
        {
            _builder.Register(c => func(SdkDI.Resolver)).As<T>().SingleInstance();
        }

        public void RegisterScoped<T, Y>() where Y : T
        {
            _builder.RegisterType<Y>().As<T>().InstancePerLifetimeScope();
        }

        public void RegisterSingleton<T, Y>(string name) where Y : T
        {
            _builder.RegisterType<Y>().Named<T>(name).SingleInstance();
        }

        public void RegisterScoped<T, Y>(string name) where Y : T
        {
            _builder.RegisterType<Y>().Named<T>(name).InstancePerLifetimeScope();
        }

        public void RegisterTransient<T, Y>(string name) where Y : T
        {
            _builder.RegisterType<Y>().Named<T>(name).InstancePerDependency();
        }

        public void RegisterScoped<T>(Func<ISdkContainer, T> func)
        {
            _builder.Register(c => func(SdkDI.Resolver)).As<T>().InstancePerLifetimeScope();
        }

        public void RegisterTransient<T, Y>() where Y : T
        {
            _builder.RegisterType<Y>().As<T>().InstancePerDependency();
        }

        public void RegisterTransient<T>(Func<ISdkContainer, T> func)
        {
            _builder.Register(c => func(SdkDI.Resolver)).As<T>().InstancePerDependency();
        }

        public void RegisterInstance<T>(T instance) where T : class
        {
            _builder.RegisterInstance(instance).As<T>();
        }

        public void RegisterInstance<T>(string name, T instance) where T : class
        {
            _builder.RegisterInstance<T>(instance).Named<T>(name);
        }
    }
}