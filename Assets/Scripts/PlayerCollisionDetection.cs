using UnityEngine;

public class PlayerCollisionDetection : MonoBehaviour
{
   public static PlayerCollisionDetection Instance { get; private set; }
   
   
   public Door door;
   public Elevator elevator;

   
   
   private void Awake()
   {
      Instance = this;
   }


   private void Update()
   {
      if (Input.GetKeyDown(KeyCode.E))
      {
         if (door != null)
         {
            door.Interact();
         }

         if (elevator != null)
         {
            elevator.Interact();
         }
      }
   }

   private void OnCollisionEnter(Collision other)
   {
      // if (other.gameObject.CompareTag("Door"))
      // {
      //    Debug.Log("Collide with player");
      //    door = other.gameObject.GetComponent<Door>();
      // }

      if (other.gameObject.GetComponent<PickableItems>())
      {
         
      }
      
   }
   
   private void OnCollisionExit(Collision other)
   {
      if (other.gameObject.CompareTag("Door"))
      {
         Debug.Log("Exit collide with player");
         door = null;
      }
   }
   
   private void OnTriggerExit(Collider other)
   {
      if (other.gameObject.CompareTag("Elevator"))
      {
         Debug.Log("Elevator exit collide with player");
         elevator = null;
         //door = null;
      }
   }
   
   private void OnTriggerEnter(Collider other)
   {
      if (other.gameObject.CompareTag("Elevator"))
      {         
         elevator = other.gameObject.GetComponentInParent<Elevator>();
      }
      if (other.gameObject.CompareTag("Door"))
      {        
         door = other.gameObject.GetComponent<Door>();

      }
   }
}
