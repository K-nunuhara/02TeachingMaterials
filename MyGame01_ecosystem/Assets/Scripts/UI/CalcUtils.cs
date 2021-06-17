using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CalcUtils
{
    public static void LookTarget(Animal mover, GameObject target)
    {
        Vector3 direction = target.transform.position - mover.transform.position;
        direction.y = 0f;
        mover.transform.rotation = Quaternion.LookRotation(direction, Vector3.up);
    }

}
