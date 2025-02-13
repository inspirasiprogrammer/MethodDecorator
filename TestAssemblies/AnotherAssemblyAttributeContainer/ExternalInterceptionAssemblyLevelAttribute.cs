﻿using System;
using System.Collections.Generic;
using System.Reflection;

[AttributeUsage(AttributeTargets.Method | AttributeTargets.Constructor | AttributeTargets.Assembly)]
public class ExternalInterceptionAssemblyLevelAttribute : Attribute
{
    public static int InitCount;
    public static object InitInstance;

    public static MethodBase InitMethod;
    public void Init(object instance, MethodBase method, object[] args)
    {
        InitCount++;
        InitMethod = method;
        InitInstance = instance;
    }

    public static uint OnEntryCount;
    public void OnEntry()
    {
        OnEntryCount++;
    }

    public static uint OnExitCount;
    public void OnExit()
    {
        OnExitCount++;
    }

    public static List<Exception> Exceptions = new();
    public void OnException(Exception exception)
    {
        Exceptions.Add(exception);
    }
}