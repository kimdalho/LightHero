using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataBase
{
    public enum item
    {
        아이디 = 0,
        타입 = 1,
        랭크 = 2,
        시리즈 = 3,
        이미지 = 4,
        이름 = 5,
        스토리 = 6,
        가격 = 7,
        공격력 = 8,
        방어력 = 9,
        속력 = 10,
        사정거리 = 11,
        불랫이미지 = 12

    }



    public object[] sprites;
    public object[] Ranksprites;
    public object[] Seriessprites;

    public List<string> itemList = new List<string>(); //전체 관리하기위한 아이템을 지정한다
    public List<string> rankList = new List<string>(); //전체 관리하기위한 아이템을 지정한다

    static List<Item> weapon = new List<Item>();
    static List<Item> armor1 = new List<Item>();

    public List<string> seriesList = new List<string>();


    //#############################

    public Dictionary<int, Dictionary<int, Item>> GetItem = new Dictionary<int, Dictionary<int, Item>>()
    {
     
    };
    public Dictionary<int, ArmorData> dic_Armor = new Dictionary<int, ArmorData>();

    public Dictionary<int, WeaponData> dic_Weapon = new Dictionary<int, WeaponData>();

    public Dictionary<int, Dictionary<int, Synergy>> GetSng = new Dictionary<int, Dictionary<int, Synergy>>()
    {

    };

    public Dictionary<int, Synergy> dic_Rank = new Dictionary<int, Synergy>();

    public Dictionary<int, Synergy> dic_Constellation = new Dictionary<int, Synergy>();


    //###############################


    private static DataBase instance;

    public static DataBase getInstance()
    {
        if(instance == null)
        {
            instance = new DataBase();
        }
        return instance;
    }

    public Sprite ScerchImg(string str_name , object[] _sp)
    {
      
        for (int i = 0; i < _sp.Length; i++)
        {
            if (_sp[i].ToString()  == (str_name + " (UnityEngine.Sprite)"))
            {
                return _sp[i] as Sprite;
            }
        }
        return null;
    }

    //case 0: part = GameManager.e_Itemtype.헬멧;
    //case 1: part = GameManager.e_Itemtype.무기;
    //case 2:part = GameManager.e_Itemtype.방어구;
    //case 3: part = GameManager.e_Itemtype.장신구;

    /*****Rank*******
            D
            C
            B
            A
            S
     ******Rank*******/

    /*****Series******
           switch (_series)
        {
            case 0:
                series = "물병자리";
                break;
            case 1:
                series = "물고기자리";
                break;
            case 2:
                series = "양자리";
                break;
            case 3:
                series = "황소자리";
                break;
            case 4:
                series = "쌍둥이자리";
                break;
            case 5:
                series = "게자리";
                break;
            case 6:
                series = "사자자리";
                break;
            case 7:
                series = "처녀자리";
                break;
            case 8:
                series = "천칭자리";
                break;
            case 9:
                series = "전갈자리";
                break;
            case 10:
                series = "사수자리";
                break;
            case 11:
                series = "염소자리";
                break;

        } // 0~11의 정수를 별자리 문자열로 변환
   ******Series*******/

    private void ArmorListCall()
    {
    
        itemList.Add("0,3,0,1,kindpng_283192_1,물병자리링,이동이 빨라졌다,4000,0,0,0.5");
        itemList.Add("1,0,0,3,kindpng_283192_78,자라나는헬멧,단순한 헬멧이다,1400,0,10,0");
        itemList.Add("2,2,0,2,kindpng_283192_85,도자기갑옷,단순한 갑옷이다,2500,0,20,0");
        itemList.Add("3,3,0,7,kindpng_283192_97,쌍둥이의 출생,비기가 적혀있는 비술서다,2000,4,0,0");
        itemList.Add("4,2,0,3,kindpng_283192_93,물병장화,이동 속도를 올려준다,2000,0,2,0.3");
        itemList.Add("5,3,0,1,kindpng_283192_1,쌍둥이 반지,단순한 검이다,2000,10,0,0");
        
    }
   
    private void WeaponListCall()
    {
        itemList.Add("0,1,0,6,kindpng_283192_72,쌍둥이 활,좋은 장검이다,2400,9,0,0,1,kindpng_283192_72");
        itemList.Add("1,1,0,9,kindpng_283192_100,사자의 지팡이,힘이 빠지는 마법봉이다,2000,7,-3,0,1,kindpng_283192_100");
        itemList.Add("2,1,0,2,kindpng_283192_70,물병,단순한 단검이다,1000,2,0,0,1,kindpng_283192_70");
    }

    private void RankListCall()
    {
        /*#################################
          순서
          아이디,타입, 호출 이미지, 나머지들 효과들

            타입 = 0 랭크
            타입 = 1 별자리
         ##################################*/



        rankList.Add("0,0,Dimg,3,3,3");
        rankList.Add("1,0,Cimg,3,3,3");
        rankList.Add("2,0,Bimg,3,3,3");
        rankList.Add("3,0,Aimg,3,3,3");
        rankList.Add("4,0,Simg,3,3,3");
    }

    private void ConstellationListCall()
    {
        /*#################################
           순서
           아이디,타입, 호출 이미지, 나머지들 효과들

             타입 = 0 랭크
             타입 = 1 별자리
        ##################################*/

        rankList.Add("0,1,cell9,3,3,3");
        rankList.Add("1,1,cell1,3,3,3");
        rankList.Add("2,1,cell2,3,3,3");
        rankList.Add("3,1,cell3,3,3,3");
        rankList.Add("4,1,cell4,3,3,3");
        rankList.Add("5,1,cell5,3,3,3");
        rankList.Add("6,1,cell6,3,3,3");
        rankList.Add("7,1,cell7,3,3,3");
        rankList.Add("8,1,cell8,3,3,3");
        rankList.Add("9,1,cell0,3,3,3");

        rankList.Add("10,1,cell10,3,3,3");
        rankList.Add("11,1,cell11,3,3,3");
        
    }



    public void ItemDataSetUp()
    {
        sprites = Resources.LoadAll("Image/item"); //아이템 아틀라스 호출
        Ranksprites = Resources.LoadAll("Image/Testimg"); //랭크 아틀라스 호출
        Seriessprites = Resources.LoadAll("Image/sceris"); // 별자리 아틀라스 호출

        ArmorListCall();
        WeaponListCall();
        RankListCall();
        ConstellationListCall();
//############################################
//############################################
        for (int i = 0; i < itemList.Count; i++)
        {
            ItemCSVRender(i);
        }

        Dictionary<int, Item> arm = new Dictionary<int, Item>();

        Dictionary<int, Item> wepon= new Dictionary<int, Item>();


        for (int i = 0; i < dic_Armor.Count; i ++)
        {
            arm.Add(i,dic_Armor[i].ToItem());
        }
        GetItem.Add(0, arm);
        

        for (int i = 0; i < dic_Weapon.Count; i++)
        {
            wepon.Add(i, dic_Weapon[i].ToItem());
        }
        GetItem.Add(1, wepon);

//############################################
 //############################################

        for (int i = 0; i < rankList.Count; i++)
        {
            RankCSVRender(i);
        }

        Dictionary<int, Synergy> testItem = new Dictionary<int, Synergy>();

        Dictionary<int, Synergy> testItem1 = new Dictionary<int, Synergy>();

        for (int i = 0; i < dic_Rank.Count; i++)
        {
            testItem.Add(i, dic_Rank[i]);
        }
        GetSng.Add(0, testItem);


        for (int i = 0; i < dic_Constellation.Count; i++)
        {
            testItem1.Add(i, dic_Constellation[i]);
        }
        GetSng.Add(1, testItem1);
    }


    




    public void ItemCSVRender(int number)
    {
            string str = itemList[number];
            string[] result = str.Split(new char[] { ',' });
            int itemtype = int.Parse(result[(int)item.타입]);
            if (itemtype != 1)
            {
                int id = int.Parse(result[(int)item.아이디]);
                int rank = int.Parse(result[(int)item.랭크]);
                int series = int.Parse(result[(int)item.시리즈]);
                Sprite img = ScerchImg(result[(int)item.이미지],sprites);
                string name = result[(int)item.이름];
                string story = result[(int)item.스토리];
                int price = int.Parse(result[(int)item.가격]);
                int atk = int.Parse(result[(int)item.공격력]);
                int def = int.Parse(result[(int)item.방어력]);
                float speed = float.Parse(result[(int)item.속력]);
                dic_Armor.Add(id, new ArmorData(id, itemtype, rank, series, img, name, story, price, atk, def, speed));
            }
             if (itemtype == 1) //무기
                {
                int id = int.Parse(result[(int)item.아이디]);
             
                int rank = int.Parse(result[(int)item.랭크]);
                int series = int.Parse(result[(int)item.시리즈]);
                Sprite img = ScerchImg(result[(int)item.이미지],sprites);
                string name = result[(int)item.이름];
                string story = result[(int)item.스토리];
                int price = int.Parse(result[(int)item.가격]);
                int atk = int.Parse(result[(int)item.공격력]);
                int def = int.Parse(result[(int)item.방어력]);
                float speed = float.Parse(result[(int)item.속력]);
                float leangth = float.Parse(result[(int)item.사정거리]);
                Sprite bulet_img = DataBase.getInstance().ScerchImg(result[(int)item.불랫이미지],sprites);

                 dic_Weapon.Add(id, new WeaponData(id, itemtype, rank, series, img, name, story, price, atk, def, speed, leangth, bulet_img));
             }

    }


    public void RankCSVRender(int number)
    {
        string str = rankList[number];
        string[] result = str.Split(new char[] { ',' });
        int type = int.Parse(result[1]);
        int id = int.Parse(result[(int)item.아이디]);
        int buffAtk = 0;
        int buffDef = 0;
        float buffSpeed = 0;
        

        Sprite img = null;
        switch (type)
        {
            case 0:
           
             img = ScerchImg(result[2], Ranksprites);
             buffAtk = int.Parse(result[3]);
             buffDef = int.Parse(result[4]);
             buffSpeed = int.Parse(result[5]);
             dic_Rank.Add(id, new Synergy(id, img, buffAtk, buffDef, buffSpeed));
             break;

            case 1:
                img = ScerchImg(result[2], Seriessprites);
                buffAtk = int.Parse(result[3]);
                buffDef = int.Parse(result[4]);
                buffSpeed = int.Parse(result[5]);

               dic_Constellation.Add(id, new Synergy(id, img, buffAtk, buffDef, buffSpeed));
                break;

        }
   
        //Sprite img = ScerchImg(result[(int)item.이미지], );
        // result[0] 아이디
        // result[1] 타입
        // result[2] 이미지
        // result[2 + n] 나머지 시너지 효과들


    }


}

