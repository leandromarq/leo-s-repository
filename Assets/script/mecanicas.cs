using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.SceneManagement;
//using Microsoft.Unity.VisualStudio.Editor;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using System.Globalization;
using UnityEngine.EventSystems;
public class NewBehaviourScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public List<GameObject>Maso=new List<GameObject>();
     List<GameObject>Maso1=new List<GameObject>();
     List<GameObject>Maso2=new List<GameObject>();
    public List<GameObject>Manoplayer1=new List<GameObject>();
    public List<GameObject>Manoplayer2=new List<GameObject>();
    public List<GameObject>CCplayer1=new List<GameObject>();
    public List<GameObject>ADplayer1=new List<GameObject>();
    public List<GameObject>AQplayer1=new List<GameObject>();
    public List<GameObject>CCplayer2=new List<GameObject>();
    public List<GameObject>ADplayer2=new List<GameObject>();
    public List<GameObject>AQplayer2=new List<GameObject>();
    private List<GameObject>Manoplayer1aux=new List<GameObject>();
    private List<GameObject>Manoplayer2aux=new List<GameObject>();
    private List<GameObject>CCplayer1aux=new List<GameObject>();
    private List<GameObject>ADplayer1aux=new List<GameObject>();
    private List<GameObject>AQplayer1aux=new List<GameObject>();
    private List<GameObject>CCplayer2aux=new List<GameObject>();
    private List<GameObject>ADplayer2aux=new List<GameObject>();
    private List<GameObject>AQplayer2aux=new List<GameObject>();
    private List<int>ADplayer1int=new List<int>();
    private List<int>CCplayer1int=new List<int>();
    private List<int>AQplayer1int=new List<int>();
    private List<int>ADplayer2int=new List<int>();
    private List<int>CCplayer2int=new List<int>();
    private List<int>AQplayer2int=new List<int>();
    public TMP_Text puntoplayer1, puntoplayer2;
    public Image ocultar1;
    public Image ocultar2;
    public Button lider1, lider2;
    public TMP_Text ronda1,ronda2;
    public Image descripcion;
    //--como primer momento del proyecto mezclamos las cartas y robamos las cartas de cada mano
   private void Start() 
  {
   mezclar();
   robarcartas(10,true,true);
   ronda1.text = ronda2.text = "0";
  }
// para mezclar las cartas primeramente relleno ambas manos con todas las cartas y luego quito de manera random hasta 25 cartas
 void mezclar ()
    {
        for (int x=0; x<Maso.Count; x++)
        {
        Maso1.Add(Maso[x]);
        Maso2.Add(Maso[x]);
        }

        while (Maso1.Count>25)
        {
        System.Random random = new System.Random();
        int n = random.Next(0,Maso1.Count-1);
        Maso1.RemoveAt(n);
        }
        while (Maso2.Count>25)
        {
        System.Random random = new System.Random();
        int n = random.Next(0,Maso2.Count-1);
        Maso2.RemoveAt(n);
        }
    }
// si b1 es true le toca robar a player1 y si b2 es true le toca robar a player2 (robaran n cartas) 
//--aunque pueden robar ambos como cuando termina la ronda, se transfieren las imagenes y los puntos del mazo a la mano
 void robarcartas (int n, bool b1, bool b2)
    {
        if (b1)
        {
        int y = Manoplayer1aux.Count;
        int c = Math.Min(n, 10 - y );

            for (int x=0; x<c; x++)
            {
            Manoplayer1aux.Add(Maso1[0]);
            Image aux = Maso1[0].GetComponentInChildren<Image>();
            Image aux2 = Manoplayer1aux[Manoplayer1aux.Count-1].GetComponentInChildren<Image>();
            aux2.sprite = aux.sprite;
            Maso1.RemoveAt(0);
            }
        }
        if (b2)
        {
        int y = Manoplayer2aux.Count;
        int c = Math.Min(n, 10 - y );

            for (int x=0; x<c; x++)
            {
           Manoplayer2aux.Add(Maso2[0]);
            Image aux = Maso2[0].GetComponentInChildren<Image>();
            Image aux2 = Manoplayer2aux[Manoplayer2aux.Count-1].GetComponentInChildren<Image>();
            aux2.sprite = aux.sprite;
            Maso2.RemoveAt(0);
            }
        }
    }
  // si tocajugar es true le toca jugar a player1 de lo contrario te toca a player2
  bool tocajugar = true; 
  int next = 0;
  //--cada vez q se juegue una carta se hace la transferencia de la imagen a su auxiliar correspondiente
  //--y los puntos se transferiran a la lista correspondiente
   public void playcard(int n)
   {  
    if (tocajugar)
    {
       juego script = Manoplayer1aux[n-1].GetComponent<juego>();
       
       if (script.tipo == "CC")
       {
       CCplayer1int.Add(script.puntos);
       CCplayer1aux.Add(Manoplayer1aux[n-1]);
       Manoplayer1aux.RemoveAt(n-1);
       }
       if (script.tipo == "AD")
       {
        ADplayer1int.Add(script.puntos);
       ADplayer1aux.Add(Manoplayer1aux[n-1]);
       Manoplayer1aux.RemoveAt(n-1);
       }
       if (script.tipo == "AQ")
       {
       AQplayer1int.Add(script.puntos);
       AQplayer1aux.Add(Manoplayer1aux[n-1]);
       Manoplayer1aux.RemoveAt(n-1);
       }
       if(script.tipo == "cl"){
         Manoplayer1aux.RemoveAt(n-1);
        jugarclima(script.puntos);
       }
        tocajugar = false;
    }
    else
    {
       juego script = Manoplayer2aux[n-1].GetComponent<juego>();
     if (script.tipo == "CC")
       { 
       CCplayer2int.Add(script.puntos); 
       CCplayer2aux.Add(Manoplayer2aux[n-1]);
       Manoplayer2aux.RemoveAt(n-1);
       }
       if (script.tipo == "AD")
       {
       ADplayer2int.Add(script.puntos);
       ADplayer2aux.Add(Manoplayer2aux[n-1]);
       Manoplayer2aux.RemoveAt(n-1);
       }
       if (script.tipo == "AQ")
       {
       AQplayer2int.Add(script.puntos);
       AQplayer2aux.Add(Manoplayer2aux[n-1]);
       Manoplayer2aux.RemoveAt(n-1);
       }
        if(script.tipo == "cl"){
         Manoplayer2aux.RemoveAt(n-1);
        jugarclima(script.puntos);
       }
         tocajugar = true;
    }
    next = 0;
   }
   //--cada vez q se active ilai se eliminara una carta random de cada fila del campo de batalla del oponente
   public void ilai()
   {
        if (ADplayer2aux.Count != 0)
        {
        System.Random random = new System.Random();
        int eliminarcarta = random.Next(0,ADplayer2aux.Count-1);
        ADplayer2aux.RemoveAt(eliminarcarta);
        ADplayer2int.RemoveAt(eliminarcarta);
        }
        if (CCplayer2aux.Count != 0)
        {
        System.Random random = new System.Random();
        int eliminarcarta = random.Next(0,CCplayer2aux.Count-1);
        CCplayer2aux.RemoveAt(eliminarcarta);
        CCplayer2int.RemoveAt(eliminarcarta);
        }
        if (AQplayer2aux.Count != 0)
        {
        System.Random random = new System.Random();
        int eliminarcarta = random.Next(0,AQplayer2aux.Count-1);
        AQplayer2aux.RemoveAt(eliminarcarta);
        AQplayer2int.RemoveAt(eliminarcarta);
        }
        tocajugar=false;
        next ++;
   }
   public void drblack()
   {
        if (ADplayer1aux.Count != 0)
        {
        System.Random random = new System.Random();
        int addcarta = random.Next(0,ADplayer1aux.Count-1);
        ADplayer2aux.Add(ADplayer1aux[addcarta]);
        ADplayer2int.Add(ADplayer1int[addcarta]);
        ADplayer1aux.RemoveAt(addcarta);
        ADplayer1int.RemoveAt(addcarta);
        }
        if (CCplayer1aux.Count != 0)
        {
        System.Random random = new System.Random();
        int addcarta = random.Next(0,CCplayer1aux.Count-1);
        CCplayer2aux.Add(CCplayer1aux[addcarta]);
        CCplayer2int.Add(CCplayer1int[addcarta]);
        CCplayer1aux.RemoveAt(addcarta);
        CCplayer1int.RemoveAt(addcarta);
        }
        if (AQplayer1aux.Count != 0)
        {
        System.Random random = new System.Random();
        int addcarta = random.Next(0,AQplayer1aux.Count-1);
        AQplayer2aux.Add(AQplayer1aux[addcarta]);
        AQplayer2int.Add(AQplayer1int[addcarta]);
        AQplayer1aux.RemoveAt(addcarta);
        AQplayer1int.RemoveAt(addcarta);
        }
            tocajugar = true;
            next++;
   }
        //--implementacion de las cartas climas jujuuuu
        int filaclima = 0;
        public void clima (int n)
        {
            filaclima = n;
        }
        void jugarclima(int n)
        {
            if(filaclima == 1)
            {
             for (int x=0 ;  x<ADplayer1int.Count; x++)
             {
                ADplayer1int[x]+=n;
             }
             for (int x=0 ;  x<ADplayer2int.Count; x++)
             {
                ADplayer2int[x]+=n;
             }
            }            
            if(filaclima == 2)
            {
                for(int x=0; x< CCplayer1int.Count; x++)
                {
                    CCplayer1int[x]+=n;
                }
                  for(int x=0; x< CCplayer2int.Count; x++)
                {
                    CCplayer2int[x]+=n;
                }
            }
            if(filaclima == 3)
            {
                for(int x=0; x< AQplayer1int.Count; x++)
                {
                    AQplayer1int[x]+=n;
                }
                  for(int x=0; x< AQplayer2int.Count; x++)
                {
                    AQplayer2int[x]+=n;
                }
            }
        }
   public void btononesnext()
   {
     next++;
     if (tocajugar) tocajugar=false;
     else tocajugar = true;
   }
    //--actualizare la cantidad de puntos en cada instancia del juego
    void actualizacion ()
    {
        if(tocajugar)
        {
           ocultar1.enabled = false;
           ocultar2.enabled=true;
           lider1.GetComponent<Image>().enabled = true;
           lider2.GetComponent<Image>().enabled = false;
        }
        else
        {
           ocultar1.enabled =true;
           ocultar2.enabled=false;
           lider1.GetComponent<Image>().enabled = false;
           lider2.GetComponent<Image>().enabled = true;
        }
        int contador1 =0 ;
      for (int x=0; x<CCplayer1int.Count; x++ )
      {
      contador1+=CCplayer1int[x];
      }
      for (int x=0; x<ADplayer1int.Count; x++ )
      {
      contador1+=ADplayer1int[x];
      }
      for (int x=0; x<AQplayer1int.Count; x++ )
      {
      contador1+=AQplayer1int[x];
      }
        int contador2 =0 ;
      for (int x=0; x<CCplayer2int.Count; x++ )
      {
      contador2+=CCplayer2int[x];
      }
      for (int x=0; x<ADplayer2int.Count; x++ )
      {
      contador2+=ADplayer2int[x];
      }
      for (int x=0; x<AQplayer2int.Count; x++ )
      {
      contador2+=AQplayer2int[x];
      }
      puntoplayer1.text = contador1.ToString();
      puntoplayer2.text = contador2.ToString();
      //--actualizamos la mano del jugador 1 en cada instancia
        for (int x=0; x<Manoplayer1aux.Count; x++)
        {
            Button aux = Manoplayer1[x].GetComponentInChildren<Button>();
             aux.GetComponent<Image>().enabled = true;
            Image aux2 = Manoplayer1aux[x].GetComponentInChildren<Image>();
            aux.image.sprite = aux2.sprite;
        }
        for(int x = Manoplayer1aux.Count ; x < Manoplayer1.Count; x++){
            Button aux = Manoplayer1[x].GetComponentInChildren<Button>();
            aux.GetComponent<Image>().enabled = false;
        }
      //--actualizamos la mano del jugador 2 en cada instancia
        for (int x=0; x<Manoplayer2aux.Count; x++)
        {
            Button aux = Manoplayer2[x].GetComponentInChildren<Button>();
            aux.GetComponent<Image>().enabled = true;
            Image aux2 = Manoplayer2aux[x].GetComponentInChildren<Image>();
            aux.image.sprite = aux2.sprite;
        }
        for(int x = Manoplayer2aux.Count ; x < Manoplayer2.Count; x++)
        {
            Button aux = Manoplayer2[x].GetComponentInChildren<Button>();
            aux.GetComponent<Image>().enabled = false;
        }
      //--actualizamos las cartas del campo
        for (int x=0; x<CCplayer1aux.Count; x++)
        {
            Image aux = CCplayer1aux[x].GetComponentInChildren<Image>();
            Image aux2 = CCplayer1[x].GetComponentInChildren<Image>();
            aux2.GetComponent<Image>().enabled = true;
            aux2.sprite = aux.sprite;
        }
        for(int x = CCplayer1aux.Count ; x < CCplayer1.Count; x++)
        {
            Image aux = CCplayer1[x].GetComponentInChildren<Image>();
            aux.GetComponent<Image>().enabled = false;
        }
        for (int x=0; x<AQplayer1aux.Count; x++)
        {
            Image aux = AQplayer1aux[x].GetComponentInChildren<Image>();
            Image aux2 = AQplayer1[x].GetComponentInChildren<Image>();
            aux2.GetComponent<Image>().enabled = true;
            aux2.sprite = aux.sprite;
        }
        for(int x = AQplayer1aux.Count ; x < AQplayer1.Count; x++)
        {
            Image aux = AQplayer1[x].GetComponentInChildren<Image>();
            aux.GetComponent<Image>().enabled = false;
        }
        for (int x=0; x<ADplayer1aux.Count; x++)
        {
            Image aux = ADplayer1aux[x].GetComponentInChildren<Image>();
            Image aux2 = ADplayer1[x].GetComponentInChildren<Image>();
            aux2.GetComponent<Image>().enabled = true;
            aux2.sprite = aux.sprite;
        }
        for(int x = ADplayer1aux.Count ; x < ADplayer1.Count; x++)
        {
            Image aux = ADplayer1[x].GetComponentInChildren<Image>();
            aux.GetComponent<Image>().enabled = false;
        }
        for (int x=0; x<CCplayer2aux.Count; x++)
        {
            Image aux = CCplayer2aux[x].GetComponentInChildren<Image>();
            Image aux2 = CCplayer2[x].GetComponentInChildren<Image>();
            aux2.GetComponent<Image>().enabled = true;
            aux2.sprite = aux.sprite;
        }
        for(int x = CCplayer2aux.Count ; x < CCplayer2.Count; x++)
        {
            Image aux = CCplayer2[x].GetComponentInChildren<Image>();
            aux.GetComponent<Image>().enabled = false;
        }
        for (int x=0; x<AQplayer2aux.Count; x++)
        {
            Image aux = AQplayer2aux[x].GetComponentInChildren<Image>();
            Image aux2 = AQplayer2[x].GetComponentInChildren<Image>();
            aux2.GetComponent<Image>().enabled = true;
            aux2.sprite = aux.sprite;
        }
        for(int x = AQplayer2aux.Count ; x < AQplayer2.Count; x++)
        {
            Image aux = AQplayer2[x].GetComponentInChildren<Image>();
            aux.GetComponent<Image>().enabled = false;
        }
        for (int x=0; x<ADplayer2aux.Count; x++)
         {
            Image aux = ADplayer2aux[x].GetComponentInChildren<Image>();
            Image aux2 = ADplayer2[x].GetComponentInChildren<Image>();
            aux2.GetComponent<Image>().enabled = true;
            aux2.sprite = aux.sprite;
        }
        for(int x = ADplayer2aux.Count ; x < ADplayer2.Count; x++)
        {
            Image aux = ADplayer2[x].GetComponentInChildren<Image>();
            aux.GetComponent<Image>().enabled = false;
        }
    }
        //--limpiaremos el campo siempre q haya algun ganador
        void alguiengano()
        {
            if(next == 2)
            {
                next = 0;

                if(int.Parse(puntoplayer1.text) >= int.Parse(puntoplayer2.text))
                {
                    int c = int.Parse(ronda1.text)+1;
                    ronda1.text = c.ToString();
                }
                if(int.Parse(puntoplayer1.text) <= int.Parse(puntoplayer2.text))
                {
                    int c = int.Parse(ronda2.text)+1;
                    ronda2.text = c.ToString();
                }
                AQplayer1aux.Clear();
                CCplayer1aux.Clear();
                ADplayer1aux.Clear();
                AQplayer1int.Clear();
                CCplayer1int.Clear();
                ADplayer1int.Clear();
                AQplayer2aux.Clear();
                CCplayer2aux.Clear();
                ADplayer2aux.Clear();
                AQplayer2int.Clear();
                CCplayer2int.Clear();
                ADplayer2int.Clear();
                robarcartas(2,true,true);
            }
        }
    //--luego en dependencia de quien gane accedemos a una escena q muestra quien gano
    void end ()
    {
        if (ronda1.text == ronda2.text && ronda2.text == "2")
        {
           // Debug.Log("1");
            SceneManager.LoadScene(3);
            return ;
        }
        if (ronda1.text == "2")
        {
          ///  Debug.Log("2");
           SceneManager.LoadScene(1);
        }
        if(ronda2.text == "2")
        {
           // Debug.Log("3");
             SceneManager.LoadScene(2);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        GameObject currentCard = eventData.pointerEnter; // Obtener la carta sobre la que se colocó el puntero
        Image cardImage = currentCard.GetComponentInChildren<Image>(); // Obtener la imagen de la carta
        
        descripcion.sprite = cardImage.sprite;
        descripcion.enabled = true;
        Debug.Log("Se mostro la carta");

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("Se oculto la carta");
        descripcion.enabled = false;
    }
     private void Update() 
    {
     actualizacion();
     alguiengano();
     end();
    }
}