using UnityEngine;
using UnityEngine.UI;

public class TankHealthBar : MonoBehaviour
{
    #region Variables

    private Slider slider;

    #endregion

    #region Buildin Methods

    void Start()
    {

        slider = gameObject.GetComponent<Slider>();

    }

    #endregion

    #region Custom Methods

    public void SetHealth(float health)
    {

        slider.value = health;

    }

    public void SetMaxHealth(float health)
    {

        slider.maxValue = health;
        slider.value = health;

    }

    #endregion
}
