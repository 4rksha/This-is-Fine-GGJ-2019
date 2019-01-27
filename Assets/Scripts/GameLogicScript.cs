using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameLogicScript : MonoBehaviour
{
    public int houseHealth;
    public int gameDuration;
    private int remainingTime;
    public Canvas victoryText;
    public Canvas defeatText;

    bool isGameWon = false;
    int seconds = 0;
    public int damagePerActiveIncident = 2;

    // Start is called before the first frame update
    void Start()
    {

        victoryText.enabled = false;
        defeatText.enabled = false;

        remainingTime = gameDuration;
        StartCoroutine("ComputeState");
    }

    // Update is called once per frame
    void Update()
    {



    }

    IEnumerator ComputeState()
    {
        while (true)
        {
            seconds += 1;
            remainingTime = gameDuration - seconds;

            houseHealth -= GameObject.FindGameObjectsWithTag("event").Length * damagePerActiveIncident;

            if (remainingTime <= 0)
            {
                isGameWon = true;
                EndScreen();
            }
            else if (houseHealth <= 0)
            {
                EndScreen();
            }

            Debug.Log("events actifs :" + GameObject.FindGameObjectsWithTag("event").Length);
            yield return new WaitForSeconds(1f);
        }
    }


    void EndScreen()
    {
        Debug.Log("End Screen");

        StartCoroutine("EndScreenUI");
    }

    IEnumerator EndScreenUI()
    {
        GameObject.Find("BlurEffect").GetComponent<MeshRenderer>().enabled = true;

        if (isGameWon)
        {
            victoryText.enabled = true;
        }
        else
        {
            defeatText.enabled = true;
        }
        Debug.Log("On passe ici");
        yield return new WaitForSeconds(5f);

        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }

}
