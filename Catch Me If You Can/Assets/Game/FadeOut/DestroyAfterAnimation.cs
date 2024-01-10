using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterAnimation : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(AnimationFinished());
    }

    private IEnumerator AnimationFinished()
    {
        yield return new WaitForSecondsRealtime(2.5f);
        Destroy(gameObject);
    }
}
