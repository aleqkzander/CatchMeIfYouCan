/*
 * Use this class to activate referenced elements for local player
 */

using UnityEngine;

public class PlayerNetworkActivator : MonoBehaviour
{
    public GameObject Cameras;

    private void Start()
    {
        // make local player check
        Cameras.SetActive(true);
    }
}
