using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
// ㅅㅂ 솔직히 개귀찮다 적 오브젝트 설정 너무 많잖아 ㅁㅊ
public class EnemyCtrl : MonoBehaviour  // 적 유닛 설정을 위한 클래스 코드
{
    public GameObject HitEffect;    // 피격 효과 오브젝트를 지정하는 선언
    private int HP;                 // 적 오브젝트의 HP 설정
    private GameObject Player;      // 플레이어의 오브젝트를 지정
    private NavMeshAgent navMesh;   // 적 오브젝트의 이동을 도와줄 네비게이션 속성을 지정하는 선언코드
    private Animator ani;           // 적 오브젝트의 애니메이션 지정 선언
    private bool isAttack;          // 적 오브젝트의 상태 중 공격상태를 지정하는 선언
    // bool 이라고 붙은 자료형은 참(true)과 거짓(false) 를 저장하는 변수

    void Start()                            // 처음 파일 실행시 한번만 실행되는 초기 설정을 위한 함수
    {
        HP = 20;                            // HP 를 20으로 지정
        Player = GameObject.Find("Player"); // 플레이어의 위치를 알기위한 위치 속성 참조 코드
        navMesh = GetComponent<NavMeshAgent>(); // navMesh 변수에 네비게이션 속성을 참조하는 코드
        ani = GetComponent<Animator>();     // 에니메이터의 속성을 참조하는 코드
        navMesh.destination = Player.transform.position;    // 네비게이션의 목적지를 플레이어의 위치로 지정
    }


    void Update()                   // 매 프레임마다 변화하는 상태를 표시, 화면의 실시간 상태변화를 표현하는 함수
    {
        float Distance = Vector3.Distance(Player.transform.position, transform.position);
                                    // 플레이어와 적 사이의 거리를 Distance 변수에 저장
        if (Distance <= 4.5f)       // 둘 사이의 거리가 4.5f 이하라면 아래 코드 실행 ( 공격을 할 정도로 가깝다면 )
        {
            navMesh.Stop();         // 네비게이션(적 오브젝트 이동을 위한 안내)을 정지
            if(isAttack == false)   // isAttack 변수의 값을 false 로 초기화(isAttack 은 공격 모션을 실행하기 위한 설정)
            {
                ani.SetBool("Idle", true);  // 애니메이션 상태 속성을 Idle 로 지정
                        // Idle 은 특정 애니메이션의 이름으로 어떤 애니를 재생할지 지정하는 코드

                StartCoroutine(Attack());   // Attack 이라는 함수를 코루틴으로 반복시킴
            }
        }
    }
    IEnumerator Attack()            // 공격을 위한 코루틴 반복 함수 코드
    {
        isAttack = true;            // 공격 상태를 true 로 설정
        yield return new WaitForSeconds(3.0f);  // 공격 전 대기시간을 지정
        ani.SetBool("Attack", true);            // 공격 상태를 true 로 지정 -> 공격 실행
        yield return new WaitForSeconds(0.5f);  // 공격 후 대기 시간(공격 텀) 을 지정(공격 끝 동작을 확실히 표시하기 위해 적당히 설정)
        Player.GetComponent<PlayerCtrl>().ApplyDamage(10);  // PlayerCtrl 클래스에서 Applydamage 함수를 참조 한다는 코드
        isAttack = false;           // 다시 공격상태를 false 로 초기화 시킴
        ani.SetBool("Attack", false);   // 적 오브젝트의 공격 상태를 false 로 완전 초기화
    }
    void OnCollisionEnter(Collision coll)   // 다른 collider 와의 접촉 발생시 아래의 코드를 실행
    {
        if(coll.gameObject.CompareTag("Bullet"))
            // Bullet 이란 이름의 태그를 가진 오브젝트 collider 와의 접촉 시 아래 코드 실행, 적이 총알에 맞았을 때 실행
            // ( coll 이란 변수에 저장된 오브젝트가 bullet 일때
        {
            GameObject hitEffect = Instantiate(HitEffect, coll.transform.position, coll.transform.rotation);
                                    // 총알 피격 이펙트를 collider 간의 충돌 위치에서 실행시키는 코드
            Destroy(coll.gameObject);   // bullet 오브젝트를 파괴(제거) 시키는 코드
            Destroy(hitEffect, 2.0f);   // 일정 시간(2.0f) 후에 피격 이펙트를 파괴(제거) 시키는 코드
            HP -= 10;               // 적 오브젝트의 HP 를 10 만큼 뺌
            if(HP <= 0)             // 만약 HP 가 0 이하일 때 아래 코드 실행
            {
                Destroy(gameObject);    // 적 오브젝트를 파괴(제거) 시키는 코드
                Player.GetComponent<PlayerCtrl>().ScoreUP(10);  // PlayerCtrl 클래스에 있는 ScoreUP이란 함수를 '10' 만큼 실행시킴
            }
        }
    }
}
