using Managers;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UI.ShopComponents
{
    public class BarrackItemController : ShopComponentController, IBeginDragHandler
    {
        public void OnBeginDrag(PointerEventData eventData)
        {
            Unit = GameManager.Instance.BarrackFactory.GetNewInstance();
        }
    }
}
