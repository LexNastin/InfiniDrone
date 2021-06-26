using SRML;
using UnityEngine;
using SRML.Console;
using System.Collections;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;
using HarmonyLib;

namespace InfiniDrone
{
    public class FixDrone : MonoBehaviour
    {
        void Update()
        {
            if (GetComponent<DroneGadget>().station.battery.meter.localScale.y <= 0.95)
            {
                GetComponent<DroneGadget>().station.battery.AddLiquid(Identifiable.Id.WATER_LIQUID, 1f);
            }
        }
    }

    public class Mod : ModEntryPoint
    {
        public override void PreLoad()
        {
            HarmonyInstance.PatchAll();
        }

        public override void Load()
        {
            SRSingleton<GameContext>.Instance.LookupDirector.GetGadgetDefinition(Gadget.Id.DRONE).prefab.AddComponent<FixDrone>();
            SRSingleton<GameContext>.Instance.LookupDirector.GetGadgetDefinition(Gadget.Id.DRONE_ADVANCED).prefab.AddComponent<FixDrone>();
        }
    }
}