using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryScript : MonoBehaviour
{
    public static float speed = 1.35f;
    public static int num = 0;
    public static bool win = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "target")
        {
            Destroy(this.gameObject);
        }
        if(other .transform .tag == "points")
        {
            Destroy(other.gameObject);
            num++;
            
        }
        if (other.transform.tag == "mub"||other .transform .tag =="mua"||other .transform .tag =="muc")
        {
            win = true;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.rotation = Quaternion.Euler(transform.eulerAngles + new Vector3(0, 90f, 0));
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.rotation = Quaternion.Euler(transform.eulerAngles + new Vector3(0, -90f, 0));
        }
        transform.Translate(new Vector3(0, 0, Input.GetAxis("Vertical") * speed * Time.deltaTime));//通过按W,S键进行移动
        //transform.Rotate(0, Input.GetAxis("Horizontal"), 0);//水平旋转
        //transform.Translate(new Vector3(0, Input.GetAxis("Jump") * 0.2f, 0));//按空格键向上跳
    }
}
