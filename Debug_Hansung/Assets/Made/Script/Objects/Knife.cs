using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : Item {
    
    protected override void PickUp()
    {
        player.GetComponent<PlayerControl>().getKnife = true;
    }
}
