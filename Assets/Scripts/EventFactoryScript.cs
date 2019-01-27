using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class EventFactoryScript : MonoBehaviour
{

    public float delay = 10.0f;
    public int timer = 0;
    public int positionNumber = 3;
    float spawnTimer = 0.0f;
    float seconds = 0.0f;

    Dictionary<EnumIncidentEvents.IncidentEvent, List<Transform>> events;
    int nextEventIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        events = new Dictionary<EnumIncidentEvents.IncidentEvent, List<Transform>>();

        foreach(EnumIncidentEvents.IncidentEvent ie in Enum.GetValues(typeof(EnumIncidentEvents.IncidentEvent)))
        {
            List<Transform> positions = new List<Transform>();
            foreach(Transform pos in transform.GetChild(0).transform)
            {
                if (pos.name.Contains(ie.ToString()))
                {
                    positions.Add(pos);
                }
            }
            events.Add(ie, positions);
        }

    }

    // Update is called once per frame
    void Update()
    {
        seconds += Time.deltaTime;
        spawnTimer += Time.deltaTime;
        timer = Mathf.RoundToInt(seconds);

        if (spawnTimer > delay)
        {
            SpawnIncident();
            spawnTimer = 0.0f;
        }
    }

    void SpawnIncident()
    {
        EnumIncidentEvents.IncidentEvent newIncident = events.Keys.ToArray()[nextEventIndex];
        List<Transform> tf = events[newIncident];
        int randomIndex = Mathf.RoundToInt(UnityEngine.Random.Range(0.0f, 1.0f) * tf.Count());

        var goArray = GameObject.FindGameObjectsWithTag("event");
        var isAlreadyActive = false;
        if (randomIndex == tf.Count())
        {
            randomIndex = 0;
        }

        var count = tf.Count() + 1;
        do
        {
            count--;
            if (count == 0)
            {
                //Debug.Log("on passe ici");
                nextEventIndex = nextEventIndex >= events.Keys.Count() - 1 ? 0 : nextEventIndex + 1;
                if (positionNumber > goArray.Length)
                {
                    spawnTimer = 0.0f;
                    SpawnIncident();
                }
                return;
            }
            foreach (GameObject gameObj in goArray)
            {
                Debug.Log("gameObj.transform.position : " + gameObj.transform.position);
                Debug.Log("tf.ToArray()[randomIndex].position : " + tf.ToArray()[randomIndex].position);
                if (gameObj.transform.position.Equals(tf.ToArray()[randomIndex].position))
                {
                    isAlreadyActive = true;
                    randomIndex++;
                    if (randomIndex == tf.Count())
                        randomIndex = 0;
                    break;
                }
            }
            //Debug.Log(isAlreadyActive);
        } while (isAlreadyActive);

        UnityEngine.Object res = Resources.Load(EnumIncidentEvents.ToString(newIncident));
        var go = Instantiate(res) as GameObject;

        go.transform.position = tf.ToArray()[randomIndex].position;
        go.tag = "event";
    }
}


