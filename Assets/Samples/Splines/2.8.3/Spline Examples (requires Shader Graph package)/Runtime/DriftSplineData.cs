using System;
using UnityEngine;
using UnityEngine.Splines;

namespace Unity.Splines.Examples
{
    public class DriftSplineData : MonoBehaviour
    {
        [HideInInspector]
        [Obsolete("No longer used.", false)]
        public float m_Default;

        [SerializeField]
        SplineData<float> m_Drift = new SplineData<float>();

        [Obsolete("Use Drift instead.", false)]
        public SplineData<float> drift => Drift;
        public SplineData<float> Drift => m_Drift;

        SplineContainer m_SplineContainer;

        [Obsolete("Use Container instead.", false)]
        public SplineContainer container => Container;
        public SplineContainer Container
        {
            get
            {
                if (m_SplineContainer == null)
                    m_SplineContainer = GetComponent<SplineContainer>();
                return m_SplineContainer;
            }
            set => m_SplineContainer = value;
        }
    }
}
