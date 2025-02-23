using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : MonoBehaviour
{
    public int attackRoll; // The roll required for the attack to go through
    public int attacks; // The number of attacks that the weapon can do
    public int normalDamage; // The damage dealt if the roll gets past the attack roll, but the roll isn't a six
    public int criticalDamage; // The damage dealt if the roll is a six


    public int GetAttacks()
    {
        return attacks;  // Returns attacks
    }
    public int GetAttackRoll()
    {
        return attackRoll;  // Returns attack roll
    }
    public int GetNormalDamage()
    {
        return normalDamage;  // Returns normal damage
    }
    public int GetCriticalDamage()
    {
        return criticalDamage;  // Returns critical damage
    }
}
