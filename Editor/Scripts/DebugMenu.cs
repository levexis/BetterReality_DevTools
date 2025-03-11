using UnityEditor;
using UnityEngine;

#if UNITY_EDITOR 

namespace BetterReality.DevTools
{
    public static class DebugMenu
    {
        [MenuItem("Debug/Print Global Position")]
        public static void PrintGlobalPosition()
        {
            if (Selection.activeGameObject != null)
            {
                Debug.Log(Selection.activeGameObject.name + " is at " + Selection.activeGameObject.transform.position);
            }
        }

        [MenuItem("Debug/Render bounds")]
        public static void PrintRenderBounds()
        {
            if (Selection.activeGameObject != null)
            {
                MeshRenderer meshy = Selection.activeGameObject.GetComponent<MeshRenderer>();
                if (meshy)
                {
                    Debug.Log($"Mesh Extents: {meshy.bounds.extents}");
                    Debug.Log($"Mesh Max: {meshy.bounds.max}");
                    Debug.Log($"Mesh Min: {meshy.bounds.min}");
                    Debug.Log($"Mesh Size: {meshy.bounds.size}");
                    Debug.Log($"Mesh Center: {meshy.bounds.center}");
                }
            }
        }

        [MenuItem("Debug/Audio sources")]
        public static void FindAudioSource()
        {
            if (Selection.activeGameObject != null)
            {
// Find all game objects with AudioSources in the scene
                AudioSource[] audioSources = GameObject.FindObjectsOfType<AudioSource>();

                // Loop through the found AudioSources
                foreach (AudioSource audioSource in audioSources)
                {
                    // Do something with each audioSource, for example, print the name
                    Debug.Log($"{audioSource.gameObject.name} is playing: {audioSource.isPlaying}");
                }
            }
        }
    }
}
#endif