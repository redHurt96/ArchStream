using UnityEngine;

namespace _Project.Logic.Common.Domain
{
    [CreateAssetMenu(menuName = "Create TowerDataContainer", fileName = "TowerDataContainer", order = 0)]
    public class TowerDataContainer : ScriptableObject
    {
        [field:SerializeField] public TowerData Value { get; private set; }
    }
}