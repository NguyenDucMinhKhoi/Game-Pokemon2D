using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPBar : MonoBehaviour
{
    [SerializeField] GameObject health;

    public void SetHP ( float hpNormallized )
    {
        health.transform .localScale = new Vector3(hpNormallized, 1f);
    }

    public IEnumerator SetHPSmooth(float newHp)
    {
        float curHp = health.transform .localScale.x;
        float changeAnt = curHp - newHp;

        while (curHp - newHp > Mathf.Epsilon)
        {
            curHp -= changeAnt * Time.deltaTime;
            health.transform .localScale = new Vector3(curHp, 1f);
            yield return null; 
        }
        health.transform.localScale = new Vector3(newHp, 1f);
    }
}
