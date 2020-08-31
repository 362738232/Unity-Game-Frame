using UnityEngine;

namespace Lzj.UI.Animation
{
    [System.Serializable]
    public class UAnimation
    {
        [HideInInspector]
        public UAnimationType AnimationType = UAnimationType.Undefined;

        public Move Move;

        public Rotate Rotate;

        public Scale Scale;

        public Fade Fade;

        public bool Enabled
        {
            get
            {
                switch (this.AnimationType)
                {
                    case UAnimationType.Undefined: return false;
                    case UAnimationType.Show: return Move.Enabled || Rotate.Enabled || Scale.Enabled || Fade.Enabled;
                    case UAnimationType.Hide: return Move.Enabled || Rotate.Enabled || Scale.Enabled || Fade.Enabled;
                    case UAnimationType.Loop: return Move.Enabled || Rotate.Enabled || Scale.Enabled || Fade.Enabled;
                    case UAnimationType.Punch: return Move.Enabled || Rotate.Enabled || Scale.Enabled;
                    case UAnimationType.State: return Move.Enabled || Rotate.Enabled || Scale.Enabled || Fade.Enabled;
                    default: return false;
                }
            }
        }

        public float Delay
        {
            get
            {
                if (!this.Enabled)
                {
                    return 0.0f;
                }
                else
                {
                    return Mathf.Min(Move.Enabled ? Move.Delay : 10000,
                                     Rotate.Enabled ? Rotate.Delay : 10000,
                                     Scale.Enabled ? Scale.Delay : 10000,
                                     Fade.Enabled ? Scale.Delay : 10000);
                }
            }
        }

        public float Duration
        {
            get
            {
                return Mathf.Max(Move.Enabled ? Move.TotalDuration : 0,
                                 Rotate.Enabled ? Rotate.TotalDuration : 0,
                                 Scale.Enabled ? Scale.TotalDuration : 0,
                                 Fade.Enabled ? Fade.TotalDuration : 0);
            }
        }

        public UAnimation(UAnimationType animationType)
        {
            this.Move = new Move(animationType);
            this.Rotate = new Rotate(animationType);
            this.Scale = new Scale(animationType);
            this.Fade = new Fade(animationType);
            this.AnimationType = animationType;
        }

        public UAnimation Copy()
        {
            return new UAnimation(this.AnimationType)
            {
                Move = this.Move.Copy(),
                Rotate = this.Rotate.Copy(),
                Scale = this.Scale.Copy(),
                Fade = this.Fade.Copy()
            };
        }
    }
}
