using Harmony;
using UnityEngine;
using UnityEngine.XR;

namespace BeatSaberIndexCorrector
{
    [HarmonyPatch(typeof(VRPlatformHelper))]
    [HarmonyPatch("AdjustPlatformSpecificControllerTransform", MethodType.Normal)]
    public class AdjustPlatformSpecificControllerTransformPatch
    {
        public static bool Prefix(XRNode node, Transform transform, Vector3 addPosition, Vector3 addRotation, VRPlatformHelper __instance)
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

            transform.Rotate(new Vector3(15f, 0f, 0f) + addRotation);
            transform.Translate(new Vector3(0f, -0.03f, 0f) + addPosition);

            return false;
        }
    }
}
