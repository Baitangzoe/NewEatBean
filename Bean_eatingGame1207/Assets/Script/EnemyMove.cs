using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyMove : MonoBehaviour
{
    NavMeshAgent nav;
    public Transform[] endPoint;
    int index = 0;
    private float timer = 0;
    private float timere = 0;
    private float speeds = 0.75f;
    private float temp = 0.0f;
    private bool isbool = false;
    public GameObject enemyObj;

    public Transform StartPoint;
    //private bool ZhuiJi;

    private EnemyYD enemyYD;
    private float tempSpeed = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        nav.SetDestination(endPoint[index].position);//获取目标点位置
        temp = nav.speed;

        tempSpeed = DestoryScript.speed;
        enemyYD = new EnemyYD(StartPoint, transform, nav, tempSpeed, new EnemyNav());
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Jr")
        {
            GameObject bzs = Instantiate(Resources.Load("bz", typeof(GameObject)) as GameObject);
            Destroy(other.gameObject);
            bzs.transform.SetParent(transform);
            bzs.transform.localPosition = Vector3.zero;
            Destroy(bzs, 1);
            nav.speed = speeds;
            enemyObj.SetActive(true);
            isbool = true;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (isbool == true)
        {
            timere += Time.deltaTime;
            if (timere >= 20.0f)
            {
                isbool = false;
                timere = 0f;
                nav.speed = temp;
                enemyObj.SetActive(false);
            }
        }

        if (nav.remainingDistance <= 0.01f)
        {
            timer += Time.deltaTime;
            if (timer >= 0.1f)
            {
                timer = 0;
                index++;
                index %= endPoint.Length;
                nav.SetDestination(endPoint[index].position);
            }
        }
        
        if (StartPoint.childCount > 0)
        {
            float length = (StartPoint.GetChild(0).position - transform.position).sqrMagnitude;
            enemyYD.HandleYd();
            //if (length < 16f)
            //{
            //    nav.isStopped = true;
            //    transform.position = Vector3.MoveTowards(transform.position, StartPoint.GetChild(0).position, Time.deltaTime * 1.65f);
            //}
            //else
            //{
            //    nav.isStopped = false;
            //}
        }
        else if (StartPoint.childCount >= 0)
        {
            nav.isStopped = false;
        }
    }

    /// <summary>  
    /// 敌人运动状态类，对应模式中的Context类,维护一个ConcreteState(On EnemyZJ)子类的实例，这个实例定义当前的状态。  
    /// </summary>  
    public class EnemyYD
    {
        private EnemyYDState enemyYDState;
        private Transform startPoint;
        private Transform enemys;
        private NavMeshAgent nav;
        private float tempSpeed;
        public EnemyYDState EnemyYDState
        {
            get { return enemyYDState; }
            set { enemyYDState = value; }
        }
        public Transform StartPoint
        {
            get { return startPoint; }
            set { startPoint = value; }
        }
        public Transform Enemys
        {
            get { return enemys; }
            set { enemys = value; }
        }
        public NavMeshAgent Nav
        {
            get { return nav; }
            set { nav = value; }
        }
        public float TempSpeed
        {
            get { return tempSpeed; }
            set { tempSpeed = value; }
        }
        public EnemyYD (Transform startPoint,Transform enemys,NavMeshAgent nav,float tempSpeed,EnemyYDState enemyYDState)
        {
            this.startPoint = startPoint;
            this.enemys = enemys;
            this.nav = nav;
            this.enemyYDState = enemyYDState;
            this.tempSpeed = tempSpeed;
        }
       
        public void HandleYd()
        {
            enemyYDState.Handle(this);
        }
    }
    /// <summary>  
    /// 抽象的【敌人运动状态类】，相当于State类，定义一个抽象类以封装与Context（EnemyYD）的一个【特定状态相关的行为】
    /// 对于继承抽象类的子类来说，对于抽象类来说，属于“是”的关系，敌人运动的状态【是】【自动寻路（不追击角色）】还是【追击角色】
    /// 当大家具有共同行为，但是行为的实现方式不同时，则可以把这个共同行为封装成一个接口interface，具有该行为的类来具体实现该接口
    /// </summary>  
    public abstract class EnemyYDState
    {
        public abstract void Handle(EnemyYD enemyYD);
    }
    /// <summary>  
    /// 具体状态类, 敌人自动寻路（不追击角色）  
    /// </summary>  
    public class EnemyZJ : EnemyYDState
    {
        /// <summary>  
        /// 在(ConcreteStateA)状态下，符合条件则开启(ConcreteStateB)敌人追击角色功能。  
        /// </summary>  
        /// <param name="enemyYD"></param>  
        public override void Handle(EnemyYD enemyYD)
        {
            Transform StartPoint = enemyYD.StartPoint;
            Transform Enemys = enemyYD.Enemys;
            NavMeshAgent Nav = enemyYD.Nav;
            float length = (StartPoint.GetChild(0).position - Enemys.position).sqrMagnitude;
            if (length < 16f)
            {
                Debug.Log("追击角色");
                Nav.isStopped = true;
                Enemys.position = Vector3.MoveTowards(Enemys.position, StartPoint.GetChild(0).position, Time.deltaTime * 1.65f);
                DestoryScript.speed += 1.10f * Time.deltaTime;
            }
            else
            {
                enemyYD.EnemyYDState = new EnemyNav();
            }
        }
    }
    /// <summary>  
    /// 具体状态类，敌人追击角色，每一个子类实现一个与Context(Light)的一个状态相关的行为    
    /// </summary>  
    public class EnemyNav : EnemyYDState
    {
        /// <summary>  
        /// 在(ConcreteStateB)状态下，符合条件则开启(ConcreteStateA)敌人自动寻路（不追击角色）功能。  
        /// </summary>  
        /// <param name="enemyYD"></param>  
        public override void Handle(EnemyYD enemyYD)
        {
            Transform StartPoint = enemyYD.StartPoint;
            Transform Enemys = enemyYD.Enemys;
            NavMeshAgent Nav = enemyYD.Nav;
            float tempSpeed = enemyYD.TempSpeed;
            float length = (StartPoint.GetChild(0).position - Enemys.position).sqrMagnitude;
            if (length >= 16)
            {
                Debug.Log("自动寻路");
                Nav.isStopped = false;
                DestoryScript.speed = tempSpeed;
            }
            else
            {
                enemyYD.EnemyYDState = new EnemyZJ();
            }
        }
    }
}
