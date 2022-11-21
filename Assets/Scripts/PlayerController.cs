using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    public float  gravityModifier;

    [Header("Controles Movimiento")]

    public float VelMovimiento;
    public CharacterController characterController;
    private Vector3 control;
    public Transform camTransform;
    public float poderSalto;
    private bool canJump, canDoubleJump;
    public Transform groundCheckPoint;
    public LayerMask whatIsGround;
    public float runSpeed;
    public GameObject bullet;
    public Transform firePoint;
    public Camera camara;
    public Transform crossHair;
    [SerializeField] public LayerMask layer; 

    [Header("Controles Camara")]

    public float SensibilidadMouse;
    public bool InvertX;
    public bool InvertY;


    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        //MOVIMIENTO PERSONAJE

        //control.x = Input.GetAxis("Horizontal") * VelMovimiento * Time.deltaTime;
        //control.z = Input.GetAxis("Vertical")* VelMovimiento * Time.deltaTime;

        //GUARDAR VELOCIDAD Y
        float yStore = control.y;

        Vector3 vertMove = transform.forward * Input.GetAxis("Vertical");
        Vector3 horiMove = transform.right * Input.GetAxis("Horizontal");

        control = horiMove + vertMove;
        control.Normalize();
        

        if(Input.GetButton("Run")){
            control *= runSpeed;
        }else{
            control *= VelMovimiento;
        }
        control.y = yStore;

        //GRAVEDAD
        control.y += Physics.gravity.y * gravityModifier *Time.deltaTime;
        if(characterController.isGrounded){
            control.y = Physics.gravity.y * gravityModifier * Time.deltaTime;
        }

        //SALTO
        //canJump = Physics.OverlapSphere(groundCheckPoint.position, .25f, whatIsGround).Length > 0;
        canJump = characterController.isGrounded;
        if(canJump){

            canDoubleJump = false;
        }

        if(Input.GetButtonDown("Jump") && canJump){

            control.y = poderSalto;
            canDoubleJump = true;

        }else if(canDoubleJump && (Input.GetButtonDown("Jump"))){
            control.y = poderSalto;
            canDoubleJump = false;
        }

        characterController.Move(control * Time.deltaTime);

        //ROTACION CAMARA
        Vector2 mouseInput = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y")) * SensibilidadMouse;
        if(InvertX){
            mouseInput.x = -mouseInput.x;
            mouseInput.y = -mouseInput.y;
        }
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + mouseInput.x, transform.rotation.eulerAngles.z);
        camTransform.rotation = Quaternion.Euler(camTransform.rotation.eulerAngles + new Vector3(-mouseInput.y,0f, 0f));

        //DISPARAR
        layer = 1<<layer;
        layer = ~layer;

        if(Input.GetMouseButtonDown(0)){
            if (Physics.Raycast(firePoint.position, firePoint.forward, out RaycastHit hitInfo, Mathf.Infinity, layerMask:layer)){
            Vector3 direction = hitInfo.point - firePoint.position;
            firePoint.rotation = Quaternion.LookRotation(direction);
            }
            GameObject bala = Instantiate(bullet, firePoint.position, firePoint.rotation);
            Rigidbody balarb = bala.GetComponent<Rigidbody>();
            balarb.AddForce(firePoint.forward * 10f, ForceMode.VelocityChange);

            //Instantiate(bullet, firePoint.position, (camTransform.rotation * Quaternion.AngleAxis(88f, Vector3.right)) * Quaternion.AngleAxis(0f, Vector3.left));
        }
        RaycastHit hitInf;
        Physics.Raycast(firePoint.position, firePoint.forward, out hitInf, Mathf.Infinity, layerMask:layer);
       if(hitInf.collider != null){
            if(hitInf.transform.tag != "Bullet"){
             crossHair.position = camara.WorldToScreenPoint(hitInf.point);
            }
        }
    }
}
