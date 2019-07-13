﻿using System;
using Reloaded.Mod.Interfaces;
using Reloaded.Mod.Interfaces.Internal;
using Reloaded.Mod.Loader.IO.Config;

namespace TestModA
{
    public class Program : IMod
    {
        public static ModConfig ModConfig = new ModConfig()
        {
            ModId = "TestModA",
            ModDll = "TestModA.dll"
        };

        /* Entry point. */
        public Action Disposing { get; }
        public void Start(IModLoaderV1 loader)
        {

        }

        /* Suspend/Unload */
        public void Suspend()
        {
            throw new NotImplementedException();
        }

        public void Resume()
        {
            throw new NotImplementedException();
        }

        public void Unload()
        {
            throw new NotImplementedException();
        }

        public bool CanUnload() => false;
        public bool CanSuspend() => false;
    }
}
