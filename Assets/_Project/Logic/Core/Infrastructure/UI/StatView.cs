using System;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.Logic.Tower
{
    public class StatView : MonoBehaviour
    {
        [SerializeField] private Slider _slider;

        public void Draw(float value) => 
            _slider.value = value;
    }
}