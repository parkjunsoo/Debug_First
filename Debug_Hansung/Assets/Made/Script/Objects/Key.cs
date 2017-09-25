using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : Item {

    protected override void PickUp()
    {
        player.GetComponent<PlayerControl>().getKey = true;
        GameObject.Find("SubTitle").GetComponent<Subtitle>().Printing("강의실 열쇠.. 일단 챙겨보자");
    }
}
