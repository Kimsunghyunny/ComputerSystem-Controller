# ComputerSystem-Controller
절전 모드 기능과 자동 종료 기능을 하는 프로그램 설계



## 프로그램에 들어가는 기능
- 컴퓨터 관리 part
 1)	모니터 밝기 조절 기능
모니터의 밝기를 버튼이나 스크롤 바를 이용해서 조절할 수 있다.
 2)	컴퓨터 볼륨 조절 기능
컴퓨터 볼륨을 버튼이나 스크롤 바를 이용해서 조절할 수 있다.
 3)	배터리 정보 열람 기능
배터리의 현재 값에 대해서 얼마나 남았는지, 충전 여부등과 같은 정보를 사용자가 볼 수 있다.
 - 파워 관리 part
 1)	절전모드
최소 절전이나 최대 절전모드를 바로 실행할 수 있다. 또한 최소 절전과 최대 절전을 사용자가 컴퓨터에 아무 반응을 보이지 않을 시 몇 분까지 기다렸다가 절전모드에 들어갈 것인지 저장하고 수정할 수 있다.
 2)	자동종료
프로세스가 없을 때만 종료하는 정상종료와 프로세스의 여부와 관계없이 컴퓨터를 종료하는 강제 종료를 시간에 맞춰서 조절할 수 있다.
 - 단축키를 이용한 절전모드 실행
1)	윈도우 바에 나타나는 메뉴 창을 이용해서 단축키를 목록 중에서 단축키를 저장해서 절전모드를 실행할 수 있다.
<br>

## :pushpin:  주의 사항
 
 1)해당 프로그램은 노트북 실행을 바탕으로 만들어졌다. \
 2)	nircmd파일을 실행할 시에, 코드상에서 nircmd파일의 위치 주소를 바꾸어 줘야 제대로 실행할 수 있다.


<br>



## :heavy_check_mark: 실행
 
실행 시 메인 화면의 모습이다. 

![image](https://user-images.githubusercontent.com/22141977/117779048-3f6fa380-b279-11eb-90a8-aaf9ac592a3d.png)

컴퓨터와 파워 세팅 두개의 관리 모드 중 하나를 선택해서 클릭하면 새로운 창이 뜬다.

![image](https://user-images.githubusercontent.com/22141977/117779067-4696b180-b279-11eb-9524-dbfb6e2815c9.png)

컴퓨터 관리 창의 모습이다. 밝기와 소리를 조절할 수 있는 트랙바와 음소거, 최대음향, 음소거 종료 버튼이 있으며, 배터리에 대한 정보 또한 볼 수 있다.

![image](https://user-images.githubusercontent.com/22141977/117779123-544c3700-b279-11eb-88e8-a1b2a289c7e2.png)
 
충전 중일 때의 화면이다. 그림과 라벨의 출력 값이 변경된 것을 확인할 수 있다.
 
![image](https://user-images.githubusercontent.com/22141977/117779147-5910eb00-b279-11eb-8c5a-3fc64467123b.png)

mute버튼을 눌렀을때의 화면이다. 소리의 값이 0으로 간 것을 확인할 수 있다.

![image](https://user-images.githubusercontent.com/22141977/117779165-5f9f6280-b279-11eb-8b0f-c602799d6406.png)
 
Max volume 버튼을 눌렀을 때의 화면이다. 소리의 값이 100으로 간 것을 확인할 수 있다.
  
![image](https://user-images.githubusercontent.com/22141977/117779187-68903400-b279-11eb-892d-5671a0cf90f9.png)

메인 화면에서 Power setting을 눌렀을 때 뜨는 창의 모습이다. 만일, 어떤 절전을 할것인지 선택을 하지않고 바로실행이나 저장 버튼을 누르면 절전모드를 선택해주세요. 라는 메시지박스가 실행된다.

![image](https://user-images.githubusercontent.com/22141977/117779229-71810580-b279-11eb-8655-2a9cf7d4a3e0.png)
  
정상종료를 선택하고 시간을 으로 설정하고 저장버튼을 눌렀을 때, 다음과 같이 밑에 언제 정상 자동 종료를 실행할것인지 출력된다. 만일, 어떤 종료를 할것인지 선택하지 않고 저장버튼을 누르면 종료 모드를 선택해주세요. 라는 메시지 박스가 실행된다.
 
강제종료를 선택한 뒤, 시간을 설정하고 저장을 눌렀을 때, 언제 강제 자동 종료를 실행할지에 대해서 출력된다. 
  
![image](https://user-images.githubusercontent.com/22141977/117779285-7f368b00-b279-11eb-8e60-ab9ec3e6da35.png)

사용안함을 선택하면 다음과 같이 출력되는 것이 사라지고, 자동 종료 또한 취소된다.
또한 만약, 정상적으로 동작이 되면 textbox에 shutdown을 서버에서 받아와서 출력하게 된다.
 
![image](https://user-images.githubusercontent.com/22141977/117779313-865d9900-b279-11eb-863b-9e12c54a7428.png)

메인 화면을 닫으면 프로그램이 종료가 되지않고, 다음과 같이 윈도우 바에 아이콘이 나타나게 된다. 아이콘을 더블클릭하면 메인 화면이 켜지게 된다.
 
![image](https://user-images.githubusercontent.com/22141977/117779342-8eb5d400-b279-11eb-936a-d37cf8b190b6.png)

윈도우바를 오른쪽 마우스를 이용해서 클릭했을 때 다음과 같은 메뉴가 출력된다. 절전모드 실행을 누르면 최소절전모드로 절전모드가 바로 실행된다. 컴퓨터 설정을 누르면 컴퓨터 설정 메뉴창이 나타나고, 파워 설정 버튼을 누르면 파워 설정 메뉴창이 나타나게 된다. 
 
![image](https://user-images.githubusercontent.com/22141977/117779360-92e1f180-b279-11eb-87b0-f1cf166f5f11.png)

절전모드 단축키 설정버튼을 누르면 다음과 같은 화면이 뜨고, 단축키를 설정한 뒤, 저장을 누르면 그 뒤로부터 단축키를 이용해서 최소절전모드를 실행할 수 있다.
 
![image](https://user-images.githubusercontent.com/22141977/117779382-98d7d280-b279-11eb-9500-755ae40bcbb0.png)

메뉴에서 종료버튼을 누르면 다음과 같은 창이 나타나고, 예를 누르면 프로그램이 종료되면서 자동종료의 내용이 삭제된다.
