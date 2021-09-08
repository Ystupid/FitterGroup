using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityEngine.UI.FitterGroup
{
    public static class LayoutHelper
    {
        public static LayoutBase GetLayout(FitterGroup.FitterAxis fitterAxis)
        {
            switch (fitterAxis)
            {
                case FitterGroup.FitterAxis.Horizontal:
                    return new HorizontalLayout();
                case FitterGroup.FitterAxis.Vertical:
                    return new VerticalLayout();
                default:
                    return new VerticalLayout();
            }
        }

        public static LayoutBase GetLayoutEditor(FitterGroup.FitterAxis fitterAxis)
        {
            switch (fitterAxis)
            {
                case FitterGroup.FitterAxis.Horizontal:
                    return new EditorHorizontalLayout();
                case FitterGroup.FitterAxis.Vertical:
                    return new EditorVerticalLayout();
                default:
                    return new EditorVerticalLayout();
            }
        }
    }
}