using System;
using System.Collections.Generic;
using System.Linq;
using Factories;
using UI;
using Units;
using UnityEngine;

namespace Managers
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }

        public static event Action OnGameStart;

        public BarrackFactory BarrackFactory;
        public PowerPlantFactory PowerPlantFactory;
        public SoldierFactory SoldierFactory;
        
        private void Awake()
        {
            if (Instance == null)
                Instance = this;
            else
                Destroy(Instance);
        }

        private void Start()
        {
            OnGameStart?.Invoke();
        }
    }
}
