using System.Collections.Generic;
using Managers;
using Units;
using UnityEngine;

namespace Factories
{
    public class UnitFactory<T> : MonoBehaviour where T : MonoBehaviour
    {
        public List<UnitController> Units = new List<UnitController>();
        [SerializeField] private T _prefab;
        [SerializeField] private Transform _tileMapTransform;
        
        public T GetNewInstance()
        {
            var unit = Instantiate(_prefab, _tileMapTransform);
            Units.Add(unit.GetComponent<UnitController>());
            return unit;
        }
    }
}
