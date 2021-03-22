using System;
using DG.Tweening;
using Managers;
using Units;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UI.ShopComponents
{
    public class ShopComponentController : MonoBehaviour, IDragHandler, IEndDragHandler
    {
        public UnitController Unit;

        //Creates a dragable unit component
        public void OnDrag(PointerEventData eventData)
        {
            var hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            var x = Mathf.Round(hit.point.x);
            var y = Mathf.Round(hit.point.y);
            Unit.GetComponent<Rigidbody2D>().DOLocalPath(new[]{(new Vector2(x, y))}, 0);
            Unit.SpriteRenderer.color = Unit.IsPlaceable ? Color.white : Color.red;

        }
        
        //Places or destroys the unit based on bools
        public void OnEndDrag(PointerEventData eventData)
        {
            if (Unit.IsPlaceable)
            {
                Unit.IsPlaced = true;
                Unit.IsPlaceable = false;
                AstarPath.active.Scan();
            }
            else
            {
                Unit.RemoveSelf();
                Destroy(Unit.gameObject);
            }
        }
    }
}
