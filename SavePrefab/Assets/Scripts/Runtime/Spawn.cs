using System.Collections;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject Prefab;

    IEnumerator Start()
    {
        yield return new WaitForSeconds(2f);
        Instantiate(Prefab);
    }

}
