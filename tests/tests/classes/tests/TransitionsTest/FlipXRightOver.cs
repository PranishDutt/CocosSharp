using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using cocos2d;

namespace tests
{
    public class FlipXRightOver : CCTransitionFlipX
    {
        public FlipXRightOver(float t, CCScene s) : base(t, s, tOrientation.kOrientationRightOver)
        {

        }
        [Obsolete("Use the parameter ctor instead.")]
        public new static CCTransitionScene Create(float t, CCScene s)
        {
            return (new FlipXRightOver(t, s));
//            return CCTransitionFlipX.Create(t, s, tOrientation.kOrientationRightOver);
        }
    }
}
