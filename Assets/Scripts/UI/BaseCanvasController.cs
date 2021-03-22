using DG.Tweening;
using UnityEngine;

namespace UI
{
    public class BaseCanvasController : MonoBehaviour
    {
        private Canvas _canvas;
        private CanvasGroup _canvasGroup;
        
        protected virtual void Awake()
        {
            _canvas = GetComponent<Canvas>();
            _canvasGroup = GetComponent<CanvasGroup>();
        }
        
        public void Show()
        {
            _canvas.enabled = true;
            _canvasGroup.DOFade(1, .2f);
            _canvasGroup.blocksRaycasts = true;
        }

        public void Hide()
        {
            _canvasGroup.blocksRaycasts = false;
            _canvasGroup.DOFade(0, .2f).OnComplete(delegate
            {
                _canvas.enabled = false;
            });
        }

    }
}
