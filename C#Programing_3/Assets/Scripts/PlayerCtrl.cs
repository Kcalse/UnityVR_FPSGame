using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerCtrl : MonoBehaviour     // 플레이어 설정 클래스
{
    public Animation DamageEffect;          // 플레이어 오브젝트의 에니메이션을 위한 선언
    public Text ScoreText;                  // 표시 점수 지정을 위한 선언
    public Text HPText;                     // 표시 현재 체력 지정을 위한 선언
    private int HP;                         // 현재 체력 지정 위한 선언
    private int Score;                      // 현재 점수 지정 위한 선언
    // Start is called before the first frame update
    void Start()                            // 처음 파일 실행시 한번만 실행되는 초기 설정을 위한 함수
    {
        HP = 100;                           // 처음 플레이어 체력을 100으로 지정
        ScoreText.text = "Score\n" + Score; // 표시되는 화면 점수를 설정 ( Score _점수_ ) 로 표시 됨
        HPText.text = "HP : " + HP;         // 표시되는 화면 체력을 설정 ( HP : _체력_ ) 로 표시 됨
    }
    public void ApplyDamage(int Damage)     // 플레이어가 입는 데미지 설정을 위한 함수
    {
        DamageEffect.Play();                // 피격 효과를 재생하는 코드
        HP -= Damage;                       // 피격시 입은 피해만큼 HP(체력)에서 차감
        HPText.text = "HP : " + HP;         // 화면에 표시되는 체력을 수정함
        if (HP <= 0)                        // 체력이 0 이하가 되면 아래 코드 실행
        {
            Application.LoadLevel(0);       // 처음 프로그램 시작 화면(레벨) 로 프로그램을 되돌림
        }
    }
    public void ScoreUP(int Score)          // 점수 획득을 위한 함수
    {
        this.Score += Score;                // 현재 점수를 추가하는 코드
        ScoreText.text = "Score\n" + this.Score;    // 현재 점수를 화면에 표시하는 코드 ( Score _점수_ )로  표시됨
    }
}
