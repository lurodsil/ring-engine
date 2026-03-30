using UnityEngine;
using UnityEngine.UIElements;

namespace Unity.Splines.Examples
{
    /// <summary>
    /// UI implementation for Paint Splines example.
    /// </summary>
    public class PaintUI : MonoBehaviour
    {
        static bool s_PointerOverUI;
        public static bool PointerOverUI => s_PointerOverUI;
        static UIDocument m_Document;
        public static VisualElement root { get; private set; }

        void Awake()
        {
            m_Document = GetComponent<UIDocument>();
            root = m_Document.rootVisualElement;
            ConnectVisualElements();
        }

        void ConnectVisualElements()
        {
            root.RegisterCallback<PointerEnterEvent>(OnPointerEnter);
            root.RegisterCallback<PointerLeaveEvent>(OnPointerExit);

            var pointReduceEpsilonSlider = root.Q<Slider>("PointReductionEpsilonSlider");
            var pointReduceEpsilonLabel = root.Q<Label>("PointReductionEpsilonLabel");
            pointReduceEpsilonSlider.RegisterValueChangedCallback(evt =>
                pointReduceEpsilonLabel.text = evt.newValue.ToString());

            var tensionSlider = root.Q<Slider>("SplineTensionSlider");
            var tensionLabel = root.Q<Label>("SplineTensionLabel");
            tensionSlider.RegisterValueChangedCallback(evt => tensionLabel.text = evt.newValue.ToString());
        }

        void OnPointerEnter(PointerEnterEvent evt) => s_PointerOverUI = true;

        void OnPointerExit(PointerLeaveEvent evt) => s_PointerOverUI = false;
    }
}
