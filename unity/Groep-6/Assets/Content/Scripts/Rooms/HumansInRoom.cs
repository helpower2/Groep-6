using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class HumansInRoom : MonoBehaviour
{
    private Dictionary<GameObject, HumanStats> _humans = new Dictionary<GameObject, HumanStats>();
    //private List<KeyValuePair<GameObject, HumanStats>> humans = new List<KeyValuePair<GameObject, HumanStats>>();
    [SerializeField] private string HumanTypeTag;

    public List<HumanStats> humanStats => _humans.Values.ToList();
    public List<GameObject> humans => _humans.Keys.ToList();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals(HumanTypeTag))
        {
            var human = new KeyValuePair<GameObject, HumanStats>(collision.gameObject, collision.GetComponent<HumanStats>());
            if (human.Value != null)
            {
                _humans.Add(human.Key, human.Value);
                Debug.Log("added");
            }
            else
            {
                Debug.Log("no HumanStats");
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.tag.Equals(HumanTypeTag))
        {
            var human = new KeyValuePair<GameObject, HumanStats>(collision.gameObject, collision.GetComponent<HumanStats>());
            _humans.Remove(human.Key);
            Debug.Log("Removed");
        }
            
    }
}
