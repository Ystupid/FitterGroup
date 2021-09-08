using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityEngine.UI.FitterGroup
{
    public class HorizontalLayout : LayoutBase
    {
        public override void Init(ILayoutable layoutable)
        {
            base.Init(layoutable);
            ScrollRect.horizontal = true;
            ScrollRect.vertical = false;

            TargetRect.anchorMin = new Vector2(0, 0);
            TargetRect.anchorMax = new Vector2(0, 1);
            TargetRect.pivot = new Vector2(0, 0.5f);
        }

        public override void Refresh()
        {
            base.Refresh();
            var anchorPosition = TargetRect.anchoredPosition;
            anchorPosition.y = 0;
            TargetRect.anchoredPosition = anchorPosition;
        }

        protected override void ResetVisualScope()
        {
            m_CurrentMinIndex = Mathf.CeilToInt((-AnchorPosition.x - Spacing.x - Padding.Left) / Spacing.x) * ConstraintCount;
            m_CurrentMaxIndex = Mathf.CeilToInt((-AnchorPosition.x - Spacing.x - Padding.Left + CellSpacing.x + ViewSize.x) / Spacing.x) * ConstraintCount + (ConstraintCount - 1);

            m_CurrentMinIndex = Mathf.Clamp(m_CurrentMinIndex, 0, ItemCount - 1);
            m_CurrentMaxIndex = Mathf.Clamp(m_CurrentMaxIndex, 0, ItemCount - 1);
        }

        protected override RectTransform ResetPosition(RectTransform itemRect, int index)
        {
            m_ItemPosition.y = Spacing.y * (-index % ConstraintCount) - Padding.Top - (CellSize.y * itemRect.pivot.y);
            m_ItemPosition.x = Spacing.x * (index / ConstraintCount) + Padding.Left;
            m_ItemPosition.x += (CellSize.x * itemRect.pivot.x);
            itemRect.anchoredPosition = m_ItemPosition;

            return itemRect;
        }

        protected override Vector2 CalculateContentSize()
        {
            var contentSize = new Vector2();
            contentSize.x = Mathf.Ceil(ItemCount * 1.0f / ConstraintCount) * Spacing.x - CellSpacing.x + Padding.Width;
            contentSize.y = Spacing.y * ConstraintCount - CellSpacing.y + Padding.Height;
            return contentSize;
        }
    }
}