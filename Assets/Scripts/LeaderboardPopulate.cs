using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderboardPopulate : MonoBehaviour {

	// Use this for initialization
	void Start () {
        List<float> times = new List<float>
        {
            PlayerPrefs.GetFloat("leader1", -1),
            PlayerPrefs.GetFloat("leader2", -1),
            PlayerPrefs.GetFloat("leader3", -1)
        };

        string s = "Leaderboard:\n";
        Debug.Log(times[0].ToString() + times[1].ToString() + times[2].ToString());

        foreach (float t in times)
        {
            if (t > 0)
            {
                string minutes = ((int)t / 60).ToString();
                if ((int)t / 60 < 10)
                {
                    minutes = "0" + minutes;
                }
                string seconds = (t % 60).ToString("f2");
                if (t % 60 < 10)
                    seconds = "0" + seconds;

                s += minutes + ":" + seconds + "\n";
            }
        }

        this.GetComponent<UnityEngine.UI.Text>().text = s;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
