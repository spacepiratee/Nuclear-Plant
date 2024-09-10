using DG.Tweening;
using UnityEngine;

public class Elevator : MonoBehaviour
{
   [Header("Floor and Ceiling")] 
   public int currentFloor;
   public Ceiling[] ceiling;
   
   
   
   
   [Header("Door")]
   [SerializeField] private Transform rightDoor;
   [SerializeField] private Transform leftDoor;
   private bool _isClosed;

   
   [Header("Components")]
   private Rigidbody rb;
   
   
   
   
   private void Start()
   {
      _isClosed = true;
      rb = GetComponent<Rigidbody>();

      for (int i = 0; i < ceiling.Length; i++)
      {
         if (i != 0)
         {
            ceiling[i].TurnLights(false);
         }
      }
   }

   public void Interact()
   {
      if (_isClosed)
      {
         Open();
      }
      else
      {
         Close();
      }
   }
   
   void Open()
   {
      _isClosed = false;
      rightDoor.DOLocalMoveX(-1, 2).SetEase(Ease.OutQuad);
      leftDoor.DOLocalMoveX(1, 2).SetEase(Ease.OutQuad);
   }

   void Close()
   {
      _isClosed = true;
      rightDoor.DOLocalMoveX(0, 2).SetEase(Ease.OutExpo);
      leftDoor.DOLocalMoveX(0, 2).SetEase(Ease.OutExpo);
   }

   public void Move()
   {
      Close();
      if (currentFloor == 0)
      {
         Invoke(nameof(GoUp), 2.25f);
      }
      else
      {
         Invoke(nameof(GoDown), 2.25f);
      }
      
   }

   void GoUp()
   {
      ceiling[currentFloor].TurnLights(false);
      ceiling[currentFloor].TurnOffMesh();
      ceiling[currentFloor].TurnOffCollider();
      
      rb.DOMoveY(5.55f, 4).OnComplete(() =>
      {
         Open();
         
         ceiling[currentFloor].TurnOnMesh();
         ceiling[currentFloor].TurnOnCollider();

         currentFloor += 1;
         
         ceiling[currentFloor].TurnLights(true);
      });
   }

   void GoDown()
   {
      // currentFloor -= 1;
      
      ceiling[currentFloor].TurnLights(false);
      ceiling[currentFloor - 1].TurnOffMesh();
      ceiling[currentFloor - 1].TurnOffCollider();
      
      rb.DOMoveY(1, 4).OnComplete(() =>
      {
         Open();
         
         
         currentFloor -= 1;
         
         
         ceiling[currentFloor].TurnOnMesh();
         ceiling[currentFloor].TurnOnCollider();

         
         ceiling[currentFloor].TurnLights(true);
      });
   }
   
   
}
