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





    



    //public class Loader : LoadingExtensionBase
    //{
    //    public override void OnLevelLoaded(LoadMode mode)
    //    {
    //        GameObject go = new GameObject("Test Object");
    //        go.AddComponent<MyBehavior>();
    //    }

    //}

    //public class MyBehavior : MonoBehaviour

    //{
    //    void Start()
    //    {
    //        DebugOutputPanel.AddMessage(PluginManager.MessageType.Message, "It works");
    //    }

    //    void Update()
    //    {

    //    }
    //}


}
