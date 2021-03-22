using System;
using UI.InfoComponents;
using UnityEngine;

namespace UI
{
    public class InfoCanvasController : BaseCanvasController
    {
        public enum InfoUnit
        {
            Barrack,
            Soldier,
            PP
        }
        public static InfoCanvasController Instance { get; private set; }

        public InfoComponent InfoComponent, ActivityComponent;
        
        private InfoUnit _currentUnit;
        
        protected override void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(Instance);
            }
            base.Awake();
        }

        public void SetInfo(InfoUnit unit)
        {
            switch (unit)
            {
                case InfoUnit.Barrack:
                    InfoComponent.Header.text = "Barrack";
                    InfoComponent.UnitName.text = "B";
                    ActivityComponent.gameObject.SetActive(true);
                    ActivityComponent.Header.text = "PRODUCTION";
                    ActivityComponent.UnitName.text = "S";
                    ActivityComponent.SetProductionButton(InfoUnit.Barrack);
                    break;
                case InfoUnit.PP:
                    InfoComponent.Header.text = "Power Plant";
                    InfoComponent.UnitName.text = "PP";
                    ActivityComponent.gameObject.SetActive(false);
                    break;
                case InfoUnit.Soldier:
                    InfoComponent.Header.text = "Soldier";
                    InfoComponent.UnitName.text = "S";
                    ActivityComponent.gameObject.SetActive(false);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(unit), unit, null);
            }
        }
    }
}
