using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;


public class TakingDamage : MonoBehaviourPunCallbacks
{


    private float health;
    public float StartHealth = 100f;
    GameRoyaleManager Game;
    [SerializeField] Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        Game = FindObjectOfType<GameRoyaleManager>();

        if(Game.setHealth)
        {
            health = StartHealth;
            slider.value = health / StartHealth;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    [PunRPC]
    public void TakeDamage(float damage)
    {
        
        
         health -= damage;

        Debug.Log(health);

        slider.value = health/StartHealth;

        if(health<=0f)
        {
            Die();
        }
    }

    void Die()
    {
        if(photonView.IsMine)
        {
            GameRoyaleManager.instance.LeaveRoom();
        }
    }
}
