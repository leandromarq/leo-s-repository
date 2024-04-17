using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;

//using Microsoft.Unity.VisualStudio.Editor;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
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


 void mezclar (){

    for (int x=0; x<Maso.Count; x++){
        Maso1.Add(Maso[x]);
        Maso2.Add(Maso[x]);
    }

    while (Maso1.Count>25){
        System.Random random = new System.Random();
        int n = random.Next(0,Maso1.Count-1);
        Maso1.RemoveAt(n);
    }

    while (Maso2.Count>25){
        System.Random random = new System.Random();
        int n = random.Next(0,Maso2.Count-1);
        Maso2.RemoveAt(n);
    }

 }

// si b1 es true le toca robar al j1 y si es true b2 le toca robar a j2 


 void robarcartas (int n, bool b1, bool b2){

    if (b1){
        int y = Manoplayer1aux.Count;
        int c = Math.Min(n, 10 - y );

        for (int x=0; x<c; x++){
            Manoplayer1aux.Add(Maso1[0]);
            Image aux = Maso1[0].GetComponentInChildren<Image>();
            Image aux2 = Manoplayer1aux[Manoplayer1aux.Count-1].GetComponentInChildren<Image>();
            aux2.sprite = aux.sprite;
            Maso1.RemoveAt(0);
        }
    }
if (b2){
        int y = Manoplayer2aux.Count;
        int c = Math.Min(n, 10 - y );

        for (int x=0; x<c; x++){
           Manoplayer2aux.Add(Maso2[0]);
            Image aux = Maso2[0].GetComponentInChildren<Image>();
            Image aux2 = Manoplayer2aux[Manoplayer2aux.Count-1].GetComponentInChildren<Image>();
            aux2.sprite = aux.sprite;
            Maso2.RemoveAt(0);
        }

    }
 }

  //funcion para jugar cada carta....

  int posicioncartajugada;
  bool tocajugar = true; // si la variable es verdadera le toca jugar al primer jugador de lo contrario te toca al jugador dos.
   public void playcard(int n){
       
    if (tocajugar){
        
       juego script = Manoplayer1aux[n-1].GetComponent<juego>();
       
       if (script.tipo == "CC"){
        
       CCplayer1int.Add(script.puntos);
       CCplayer1aux.Add(Manoplayer1aux[n-1]);
       Manoplayer1aux.RemoveAt(n-1);
        
       }

       if (script.tipo == "AD"){
        ADplayer1int.Add(script.puntos);
       ADplayer1aux.Add(Manoplayer1aux[n-1]);
       Manoplayer1aux.RemoveAt(n-1);
       }

     if (script.tipo == "AQ"){
       AQplayer1int.Add(script.puntos);
       AQplayer1aux.Add(Manoplayer1aux[n-1]);
       Manoplayer1aux.RemoveAt(n-1);
       }
        tocajugar = false;
}


    else{
       juego script = Manoplayer2aux[n-1].GetComponent<juego>();
     if (script.tipo == "CC"){
        
       CCplayer2int.Add(script.puntos); 
       CCplayer2aux.Add(Manoplayer2aux[n-1]);
       Manoplayer2aux.RemoveAt(n-1);
        
       }

       if (script.tipo == "AD"){
       ADplayer2int.Add(script.puntos);
       ADplayer2aux.Add(Manoplayer2aux[n-1]);
       Manoplayer2aux.RemoveAt(n-1);
       }

     if (script.tipo == "AQ"){
       AQplayer2int.Add(script.puntos);
       AQplayer2aux.Add(Manoplayer2aux[n-1]);
       Manoplayer2aux.RemoveAt(n-1);
       }

         tocajugar = true;
    }

   }


  private void Start() {
    mezclar();
   robarcartas(10,true,true);

  }

    void actualizacion (){

        if(tocajugar){
           ocultar1.enabled = false;
           ocultar2.enabled=true;
        }
        else{
           ocultar1.enabled =true;
           ocultar2.enabled=false;
        }


      // actualizar la cantidad de puntos en cada fotograma.

      int contador1 =0 ;

      for (int x=0; x<CCplayer1int.Count; x++ ){
      contador1+=CCplayer1int[x];
      }
        for (int x=0; x<ADplayer1int.Count; x++ ){
      contador1+=ADplayer1int[x];
      }
        for (int x=0; x<AQplayer1int.Count; x++ ){
      contador1+=AQplayer1int[x];
      }
      
          int contador2 =0 ;

      for (int x=0; x<CCplayer2int.Count; x++ ){
      contador2+=CCplayer2int[x];
      }
        for (int x=0; x<ADplayer2int.Count; x++ ){
      contador2+=ADplayer2int[x];
      }
        for (int x=0; x<AQplayer2int.Count; x++ ){
      contador2+=AQplayer2int[x];
      }

      puntoplayer1.text = contador1.ToString();

      puntoplayer2.text = contador2.ToString();


      // actualizamos la mano del jugador 1 en cada fotograma
      for (int x=0; x<Manoplayer1aux.Count; x++){
            Button aux = Manoplayer1[x].GetComponentInChildren<Button>();
             aux.GetComponent<Image>().enabled = true;
            Image aux2 = Manoplayer1aux[x].GetComponentInChildren<Image>();
            aux.image.sprite = aux2.sprite;
        }
        for(int x = Manoplayer1aux.Count ; x < Manoplayer1.Count; x++){
            Button aux = Manoplayer1[x].GetComponentInChildren<Button>();
            aux.GetComponent<Image>().enabled = false;
        }


           // actualizamos la mano del jugador 2 en cada fotograma
      for (int x=0; x<Manoplayer2aux.Count; x++){
            Button aux = Manoplayer2[x].GetComponentInChildren<Button>();
            aux.GetComponent<Image>().enabled = true;
            Image aux2 = Manoplayer2aux[x].GetComponentInChildren<Image>();
            aux.image.sprite = aux2.sprite;
        }
        for(int x = Manoplayer2aux.Count ; x < Manoplayer2.Count; x++){
            Button aux = Manoplayer2[x].GetComponentInChildren<Button>();
            aux.GetComponent<Image>().enabled = false;
        }

        
      //  actualicemos las cartas del campo

      for (int x=0; x<CCplayer1aux.Count; x++){
            Image aux = CCplayer1aux[x].GetComponentInChildren<Image>();
            Image aux2 = CCplayer1[x].GetComponentInChildren<Image>();
            aux2.GetComponent<Image>().enabled = true;
            aux2.sprite = aux.sprite;
        }
        for(int x = CCplayer1aux.Count ; x < CCplayer1.Count; x++){
            Image aux = CCplayer1[x].GetComponentInChildren<Image>();
            aux.GetComponent<Image>().enabled = false;
        }

         for (int x=0; x<AQplayer1aux.Count; x++){
            Image aux = AQplayer1aux[x].GetComponentInChildren<Image>();
            Image aux2 = AQplayer1[x].GetComponentInChildren<Image>();
            aux2.GetComponent<Image>().enabled = true;
            aux2.sprite = aux.sprite;
        }
        for(int x = AQplayer1aux.Count ; x < AQplayer1.Count; x++){
            Image aux = AQplayer1[x].GetComponentInChildren<Image>();
            aux.GetComponent<Image>().enabled = false;
        }

         for (int x=0; x<ADplayer1aux.Count; x++){
            Image aux = ADplayer1aux[x].GetComponentInChildren<Image>();
            Image aux2 = ADplayer1[x].GetComponentInChildren<Image>();
            aux2.GetComponent<Image>().enabled = true;
            aux2.sprite = aux.sprite;
        }
        for(int x = ADplayer1aux.Count ; x < ADplayer1.Count; x++){
            Image aux = ADplayer1[x].GetComponentInChildren<Image>();
            aux.GetComponent<Image>().enabled = false;
        }

        for (int x=0; x<CCplayer2aux.Count; x++){
            Image aux = CCplayer2aux[x].GetComponentInChildren<Image>();
            Image aux2 = CCplayer2[x].GetComponentInChildren<Image>();
            aux2.GetComponent<Image>().enabled = true;
            aux2.sprite = aux.sprite;
        }
        for(int x = CCplayer2aux.Count ; x < CCplayer2.Count; x++){
            Image aux = CCplayer2[x].GetComponentInChildren<Image>();
            aux.GetComponent<Image>().enabled = false;
        }

         for (int x=0; x<AQplayer2aux.Count; x++){
            Image aux = AQplayer2aux[x].GetComponentInChildren<Image>();
            Image aux2 = AQplayer2[x].GetComponentInChildren<Image>();
            aux2.GetComponent<Image>().enabled = true;
            aux2.sprite = aux.sprite;
        }
        for(int x = AQplayer2aux.Count ; x < AQplayer2.Count; x++){
            Image aux = AQplayer2[x].GetComponentInChildren<Image>();
            aux.GetComponent<Image>().enabled = false;
        }

         for (int x=0; x<ADplayer2aux.Count; x++){
            Image aux = ADplayer2aux[x].GetComponentInChildren<Image>();
            Image aux2 = ADplayer2[x].GetComponentInChildren<Image>();
            aux2.GetComponent<Image>().enabled = true;
            aux2.sprite = aux.sprite;
        }
        for(int x = ADplayer2aux.Count ; x < ADplayer2.Count; x++){
            Image aux = ADplayer2[x].GetComponentInChildren<Image>();
            aux.GetComponent<Image>().enabled = false;
        }
        

    }




     private void Update() {
     actualizacion();

   }

}
