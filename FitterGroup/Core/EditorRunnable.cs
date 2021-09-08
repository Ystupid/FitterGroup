using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityEngine.UI.FitterGroup
{
    [ExecuteAlways]
    public class EditorRunnable : MonoBehaviour
    {
#if UNITY_EDITOR
        private void Awake()
        {
            if (!Application.isPlaying)
                EditorInit();
        }

        private void Update() => EditorUpdate();
        private void OnValidate() => EditorValidate();
#endif
        protected virtual void EditorInit() { }
        protected virtual void EditorUpdate() { }
        protected virtual void EditorValidate() { }
    }
}