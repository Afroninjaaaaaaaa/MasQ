using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetEnvironment : MonoBehaviour {

    GameObject[] objectsAngry;
    GameObject[] objectsContempt;
    GameObject[] objectsDisgust;
    GameObject[] objectsFear;
    GameObject[] objectsHappy;
    GameObject[] objectsNeutral;
    GameObject[] objectsSadness;
    GameObject[] objectsSurprise;
    List<GameObject> currObjects;

    Vector3 deltaPosition;
    Quaternion deltaRotation;

    void Start ()
    {
        objectsAngry = new GameObject[12];
        objectsAngry[0] = Resources.Load("Prefabs/angry/Axe", typeof(GameObject)) as GameObject;
        objectsAngry[1] = Resources.Load("Prefabs/angry/Axe", typeof(GameObject)) as GameObject;
        objectsAngry[2] = Resources.Load("Prefabs/angry/Axe", typeof(GameObject)) as GameObject;
        objectsAngry[3] = Resources.Load("Prefabs/angry/Axe", typeof(GameObject)) as GameObject;
        objectsAngry[4] = Resources.Load("Prefabs/angry/Knife", typeof(GameObject)) as GameObject;
        objectsAngry[5] = Resources.Load("Prefabs/angry/Knife", typeof(GameObject)) as GameObject;
        objectsAngry[6] = Resources.Load("Prefabs/angry/Knife", typeof(GameObject)) as GameObject;
        objectsAngry[7] = Resources.Load("Prefabs/angry/Knife", typeof(GameObject)) as GameObject;
        objectsAngry[8] = Resources.Load("Prefabs/angry/Sword", typeof(GameObject)) as GameObject;
        objectsAngry[9] = Resources.Load("Prefabs/angry/Sword", typeof(GameObject)) as GameObject;
        objectsAngry[10] = Resources.Load("Prefabs/angry/Sword", typeof(GameObject)) as GameObject;
        objectsAngry[11] = Resources.Load("Prefabs/angry/Sword", typeof(GameObject)) as GameObject;

        objectsContempt = new GameObject[10];
        objectsContempt[0] = Resources.Load("Prefabs/contempt/Glasses", typeof(GameObject)) as GameObject;
        objectsContempt[1] = Resources.Load("Prefabs/contempt/Hat", typeof(GameObject)) as GameObject;
        objectsContempt[2] = Resources.Load("Prefabs/contempt/Salaryman", typeof(GameObject)) as GameObject;
        objectsContempt[3] = Resources.Load("Prefabs/contempt/Security1", typeof(GameObject)) as GameObject;
        objectsContempt[4] = Resources.Load("Prefabs/contempt/Security2", typeof(GameObject)) as GameObject;
        objectsContempt[5] = Resources.Load("Prefabs/contempt/Glasses", typeof(GameObject)) as GameObject;
        objectsContempt[6] = Resources.Load("Prefabs/contempt/Hat", typeof(GameObject)) as GameObject;
        objectsContempt[7] = Resources.Load("Prefabs/contempt/Salaryman", typeof(GameObject)) as GameObject;
        objectsContempt[8] = Resources.Load("Prefabs/contempt/Security1", typeof(GameObject)) as GameObject;
        objectsContempt[9] = Resources.Load("Prefabs/contempt/Security2", typeof(GameObject)) as GameObject;

        objectsDisgust = new GameObject[10];
        objectsDisgust[0] = Resources.Load("Prefabs/disgust/Minion", typeof(GameObject)) as GameObject;
        objectsDisgust[1] = Resources.Load("Prefabs/disgust/Minion", typeof(GameObject)) as GameObject;
        objectsDisgust[2] = Resources.Load("Prefabs/disgust/Minion", typeof(GameObject)) as GameObject;
        objectsDisgust[3] = Resources.Load("Prefabs/disgust/Minion", typeof(GameObject)) as GameObject;
        objectsDisgust[4] = Resources.Load("Prefabs/disgust/Minion", typeof(GameObject)) as GameObject;
        objectsDisgust[5] = Resources.Load("Prefabs/disgust/Poison", typeof(GameObject)) as GameObject;
        objectsDisgust[6] = Resources.Load("Prefabs/disgust/Poison", typeof(GameObject)) as GameObject;
        objectsDisgust[7] = Resources.Load("Prefabs/disgust/Poison", typeof(GameObject)) as GameObject;
        objectsDisgust[8] = Resources.Load("Prefabs/disgust/Poison", typeof(GameObject)) as GameObject;
        objectsDisgust[9] = Resources.Load("Prefabs/disgust/Poison", typeof(GameObject)) as GameObject;

        objectsFear = new GameObject[12];
        objectsFear[0] = Resources.Load("Prefabs/fear/Eye1", typeof(GameObject)) as GameObject;
        objectsFear[1] = Resources.Load("Prefabs/fear/Eye1", typeof(GameObject)) as GameObject;
        objectsFear[2] = Resources.Load("Prefabs/fear/Eye1", typeof(GameObject)) as GameObject;
        objectsFear[3] = Resources.Load("Prefabs/fear/Eye2", typeof(GameObject)) as GameObject;
        objectsFear[4] = Resources.Load("Prefabs/fear/Eye2", typeof(GameObject)) as GameObject;
        objectsFear[5] = Resources.Load("Prefabs/fear/Eye2", typeof(GameObject)) as GameObject;
        objectsFear[6] = Resources.Load("Prefabs/fear/Eye3", typeof(GameObject)) as GameObject;
        objectsFear[7] = Resources.Load("Prefabs/fear/Eye3", typeof(GameObject)) as GameObject;
        objectsFear[8] = Resources.Load("Prefabs/fear/Eye3", typeof(GameObject)) as GameObject;
        objectsFear[9] = Resources.Load("Prefabs/fear/Spider", typeof(GameObject)) as GameObject;
        objectsFear[10] = Resources.Load("Prefabs/fear/Spider", typeof(GameObject)) as GameObject;
        objectsFear[11] = Resources.Load("Prefabs/fear/Spider", typeof(GameObject)) as GameObject;

        objectsHappy = new GameObject[12];
        objectsHappy[0] = Resources.Load("Prefabs/happy/Heart", typeof(GameObject)) as GameObject;
        objectsHappy[1] = Resources.Load("Prefabs/happy/Heart", typeof(GameObject)) as GameObject;
        objectsHappy[2] = Resources.Load("Prefabs/happy/Heart", typeof(GameObject)) as GameObject;
        objectsHappy[3] = Resources.Load("Prefabs/happy/Mill", typeof(GameObject)) as GameObject;
        objectsHappy[4] = Resources.Load("Prefabs/happy/Mill", typeof(GameObject)) as GameObject;
        objectsHappy[5] = Resources.Load("Prefabs/happy/Mill", typeof(GameObject)) as GameObject;
        objectsHappy[6] = Resources.Load("Prefabs/happy/Pokeball", typeof(GameObject)) as GameObject;
        objectsHappy[7] = Resources.Load("Prefabs/happy/Pokeball", typeof(GameObject)) as GameObject;
        objectsHappy[8] = Resources.Load("Prefabs/happy/Pokeball", typeof(GameObject)) as GameObject;
        objectsHappy[9] = Resources.Load("Prefabs/happy/Unicorn", typeof(GameObject)) as GameObject;
        objectsHappy[10] = Resources.Load("Prefabs/happy/Unicorn", typeof(GameObject)) as GameObject;
        objectsHappy[11] = Resources.Load("Prefabs/happy/Unicorn", typeof(GameObject)) as GameObject;

        objectsNeutral = new GameObject[0];
        objectsSadness = new GameObject[0];

        objectsSurprise = new GameObject[14];
        objectsSurprise[0] = Resources.Load("Prefabs/surprise/Mushroom1", typeof(GameObject)) as GameObject;
        objectsSurprise[1] = Resources.Load("Prefabs/surprise/Mushroom2", typeof(GameObject)) as GameObject;
        objectsSurprise[2] = Resources.Load("Prefabs/surprise/Mushroom3", typeof(GameObject)) as GameObject;
        objectsSurprise[3] = Resources.Load("Prefabs/surprise/Mushroom4", typeof(GameObject)) as GameObject;
        objectsSurprise[4] = Resources.Load("Prefabs/surprise/Mushroom5", typeof(GameObject)) as GameObject;
        objectsSurprise[5] = Resources.Load("Prefabs/surprise/Mushroom6", typeof(GameObject)) as GameObject;
        objectsSurprise[6] = Resources.Load("Prefabs/surprise/Mushroom7", typeof(GameObject)) as GameObject;
        objectsSurprise[7] = Resources.Load("Prefabs/surprise/Mushroom1", typeof(GameObject)) as GameObject;
        objectsSurprise[8] = Resources.Load("Prefabs/surprise/Mushroom2", typeof(GameObject)) as GameObject;
        objectsSurprise[9] = Resources.Load("Prefabs/surprise/Mushroom3", typeof(GameObject)) as GameObject;
        objectsSurprise[10] = Resources.Load("Prefabs/surprise/Mushroom4", typeof(GameObject)) as GameObject;
        objectsSurprise[11] = Resources.Load("Prefabs/surprise/Mushroom5", typeof(GameObject)) as GameObject;
        objectsSurprise[12] = Resources.Load("Prefabs/surprise/Mushroom6", typeof(GameObject)) as GameObject;
        objectsSurprise[13] = Resources.Load("Prefabs/surprise/Mushroom7", typeof(GameObject)) as GameObject;

        currObjects = new List<GameObject>();
    }
	

	void Update ()
    {
        if      (ChangeFace.currFeeling == "angry")     { InitNewEnvironnment(objectsAngry); }
        else if (ChangeFace.currFeeling == "contempt")  { InitNewEnvironnment(objectsContempt); }
        else if (ChangeFace.currFeeling == "disgust")   { InitNewEnvironnment(objectsDisgust); }
        else if (ChangeFace.currFeeling == "fear")      { InitNewEnvironnment(objectsFear); }
        else if (ChangeFace.currFeeling == "happy")     { InitNewEnvironnment(objectsHappy); }
        else if (ChangeFace.currFeeling == "neutral")   { InitNewEnvironnment(objectsNeutral); }
        else if (ChangeFace.currFeeling == "sadness")   { InitNewEnvironnment(objectsSadness); }
        else if (ChangeFace.currFeeling == "surprise")  { InitNewEnvironnment(objectsSurprise); }
    }

    private void InitNewEnvironnment(GameObject[] environnment)
    {
        foreach (GameObject item in currObjects)
        {
            Destroy(item);
        }
        foreach (GameObject item in environnment)
        {
            deltaPosition = new Vector3(Random.Range(-3.0f, 3.0f), Random.Range(-3.0f, 3.0f), Random.Range(-3.0f, 3.0f));
            deltaRotation = new Quaternion(Random.Range(0.0f, 360.0f), Random.Range(0.0f, 360.0f), Random.Range(0.0f, 360.0f), 1);
            var currObj = Instantiate(item, transform.position + deltaPosition, new Quaternion(transform.rotation.x + deltaRotation.x, transform.rotation.y + deltaRotation.y, transform.rotation.z + deltaRotation.z, transform.rotation.w));
            currObj.AddComponent<Rotate>();
            currObj.AddComponent<RotateAround>();
            currObjects.Add(currObj);
        }
        ChangeFace.currFeeling = null;
    }
}
