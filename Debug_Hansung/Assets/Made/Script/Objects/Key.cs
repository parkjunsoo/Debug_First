using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : Item {

    protected override void PickUp()
    {
        player.GetComponent<PlayerControl>().getKey = true;
    }
}
