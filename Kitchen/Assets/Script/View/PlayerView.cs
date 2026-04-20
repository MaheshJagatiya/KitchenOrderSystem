using UnityEngine;

public class PlayerView : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    [SerializeField] float interactDistance = 2f;

    CharacterController controller;

    public IngredientView HeldItem { get; private set; }

    void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        HandleMovement();
        HandleInteraction();
    }
    void HandleMovement()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(h, 0, v);

        
        controller.Move(move * speed * Time.deltaTime);

      
        if (move != Vector3.zero)
        {
            transform.forward = move;
        }
    }

    void HandleInteraction()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            
            Vector3 origin = transform.position + Vector3.up * 1f;

            Ray ray = new Ray(origin, transform.forward);

            if (Physics.Raycast(ray, out RaycastHit hit, interactDistance))
            {
                Debug.Log("Hit: " + hit.collider.name);

                IInteractable interactable = hit.collider.GetComponent<IInteractable>();

                if (interactable != null)
                {
                    interactable.Interact(this);
                }
            }

            
            Debug.DrawRay(origin, transform.forward * interactDistance, Color.red, 2f);
        }
    }

    public void PickItem(IngredientView item)
    {
        HeldItem = item;

        item.transform.SetParent(transform);
        item.transform.localPosition = Vector3.up * 1.2f;
    }

    public void DropItem()
    {
        if (HeldItem == null) return;

        HeldItem.transform.SetParent(null);
        HeldItem = null;
    }

    public void ClearItem()
    {
        HeldItem = null;
    }
}
