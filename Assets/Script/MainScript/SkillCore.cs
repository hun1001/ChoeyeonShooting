using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillCore : MonoBehaviour
{
    [SerializeField]
    private GameObject core = null;
    private bool active = true;

    public void ActSkill()
    {
        if(active)
        {
            Instantiate(core, new Vector3(0, -15, 2), Quaternion.identity);
            StartCoroutine(Cool());
        }
    }
    private IEnumerator Cool()
    {
        if (active)
        {
            active = false;
            yield return new WaitForSeconds(5f);
            active = true;
        }
    }
}
