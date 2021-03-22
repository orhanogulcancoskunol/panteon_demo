using System;
using System.Collections;
using System.Collections.Generic;
using Managers;
using UI.ShopComponents;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.UIElements;

namespace UI
{
    public class ShopCanvasController : BaseCanvasController, IPointerEnterHandler, IPointerExitHandler
    {
        public static ShopCanvasController Instance { get; private set; }
        public List<Transform> ShopComponentTransforms;
        public List<ShopComponentController> ShopItems;

        [SerializeField] private int _populationSize;
        private ScrollRect _scrollRect;
        
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

            _scrollRect = GetComponentInChildren<ScrollRect>();
            base.Awake();
        }

        private void OnEnable()
        {
            _scrollRect.onValueChanged.AddListener(CheckScrollRectBottom);
            GameManager.OnGameStart += PopulateShopList;
        }

        private void OnDisable()
        {
            _scrollRect.onValueChanged.RemoveListener(CheckScrollRectBottom);
            GameManager.OnGameStart -= PopulateShopList;
        }

        //Initial shop list items
        private void PopulateShopList()
        {
            for (var index = 0; index < ShopItems.Count; index++)
            {
                var item = ShopItems[index];
                for (var i = 0; i < _populationSize; i++)
                {
                    Instantiate(item, ShopComponentTransforms[index]);
                }
            }
        }
        //Returns center of the view at the near of the end
        private void CheckScrollRectBottom(Vector2 val)
        {
            if (_scrollRect.verticalNormalizedPosition <= .1f)
            {
                _scrollRect.verticalNormalizedPosition = .5f;
            }
        }
        
        //To fix conflict of camera zoom and scroll view
        public void OnPointerEnter(PointerEventData eventData)
        {
            Camera.main.GetComponent<CameraController>().IsAvailable = false;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            Camera.main.GetComponent<CameraController>().IsAvailable = true;
        }
    }
}
