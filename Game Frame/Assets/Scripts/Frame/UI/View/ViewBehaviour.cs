using System;
using UnityEngine;
using Lzj.UI.Animation;
using Sirenix.OdinInspector;

namespace Lzj.UI.View
{
    [Serializable]
    public class ViewBehaviour
    {
        [HideLabel]
        public UAnimation Animation = null;

        [HideInInspector]
        public UAnimationType AnimationType;

        public ViewBehaviour(UAnimationType animationType)
        {
            this.AnimationType = animationType;
            this.Animation = new UAnimation(animationType);
        }
    }
}
