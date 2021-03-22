using Managers;
using UI;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Units
{
    public class BarrackController : UnitController
    {
        public override void OnPointerClick(PointerEventData eventData)
        {
            base.OnPointerClick(eventData);
            InfoCanvasController.Instance.SetInfo(InfoCanvasController.InfoUnit.Barrack);
        }
        
        public override void RemoveSelf()
        {
            GameManager.Instance.BarrackFactory.Units.Remove(this);
        }
    }
}
