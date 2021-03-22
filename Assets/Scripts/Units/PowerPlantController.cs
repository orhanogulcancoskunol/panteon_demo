using Managers;
using UI;
using UnityEngine.EventSystems;

namespace Units
{
    public class PowerPlantController : UnitController
    {
        public override void OnPointerClick(PointerEventData eventData)
        {
            base.OnPointerClick(eventData);
            InfoCanvasController.Instance.SetInfo(InfoCanvasController.InfoUnit.PP);
        }
        
        public override void RemoveSelf()
        {
            GameManager.Instance.PowerPlantFactory.Units.Remove(this);
        }
    }
}
