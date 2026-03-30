using Unity.Splines.Examples;
using UnityEditor;
using UnityEngine;

namespace Unity.Splines.Examples
{
    [CustomEditor(typeof(AnimateCarAlongSpline))]
    public class AnimateCarAlongSplineEditor : UnityEditor.Editor
    {
        void OnEnable()
        {
            ((AnimateCarAlongSpline)target).Initialize();
        }
    }
}
