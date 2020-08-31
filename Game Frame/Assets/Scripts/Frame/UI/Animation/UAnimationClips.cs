using System;
using UnityEngine;
using DG.Tweening;
using Sirenix.OdinInspector;

namespace Lzj.UI.Animation
{
    public interface IAnimationEase
    {
        UEaseType EaseType { get; }

        Ease Ease { get; }

        AnimationCurve Curve { get; }
    }

    [Serializable]
    public abstract class AnimationValues<T>
    {
        public T From, To, By;
    }

    [Serializable]
    public class UAnimaionClip<T> : AnimationValues<T>, IAnimationEase
    {
        [HideInInspector]
        public UAnimationType AnimationType;

        public float Delay = UIAnimator.DefaultDelay;

        public float Duration = UIAnimator.DefaultDuration;

        public bool Enabled = UIAnimator.DefaultAnimationClipEnabled;

        public bool UseCustomFromAndTo = false;

        public int Vibrato = UIAnimator.DefaultVibrato;

        public float Elasticity = UIAnimator.DefaultElasticity;

        public int LoopTimes = UIAnimator.DefaultLoopTimes;

        public LoopType LoopType = UIAnimator.DefaultLoopType;

        public UEaseType EaseType = UIAnimator.DefaultEaseType;

        public Ease Ease = UIAnimator.DefaultEase;

        public AnimationCurve Curve = default;

        public float TotalDuration => this.Delay + this.Duration;

        UEaseType IAnimationEase.EaseType => this.EaseType;

        Ease IAnimationEase.Ease => this.Ease;

        AnimationCurve IAnimationEase.Curve => this.Curve;

        public UAnimaionClip(UAnimationType animationType)
        {
            this.AnimationType = animationType;
        }

        protected UAnimaionClip<T> CopySelf()
        {
            return new UAnimaionClip<T>(this.AnimationType)
            {
                Delay = this.Delay,
                Duration = this.Duration,
                Enabled = this.Enabled,
                UseCustomFromAndTo = this.UseCustomFromAndTo,
                Vibrato = this.Vibrato,
                Elasticity = this.Elasticity,
                LoopTimes = this.LoopTimes,
                LoopType = this.LoopType,
                EaseType = this.EaseType,
                Ease = this.Ease,
                Curve = this.Curve,
            };
        }

        public virtual void Reset()
        {
            this.Enabled = UIAnimator.DefaultAnimationClipEnabled;
            this.LoopType = UIAnimator.DefaultLoopType;
            this.EaseType = UIAnimator.DefaultEaseType;
            this.Ease = UIAnimator.DefaultEase;
            this.Curve = default;
            this.Vibrato = UIAnimator.DefaultVibrato;
            this.Elasticity = UIAnimator.DefaultElasticity;
            this.LoopTimes = UIAnimator.DefaultLoopTimes;
            this.Delay = UIAnimator.DefaultDelay;
            this.Duration = UIAnimator.DefaultDuration;
            this.UseCustomFromAndTo = false;
        }
    }

    [Serializable]
    public class Move : UAnimaionClip<Vector3>
    {
        public UDirection Direction;
        public Vector3 CustomPosition;

        public Move(UAnimationType animationType) : base(animationType)
        {
        }

        public Move Copy()
        {
            var tmep = this.CopySelf() as Move;
            tmep.Direction = this.Direction;
            tmep.CustomPosition = this.CustomPosition;
            return tmep;
        }

        public override void Reset()
        {
            base.Reset();
            this.Direction = UIAnimator.DefaultDirection;
            this.CustomPosition = Vector3.zero;
        }
    }

    [Serializable]
    public class Rotate : UAnimaionClip<Vector3>
    {
        public RotateMode RotateMode;

        public Rotate(UAnimationType animationType) : base(animationType)
        {
        }

        public Rotate Copy()
        {
            var tmep = this.CopySelf() as Rotate;
            tmep.RotateMode = this.RotateMode;
            return tmep;
        }

        public override void Reset()
        {
            base.Reset();
            this.RotateMode = UIAnimator.DefaultRotateMode;
        }
    }

    [Serializable]
    public class Scale : UAnimaionClip<Vector3>
    {
        public Scale(UAnimationType animationType) : base(animationType)
        {
        }

        public Scale Copy()
        {
            return this.CopySelf() as Scale;
        }

        public override void Reset()
        {
            base.Reset();
        }
    }

    [Serializable]
    public class Fade : UAnimaionClip<float>
    {
        public Fade(UAnimationType animationType) : base(animationType)
        {
        }

        public Fade Copy()
        {
            return this.CopySelf() as Fade;
        }

        public override void Reset()
        {
            base.Reset();
        }
    }

}
