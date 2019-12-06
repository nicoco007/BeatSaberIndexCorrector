using Harmony;
using UnityEngine;
using UnityEngine.XR;

namespace BeatSaberIndexCorrector
{
    [HarmonyPatch(typeof(VRPlatformHelper))]
    [HarmonyPatch("AdjustPlatformSpecificControllerTransform", MethodType.Normal)]
    public class AdjustPlatformSpecificControllerTransformPatch
    {
        public static bool Prefix(XRNode node, Transform transform, VRPlatformHelper __instance)
        {
            if (__instance.vrPlatformSDK != VRPlatformHelper.VRPlatformSDK.OpenVR)
            {
                return true;
            }

            OpenVRHelper openVRHelper = Traverse.Create(__instance).Field("_openVRHeper").GetValue<OpenVRHelper>();

            if (openVRHelper.vrControllerManufacturerName != OpenVRHelper.VRControllerManufacturerName.Valve)
            {
                return true;
            }

            transform.Rotate(15f, 0f, 0f);
            transform.Translate(0f, -0.03f, 0f);

            return false;
        }
    }
}
