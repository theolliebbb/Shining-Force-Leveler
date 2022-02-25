using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Maxstats : MonoBehaviour
{
    static System.Random rnd = new System.Random();
        
        public int upattack = rnd.Next(1, 6);

        public int updefense = rnd.Next(1, 4);

        public int uphp = rnd.Next(1, 5);

        public int upmp = rnd.Next(1, 5);

        public int upagility = rnd.Next(1, 6);
    public SpriteRenderer maxSwordsman;
    public Sprite maxHero;
    
    public Text title;
    
    public GameObject title1;
    public GameObject title2;
    public Text attack;
    public Text defense;
    public AudioSource hq;
    public AudioSource promotesound;
    public Text level;
    public Text hp;
    public Text mp;
    public Text agility;
    public int atval = 7;
    public int levval = 1;
    public int mpval = 8;
    public int defval =7;
    public int hpval = 14;
    public int agval = 6;
    public string sdmn = "SDMN Max";
    public string hero = "HERO Max";
    
    public GameObject promoteButton;
    public GameObject boltImage;
    public GameObject boltPill2;
    public bool promoted;
   
    public void Start()
    {    
        
        
         attack = GetComponent<Text>();
         attack.text = atval.ToString();
         level = GetComponent<Text>();
         level.text = levval.ToString();
         mp = GetComponent<Text>();
         mp.text = mpval.ToString();
         agility = GetComponent<Text>();
         agility.text = agval.ToString();
         hp = GetComponent<Text>();
         hp.text = hpval.ToString();
         defense = GetComponent<Text>();
         defense.text = defval.ToString();
         promoteButton.SetActive(false);
         promoted = false;
         title.text = hero;
         title1.SetActive(true);
          title2.SetActive(false);

    }
    public void classChange()
    {       
            hq.Pause();
              hq.Stop();
            promotesound.Play();
            StartCoroutine(waitMusic());
          
          
           title1.SetActive(false);
           title2.SetActive(true);
           title.text = hero;
        
    }
    IEnumerator waitMusic()
    {
        yield return new WaitForSecondsRealtime(13);
    }
  


    public void promote()
       {    promoted = true;
            hq.Pause();
              hq.Pause();
            promotesound.Play();
            StartCoroutine(waitMusic());
          
         
             
           promoteButton.SetActive(false);
            maxSwordsman.sprite = maxHero;
            levval = 0;
            levelup();
            level = GetComponent<Text>();
             level.text = levval.ToString();
            hq.Pause();
             promotesound.Play();
              hq.Play();

             
            
            
             
             
       } 
    
    public void levelup()
    {
       attack = GameObject.Find("attack").GetComponent<Text>();
       level = GameObject.Find("level").GetComponent<Text>();
       levval += 1;
       level.text = levval.ToString();
       atval += upattack;
       attack.text = atval.ToString();
       mp = GameObject.Find("mp").GetComponent<Text>();
        mp.text = mpval.ToString();
        agility = GameObject.Find("agility").GetComponent<Text>();
        agility.text = agval.ToString();
        agval += upagility;
         hp = GameObject.Find("hp").GetComponent<Text>();
        hp.text = hpval.ToString();
        hpval += uphp;
        defense = GameObject.Find("defense").GetComponent<Text>();
        defense.text = defval.ToString();
        defval += updefense;
       if (levval >= 10 && promoted == false)
        {
            promoteButton.SetActive(true);
            
        }
        if (promoted == true)
        {
            title.text = hero;
         title1.SetActive(true);
          title2.SetActive(false);
            mpval += upmp;
            
        }
        if (((promoted == true) & (levval == 1)) || ((promoted == false) & (levval == 11)))
       {
           boltImage.SetActive(true);
       }
       if (((promoted == true) & (levval == 6)) || ((promoted == false) & (levval == 16)))
       {
           boltPill2.SetActive(true);
       }
         void Update()
        {
       
        
        }
    
    
    }
    
}
