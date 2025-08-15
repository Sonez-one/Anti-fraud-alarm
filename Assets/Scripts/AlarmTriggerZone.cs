using System;
using UnityEngine;

public class AlarmTriggerZone : MonoBehaviour
{
    public event Action RogueCame;
    public event Action RogueGone;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Rogue>(out _))
            RogueCame?.Invoke();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Rogue>(out _))
            RogueGone?.Invoke();
    }
}
