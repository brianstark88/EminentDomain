using ICities;
using UnityEngine;
using ColossalFramework.Plugins;
using ColossalFramework;
using System;


namespace EminentDomain.Source
{
    public class ChargeEminentDomain : BuildingExtensionBase
    {

  

        public override void OnBuildingReleased(ushort buildingId)
        {
            BuildingManager buildingManager = Singleton<BuildingManager>.instance;
            Building building = buildingManager.m_buildings.m_buffer[buildingId];
            BuildingInfo buildingInfo = building.Info;
            ItemClass.Service buildingService = buildingInfo.GetService();

            int eminentDomain = CalculateEminentDomain(buildingId);

            if (eminentDomain != 0)
                Singleton<EconomyManager>.instance.AddResource(EconomyManager.Resource.RefundAmount, eminentDomain, buildingInfo.m_class);

        }

        public static int CalculateEminentDomain(ushort buildingId)
        {

            
            Building building = GetBuilding(buildingId);
            BuildingInfo buildingInfo = building.Info;
            ItemClass.Service buildingService = buildingInfo.GetService();
            ItemClass.SubService subService = buildingInfo.GetSubService();
            int eminentDomain = 0;

            // District land value * 64 m^2 * length * width
            int landValue = GetLandValue(buildingId);



            //DebugOutputPanel.AddMessage(PluginManager.MessageType.Message, "AutoRemove :" + buildingInfo.m_autoRemove);

            if (buildingService == ItemClass.Service.Residential || buildingService == ItemClass.Service.Commercial || buildingService == ItemClass.Service.Industrial)// && building.CheckZoning(ItemClass.Zone.ResidentialLow, ItemClass.Zone.ResidentialHigh, false) == false)
            {
                if (subService == ItemClass.SubService.ResidentialLow ||
                    subService == ItemClass.SubService.ResidentialLowEco ||
                    subService == ItemClass.SubService.CommercialLow ||
                    subService == ItemClass.SubService.CommercialEco ||
                    subService == ItemClass.SubService.IndustrialFarming ||
                    subService == ItemClass.SubService.IndustrialForestry ||
                    subService == ItemClass.SubService.IndustrialGeneric ||
                    subService == ItemClass.SubService.IndustrialOil ||
                    subService == ItemClass.SubService.IndustrialOre)
                {
                    eminentDomain = -1 * landValue;
                }
                else if (subService == ItemClass.SubService.CommercialHigh ||
                        subService == ItemClass.SubService.CommercialLeisure ||
                        subService == ItemClass.SubService.CommercialTourist ||
                        subService == ItemClass.SubService.ResidentialHigh ||
                        subService == ItemClass.SubService.ResidentialHighEco ||
                        subService == ItemClass.SubService.OfficeGeneric ||
                        subService == ItemClass.SubService.OfficeHightech)
                {
                    eminentDomain = -2 * landValue;
                }

                if(eminentDomain != 0)
                    Singleton<EconomyManager>.instance.AddResource(EconomyManager.Resource.RefundAmount, eminentDomain, buildingInfo.m_class);

                



            }


            return eminentDomain;
        }


        public static int GetLandValue(ushort buildingId)
        {
            var building = GetBuilding(buildingId);
            var buildingInfo = building.Info;
            DistrictManager districtManager = Singleton<DistrictManager>.instance;
            District district = districtManager.m_districts.m_buffer[districtManager.GetDistrict(building.m_position)];
            

            return district.GetLandValue() * 64 * buildingInfo.m_cellLength * buildingInfo.m_cellWidth;
        }

        public static Building GetBuilding(ushort buildingId)
        {
            BuildingManager buildingManager = Singleton<BuildingManager>.instance;
            return buildingManager.m_buildings.m_buffer[buildingId];
        }
    }
}
