
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ScoringZone : MonoBehaviour
{
    public EventTrigger.TriggerEvent scoreTrigger;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "ball")
        {
            BaseEventData eventData = new BaseEventData(EventSystem.current);
            this.scoreTrigger.Invoke(eventData);

            GetComponent<Rigidbody2D>().position = Vector2.zero;

        }
    }
}
