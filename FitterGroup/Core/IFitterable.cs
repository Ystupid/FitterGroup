using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UnityEngine.UI.FitterGroup
{
    public interface IFitterable
    {
        int ItemCount { get; }
        RectTransform EnableItem(int index);
        void DisableItem(int index, RectTransform itemRect);
    }
}