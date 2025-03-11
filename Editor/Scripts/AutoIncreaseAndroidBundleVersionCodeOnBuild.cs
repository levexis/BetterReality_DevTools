#if UNITY_EDITOR

using System;
using UnityEditor;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;

namespace BetterReality.DevTools
{
    /// <summary>
    ///     Automatically increase the BundleVersionCode that is required by Android
    /// </summary>
    public class AutoIncreaseAndroidBundleVersionCodeOnBuild : IPostprocessBuildWithReport
    {
        private int _oldBundleVersionCode;
        private int _newBundleVersionCode;

        public int callbackOrder { get; }


        /// <summary>
        ///     Moved the logic to the PostProcessBuild instead of the PreProcess build because every failed build attempt was
        ///     taken into account previously. Now only successful build should be numbered.
        /// </summary>
        /// <param name="report"></param>
        public void OnPostprocessBuild(BuildReport report)
        {
            try
            {

                _oldBundleVersionCode = PlayerSettings.Android.bundleVersionCode;
                _newBundleVersionCode = PlayerSettings.Android.bundleVersionCode + 1;
                PlayerSettings.Android.bundleVersionCode = _newBundleVersionCode;

                Console.Write("Incremented Android BundleVersionCode from", _oldBundleVersionCode, "to",
                    _newBundleVersionCode);
            }
            catch (Exception e)
            {
                Console.Write("Error incrementing android bundleVersion " + e.Message);
            }
        }
    }
}
#endif
