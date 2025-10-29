using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public static bool isShooting;

    void Update()
    {
        isShooting = InputActionManager.instance.GetShootAction().ReadValue<float>() > 0;
    }

}
