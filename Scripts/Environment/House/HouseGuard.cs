using UnityEngine;
using UnityEngine.Events;

public class HouseGuard : MonoBehaviour
{
    [SerializeField] private UnityEvent<AudioClip> _startedAlarm;
    [SerializeField] private UnityEvent _stoppedAlarm;
    [SerializeField] private AudioClip _signalinSound;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.TryGetComponent<Player>(out Player player))
        {
            _startedAlarm?.Invoke(_signalinSound);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.TryGetComponent<Player>(out Player player))
        {
            _stoppedAlarm?.Invoke();
        }
    }

    public AudioClip StartAlarm() => _signalinSound;
}
