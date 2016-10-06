﻿using System;
using System.Threading;

using Orleans;
using Orleans.Providers.MongoDB.Test.GrainInterfaces;
using Orleans.Runtime.Configuration;

internal class Program
{
    private static void Main(string[] args)
    {
        // initialize the grain client, with some retry logic
        var initialized = false;
        while (!initialized)
        {
            try
            {
                // Todo: This configuration should not be called from the config file
                GrainClient.Initialize(ClientConfiguration.LoadFromFile(@".\ClientConfiguration.xml"));
                initialized = GrainClient.IsInitialized;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Thread.Sleep(TimeSpan.FromSeconds(1));
            }
        }

        // get a reference to the grain from the grain factory
        var helloWorldGrain = GrainClient.GrainFactory.GetGrain<IHelloWorldGrain>(1);

        // call the grain
        var response = helloWorldGrain.SayHello("World").Result;

        var reminderGrain = GrainClient.GrainFactory.GetGrain<INewsReminderGrain>(1);

        reminderGrain.StartReminder("TestReminder", TimeSpan.FromMinutes(10));
        reminderGrain.RemoveReminder("TestReminder");

        Console.WriteLine(response);
        Console.ReadKey();
    }
}