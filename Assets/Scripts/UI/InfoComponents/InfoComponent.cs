using Managers;
using TMPro;
using Units;
using UnityEngine;
using UnityEngine.UI;

namespace UI.InfoComponents
{
    public class InfoComponent : MonoBehaviour
    {
        public TextMeshProUGUI Header, UnitName;
        public Button ProductionButton;

        //Enables production button based on unit type
        public void SetProductionButton(InfoCanvasController.InfoUnit unit)
        {
            if (unit != InfoCanvasController.InfoUnit.Barrack) return;
            ProductionButton.onClick.RemoveAllListeners();
            ProductionButton.onClick.AddListener(SoldierProduction);
        }

        //Creates a new soldier on a random location with random side
        private static void SoldierProduction()
        {
            var unit = GameManager.Instance.SoldierFactory.GetNewInstance();
            unit.transform.localPosition = new Vector2(Random.Range(-16, 16), Random.Range(-16, 16));
            var randSide = Random.Range(0, 2);
            if (randSide == 1) unit.SideOfSoldier = Side.Enemy;
        }
    }
}
