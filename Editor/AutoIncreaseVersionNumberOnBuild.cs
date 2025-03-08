#if UNITY_EDITOR
using System;
using UnityEditor;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;

namespace BetterReality.DevTools
{

    /// <summary>
    ///     Automatically set the Version number (semantic)
    ///     When building for Android, we're also needing the AutoIncreaseAndroidBundleVersionCodeOnBuild.cs
    ///     With help from ChatGPT
    /// </summary>
    public class AutoIncreaseVersionNumberOnBuild : IPostprocessBuildWithReport
    {
        private string _oldVersion;
        private string _newVersion;
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
                _oldVersion = PlayerSettings.bundleVersion;

                _newVersion = IncrementVersionNumber(_oldVersion);

                PlayerSettings.bundleVersion = _newVersion;

                Console.Write("Incremented the NEXT version number from", _oldVersion, "to", _newVersion);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error incrementing version number: ", e.Message, "\n", e.StackTrace);
                throw;
            }
        }


        public static string IncrementVersionNumber(string version)
        {
            // Split the version string into parts
            var parts = version.Split('_');

            // Extract the last part (current number to increment)
            var lastNumberIndex = parts.Length - 1;
            var currentNumber = int.Parse(parts[lastNumberIndex]);

            currentNumber++;

            // Replace the last part with the incremented number
            parts[lastNumberIndex] = currentNumber.ToString();

            // Join all parts back into a single string
            return string.Join("_", parts);
        }
    }
}
#endif
