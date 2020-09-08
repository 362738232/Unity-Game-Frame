using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Sirenix.Utilities;
using Sirenix.OdinInspector.Editor;
using Sirenix.Utilities.Editor;

namespace Lzj.UI.Animation.Editor
{
    public class BaseUClipDrawer : OdinValueDrawer<Move>
    {
        private GUIContent m_moveContent;
        private GUIContent m_DelayContent;

        protected override void Initialize()
        {
            base.Initialize();
            this.m_moveContent = EditorGUIUtility.TrIconContent("MoveTool");
            this.m_DelayContent = new GUIContent("Start Delay");
        }

        protected virtual GUIContent GetIconContent()
        {
            return this.m_moveContent;
        }

        protected override void DrawPropertyLayout(GUIContent label)
        {
            var height = EditorGUIUtility.singleLineHeight;
            var rect = EditorGUILayout.GetControlRect(true, height * 2);

            GUI.Box(rect, GUIContent.none);
            GUI.Box(rect.AlignMiddle(rect.height).SetWidth(18), GUIContent.none);

            //var iconWidth = height;
            //EditorGUI.LabelField(rect, this.m_moveContent);

            //rect = rect.AddX(iconWidth).SubXMax(iconWidth);
            //GUI.Box(rect, GUIContent.none);
            //EditorGUI.LabelField(rect.AlignTop(height), "Move", SirenixGUIStyles.BoldLabel);

            //rect = rect.AddY(height);
            //var oldLabelWidth = EditorGUIUtility.labelWidth;
            //var lableRect = GUILayoutUtility.GetRect(this.m_DelayContent, GUI.skin.label, GUILayoutOptions.ExpandWidth(false));
            //GUI.Label(rect.AlignTop(height).Split(2, 3).AlignLeft(lableRect.width), this.m_DelayContent);
            //EditorGUI.FloatField(rect.AlignTop(height).Split(2, 3).AddX(lableRect.width), 1);
        }
    }
}
