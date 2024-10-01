using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] Alarm _alarm;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent(out Player player))
            _alarm.OnEnter();
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.TryGetComponent(out Player player))
            _alarm.OnExit();
    }
}