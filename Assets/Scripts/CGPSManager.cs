using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 구글 플레이 사용
using GooglePlayGames;
using UnityEngine.SocialPlatforms;
using GooglePlayGames.BasicApi;

public class CGPSManager : MonoBehaviour {

    public Text _msgText;

    public int _clickCount;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnGPSLoginButtonClick()
    {
        // 구글 플레이 게임즈 활성화
        PlayGamesPlatform.Activate();

        // 구글 플레이 인증
        Social.localUser.Authenticate(GooglePlayGamesLoginCallback);
    }

    // 구글 플레이 인증 처리 완료 (콜백 이벤트)
    public void GooglePlayGamesLoginCallback(bool result)
    {
        // 인증 성공
        if (result)
        {
            _msgText.text = "구글 플레이 인증 완료";
        }
        else
        {
            _msgText.text = "구글 플레이 인증 실패";
        }
    }

    // 비행기를 클릭하면 클릭카운트를 증가 시킴
    public void OnClickCountUpButtonClick()
    {
        _clickCount++;

        _msgText.text = _clickCount.ToString() + "번 비행기를 클릭함";

        if (_clickCount >= 50)
        {
            // 업적 수행 (업적id, 진행률, 완료이벤트메소드)
            Social.ReportProgress(CGPGSIds.achievement_5, 
                100f, AchievementCallback);
        }
        else if (_clickCount >= 40)
        {
            Social.ReportProgress(CGPGSIds.achievement_4,
                100f, AchievementCallback);
        }
        else if (_clickCount >= 30)
        {
            Social.ReportProgress(CGPGSIds.achievement_3,
                100f, AchievementCallback);
        }
        else if (_clickCount >= 20)
        {
            Social.ReportProgress(CGPGSIds.achievement_2,
                100f, AchievementCallback);
        }
        else if (_clickCount >= 10)
        {
            Social.ReportProgress(CGPGSIds.achievement_1,
                100f, AchievementCallback);
        }

        // 리더보드 갱신 (점수, 리더보드id, 완료 이벤트 콜백 메소드)
        Social.ReportScore(_clickCount, CGPGSIds.leaderboard_isgpgssimplesample,
            LeaderBoardCallback);
    }

    public void AchievementCallback(bool result)
    {
        _msgText.text = "업적 수행이 완료됨 (클릭카운트 : " 
            + _clickCount.ToString();
    }

    public void LeaderBoardCallback(bool result)
    {

    }

    public void OnShowAchievementButtonClick()
    {
        // 업적 보기 ui를 출력함
        Social.ShowAchievementsUI();
    }

    public void OnShowLeaderboardButtonClick()
    {
        // 순위 보기 ui를 출력함
        Social.ShowLeaderboardUI();
    }

}
