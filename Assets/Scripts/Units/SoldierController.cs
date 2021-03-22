using System;
using System.Linq;
using Managers;
using Pathfinding;
using UI;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Units
{
    public enum Side
    {
        Friendly,
        Enemy
    }
    public class SoldierController : UnitController
    {
        public Side SideOfSoldier;
        private AIDestinationSetter _aiDestinationSetter;

        private void Awake()
        {
            _aiDestinationSetter = GetComponent<AIDestinationSetter>();
        }

        private void Start()
        {
            //Selects the first opposite sided enemy
            var target = GameManager.Instance.SoldierFactory.Units
                .FirstOrDefault(x => x.GetComponent<SoldierController>() != null
                            && x.GetComponent<SoldierController>().SideOfSoldier != SideOfSoldier);
            if(target!=null)
                _aiDestinationSetter.target = target.transform;
        }
        
        public override void OnPointerClick(PointerEventData eventData)
        {
            base.OnPointerClick(eventData);
            InfoCanvasController.Instance.SetInfo(InfoCanvasController.InfoUnit.Soldier);
        }

        public override void RemoveSelf()
        {
            GameManager.Instance.SoldierFactory.Units.Remove(this);
        }

        //Each soldier destroys themselves on trigger
        public override void OnTriggerEnter2D(Collider2D other)
        {
            base.OnTriggerEnter2D(other);
            if (!other.GetComponent<SoldierController>()) return;
            RemoveSelf();
            Destroy(other.gameObject);
        }
    }
}
