using System;
using UI;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Units
{
    public abstract class UnitController: MonoBehaviour, IPointerClickHandler
    {
        public bool IsPlaced, IsPlaceable;
        
        private SpriteRenderer _spriteRenderer;
        
        public SpriteRenderer SpriteRenderer
        {
            get => _spriteRenderer;
            set => _spriteRenderer = value;
        }
        
        private void Awake()
        {
            IsPlaceable = true;
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }
        
        //Triggers to check shop component placement
        public virtual void OnTriggerEnter2D(Collider2D other)
        {
            if (IsPlaced) return;
            var isUnit = other.gameObject.TryGetComponent<UnitController>(out var unit);
            if (isUnit)
            {
                IsPlaceable = false;
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (IsPlaced) return;
            var isUnit = other.gameObject.TryGetComponent<UnitController>(out var unit);
            if (isUnit)
            {
                IsPlaceable = true;
            }
        }

        public virtual void OnPointerClick(PointerEventData eventData)
        {
            if (!IsPlaced) return;
            InfoCanvasController.Instance.Show();
        }

        //Remove from the list
        public abstract void RemoveSelf();
    }
}
