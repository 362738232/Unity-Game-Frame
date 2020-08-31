using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;

namespace Lzj.UI.Animation
{
    public static partial class UIAnimator
    {
        public static bool IgnoreUnityTimescale;

        public static bool AnimationSpeedBased;

        #region Tweens

        #region MoveTween MoveLoopTween MovePunchTween, MoveStateTween

        public static Tween MoveTween(RectTransform transform, UAnimation animation, Vector3 start, Vector3 end)
        {
            transform.anchoredPosition3D = start;
            Tween tween = transform.DOAnchorPos3D(end, animation.Move.Duration)
                                   .SetDelay(animation.Move.Delay)
                                   .SetUpdate(IgnoreUnityTimescale)
                                   .SetSpeedBased(AnimationSpeedBased);
            tween.SetEaseByClip(animation.Move);
            return tween;
        }

        public static Vector3 MoveLoopPositionA(UAnimation animation, Vector3 startValue) { return startValue - animation.Move.By; }

        public static Vector3 MoveLoopPositionB(UAnimation animation, Vector3 startValue) { return startValue + animation.Move.By; }

        public static Tween MoveLoopTween(RectTransform target, UAnimation animation, Vector3 startValue)
        {
            Tween loopTween = target.DOAnchorPos(MoveLoopPositionB(animation, startValue), animation.Move.Duration)
                                    .SetUpdate(IgnoreUnityTimescale)
                                    .SetSpeedBased(AnimationSpeedBased)
                                    .SetLoops(animation.Move.LoopTimes, animation.Move.LoopType);
            loopTween.SetEaseByClip(animation.Move);
            return loopTween;
        }

        public static Tween MovePunchTween(RectTransform transform, UAnimation animation)
        {
            return transform.DOPunchAnchorPos(animation.Move.By, animation.Move.Duration, animation.Move.Vibrato, animation.Move.Elasticity)
                            .SetDelay(animation.Move.Delay)
                            .SetUpdate(IgnoreUnityTimescale)
                            .SetSpeedBased(AnimationSpeedBased);
        }

        public static Tween MoveStateTween(RectTransform transform, UAnimation animation, Vector3 start)
        {
            Tween tween = transform.DOAnchorPos(start + animation.Move.By, animation.Move.Duration)
                                   .SetDelay(animation.Move.Delay)
                                   .SetUpdate(IgnoreUnityTimescale)
                                   .SetSpeedBased(AnimationSpeedBased);
            tween.SetEaseByClip(animation.Move);
            return tween;
        }

        #endregion

        #region RotateTween RotateLoopTween, RotatePunchTween RotateStateTween

        public static Tween RotateTween(RectTransform transform, UAnimation animation, Vector3 start, Vector3 end)
        {
            transform.localEulerAngles = start;
            Tween tween = transform.DOLocalRotate(end, animation.Rotate.Duration)
                                   .SetDelay(animation.Rotate.Delay)
                                   .SetUpdate(IgnoreUnityTimescale)
                                   .SetSpeedBased(AnimationSpeedBased);
            tween.SetEaseByClip(animation.Rotate);
            return tween;
        }

        public static Vector3 RotateLoopRotationA(UAnimation animation, Vector3 startValue) { return startValue - animation.Rotate.By; }

        public static Vector3 RotateLoopRotationB(UAnimation animation, Vector3 startValue) { return startValue + animation.Rotate.By; }

        public static Tween RotateLoopTween(RectTransform target, UAnimation animation, Vector3 startValue)
        {
            Tween loopTween = target.DOLocalRotate(RotateLoopRotationB(animation, startValue), animation.Rotate.Duration, animation.Rotate.RotateMode)
                                    .SetUpdate(IgnoreUnityTimescale)
                                    .SetSpeedBased(AnimationSpeedBased)
                                    .SetLoops(animation.Rotate.LoopTimes, animation.Rotate.LoopType);
            loopTween.SetEaseByClip(animation.Rotate);
            return loopTween;
        }

        public static Tween RotatePunchTween(RectTransform transform, UAnimation animation)
        {
            return transform.DOPunchRotation(animation.Rotate.By, animation.Rotate.Duration, animation.Rotate.Vibrato, animation.Rotate.Elasticity)
                            .SetDelay(animation.Rotate.Delay)
                            .SetUpdate(IgnoreUnityTimescale)
                            .SetSpeedBased(AnimationSpeedBased);
        }

        public static Tween RotateStateTween(RectTransform transform, UAnimation animation, Vector3 start)
        {
            Tween tween = transform.DOLocalRotate(start + animation.Rotate.By, animation.Rotate.Duration)
                                   .SetDelay(animation.Rotate.Delay)
                                   .SetUpdate(IgnoreUnityTimescale)
                                   .SetSpeedBased(AnimationSpeedBased);
            tween.SetEaseByClip(animation.Rotate);
            return tween;
        }

        #endregion

        #region ScaleTween ScaleLoopTween, ScalePunchTween ScaleStateTween

        public static Tween ScaleTween(RectTransform transform, UAnimation animation, Vector3 start, Vector3 end)
        {
            start.z = end.z = 1;
            transform.localScale = start;
            Tween tween = transform.DOScale(end, animation.Scale.Duration)
                                   .SetDelay(animation.Scale.Delay)
                                   .SetUpdate(IgnoreUnityTimescale)
                                   .SetSpeedBased(AnimationSpeedBased);
            tween.SetEaseByClip(animation.Scale);
            return tween;
        }

        public static Tween ScaleLoopTween(RectTransform target, UAnimation animation)
        {
            animation.Scale.From.z = 1f;
            animation.Scale.To.z = 1f;
            Tweener loopTween = target.DOScale(animation.Scale.To, animation.Scale.Duration)
                                      .SetUpdate(IgnoreUnityTimescale)
                                      .SetSpeedBased(AnimationSpeedBased)
                                      .SetLoops(animation.Scale.LoopTimes, animation.Scale.LoopType);
            loopTween.SetEaseByClip(animation.Scale);
            return loopTween;
        }

        public static Tween ScalePunchTween(RectTransform transform, UAnimation animation)
        {
            animation.Scale.By.z = 0;
            return transform.DOPunchScale(animation.Scale.By, animation.Scale.Duration, animation.Scale.Vibrato, animation.Scale.Elasticity)
                            .SetDelay(animation.Scale.Delay)
                            .SetUpdate(IgnoreUnityTimescale)
                            .SetSpeedBased(AnimationSpeedBased);
        }

        public static Tween ScaleStateTween(RectTransform transform, UAnimation animation, Vector3 start)
        {
            animation.Scale.By.z = 0;
            Tween tween = transform.DOScale(start + animation.Scale.By, animation.Scale.Duration)
                                   .SetDelay(animation.Scale.Delay)
                                   .SetUpdate(IgnoreUnityTimescale)
                                   .SetSpeedBased(AnimationSpeedBased);
            tween.SetEaseByClip(animation.Scale);
            return tween;
        }

        #endregion

        #region FadeTween FadeLoopTween, FadePunchTween FadeStateTween

        public static Tween FadeTween(RectTransform transform, UAnimation animation, float start, float end)
        {
            start = Mathf.Clamp01(start);
            end = Mathf.Clamp01(end);
            CanvasGroup canvasGroup = transform.GetComponent<CanvasGroup>() ?? transform.gameObject.AddComponent<CanvasGroup>();
            canvasGroup.alpha = start;
            Tween tween = canvasGroup.DOFade(end, animation.Fade.Duration)
                                   .SetDelay(animation.Fade.Delay)
                                   .SetUpdate(IgnoreUnityTimescale)
                                   .SetSpeedBased(AnimationSpeedBased);
            tween.SetEaseByClip(animation.Fade);
            return tween;
        }

        public static Tween FadeLoopTween(RectTransform target, UAnimation animation)
        {
            animation.Fade.From = Mathf.Clamp01(animation.Fade.From);
            animation.Fade.To = Mathf.Clamp01(animation.Fade.To);
            CanvasGroup canvasGroup = target.GetComponent<CanvasGroup>() != null ? target.GetComponent<CanvasGroup>() : target.gameObject.AddComponent<CanvasGroup>();
            Tweener loopTween = canvasGroup.DOFade(animation.Fade.To, animation.Fade.Duration)
                                           .SetUpdate(IgnoreUnityTimescale)
                                           .SetSpeedBased(AnimationSpeedBased)
                                           .SetLoops(animation.Fade.LoopTimes, animation.Fade.LoopType);
            loopTween.SetEaseByClip(animation.Fade);
            return loopTween;
        }

        public static Tween FadeStateTween(RectTransform transform, UAnimation animation, float start)
        {
            float end = Mathf.Clamp01(start + animation.Fade.By);
            CanvasGroup canvasGroup = transform.GetComponent<CanvasGroup>() ?? transform.gameObject.AddComponent<CanvasGroup>();
            Tween tween = canvasGroup.DOFade(end, animation.Fade.Duration)
                                   .SetDelay(animation.Fade.Delay)
                                   .SetUpdate(IgnoreUnityTimescale)
                                   .SetSpeedBased(AnimationSpeedBased);
            tween.SetEaseByClip(animation.Fade);
            return tween;
        }

        #endregion

        #endregion

        #region Animations

        #region Move Rotate Scale Fade

        public static void Move(RectTransform transform, UAnimation animation, Vector3 start, Vector3 end, bool instantAnimation = false, UnityAction onStartCallBack = null, UnityAction onCompleteCallBack = null)
        {
            if (!animation.Move.Enabled && !instantAnimation)
                return;

            if (instantAnimation)
            {
                transform.anchoredPosition3D = end;
                onStartCallBack?.Invoke();
                onCompleteCallBack?.Invoke();
                return;
            }

            DOTween.Sequence()
                   .SetId(GenerateTweenId(transform, animation.AnimationType, UClipType.Move))
                   .SetUpdate(IgnoreUnityTimescale)
                   .SetSpeedBased(AnimationSpeedBased)
                   .OnStart(() => { onStartCallBack?.Invoke(); })
                   .OnComplete(() => { onCompleteCallBack?.Invoke(); })
                   .Append(MoveTween(transform, animation, start, end))
                   .Play();
        }

        public static void Rotate(RectTransform transform, UAnimation animation, Vector3 start, Vector3 end, bool instantAnimation = false, UnityAction onStartCallBack = null, UnityAction onCompleteCallBack = null)
        {
            if (!animation.Rotate.Enabled && !instantAnimation)
                return;

            if (instantAnimation)
            {
                transform.localEulerAngles = end;
                onStartCallBack?.Invoke();
                onCompleteCallBack?.Invoke();
                return;
            }

            DOTween.Sequence()
                   .SetId(GenerateTweenId(transform, animation.AnimationType, UClipType.Rotate))
                   .SetUpdate(IgnoreUnityTimescale)
                   .SetSpeedBased(AnimationSpeedBased)
                   .OnStart(() => { onStartCallBack?.Invoke(); })
                   .OnComplete(() => { onCompleteCallBack?.Invoke(); })
                   .Append(RotateTween(transform, animation, start, end))
                   .Play();
        }

        public static void Scale(RectTransform transform, UAnimation animation, Vector3 start, Vector3 end, bool instantAnimation = false, UnityAction onStartCallBack = null, UnityAction onCompleteCallBack = null)
        {
            if (!animation.Scale.Enabled && !instantAnimation)
                return;

            if (instantAnimation)
            {
                transform.localScale = end;
                onStartCallBack?.Invoke();
                onCompleteCallBack?.Invoke();
                return;
            }

            DOTween.Sequence()
                   .SetId(GenerateTweenId(transform, animation.AnimationType, UClipType.Scale))
                   .SetUpdate(IgnoreUnityTimescale)
                   .SetSpeedBased(AnimationSpeedBased)
                   .OnStart(() => { onStartCallBack?.Invoke(); })
                   .OnComplete(() => { onCompleteCallBack?.Invoke(); })
                   .Append(ScaleTween(transform, animation, start, end))
                   .Play();
        }

        public static void Fade(RectTransform transform, UAnimation animation, float start, float end, bool instantAnimation = false, UnityAction onStartCallBack = null, UnityAction onCompleteCallBack = null)
        {
            if (!animation.Fade.Enabled && !instantAnimation)
                return;

            CanvasGroup canvasGroup = transform.GetComponent<CanvasGroup>() ?? transform.gameObject.AddComponent<CanvasGroup>();
            if (instantAnimation)
            {
                canvasGroup.alpha = end;
                onStartCallBack?.Invoke();
                onCompleteCallBack?.Invoke();
                return;
            }

            DOTween.Sequence()
                   .SetId(GenerateTweenId(transform, animation.AnimationType, UClipType.Fade))
                   .SetUpdate(IgnoreUnityTimescale)
                   .SetSpeedBased(AnimationSpeedBased)
                   .OnStart(() => { onStartCallBack?.Invoke(); })
                   .OnComplete(() => { onCompleteCallBack?.Invoke(); })
                   .Append(FadeTween(transform, animation, start, end))
                   .Play();
        }

        #endregion

        #region MoveLoop, RotateLoop, ScaleLoop, FadeLoop

        /// <summary> Moves the specified target by animating the anchoredPosition3D value in a loop </summary>
        /// <param name="target"> Target RectTransform </param>
        /// <param name="animation"> Animation settings  </param>
        /// <param name="startValue"> Start anchoredPosition3D for the animation </param>
        /// <param name="onStartCallback"> Callback executed when the animation starts playing </param>
        /// <param name="onCompleteCallback"> Callback executed when the animation completed playing </param>
        public static void MoveLoop(RectTransform target, UAnimation animation, Vector3 startValue, UnityAction onStartCallback = null, UnityAction onCompleteCallback = null)
        {
            if (!animation.Move.Enabled) return;
            if (animation.AnimationType != UAnimationType.Loop) return;

            // positionA <---> startPosition <---> positionB
            Vector3 positionA = MoveLoopPositionA(animation, startValue);
            //            Vector3 positionB = MoveLoopPositionB(animation, startValue);

            Sequence loopSequence = DOTween.Sequence()
                                           .SetId(GenerateTweenId(target, animation.AnimationType, UClipType.Move))
                                           .SetUpdate(IgnoreUnityTimescale)
                                           .SetSpeedBased(AnimationSpeedBased)
                                           .Append(MoveLoopTween(target, animation, startValue))
                                           .SetLoops(animation.Move.LoopTimes, animation.Move.LoopType)
                                           .OnComplete(() =>
                                                       {
                                                           if (onCompleteCallback != null) onCompleteCallback.Invoke();
                                                       })
                                           .OnKill(() =>
                                                   {
                                                       if (onCompleteCallback != null) onCompleteCallback.Invoke();
                                                   })
                                           .Pause();


            Tween startTween = target.DOAnchorPos(positionA, animation.Move.Duration / 2f)
                                     .SetDelay(animation.Move.Delay)
                                     .SetUpdate(IgnoreUnityTimescale)
                                     .SetSpeedBased(AnimationSpeedBased)
                                     .Pause();


            DOTween.Sequence()
                   .SetId(GenerateTweenId(target, animation.AnimationType, UClipType.Move))
                   .SetUpdate(IgnoreUnityTimescale)
                   .SetSpeedBased(AnimationSpeedBased)
                   .Append(startTween)
                   .OnStart(() =>
                            {
                                if (onStartCallback != null) onStartCallback.Invoke();
                            })
                   .OnComplete(() =>
                               {
                                   loopSequence.Play();
                               });
        }

        public static void RotateLoop(RectTransform target, UAnimation animation, Vector3 startValue, UnityAction onStartCallback = null, UnityAction onCompleteCallback = null)
        {
            if (!animation.Rotate.Enabled) return;
            if (animation.AnimationType != UAnimationType.Loop) return;

            // rotationA <---> startRotation <---> rotationB
            Vector3 rotationA = RotateLoopRotationA(animation, startValue);
            //            Vector3 rotationB = RotateLoopRotationB(animation, startValue);

            Sequence loopSequence = DOTween.Sequence()
                                           .SetId(GenerateTweenId(target, animation.AnimationType, UClipType.Rotate))
                                           .SetUpdate(IgnoreUnityTimescale)
                                           .SetSpeedBased(AnimationSpeedBased)
                                           .Append(RotateLoopTween(target, animation, startValue))
                                           .SetLoops(animation.Rotate.LoopTimes, animation.Rotate.LoopType)
                                           .OnComplete(() =>
                                                       {
                                                           if (onCompleteCallback != null) onCompleteCallback.Invoke();
                                                       })
                                           .OnKill(() =>
                                                   {
                                                       if (onCompleteCallback != null) onCompleteCallback.Invoke();
                                                   })
                                           .Pause();

            Tween startTween = target.DOLocalRotate(rotationA, animation.Rotate.Duration / 2f, animation.Rotate.RotateMode)
                                     .SetDelay(animation.Rotate.Delay)
                                     .SetUpdate(IgnoreUnityTimescale)
                                     .SetSpeedBased(AnimationSpeedBased)
                                     .Pause();


            DOTween.Sequence()
                   .SetId(GenerateTweenId(target, animation.AnimationType, UClipType.Rotate))
                   .SetUpdate(IgnoreUnityTimescale)
                   .SetSpeedBased(AnimationSpeedBased)
                   .Append(startTween)
                   .OnStart(() =>
                            {
                                if (onStartCallback != null) onStartCallback.Invoke();
                            })
                   .OnComplete(() =>
                               {
                                   loopSequence.Play();
                               });
        }

        public static void ScaleLoop(RectTransform target, UAnimation animation, UnityAction onStartCallback = null, UnityAction onCompleteCallback = null)
        {
            if (!animation.Scale.Enabled) return;
            if (animation.AnimationType != UAnimationType.Loop) return;

            Sequence loopSequence = DOTween.Sequence()
                                           .SetId(GenerateTweenId(target, animation.AnimationType, UClipType.Scale))
                                           .SetUpdate(IgnoreUnityTimescale)
                                           .SetSpeedBased(AnimationSpeedBased)
                                           .Append(ScaleLoopTween(target, animation))
                                           .SetLoops(animation.Scale.LoopTimes, animation.Scale.LoopType)
                                           .OnComplete(() =>
                                                       {
                                                           if (onCompleteCallback != null) onCompleteCallback.Invoke();
                                                       })
                                           .OnKill(() =>
                                                   {
                                                       if (onCompleteCallback != null) onCompleteCallback.Invoke();
                                                   })
                                           .Pause();


            Tween startTween = target.DOScale(animation.Scale.From, animation.Scale.Duration / 2f)
                                     .SetDelay(animation.Scale.Delay)
                                     .SetUpdate(IgnoreUnityTimescale)
                                     .SetSpeedBased(AnimationSpeedBased)
                                     .Pause();


            DOTween.Sequence()
                   .SetId(GenerateTweenId(target, animation.AnimationType, UClipType.Scale))
                   .SetUpdate(IgnoreUnityTimescale)
                   .SetSpeedBased(AnimationSpeedBased)
                   .Append(startTween)
                   .OnStart(() =>
                            {
                                if (onStartCallback != null) onStartCallback.Invoke();
                            })
                   .OnComplete(() =>
                               {
                                   loopSequence.Play();
                               });
        }

        public static void FadeLoop(RectTransform target, UAnimation animation, UnityAction onStartCallback = null, UnityAction onCompleteCallback = null)
        {
            if (!animation.Fade.Enabled) return;
            if (animation.AnimationType != UAnimationType.Loop) return;

            CanvasGroup canvasGroup = target.GetComponent<CanvasGroup>() != null ? target.GetComponent<CanvasGroup>() : target.gameObject.AddComponent<CanvasGroup>();

            Sequence loopSequence = DOTween.Sequence()
                                           .SetId(GenerateTweenId(target, animation.AnimationType, UClipType.Fade))
                                           .SetUpdate(IgnoreUnityTimescale)
                                           .SetSpeedBased(AnimationSpeedBased)
                                           .Append(FadeLoopTween(target, animation))
                                           .SetLoops(animation.Fade.LoopTimes, animation.Fade.LoopType)
                                           .OnComplete(() =>
                                                       {
                                                           if (onCompleteCallback != null) onCompleteCallback.Invoke();
                                                       })
                                           .OnKill(() =>
                                                   {
                                                       if (onCompleteCallback != null) onCompleteCallback.Invoke();
                                                   })
                                           .Pause();


            Tween startTween = canvasGroup.DOFade(animation.Fade.From, animation.Fade.Duration / 2f)
                                          .SetDelay(animation.Fade.Delay)
                                          .SetUpdate(IgnoreUnityTimescale)
                                          .SetSpeedBased(AnimationSpeedBased)
                                          .Pause();


            DOTween.Sequence()
                   .SetId(GenerateTweenId(target, animation.AnimationType, UClipType.Fade))
                   .SetUpdate(IgnoreUnityTimescale)
                   .SetSpeedBased(AnimationSpeedBased)
                   .Append(startTween)
                   .OnStart(() =>
                            {
                                if (onStartCallback != null) onStartCallback.Invoke();
                            })
                   .OnComplete(() =>
                               {
                                   loopSequence.Play();
                               });
        }

        #endregion

        #endregion

        #region Extension Methods - tween - SetEase

        public static void SetEaseByClip(this Tween tween, IAnimationEase animationEase)
        {
            switch (animationEase.EaseType)
            {
                case UEaseType.Ease: tween.SetEase(animationEase.Ease); break;
                case UEaseType.Curve: tween.SetEase(animationEase.Curve); break;
            }
        }

        #endregion

        #region Helper Methods

        private static string GenerateTweenId(RectTransform target, UAnimationType animationType, UClipType clipType)
        {
            return target.GetInstanceID() + animationType.ToString() + clipType.ToString();
        }

        public static void StopAnimation(RectTransform transform, UAnimationType animationType, bool complete = false)
        {
            if (transform == null)
                return;

            DOTween.Kill(GenerateTweenId(transform, animationType, UClipType.Move), complete);
            DOTween.Kill(GenerateTweenId(transform, animationType, UClipType.Rotate), complete);
            DOTween.Kill(GenerateTweenId(transform, animationType, UClipType.Scale), complete);
            DOTween.Kill(GenerateTweenId(transform, animationType, UClipType.Fade), complete);
        }

        public static Vector3 GetAnimationMoveFrom(RectTransform target, UAnimation animation, Vector3 startValue)
        {
            switch (animation.AnimationType)
            {
                case UAnimationType.Show:
                    return animation.Move.UseCustomFromAndTo ? animation.Move.From : GetPositionByDirection(target, animation, animation.Move.UseCustomFromAndTo ? animation.Move.CustomPosition : startValue);
                case UAnimationType.Hide:
                    return animation.Move.UseCustomFromAndTo ? animation.Move.From : startValue;
                default:
                    return UIAnimator.DEFAULT_START_POSITION;
            }
        }

        public static Vector3 GetAnimationMoveTo(RectTransform target, UAnimation animation, Vector3 startValue)
        {
            switch (animation.AnimationType)
            {
                case UAnimationType.Show:
                    return animation.Move.UseCustomFromAndTo ? animation.Move.To : startValue;
                case UAnimationType.Hide:
                    return animation.Move.UseCustomFromAndTo ? animation.Move.To : GetPositionByDirection(target, animation, animation.Move.UseCustomFromAndTo ? animation.Move.CustomPosition : startValue);
                default:
                    return UIAnimator.DEFAULT_START_POSITION;
            }
        }

        public static Vector3 GetAnimationRotateFrom(UAnimation animation, Vector3 startValue)
        {
            switch (animation.AnimationType)
            {
                case UAnimationType.Show: return animation.Rotate.From;
                case UAnimationType.Hide: return animation.Rotate.UseCustomFromAndTo ? animation.Rotate.From : startValue;
                default: return DEFAULT_START_ROTATION;
            }
        }

        public static Vector3 GetAnimationRotateTo(UAnimation animation, Vector3 startValue)
        {
            switch (animation.AnimationType)
            {
                case UAnimationType.Show: return animation.Rotate.UseCustomFromAndTo ? animation.Rotate.To : startValue;
                case UAnimationType.Hide: return animation.Rotate.To;
                default: return DEFAULT_START_ROTATION;
            }
        }

        public static Vector3 GetAnimationScaleFrom(UAnimation animation, Vector3 startValue)
        {
            Vector3 value;
            switch (animation.AnimationType)
            {
                case UAnimationType.Show: value = animation.Scale.From; break;
                case UAnimationType.Hide: value = animation.Scale.UseCustomFromAndTo ? animation.Scale.From : startValue; break;
                default: value = DEFAULT_START_SCALE; break;
            }

            return new Vector3(value.x, value.y, 1f); ;
        }

        public static Vector3 GetAnimationScaleTo(UAnimation animation, Vector3 startValue)
        {
            Vector3 value;
            switch (animation.AnimationType)
            {
                case UAnimationType.Show: value = animation.Scale.UseCustomFromAndTo ? animation.Scale.To : startValue; break;
                case UAnimationType.Hide: value = animation.Scale.To; break;
                default: value = DEFAULT_START_SCALE; break;
            }

            return new Vector3(value.x, value.y, 1f); ;
        }

        public static float GetAnimationFadeFrom(UAnimation animation, float startValue)
        {
            switch (animation.AnimationType)
            {
                case UAnimationType.Show: return animation.Fade.From;
                case UAnimationType.Hide: return animation.Fade.UseCustomFromAndTo ? animation.Fade.From : startValue;
                default: return DEFAULT_START_ALPHA;
            }
        }

        public static float GetAnimationFadeTo(UAnimation animation, float startValue)
        {
            switch (animation.AnimationType)
            {
                case UAnimationType.Show: return animation.Fade.UseCustomFromAndTo ? animation.Fade.To : startValue;
                case UAnimationType.Hide: return animation.Fade.To;
                default: return DEFAULT_START_ALPHA;
            }
        }

        public static Vector3 GetPositionByDirection(RectTransform target, UAnimation animation, Vector3 position)
        {
            Canvas canvas = target.GetComponent<Canvas>();
            Rect rootCanvasRect = canvas.rootCanvas.GetComponent<RectTransform>().rect;
            float xOffset = rootCanvasRect.width / 2 + target.rect.width * target.pivot.x;
            float yOfsset = rootCanvasRect.height / 2 + target.rect.height * target.pivot.y;
            switch (animation.Move.Direction)
            {
                case UDirection.Left: return new Vector3(-xOffset, position.y, position.z);
                case UDirection.Right: return new Vector3(xOffset, position.y, position.z);
                case UDirection.Top: return new Vector3(position.x, yOfsset, position.z);
                case UDirection.Bottom: return new Vector3(position.x, -yOfsset, position.z);
                case UDirection.TopLeft: return new Vector3(-xOffset, yOfsset, position.z);
                case UDirection.TopCenter: return new Vector3(0, yOfsset, position.z);
                case UDirection.TopRight: return new Vector3(xOffset, yOfsset, position.z);
                case UDirection.MiddleLeft: return new Vector3(-xOffset, 0, position.z);
                case UDirection.MiddleCenter: return new Vector3(0, 0, position.z);
                case UDirection.MiddleRight: return new Vector3(xOffset, 0, position.z);
                case UDirection.BottomLeft: return new Vector3(-xOffset, -yOfsset, position.z);
                case UDirection.BottomCenter: return new Vector3(0, -yOfsset, position.z);
                case UDirection.BottomRight: return new Vector3(xOffset, -yOfsset, position.z);
                case UDirection.CustomPosition: return animation.Move.CustomPosition;
                default: return Vector3.zero;
            }
        }

        #endregion
    }
}