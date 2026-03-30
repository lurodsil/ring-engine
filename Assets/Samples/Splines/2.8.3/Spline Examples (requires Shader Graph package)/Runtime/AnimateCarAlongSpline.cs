using System;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Splines;
using Unity.Mathematics;
using UnityEngine.Serialization;
using Interpolators = UnityEngine.Splines.Interpolators;
using Quaternion = UnityEngine.Quaternion;

namespace Unity.Splines.Examples
{
    public class AnimateCarAlongSpline : MonoBehaviour
    {
        [SerializeField]
        SplineContainer m_SplineContainer;
        [Obsolete("Use Container instead.", false)]
        public SplineContainer splineContainer => Container;
        public SplineContainer Container => m_SplineContainer;

        [SerializeField]
        Car m_CarToAnimate;

        [HideInInspector]
        [Obsolete("No longer used.", false)]
        public float m_DefaultSpeed;

        [HideInInspector]
        [Obsolete("No longer used.", false)]
        public Vector3 m_DefaultTilt;

        [HideInInspector]
        [Obsolete("Use MaxSpeed instead.", false)]
        public float m_MaxSpeed = 40f;
        [FormerlySerializedAs("m_MaxSpeed")]
        [Min(0f)]
        public float MaxSpeed = 40f;

        [SerializeField]
        SplineData<float> m_Speed = new SplineData<float>();
        [Obsolete("Use Speed instead.", false)]
        public SplineData<float> speed => Speed;
        public SplineData<float> Speed => m_Speed;

        [SerializeField]
        SplineData<float3> m_Tilt = new SplineData<float3>();
        [Obsolete("Use Tilt instead.", false)]
        public SplineData<float3> tilt => Tilt;
        public SplineData<float3> Tilt => m_Tilt;

        [SerializeField]
        DriftSplineData m_Drift;

        [Obsolete("Use DriftData instead.", false)]
        public DriftSplineData driftData => DriftData;
        public DriftSplineData DriftData
        {
            get
            {
                if (m_Drift == null)
                    m_Drift = GetComponent<DriftSplineData>();

                return m_Drift;
            }
        }

        float m_CurrentOffset;
        float m_CurrentSpeed;
        float m_SplineLength;
        Spline m_Spline;

        public void Initialize()
        {
            //Trying to initialize either the spline container or the car
            if (m_SplineContainer == null && !TryGetComponent<SplineContainer>(out m_SplineContainer))
                if (m_CarToAnimate == null)
                    TryGetComponent<Car>(out m_CarToAnimate);
        }

        void Start()
        {
            Assert.IsNotNull(m_SplineContainer);

            m_Spline = m_SplineContainer.Spline;
            m_SplineLength = m_Spline.GetLength();
            m_CurrentOffset = 0f;
        }

        void OnValidate()
        {
            if (m_Speed != null)
            {
                for (int index = 0; index < m_Speed.Count; index++)
                {
                    var data = m_Speed[index];

                    //We don't want to have a value that is negative or null as it might block the simulation
                    if (data.Value <= 0)
                    {
                        data.Value = Mathf.Max(0f, m_Speed.DefaultValue);
                        m_Speed[index] = data;
                    }
                }
            }

            if (m_Tilt != null)
            {
                for (int index = 0; index < m_Tilt.Count; index++)
                {
                    var data = m_Tilt[index];

                    //We don't want to have a up vector of magnitude 0
                    if (math.length(data.Value) == 0)
                    {
                        data.Value = m_Tilt.DefaultValue;
                        m_Tilt[index] = data;
                    }
                }
            }

            if (DriftData != null)
                DriftData.Container = Container;
        }

        void Update()
        {
            if (m_SplineContainer == null || m_CarToAnimate == null)
                return;

            m_CurrentOffset = (m_CurrentOffset + m_CurrentSpeed * Time.deltaTime / m_SplineLength) % 1f;

            if (m_Speed.Count > 0)
                m_CurrentSpeed = m_Speed.Evaluate(m_Spline, m_CurrentOffset, PathIndexUnit.Normalized, new Interpolators.LerpFloat());
            else
                m_CurrentSpeed = m_Speed.DefaultValue;

            var posOnSplineLocal = SplineUtility.EvaluatePosition(m_Spline, m_CurrentOffset);
            var direction = SplineUtility.EvaluateTangent(m_Spline, m_CurrentOffset);
            var upSplineDirection = SplineUtility.EvaluateUpVector(m_Spline, m_CurrentOffset);
            var right = math.normalize(math.cross(upSplineDirection, direction));
            var driftOffset = 0f;
            if (DriftData != null)
            {
                driftOffset = DriftData.Drift.Count == 0 ?
                    DriftData.Drift.DefaultValue :
                    DriftData.Drift.Evaluate(m_Spline, m_CurrentOffset, PathIndexUnit.Normalized, new Interpolators.LerpFloat());
            }

            m_CarToAnimate.transform.position = m_SplineContainer.transform.TransformPoint(posOnSplineLocal + driftOffset * right);

            var up =
                (m_Tilt.Count == 0) ?
                m_Tilt.DefaultValue :
                m_Tilt.Evaluate(m_Spline, m_CurrentOffset, PathIndexUnit.Normalized, new Interpolators.LerpFloat3());

            var rot = Quaternion.LookRotation(direction, upSplineDirection);
            m_CarToAnimate.transform.rotation = Quaternion.LookRotation(direction, rot * up);
        }
    }
}
