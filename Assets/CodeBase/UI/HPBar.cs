using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.UI
{
    public class HPBar : MonoBehaviour
    {
        public Image ImageCurrent;

        public void SetValue(float current, float max) =>
            ImageCurrent.fillAmount = current / max;
    }
}