using System;
using UnityEditor;
using UnityEditor.Toolbars;
using UnityEngine;

namespace Unity.Splines.Examples
{
    [EditorToolbarElement("SpeedTiltTool/SplineDataType")]
    public class SpeedTiltDropdown : EditorToolbarDropdown
    {
        string[] m_SplineDataTypes = new[]
        {
            SpeedTiltTool.SplineDataType.SpeedData.ToString(),
                 SpeedTiltTool.SplineDataType.TiltData.ToString()
        };

        [Obsolete("Use Tooltip instead.", false)]
        public string k_Tooltip = "Select the SplineData to target for interactions.";
        public string Tooltip = "Select the SplineData to target for interactions.";

        public SpeedTiltDropdown()
        {
            name = "SplineData Target Type";

            clicked += OpenContextMenu;
            text = m_SplineDataTypes[(int)SpeedTiltTool.selectedSplineData];
        }

        void OpenContextMenu()
        {
            var menu = new GenericMenu();
            for (int i = 0; i < m_SplineDataTypes.Length; i++)
            {
                var index = i;
                var component = m_SplineDataTypes[i];
                menu.AddItem(new GUIContent(component, Tooltip), text == component,
                    () => SetSelectedComponent(index));
            }
            menu.DropDown(worldBound);
        }

        void SetSelectedComponent(int selectedIndex)
        {
            text = m_SplineDataTypes[selectedIndex];
            SpeedTiltTool.selectedSplineData = (SpeedTiltTool.SplineDataType)selectedIndex;
        }
    }
}
