using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UnityEngine.UI.FitterGroup
{
    public interface ILayoutable
    {
        int ItemCount { get; }
        Padding Padding { get; }
        Vector2 CellSize { get; }
        Vector2 CellSpacing { get; }
        int ConstraintCount { get; }
        ScrollRect ScrollRect { get; }
        RectTransform TargetRect { get; }
        RectTransform EnableItem(int index);
        void DisableItem(int index, RectTransform itemRect);
    }
}
