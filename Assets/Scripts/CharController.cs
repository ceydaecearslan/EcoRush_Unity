using System.Numerics;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController : MonoBehaviour
{
    public static CharController Instance;

    private void Awake()
    {
        if (Instance)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float rotationValue = 10f;
    //[SerializeField] SpawnManager spawnManager;
    Animator animator;
    Rigidbody rbody;

    void Start()
    {
        animator = GetComponent<Animator>();
        rbody = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Turn();
        Run();
    }

    void Turn()
    { 
        if (Input.GetKey(KeyCode.D))
        {
            RotateRight();
        }
        else if (Input.GetKey(KeyCode.A))
        {
            RotateLeft();
        }
    }

    void RotateRight()
    {
        ApplyRotation(rotationValue);
    }

    void RotateLeft()
    {
        ApplyRotation(-rotationValue);
    }

    void ApplyRotation(float rotationValue)
    {
        StartRotation(rotationValue);
    }

    void StartRotation(float rotationValue)
    {
        rbody.freezeRotation = false;
        transform.Rotate(UnityEngine.Vector3.up * rotationValue * Time.deltaTime);
        rbody.freezeRotation = true;
    }

    void Run()
    {
        if (Input.GetKey(KeyCode.W))
        {
            StartRun();
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            StopRun();
        }

    }

    private void StartRun()
    {
        animator.SetBool("isRunning", true);
        //float xValue = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        float zValue = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;

    
        UnityEngine.Vector3 moveDirection = new UnityEngine.Vector3(0, 0, zValue);
        transform.Translate(moveDirection);
    }

    private void StopRun()
    {
        animator.SetBool("isRunning", false);
    }
    

    private void OnTriggerEnter(Collider collider) 
    {
        Debug.Log(collider.tag);
        if (collider.tag == "SpawnTrigger")
        {
            SpawnManager.Instance.SpawnTriggerEntered();
            Debug.Log("OnTriggerEnter çalıştı");
        }
        
    }

    private void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.GetComponent<TrashInteraction>() != null && other.collider.tag == "Trash")
        {
            other.gameObject.GetComponent<TrashInteraction>().Interact(transform.position);
            Debug.Log("topladım");
        }
    }

}


