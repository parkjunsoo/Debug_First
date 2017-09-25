using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : Item {
    
    protected override void PickUp()
    {
        player.GetComponent<PlayerControl>().getKnife = true;
        GameObject.Find("SubTitle").GetComponent<Subtitle>().Printing("커터칼.. 혹시 모르니 챙겨두자");
    }
}
