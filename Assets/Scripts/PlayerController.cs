using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float x;
    float z;
    float cameraX;
    float cameraZ;
    public float moveSpeed;
    public float magicSpeed = 10.0f;

    Rigidbody rb;
    Animator animator;

    public GameObject magicPrefabs;

    public bool isShoot = true;

    private Vector3 playerPos;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        cameraX = Input.GetAxisRaw("Horizontal");
        cameraZ = Input.GetAxisRaw("Vertical");

        Clamp();
    }

    private void FixedUpdate() {

        animator.SetFloat("MoveSpeed", rb.velocity.magnitude); //rb.velocityはベクトル。そのmagnitudeで大きさ


        // カメラの方向から、X-Z平面の単位ベクトルを取得
        Vector3 cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;

        // 方向キーの入力値とカメラの向きから、移動方向を決定
        Vector3 moveForward = cameraForward * cameraZ + Camera.main.transform.right * cameraX;

        // 移動方向にスピードを掛ける。ジャンプや落下がある場合は、別途Y軸方向の速度ベクトルを足す。
        rb.velocity = moveForward * moveSpeed + new Vector3(0, rb.velocity.y, 0);

        // キャラクターの向きを進行方向に
        if (moveForward != Vector3.zero) {
            transform.rotation = Quaternion.LookRotation(moveForward);
        }

        //magic

        if (Input.GetKeyDown(KeyCode.Space) && isShoot) {
            animator.SetTrigger("Hit");
            magic();
            StartCoroutine("Reload");
        }

    }

    void magic() {
        Debug.Log("magic");
        Vector3 player = GameObject.Find("Player").transform.position;
        GameObject runcherMagic = Instantiate(magicPrefabs, player, Quaternion.identity) as GameObject;
        runcherMagic.GetComponent<Rigidbody>().velocity = transform.forward * magicSpeed;
        runcherMagic.transform.position = transform.position + new Vector3(0, 0.5f, 0);        
    }

    IEnumerator Reload() {
        isShoot = false;
        yield return new WaitForSeconds(1.0f);
        isShoot = true;
    }

    void Clamp() {
        playerPos = transform.position;
        playerPos.x = Mathf.Clamp(playerPos.x, -20.0f, 20.0f);
        playerPos.z = Mathf.Clamp(playerPos.z, -50.0f, -35.0f);
        transform.position = new Vector3(playerPos.x, playerPos.y, playerPos.z);
        transform.position = playerPos;
    }

}
