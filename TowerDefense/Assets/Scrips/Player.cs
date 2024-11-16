using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    static public int hp;
    static public int electrum;

    static public void damageRecieve(int damage)
    {
        hp -= damage;
    } 
}
