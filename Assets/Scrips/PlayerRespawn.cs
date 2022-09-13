using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerRespawn : MonoBehaviour
{
    private float checkPointPositionX, checkPointPositionY;

    private void Start()
    {
        if(PlayerPrefs.GetFloat("checkPointPositionX")!=0)
        {
            transform.position = (new Vector2(PlayerPrefs.GetFloat("checkPointPositionX"), PlayerPrefs.GetFloat("checkPointPositionY")));
        }
    }

    public void ReachedCheckpoint(float x, float y)
    {
        PlayerPrefs.SetFloat("checkPointPositionX",x);
        PlayerPrefs.SetFloat("checkPointPositionY",y);

    }
    //https://www.youtube.com/watch?v=ONGadgr7ZtQ&list=PLNEAWvYbJJ9kZpaIg2RfzAc_KZixBgchT&index=8&ab_channel=LuisCanary
    public void PlayerDamaged()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
