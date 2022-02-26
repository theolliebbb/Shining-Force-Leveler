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
    public Sprite maxSdmn;
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
    public int levval;
    public int levval2;
    public int mpval = 8;
    public int defval;
    public int hpval;
    public int agval;
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
    public int promotedVal;
    public int boltVal;
    public int bolt2Val;
   
    public void Start()
    {    
       
        hq.Play();
        attack = GetComponent<Text>();
        if (PlayerPrefs.HasKey("savedAttack"))
        {
        atval = PlayerPrefs.GetInt("savedAttack");
        }
        else
        {
        atval = 7;

        }
        if (PlayerPrefs.HasKey("savedLevel"))
        {
        levval = PlayerPrefs.GetInt("savedLevel");
        }
        else
        {
        levval2 = 1;
        }

        if (PlayerPrefs.HasKey("savedHP"))
        {
        hpval = PlayerPrefs.GetInt("savedHP");
        }
        else
        {
        hpval = 14;
        }

        if (PlayerPrefs.HasKey("savedDefense"))
        {
        defval = PlayerPrefs.GetInt("savedDefense");
        }
        else
        {
        defval = 6;
        }
        
        if (PlayerPrefs.HasKey("savedMP"))
        {
        mpval = PlayerPrefs.GetInt("savedMP");
        }
        else
        {
        mpval = 8;
        }

        if (PlayerPrefs.HasKey("savedAgility"))
        {
        agval = PlayerPrefs.GetInt("savedAgility");
        }
        else
        {
        agval = 9;
        }
        
         if (PlayerPrefs.HasKey("promotedVal"))
        {
        promotedVal = PlayerPrefs.GetInt("promotedVal");
        }
        else
        {
        promotedVal = 0;
        }
        
        if (promotedVal == 0)
        {
            promoted = false;
        }
        else
        {
            promoted = true;
        }

        if (PlayerPrefs.HasKey("boltVal"))
        {
        boltVal = PlayerPrefs.GetInt("boltVal");
        }
        else
        {
        boltVal = 0;
        }
        
         if (PlayerPrefs.HasKey("bolt2Val"))
        {
        bolt2Val = PlayerPrefs.GetInt("bolt2Val");
        }
        else
        {
        bolt2Val = 0;
        }

         if (((promoted == true) & (levval >= 1)) || ((promoted == false) & (levval >= 11)))
        {
           boltImage.SetActive(true);
           boltVal = 1;
        }
        if (bolt2Val == 1)
        {
           boltPill2.SetActive(true);
          
           
        }

        attack.text = atval.ToString();
        level.text = levval.ToString();
        mp.text = mpval.ToString();
        agility.text = agval.ToString();
        hp.text = hpval.ToString();
        defense.text = defval.ToString();
        
         if (levval >= 10 && promoted == false)
        {
        
        }
        else
            promoteButton.SetActive(false);

        if (promoted = true);
        {
             title1.SetActive(false);
        title2.SetActive(true);
        title.text = hero;
        }
        promoted = false;
        title.text = hero;
        title1.SetActive(true);
        title2.SetActive(false);
         if (boltVal == 0)
        {
            boltImage.SetActive(false);
        }
        else
        {
           boltImage.SetActive(true);
        }

         if (bolt2Val == 0)
        {
            boltPill2.SetActive(false);
        }
        else
        {
           boltPill2.SetActive(true);
        }


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
        promotedVal = 1;
        PlayerPrefs.SetInt("promotedVal", promotedVal);
        
        promotesound.Play();     
        promoteButton.SetActive(false);
        maxSwordsman.sprite = maxHero;
        levval = 0;
        levval2 = 0;
        PlayerPrefs.SetInt("savedLevel", levval2);
        levelup();
        level = GetComponent<Text>();
        level.text = levval.ToString();
        
       } 

    public void levelup()
    {
        
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
       
        
        
        levval = PlayerPrefs.GetInt("savedLevel");
        levval = levval2;
        level = GameObject.Find("level").GetComponent<Text>();
        levval += 1;
        
        levval2 = levval;
        level.text = levval.ToString();
        PlayerPrefs.SetInt("savedLevel", levval2);
	    PlayerPrefs.Save();
   
        attack = GameObject.Find("attack").GetComponent<Text>();
        atval += upattack;
        attack.text = atval.ToString();
        PlayerPrefs.SetInt("savedAttack", atval);
	    PlayerPrefs.Save();

        mp = GameObject.Find("mp").GetComponent<Text>();
        mp.text = mpval.ToString();

        agility = GameObject.Find("agility").GetComponent<Text>();
        agility.text = agval.ToString();
        agval += upagility;
        PlayerPrefs.SetInt("savedAgility", agval);
	    PlayerPrefs.Save();

        hp = GameObject.Find("hp").GetComponent<Text>();
        hp.text = hpval.ToString();
        hpval += uphp;
        PlayerPrefs.SetInt("savedHP", hpval);
	    PlayerPrefs.Save();

        defense = GameObject.Find("defense").GetComponent<Text>();
        defense.text = defval.ToString();
        defval += updefense;
        PlayerPrefs.SetInt("savedDefense", defval);
	    PlayerPrefs.Save();

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
        PlayerPrefs.SetInt("savedMP", mpval);
	    PlayerPrefs.Save();
            
        }
        if (((promoted == true) & (levval >= 1)) || ((promoted == false) & (levval >= 11)))
        {
           boltImage.SetActive(true);
           boltVal = 1;
        }
        if (((promoted == true) & (levval >= 6)) || ((promoted == false) & (levval >= 16)))
        {
           boltPill2.SetActive(true);
           bolt2Val = 1;
           PlayerPrefs.SetInt("bolt2Val", bolt2Val);
        }


    }    

        public void resetStats()
        {
              PlayerPrefs.DeleteAll();
              levval = 1;
              levval2 = 1;
              atval = 7;
              defval = 6;
              agval = 9;
              hpval = 14;
              mpval = 8;
              PlayerPrefs.SetInt("savedMP", mpval);
               promoted = false;
               boltImage.SetActive(false);
               boltPill2.SetActive(false);
               bolt2Val = 0;
               boltVal = 0;
        promotedVal = 0;
        title1.SetActive(true);
        title2.SetActive(false);
        title.text = sdmn;
        maxSwordsman.sprite = maxSdmn;
        PlayerPrefs.SetInt("promotedVal", promotedVal);
              level = GameObject.Find("level").GetComponent<Text>();
        levval += 0;
        level.text = levval.ToString();
        attack = GameObject.Find("attack").GetComponent<Text>();
        atval += 0;
        attack.text = atval.ToString();
        defense = GameObject.Find("defense").GetComponent<Text>();
        defval += 0;
        defense.text = defval.ToString();
        hp = GameObject.Find("hp").GetComponent<Text>();
        hpval += 0;
        hp.text = hpval.ToString();
        mp = GameObject.Find("mp").GetComponent<Text>();
        mpval += 0;
        mp.text = mpval.ToString();
        agility = GameObject.Find("agility").GetComponent<Text>();
        agval += 0;
        agility.text = agval.ToString();
        }

         void Update()
        {
         attack = GameObject.Find("attack").GetComponent<Text>();
        if (promotedVal == 0)
        {
            promoted = false;
        }
        else
        {
            promoted = true;
            title1.SetActive(false);
             title2.SetActive(true);
            title.text = hero;
            maxSwordsman.sprite = maxHero;
        }
        attack.text = atval.ToString();
        defense.text = defval.ToString();
        agility.text = agval.ToString();
        hp.text = hpval.ToString();
        mp.text = mpval.ToString();
        level.text = levval.ToString();

       if (levval >= 10 && promoted == false)
        {
            promoteButton.SetActive(true);
        }
        }
    
    
    
}
    

