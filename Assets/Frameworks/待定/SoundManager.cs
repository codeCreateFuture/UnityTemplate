/// <summary>
/// Sound manager.
/// This script use for manager all sound(bgm,sfx) in game
/// </summary>

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SoundManager : MonoBehaviour {
	/*
	[System.Serializable]
	public class SoundGroup{
		public AudioClip audioClip;
		public SoundType sountType;
	}

	public enum BgmType
	{
		NONE = 0,
		BGM_DESERT,         //---ɳĮ��������
		BGM_FOREST,         //---ɭ�ֱ�������
		BGM_OCEAN,          //---���󱳾�����
		BGM_KAPAI,          //---�����淨��������
		BGM_WUXIAN,         //---�����淨��������
		BGM_HOUZIDAO,       //---��ʯ�淨��������
		BGM_ZHANCHE,        //---ս���淨��������
		BGM_NORMAL_1,       //---��ͨ�淨��������1
		BGM_NORMAL_2,        //---��ͨ�淨��������2
		BGM_UI_MAIN_1,      //---UI���汳������1
		BGM_UI_MAIN_2       //---UI���汳������2
	}

	public enum SoundType
	{
		NONE = 0,
		SOUND_BOSS_APPEAR,           //---BOSS����
		SOUND_BOSS_DEAD,             //---BOSS������ը
		SOUND_BOSS_DAODAN,           //---BOSS����
		SOUND_GET_COIN,            //�������
		SOUND_GET_COIN2,
		SOUND_MAGNET_DOUBLE_COIN,   //---�����ͽ�Ҽӱ�
		SOUND_KAPAI_WRONG,          //---����ײ������ 
		SOUND_KAPAI_RIGHT,          //---��ȷײ������
		SOUND_COUNTDOWN,            //---����ʱ
		SOUND_GET_ITEM,              //---��õ���
		SOUND_GET_COMBO,            //---�����Ʒ��COMBO��
		SOUND_GET_MAGNET,           //---��ô���
		SOUND_GET_MISSILE,          //---����ڵ�
		SOUND_GET_RANDOMITEM,       //---��������Ʒ
		SOUND_GET_SPRINT,           //---��ó��
		SOUND_BULLET_1,             //---��ǹ�ӵ�
		SOUND_BULLET_2,             //---�ӵ�
		SOUND_JITING,               //---��ͣ
		SOUND_JIASU,                //---����
		SOUND_MISSILE,              //---�����ڵ�
		SOUND_MISSILE_2,
		SOUND_JUMP,                 //---��Ծ
		SOUND_GAME_LOSE,            //---��Ϸʧ��
		SOUND_GAME_WIN,             //---��Ϸʤ��
		SOUND_ENGINE,               //---����
		SOUND_RUN,                  //---������
		SOUND_CAR_READY,            //---�����ܳ�
		SOUND_CAR_OUT,              //---�����ܳ�
		SOUND_COLLISION,             //---ײ��
		SOUND_BTN_CLICK_1,          //---��ť���1
		SOUND_BTN_CLICK_2,          //---��ť���2
		SOUND_GAME_START,           //---��Ϸ��ʼ
		SOUND_UI_LEVEL_UP_1,        //---����1��������
		SOUND_UI_LEVEL_UP_2,         //---����2��������Ʒ��
		SOUND_EXPLOSION,            //������ը
		SOUND_GET_GEM1,             //��ȡ��ʯ
		SOUND_GET_GEM2,
		SOUND_GET_GEM3,
		SOUND_GET_GEM4,
		SOUND_GET_GEM5,
		SOUND_CAR_EXPLOSION,       //�ϰ�������ը
		SOUND_CAR_TUPO,            //����ͻ��
		SOUND_CAR_UP,              //��������
		SOUND_CHONGCI_COLLISION,   //���ײ��
		SOUND_DAODAN_1,            //����1��2��3
		SOUND_DAODAN_2,
		SOUND_DAODAN_3,
		SOUND_PLAYER_SHOT,         //���ǳ�����
		SOUND_SIDE_COLLISION,      //������ײ
		SOUND_SKILL_UP,            //��������
		SOUND_HELICOPTER,          //ֱ���ɻ�
		SOUND_FINISH_COMBO,        //COMBOO
		SOUND_RESULT_STAR,         //��������
		SOUND_PK_MATCH,            //PKƥ��
		SOUND_CHONGJIBO,           //�����
		SOUND_GET_SPRINT2,         //�޵г�̹���
		SOUND_VS,                  //vs����
		SOUND_ALERT,               //�������㵹��ʱ
		SOUND_GET_PROP             //�����Ʒ����
	}
	public AudioSource bgmSound;
	public AudioSource runSound;
	public AudioSource fireBulletSound;
	public AudioSource sound1;
	public AudioSource sound2;
	public AudioSource sound3;
	public AudioSource carReadySound;
	
	public List<AudioClip> encourage_List = new List<AudioClip>();
	public List<AudioClip> countDown_List = new List<AudioClip>();
	private List<SoundGroup> soundList = new List<SoundGroup>();
	
	public static SoundManager instance;
	
	void Awake()
	{
		instance = this;
		DontDestroyOnLoad (this.gameObject);
		StartCoroutine(StartBGM());
	}


	public void OnChangeScene(bool isStartGame = false)
	{
		StopAllCoroutines ();
		bgmSound.Stop ();
		runSound.Stop ();
		sound1.Stop();
		sound2.Stop();
		sound3.Stop();
		if (!isStartGame)
		{
			StopCarReady();
		}      
		StopSound(SoundType.SOUND_COUNTDOWN);
		fireBulletSound.Stop();

		StartCoroutine(StartBGM());
	}

	void Update()
	{
		bgmSound.volume = GameData.isBgMusicOn == 1 ? BGM_VOLUME : 0;
		sound1.volume = GameData.isSoundOn == 1 ? SOUND_VOLUME : 0;
		sound2.volume = GameData.isSoundOn == 1 ? SOUND_VOLUME : 0;
		sound3.volume = GameData.isSoundOn == 1 ? SOUND_VOLUME : 0;
		runSound.volume = GameData.isSoundOn == 1 ? RUN_VOLUME : 0;
		fireBulletSound.volume = GameData.isSoundOn == 1 ? BULLET_VOLUME : 0;
		carReadySound.volume = GameData.isSoundOn == 1 ? CAR_READY_VOLUME : 0;
	}


	private const float SOUND_VOLUME = 1f;
	private const float BGM_VOLUME = 0.5f;
	private const float RUN_VOLUME = 0.8f;
	private const float BULLET_VOLUME = 0.4f;
	private const float CAR_READY_VOLUME = 1f;

	private float _bgmVolume;
	private float _soundVolume;
	public  float bgmVolume
	{
		set 
		{
			_bgmVolume = value;
		}
		get { return _bgmVolume; }
	}

	public  float soundVolume
	{
		set 
		{ 
			_soundVolume = value;
		}
		get { return _soundVolume; }
	}
	
	public void PlayingSound(SoundType type, float volume = 1f)
	{           
		if (GameData.isSoundOn == 1)
		{
			sound1.PlayOneShot(GetSoundAudioClip(type), volume);
		}
	}

	public void PlayingSound(SoundType type, bool isLoop, float volume = 1f)
	{
		if (GameData.isSoundOn == 1)
		{
			if (!sound2.isPlaying)
			{
				sound2.loop = isLoop;
				sound2.clip = GetSoundAudioClip(type);
				sound2.volume = volume;
				sound2.Play();
			}
			else if (!sound3.isPlaying)
			{
				sound3.loop = isLoop;
				sound3.clip = GetSoundAudioClip(type);
				sound3.volume = volume;
				sound3.Play();
			}
		}
	}

	public void StopSound(SoundType type)
	{
		if (sound1.clip != null && sound1.clip.name == GetSoundAudioClip(type).name)
		{
			sound1.Stop();
		}
		if (sound2.clip != null && sound2.clip.name == GetSoundAudioClip(type).name)
		{
			sound2.Stop();
		}
		if (sound3.clip != null && sound3.clip.name == GetSoundAudioClip(type).name)
		{
			sound3.Stop();
		} 
	}

	public AudioClip GetSoundAudioClip(SoundType type)
	{
		AudioClip clip = null;
		SoundGroup soundGroup = soundList.Find(c => c.sountType == type);
		if (soundGroup != null)
		{
			clip = soundGroup.audioClip;
		}
		else
		{
			clip = (AudioClip)Resources.Load("Audio/" + GameDefine.soundKeyList[type], typeof(AudioClip));
			SoundGroup soundItem = new SoundGroup();
			soundItem.audioClip = clip;
			soundItem.sountType = type;
			soundList.Add(soundItem);
		}
		return clip;
	}

	public void ClearSoundList()
	{
		soundList.Clear();
	}

	public AudioClip GetBgmAudioClip(BgmType type)
	{
		AudioClip clip = null;
		clip = (AudioClip)Resources.Load("Audio/" + GameDefine.BgmKeyList[type], typeof(AudioClip));
		return clip;
	}

	public void PlayRunSound()
	{
		runSound.clip = GetSoundAudioClip(SoundType.SOUND_RUN);
		runSound.Play ();
	}

	public void StopAllSound()
	{
		StopAllCoroutines();
		bgmSound.Stop();
		runSound.Stop();
		fireBulletSound.Stop();
		sound1.Stop();
		sound2.Stop();
		sound3.Stop();
	}

	public void StopRunSound()
	{
		runSound.Stop ();
	}

	public void PlayCarReadySoud()
	{
		carReadySound.clip = GetSoundAudioClip(SoundType.SOUND_ENGINE);
		carReadySound.Play();
	}

	public void StopCarReady()
	{
		carReadySound.Stop();
	}

	public void PlayFireBulletSound()
	{
		if(GameData.gameMode == GameDefine.GameModeZhanche || GameData.gameMode == GameDefine.GameModeZhancheBoss || SpecialPlatformManager.instance .isSpPlatform){
			fireBulletSound.clip = GetSoundAudioClip(SoundType.SOUND_PLAYER_SHOT); 
			fireBulletSound.Play ();
		}
	}
	public void StopFireBulletSound()
	{
		fireBulletSound.Stop ();
	}

	public void StopBackMusic()
	{
		StopCoroutine("StartBGM");
		StopCoroutine("StartCheckBgMusic");
		StartCoroutine(CoolGame.GameUtility.DelayToInvokeDo(() => { bgmSound.Stop(); }, 0.05f));
		
	}

	public void StartBackMusic()
	{
		StartCoroutine("StartCheckBgMusic");
	}

	//Start BGM when loading complete
	IEnumerator StartBGM()
	{
		yield return new WaitForSeconds(0.5f);

		if(GameData.sceneName == GameDefine.SceneNameGamePlay)
		{
			while (PatternSystem.instance.loadingComplete == false || GameAttribute.gameAttribute.gameState != GameState.GAMESTATE_COUNTDOWN)
			{
				yield return 0;
			}
		}
		
		if(GameData.sceneName == GameDefine.SceneNameGamePlay)
		{
			while (GameAttribute.gameAttribute.gameState == GameState.GAMESTATE_WAIT_FOR_START)
			{
				yield return 0;
			}

			if(GameData.gameMode == GameDefine.GameModeHouzidao)
			{
				bgmSound.clip = GetBgmAudioClip(BgmType.BGM_HOUZIDAO);
			}
			else if(GameData.gameMode == GameDefine.GameModeKapai)
			{
				bgmSound.clip = GetBgmAudioClip(BgmType.BGM_KAPAI);
			}
			else if(GameData.gameMode == GameDefine.GameModeWuxian)
			{
				bgmSound.clip = GetBgmAudioClip(BgmType.BGM_WUXIAN);
			}
			else if(ConfigData.instance.taskConfigs[GameData.GameTaskId].mapId == 1)
			{
				bgmSound.clip = GetBgmAudioClip(BgmType.BGM_DESERT);
			}
			else if (ConfigData.instance.taskConfigs[GameData.GameTaskId].mapId == 2)
			{
				bgmSound.clip = GetBgmAudioClip(BgmType.BGM_FOREST);
			}
			else if (ConfigData.instance.taskConfigs[GameData.GameTaskId].mapId == 3)
			{
				bgmSound.clip = GetBgmAudioClip(BgmType.BGM_OCEAN);
			}
			else
			{
				int randomValue = MyRandom.Range(0, 2);
				if (randomValue == 0)
				{
					bgmSound.clip = GetBgmAudioClip(BgmType.BGM_NORMAL_1);
				}
				else
				{
					bgmSound.clip = GetBgmAudioClip(BgmType.BGM_NORMAL_2);
				}
			}
		}
		else if (GameData.sceneName == GameDefine.SceneNameUI || GameData.sceneName == GameDefine.SceneNameLogin)
		{
			int randomValue = MyRandom.Range(0, 2);
			if (randomValue == 0)
			{
				bgmSound.clip = GetBgmAudioClip(BgmType.BGM_UI_MAIN_1);
			}
			else
			{
				bgmSound.clip = GetBgmAudioClip(BgmType.BGM_UI_MAIN_2);
			}
		}
		
		bgmSound.Play();
		StartCoroutine("StartCheckBgMusic");
		
	}

	IEnumerator StartCheckBgMusic()
	{
		if(GameData.sceneName == GameDefine.SceneNameGamePlay){
			while (PatternSystem.instance.loadingComplete == false)
			{
				yield return 0;
			}
		}

		//while(bgmSound.isPlaying){
		//    yield return 0;
		//}
		while (true)
		{
			if (bgmSound.isPlaying)
			{
				yield return 0;
			}
			else
			{
				if (GameData.sceneName == GameDefine.SceneNameGamePlay)
				{
					while (GameAttribute.gameAttribute.gameState == GameState.GAMESTATE_WAIT_FOR_START)
					{
						yield return 0;
					}

					if (GameData.gameMode == GameDefine.GameModeHouzidao)
					{
						bgmSound.clip = GetBgmAudioClip(BgmType.BGM_HOUZIDAO);
					}
					else if (GameData.gameMode == GameDefine.GameModeKapai)
					{
						bgmSound.clip = GetBgmAudioClip(BgmType.BGM_KAPAI);
					}
					else if (GameData.gameMode == GameDefine.GameModeWuxian)
					{
						bgmSound.clip = GetBgmAudioClip(BgmType.BGM_WUXIAN);
					}
					else if (ConfigData.instance.taskConfigs[GameData.GameTaskId].mapId == 1)
					{
						bgmSound.clip = GetBgmAudioClip(BgmType.BGM_DESERT);
					}
					else if (ConfigData.instance.taskConfigs[GameData.GameTaskId].mapId == 2)
					{
						bgmSound.clip = GetBgmAudioClip(BgmType.BGM_FOREST);
					}
					else if (ConfigData.instance.taskConfigs[GameData.GameTaskId].mapId == 3)
					{
						bgmSound.clip = GetBgmAudioClip(BgmType.BGM_OCEAN);
					}
					else
					{
						int randomValue = MyRandom.Range(0, 2);
						if (randomValue == 0)
						{
							bgmSound.clip = GetBgmAudioClip(BgmType.BGM_NORMAL_1);
						}
						else
						{
							bgmSound.clip = GetBgmAudioClip(BgmType.BGM_NORMAL_2);
						}
					}
				}
				else if (GameData.sceneName == GameDefine.SceneNameUI || GameData.sceneName == GameDefine.SceneNameLogin)
				{
					int randomValue = MyRandom.Range(0, 2);
					if (randomValue == 0)
					{
						bgmSound.clip = GetBgmAudioClip(BgmType.BGM_UI_MAIN_1);
					}
					else
					{
						bgmSound.clip = GetBgmAudioClip(BgmType.BGM_UI_MAIN_2);
					}
				}
				bgmSound.Play();
				yield return 0;
			}
		}
				

		//StartCoroutine (StartCheckBgMusic ());
	}

	IEnumerator WaitToPlayRunSound() {
		StopRunSound();
		float countdown = 2;
		while (countdown > 0) {
			yield return new WaitForSeconds(1);
			countdown--;
		}
		if (!GameAttribute.gameAttribute.isOver)
		{
			PlayRunSound();
		}
	}

	public void HitCar()
	{
		StopCoroutine("StartCheckHitCar");
		isHitCar = true;
		StartCoroutine("StartCheckHitCar");
	}

	public bool isHitCar = false;
	IEnumerator StartCheckHitCar()
	{
		while (isHitCar)
		{
			StopRunSound();
			yield return new WaitForSeconds(2f);
			if (!GameAttribute.gameAttribute.isOver)
			{
				PlayRunSound();
			}
			isHitCar = false;
		}
		yield return 0;
			
	}

	public void PlayEncourageSound()
	{
		int index = 0;
		if(ConfigData.LANGUAGE == Language.EN_US)
		{
			index = 5;
		}else if (ConfigData.LANGUAGE == Language.ZH_CN || ConfigData.LANGUAGE == Language.ZH_HK)
		{
			index = MyRandom.Range(0, encourage_List.Count);
		}
		if (GameData.isSoundOn == 1)
		{
			if (!sound3.isPlaying)
			{
				sound3.loop = false;
				sound3.clip = encourage_List[index];
				sound3.volume = 1f;
				sound3.Play();
			}
		}
	}

	public void PlayCountDownSound(int index)
	{
		if (GameData.isSoundOn == 1)
		{
			if (index >= 0 && index < countDown_List.Count)
			{
				sound1.PlayOneShot(countDown_List[index], 1f);
			} 
		}             
	}

	public void PlayWordSoundByName(string name, float volume = 2f)
	{
		if (GameData.isSoundOn == 1)
		{
			AudioClip clip = (AudioClip)Resources.Load("Audio/word/" + name, typeof(AudioClip));
			if (clip != null)
			{
				sound1.PlayOneShot(clip, volume);
			}
		}
	}

	*/
}
