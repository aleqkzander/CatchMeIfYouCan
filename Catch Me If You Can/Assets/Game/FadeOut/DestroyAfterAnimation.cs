using System.Collections;
using UnityEngine;

public class DestroyAfterAnimation : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(AnimationFinished());
    }

    private IEnumerator AnimationFinished()
    {
        yield return new WaitForSecondsRealtime(GetComponent<Animation>().clip.length + 1f);
        Destroy(gameObject);
    }
}
