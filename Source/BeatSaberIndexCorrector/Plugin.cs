using Harmony;
using IPA;
using UnityEngine.SceneManagement;
using Logger = IPA.Logging.Logger;

namespace BeatSaberIndexCorrector
{
    public class Plugin : IBeatSaberPlugin, IDisablablePlugin
    {
        public const string kHarmonyId = "com.nicoco007.beatsaberindexcorrector";

        public static Logger logger;

        private HarmonyInstance _harmonyInstance;

        public void Init(Logger logger)
        {
            Plugin.logger = logger;
        }

        public void OnEnable()
        {
            _harmonyInstance = HarmonyInstance.Create(kHarmonyId);

            logger.Info("Applying Index controller patch");

            _harmonyInstance.PatchAll();
        }

        public void OnDisable()
        {
            _harmonyInstance.UnpatchAll(kHarmonyId);
        }

        public void OnApplicationStart() { }

        public void OnActiveSceneChanged(Scene prevScene, Scene nextScene) { }

        public void OnApplicationQuit() { }

        public void OnFixedUpdate() { }

        public void OnSceneLoaded(Scene scene, LoadSceneMode sceneMode) { }

        public void OnSceneUnloaded(Scene scene) { }

        public void OnUpdate() { }
    }
}
