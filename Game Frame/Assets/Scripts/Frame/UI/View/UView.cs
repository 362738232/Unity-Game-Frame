using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace Lzj.UI.View
{
    [RequireComponent(typeof(Canvas))]
    [RequireComponent(typeof(CanvasGroup))]
    [RequireComponent(typeof(GraphicRaycaster))]
    public class UView : MonoBehaviour
    {
        #region Properties

        public new RectTransform transform
        {
            get
            {
                return base.transform as RectTransform;
            }
        }

        public Canvas canvas
        {
            get
            {
                return this.m_canvas ?? (this.m_canvas = this.GetComponent<Canvas>());
            }
        }

        public CanvasGroup canvasGroup
        {
            get
            {
                return this.m_canvasGroup ?? (this.m_canvasGroup = this.GetComponent<CanvasGroup>());
            }
        }

        public GraphicRaycaster graphicRaycaster
        {
            get
            {
                return this.m_graphicRaycaster ?? (this.m_graphicRaycaster = this.GetComponent<GraphicRaycaster>());
            }
        }

        #endregion

        #region Public Variables

        [TitleGroup("Actions")]
        [HorizontalGroup("Actions/Split")]
        [VerticalGroup("Actions/Split/Left")]
        [BoxGroup("Actions/Split/Left/Behavior At Start"), HideLabel]
        public StartAction StartAction = StartAction.Donoting;

        [VerticalGroup("Actions/Split/Right")]
        [BoxGroup("Actions/Split/Right/When View is Hidden Disable"), HideLabel]
        public HiddenAction HiddenAction = HiddenAction.DisableGameObject;

        [BoxGroup("CustomPosition", false)]
        public Vector3 CustomStartAnchoredPosition = Vector3.zero;

        [FoldoutGroup("Show Behaviour"), HideLabel]
        public ViewBehaviour ShowBehaviour = new ViewBehaviour(Animation.UAnimationType.Show);

        [FoldoutGroup("Hide Behaviour"), HideLabel]
        public ViewBehaviour HideBehaviour = new ViewBehaviour(Animation.UAnimationType.Hide);

        [FoldoutGroup("Loop Behaviour"), HideLabel]
        public ViewBehaviour LoopBehaviour = new ViewBehaviour(Animation.UAnimationType.Loop);

        #endregion

        #region Private Variables

        private Canvas m_canvas;

        private CanvasGroup m_canvasGroup;

        private GraphicRaycaster m_graphicRaycaster;

        private Vector3 m_startPosition = Vector3.zero;

        private Vector3 m_startRotation = Vector3.zero;

        private Vector3 m_startScale = Vector3.one;

        private float m_startalpha = 1;

        #endregion

        private void Awake()
        {
            this.m_startPosition = this.transform.anchoredPosition3D;
            this.m_startRotation = this.transform.localEulerAngles;
            this.m_startScale = this.transform.localScale;
            this.m_startalpha = this.canvasGroup.alpha;
        }

#if UNITY_EDITOR
        [ButtonGroup("CustomPosition/Btns"), LabelText("↑Get Position")]
        private void GetCustomPosition()
        {
            this.transform.anchoredPosition3D = this.CustomStartAnchoredPosition;
        }

        [ButtonGroup("CustomPosition/Btns"), LabelText("↓Set Position")]
        private void SetCustomPosition()
        {
            UnityEditor.Undo.RecordObject(this, "Set Position");
            this.CustomStartAnchoredPosition = this.transform.anchoredPosition3D;

        }

        [ButtonGroup("CustomPosition/Btns"), LabelText("↺Reset Position")]
        private void ResetCustomPosition()
        {
            UnityEditor.Undo.RecordObject(this, "Reset Position");
            this.CustomStartAnchoredPosition = Vector3.zero;
        }
#endif
    }
}