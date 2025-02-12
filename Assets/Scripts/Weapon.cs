using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int attackRoll;
    public int attacks;
    public int normalDamage;
    public int criticalDamage;
    public bool rangedWeapon;
    public bool meleeWeapon;

    public int GetAttacks()
    {
        return attacks;  // Returns wounds
    }
    public int GetAttackRoll()
    {
        return attackRoll;  // Returns wounds
    }
    public int GetNormalDamage()
    {
        return normalDamage;  // Returns wounds
    }
    public int GetCriticalDamage()
    {
        return criticalDamage;  // Returns wounds
    }
    public bool GetRangedWeapon()
    {
        return rangedWeapon;
    }
    public bool GetMeleeWeapon()
    {
        return meleeWeapon;
    }
}
