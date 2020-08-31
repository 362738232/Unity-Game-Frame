using DG.Tweening;
using UnityEngine;

namespace Lzj.UI.Animation
{
    public partial class UIAnimator
    {
        public const bool DefaultAnimationClipEnabled = false;

        public const UDirection DefaultDirection = UDirection.Left;

        public const RotateMode DefaultRotateMode = RotateMode.FastBeyond360;

        public const LoopType DefaultLoopType = LoopType.Yoyo;

        public const UEaseType DefaultEaseType = UEaseType.Ease;

        public const Ease DefaultEase = Ease.Linear;

        public const float DefaultDuration = 0.2f;

        public const float DefaultDelay = 0f;

        public const int DefaultLoopTimes = -1;

        public const int DefaultVibrato = 10;

        public const float DefaultElasticity = 1;

        public static Vector3 DEFAULT_START_POSITION = Vector3.zero;
        public static Vector3 DEFAULT_START_ROTATION = Vector3.zero;
        public static Vector3 DEFAULT_START_SCALE = Vector3.one;
        public const float DEFAULT_START_ALPHA = 1f;
    }
}
