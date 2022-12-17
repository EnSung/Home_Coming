using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery : Item
{
    public override void Use()
    {
        IngameManager.Instance.player.OnHeal(2);
        base.Use();
    }


}
