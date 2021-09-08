using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityEngine.UI.FitterGroup
{
    public class EditorHorizontalLayout : HorizontalLayout
    {
        protected override int ItemCount => m_ItemMap.Count;

        protected override void EnableItem(int index)
        {
            if (!HasItem(index)) return;
            ResetPosition(ResetAnchor(m_ItemMap[index]), index);
        }

        public override void Clear()
        {
            m_ItemMap.Clear();
        }

        public override void Tick()
        {
            Clear();
            for (int i = 0; i < TargetRect.childCount; i++)
            {
                m_ItemMap.Add(i, TargetRect.GetChild(i).GetComponent<RectTransform>());
                EnableItem(i);
            }

            ResetContentRect();
        }
    }
}
