using UnityEditor;

namespace Unity.Splines.Examples.Editor
{
    [CustomEditor(typeof(LoftRoadBehaviour))]
    [CanEditMultipleObjects]
    class SplineWidthEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            EditorGUI.BeginChangeCheck();

            base.OnInspectorGUI();

            if (EditorGUI.EndChangeCheck())
            {
                EditorApplication.delayCall += () =>
                {
                    foreach (var target in targets)
                        ((LoftRoadBehaviour)target).LoftAllRoads();
                };
            }
        }
    }
}