using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Taostats : MonoBehaviour
{
    static System.Random rnd = new System.Random();
        
        public int upattack = rnd.Next(1, 4);

        public int updefense = rnd.Next(1, 3);

        public int uphp = rnd.Next(1, 5);

        public int upmp = rnd.Next(1, 7);

        public int upagility = rnd.Next(1, 7);
    
    
    
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
    public string mage = "MAGE Tao";
    public string wiz = "WIZD Tao";
    
    public GameObject promoteButton;
    public GameObject sleepImage;
    public GameObject sleepPill2;
     public GameObject blazePill2;
     public GameObject blazePill3;
     public GameObject blazePill4;
     public GameObject desoulImage;
     public GameObject desoulPill2;
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
         title.text = wiz;
         title1.SetActive(true);
          title2.SetActive(false);

    }
    public void classChange()
    {       
        promoted = true;
            hq.Pause();
              hq.Stop();
            promotesound.Play();
            StartCoroutine(waitMusic());
          
          
           title1.SetActive(false);
           title2.SetActive(true);
           title.text = wiz;
        
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
         mpval += upmp;
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
            title.text = wiz;
         title1.SetActive(true);
          title2.SetActive(false);
           
            
        }
        if ((promoted == false) & (levval == 5))
        {
            blazePill2.SetActive(true);
        }
        if ((promoted == false) & (levval == 8))
        {
            blazePill3.SetActive(true);
        }
        if ((promoted == true) & (levval == 6) || (promoted == false) & (levval == 16))
       {
           blazePill4.SetActive(true);
       }
       
       if ((promoted == false) & (levval == 6))
       {
           sleepImage.SetActive(true);
       }
        if ((promoted == true) & (levval == 8)|| (promoted == false) & (levval == 18)) 
        {
           sleepPill2.SetActive(true);
       }
       if ((promoted == false) & (levval == 10))
        {
            desoulImage.SetActive(true);
        }
        if ((promoted == true) & (levval == 12)|| (promoted == false) & (levval == 22)) 
        {
           desoulPill2.SetActive(true);
       }
         void Update()
        {
       
        
        }
    
    
    }
    
}
