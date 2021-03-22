using Managers;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UI.ShopComponents
{
    public class PPItemController : ShopComponentController, IBeginDragHandler
    {
        public void OnBeginDrag(PointerEventData eventData)
        {
            Unit = GameManager.Instance.PowerPlantFactory.GetNewInstance();
        }
    }
}
