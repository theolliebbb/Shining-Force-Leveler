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
    public string savedLevel;
    public string sdmn = "SDMN Max";
    public string hero = "HERO Max";
    int upattack;
    int updefense;
    int uphp;
    int upmp;
    int upagility;
    public GameObject promoteButton;
    public GameObject boltImage;
    public GameObject boltPill2;
    public bool promoted;
   
    public void Start()
    {    
        hq.Play();
        attack = GetComponent<Text>();
        attack.text = atval.ToString();
        PlayerPrefs.GetString(savedLevel);
        level.text = savedLevel;
        level = GetComponent<Text>();
        
       
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
        title1.SetActive(false);
        title2.SetActive(true);
        title.text = hero;
        
    }
    public void promote()
       {    
        promoted = true;
        hq.Pause();
        promotesound.Play();     
        promoteButton.SetActive(false);
        maxSwordsman.sprite = maxHero;
        levval = 0;
        levelup();
        level = GetComponent<Text>();
        level.text = levval.ToString();
        
       } 
    
    public void levelup()
    {
        hq.Pause();
        hq.Play();
        if (promoted == false)
        {
        upattack = rnd.Next(0, 3);
        updefense = rnd.Next(0, 2);
        uphp = rnd.Next(0, 3);
        upmp = rnd.Next(0, 2);
        upagility = rnd.Next(0, 2);
        }
        else
        {
        upattack = rnd.Next(0, 4);
        updefense = rnd.Next(0, 3);
        uphp = rnd.Next(0, 4);
        upmp = rnd.Next(0, 3);
        upagility = rnd.Next(0, 3);
        }
       
        attack = GameObject.Find("attack").GetComponent<Text>();
        
        level = GameObject.Find("level").GetComponent<Text>();
        levval += 1;
        savedLevel = levval.ToString();;
        level.text = savedLevel;
        PlayerPrefs.SetString(savedLevel,levval.ToString());
        
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
    

