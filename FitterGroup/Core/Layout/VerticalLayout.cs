using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityEngine.UI.FitterGroup
{
    public class VerticalLayout : LayoutBase
    {
        public override void Init(ILayoutable layoutable)
        {
            base.Init(layoutable);
            ScrollRect.horizontal = false;
            ScrollRect.vertical = true;

            TargetRect.anchorMin = new Vector2(0, 1);
            TargetRect.anchorMax = new Vector2(1, 1);
            TargetRect.pivot = new Vector2(0.5f, 1);
        }

        public override void Refresh()
        {
            base.Refresh();
            var anchorPosition = TargetRect.anchoredPosition;
            anchorPosition.x = 0;
            TargetRect.anchoredPosition = anchorPosition;
        }

        protected override void ResetVisualScope()
        {
            m_CurrentMinIndex = Mathf.CeilToInt((AnchorPosition.y - Spacing.y - Padding.Top) / Spacing.y) * ConstraintCount;
            m_CurrentMaxIndex = Mathf.CeilToInt((AnchorPosition.y - Spacing.y - Padding.Top + CellSpacing.y + ViewSize.y) / Spacing.y) * ConstraintCount + (ConstraintCount - 1);

            m_CurrentMinIndex = Mathf.Clamp(m_CurrentMinIndex, 0, ItemCount - 1);
            m_CurrentMaxIndex = Mathf.Clamp(m_CurrentMaxIndex, 0, ItemCount - 1);
        }

        protected override RectTransform ResetPosition(RectTransform itemRect, int index)
        {
            m_ItemPosition.x = Spacing.x * (index % ConstraintCount) + Padding.Left + (CellSize.x * itemRect.pivot.x);
            m_ItemPosition.y = Spacing.y * (-index / ConstraintCount) - Padding.Top;
            m_ItemPosition.y -= (CellSize.y * itemRect.pivot.y);
            itemRect.anchoredPosition = m_ItemPosition;

            return itemRect;
        }

        protected override Vector2 CalculateContentSize()
        {
            var contentSize = new Vector2();
            contentSize.x = Spacing.x * ConstraintCount - CellSpacing.x + Padding.Width;
            contentSize.y = Mathf.Ceil(ItemCount * 1.0f / ConstraintCount) * Spacing.y - CellSpacing.y + Padding.Height;
            return contentSize;
        }
    }
}