using ICities;
using UnityEngine;
using ColossalFramework.Plugins;
using ColossalFramework;
using System;

namespace EminentDomain
{
    public class EminentDomain : IUserMod
    {

        public string Name
        {
            get { return "Eminent Domain"; }
        }

          
        public string Description
        {
            get { return "Eminent Domain costs for demolition"; }
        }

    }

}
