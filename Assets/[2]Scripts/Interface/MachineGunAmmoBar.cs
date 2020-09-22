using UnityEngine;
using UnityEngine.UI;

/* 
 * Lista de objetos que usam esse script
 * AmmoBar
 */

public class MachineGunAmmoBar : MonoBehaviour
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

    public void SetAmmo (int ammo)
    {

        slider.value = ammo;

    }

    public void SetMaxAmmo (int ammo)
    {

        slider.maxValue = ammo;
        slider.value = ammo;

    }

    #endregion

}
