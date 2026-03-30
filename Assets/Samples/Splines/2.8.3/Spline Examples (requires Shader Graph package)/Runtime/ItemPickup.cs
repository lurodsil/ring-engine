using System;
#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.Splines;
#endif

// An example showing how to use embedded SplineData on the Spline class. Additionally showcases how to respond to
// changes in the Inspector.
namespace UnityEngine.Splines.Examples
{
#if UNITY_EDITOR
    [CustomEditor(typeof(ItemPickup))]
    class ItemPickupEditor : Editor
    {
        void OnEnable()
        {
            EditorSplineUtility.AfterSplineWasModified += OnAfterSplineModified;
            EditorSplineUtility.RegisterSplineDataChanged<Object>(OnAfterSplineDataWasModified);
            Undo.undoRedoPerformed += InstantiatePrefabs;
        }

        void OnDisable()
        {
            EditorSplineUtility.AfterSplineWasModified -= OnAfterSplineModified;
            EditorSplineUtility.UnregisterSplineDataChanged<Object>(OnAfterSplineDataWasModified);
            Undo.undoRedoPerformed -= InstantiatePrefabs;
        }

        void OnAfterSplineModified(Spline _) => InstantiatePrefabs();

        void InstantiatePrefabs()
        {
            if (target is ItemPickup pickup)
                pickup.Instantiate();
        }

        void OnAfterSplineDataWasModified(SplineData<Object> splineData)
        {
            InstantiatePrefabs();
        }

        public override void OnInspectorGUI()
        {
            EditorGUI.BeginChangeCheck();
            base.OnInspectorGUI();
            if (EditorGUI.EndChangeCheck())
                InstantiatePrefabs();
        }
    }
#endif

    [RequireComponent(typeof(SplineContainer))]
    public class ItemPickup : MonoBehaviour
    {
        public const string PickupDataKey = "pickups";

        // EmbeddedSplineData is a convenience class that wraps all the fields necessary to access SplineData embedded
        // in a Spline class and provides a custom property drawer.
        // If `Container` and `SplineIndex` are omitted, it is assumed that the referenced Spline is on the first
        // SplineContainer component found on the same GameObject, at index 0.
        // I.e., gameObject.Component<SplineContainer>().Splines[0].
        // In this example we specify that only the key should be shown in the Inspector.
        [SerializeField, EmbeddedSplineDataFields(EmbeddedSplineDataField.Key | EmbeddedSplineDataField.SplineIndex)]
        EmbeddedSplineData m_Pickups = new EmbeddedSplineData()
        {
            Key = PickupDataKey,
            Type = EmbeddedSplineDataType.Object
        };

        public void Instantiate()
        {
            m_Pickups.Container = GetComponent<SplineContainer>();

            for (int i = transform.childCount - 1; i > -1; --i)
                DestroyImmediate(transform.GetChild(i).gameObject);

            if (!m_Pickups.TryGetSpline(out var spline))
                return;

            var parent = transform;

            // SplineData embedded in a Spline directly is accessed through a key value pair interface. You could also use TryGetObjectData
            // if you do not want to create a new SplineData entry. This function
            // will create a new SplineData object if one does not exist already.
            if (!m_Pickups.TryGetObjectData(out var prefabs))
                return;

            foreach (var key in prefabs)
            {
                if (key.Value == null)
                    continue;

                float t = spline.ConvertIndexUnit(key.Index, prefabs.PathIndexUnit, PathIndexUnit.Normalized);
                m_Pickups.Container.Evaluate(m_Pickups.SplineIndex, t, out var position, out var tangent, out var normal);
                var rotation = Vector3.SqrMagnitude(tangent) < float.Epsilon || Vector3.SqrMagnitude(normal) < float.Epsilon
                    ? Quaternion.identity
                    : Quaternion.LookRotation(tangent, normal);

                #if UNITY_EDITOR
                if (PrefabUtility.InstantiatePrefab(key.Value, parent) is GameObject instance)
                #else
                if (Instantiate(key.Value, parent) is GameObject instance)
                #endif
                    instance.transform.SetPositionAndRotation(position, rotation);
            }

            #if UNITY_EDITOR
            Selection.activeObject = gameObject;
            #endif
        }
    }
}
