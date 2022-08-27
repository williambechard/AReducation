using UnityEngine;
 using UnityEngine.UI;
 using UnityEngine.EventSystems;
 using System.Collections;
 
 public class PlaySoundOnHover : MonoBehaviour, IPointerEnterHandler, IPointerDownHandler {

     public void OnPointerEnter( PointerEventData ped ) {
         AudioManager.Instance.PlaySFXOneShot("UIHover");
     }
 
     public void OnPointerDown( PointerEventData ped ) {
         AudioManager.Instance.PlaySFXOneShot("UIPress");
     }    
 }