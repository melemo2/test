using System.Collections.Specialized;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace WinFormsApp9
{
    public partial class Form1 : Form
    {
        public class Concept
        {
            public string label { get; set; }
            public string title { get; set; }
            public string type { get; set; }
            public string text { get; set; }
        }

        public class Angle
        {
            public string label { get; set; }
            public string desc { get; set; }
        }

        public class Gender
        {
            public string label { get; set; }
            public string desc { get; set; }
        }

        public class Body
        {
            public string label { get; set; }
            public string desc { get; set; }
        }

        public class HairStyle
        {
            public string label { get; set; }
            public string desc { get; set; }
        }

        public class Face
        {
            public string label { get; set; }
            public string desc { get; set; }
        }

        public class Look
        {
            public string label { get; set; }
            public string desc { get; set; }
        }

        public static class APIS
        {
            public static string domain = "211.241.108.205";
            //public static string domain = "127.0.0.1";

            public static void InitAPI()
            {
                string url = "http://" + domain + "/InitAPI";

                HttpClient httpClient = new HttpClient();
                httpClient.Timeout = TimeSpan.FromMinutes(30);

                using HttpResponseMessage response = httpClient.GetAsync(url).Result;
                return;
            }

            public static string CallAPI(string text)
            {
                string url = "http://" + domain + "/CallAPI";

                HttpClient httpClient = new HttpClient();
                httpClient.Timeout = TimeSpan.FromMinutes(30);

                using StringContent jsonContent = new(text, Encoding.UTF8, "application/text");

                using HttpResponseMessage response = httpClient.PostAsync(url, jsonContent).Result;

                var jsonResponse = response.Content.ReadAsStringAsync().Result;

                return jsonResponse;
            }

            public static string CallRAG(string text)
            {
                string url = "http://" + domain + "/CallRAG";

                HttpClient httpClient = new HttpClient();
                httpClient.Timeout = TimeSpan.FromMinutes(30);

                using StringContent jsonContent = new(text, Encoding.UTF8, "application/text");

                using HttpResponseMessage response = httpClient.PostAsync(url, jsonContent).Result;

                var jsonResponse = response.Content.ReadAsStringAsync().Result;

                return jsonResponse;
            }

            public static string AddRAG(string name, string info)
            {
                string url = "http://" + domain + "/AddRAG/" + name;

                HttpClient httpClient = new HttpClient();
                httpClient.Timeout = TimeSpan.FromMinutes(30);

                using StringContent jsonContent = new(info, Encoding.UTF8, "application/text");

                using HttpResponseMessage response = httpClient.PostAsync(url, jsonContent).Result;

                var jsonResponse = response.Content.ReadAsStringAsync().Result;

                return jsonResponse;
            }

            public static string DeleteRAG(string name)
            {
                string url = "http://" + domain + "/DeleteRAG/" + name;

                HttpClient httpClient = new HttpClient();
                httpClient.Timeout = TimeSpan.FromMinutes(30);

                using HttpResponseMessage response = httpClient.GetAsync(url).Result;

                var jsonResponse = response.Content.ReadAsStringAsync().Result;

                return jsonResponse;
            }

            public static Bitmap CallSD(string text)
            {
                string url = "http://" + domain + "/CallSD";

                HttpClient httpClient = new HttpClient();
                httpClient.Timeout = TimeSpan.FromMinutes(30);

                using StringContent jsonContent = new(text, Encoding.UTF8, "application/text");

                using HttpResponseMessage response = httpClient.PostAsync(url, jsonContent).Result;

                if (response.Content.Headers.ContentType.MediaType == "image/png")
                {
                    byte[] bytes = response.Content.ReadAsByteArrayAsync().Result;
                    FileStream file = new FileStream("sd.png", FileMode.Create);
                    file.Write(bytes, 0, bytes.Length);
                    file.Close();

                    using (var fs = new System.IO.FileStream("sd.png", System.IO.FileMode.Open))
                    {
                        var bmp = new Bitmap(fs);
                        return (Bitmap)bmp.Clone();
                    }   
                }
                else
                {
                    return null;
                }
            }
        }

        public List<Concept> Concepts = new();
        public List<Angle> Angles = new();
        public List<Gender> Genders = new();
        public List<Body> Bodies = new();
        public List<HairStyle> HairStyles = new();
        public List<Look> Looks = new();
        public List<Face> Facies = new();

        public Form1()
        {
            InitializeComponent();
            //APIS.InitAPI();

            ImageList imgList = new ImageList();
            imgList.Images.Add(stringToImage("Ep"));
            imgList.Images.Add(stringToImage("Pl"));
            imgList.Images.Add(stringToImage("Sc"));
            treeView1.ImageList = imgList;

            treeView1.LabelEdit = true;

            treeView1.AfterSelect += (s, e) =>
            {
                textBox9.Text = treeView1.SelectedNode.ToolTipText;
            };

            treeView1.DoubleClick += (s, e) =>
            {
                if (treeView1.SelectedNode != null)
                    treeView1.SelectedNode.BeginEdit();
            };

            listBox1.DataSource = Concepts;
            listBox1.DisplayMember = "label";
            listBox1.SelectedIndexChanged += (s, e) =>
            {
                comboBox1.Text = Concepts[listBox1.SelectedIndex].type;
                textBox1.Text = Concepts[listBox1.SelectedIndex].text;
                textBox8.Text = Concepts[listBox1.SelectedIndex].title;
            };
            listBox1.DoubleClick += (s, e) =>
            {
                if (listBox1.SelectedItem != null)
                {
                    APIS.DeleteRAG(Concepts[listBox1.SelectedIndex].title);
                    Concepts.RemoveAt(listBox1.SelectedIndex);

                    listBox1.DataSource = null;
                    listBox1.DataSource = Concepts;
                    listBox1.DisplayMember = "label";
                }
            };

            //var result = "{\r\n\t\"result\": [\r\n\t\t{\r\n\t\t\t\"title\": \"현실과 아스트랄의 경계\", \r\n\t\t\t\"description\": \"20살 프로그래머 주인공, '아스트랄'에 매료되어 현실과 가상현실의 경계를 넘나드는 삶을 살아감.  '아스트랄'에서 만난 다양한 여성 캐릭터들과 관계를 맺으며 흥미로운 스토리가 시작됨. \"\r\n\t\t},\r\n\t\t{\r\n\t\t\t\"title\": \"첫 번째 만남, 그녀의 비밀\", \r\n\t\t\t\"description\": \"'아스트랄'에서 만난 첫 번째 히로인, '서윤'과의 만남. 그녀는 '아스트랄' 내부의 특수 종족으로, 주인공에게 숨겨진 비밀을 알려주며 위험한 상황에 휘말리게 됨.\"\r\n\t\t},\r\n\t\t{\r\n\t\t\t\"title\": \"아스트랄의 위협\", \r\n\t\t\t\"description\": \" '아스트랄' 관리자 조직의 음모가 드러나고, 주인공은 '아스트랄'의 안전과 자신의 목숨을 지키기 위해 고군분투. '아스트랄' 내부의 특수 종족들과의 충돌, 현실 세계와의 연결 문제 등 위기가 닥쳐옴.\"\r\n\t\t},\r\n\t\t{\r\n\t\t\t\"title\": \"두 번째 만남, 그녀의 상처\", \r\n\t\t\t\"description\": \" '아스트랄'에서 만난 두 번째 히로인, '하연'과의 만남. 그녀는 과거 아스트랄 관련 사건으로 인해 상처를 입고, 주인공에게 도움을 요청. 주인공은 그녀의 상처를 치유하고 함께 위기를 헤쳐나가야 함.\"\r\n\t\t},\r\n\t\t{\r\n\t\t\t\"title\": \"현실의 그림자\", \r\n\t\t\t\"description\": \" '아스트랄'에서 벌어지는 사건들이 현실 세계에 영향을 미치기 시작. 주인공은 '아스트랄'의 문제를 해결하기 위해 현실 세계로 돌아와 '아스트랄' 관리자 조직과 대립. \"\r\n\t\t},\r\n\t\t{\r\n\t\t\t\"title\": \"세 번째 만남, 그녀의 선택\", \r\n\t\t\t\"description\": \" '아스트랄'에서 만난 세 번째 히로인, '지은'과의 만남. 그녀는 '아스트랄' 관리자 조직의 일원이었지만, 주인공의 진심에 감동해 그를 돕기로 결심. 하지만 조직의 배신과 자신의 과거에 대한 죄책감에 괴로워함.\"\r\n\t\t},\r\n\t\t{\r\n\t\t\t\"title\": \"위험한 선택\", \r\n\t\t\t\"description\": \" 주인공은 '아스트랄' 관리자 조직의 음모를 막기 위해 '아스트랄' 내부의 특수 종족들과 손을 잡는 위험한 선택을 하게 됨. 히로인들과의 관계는 더욱 복잡해지고,  주인공은 자신의 선택에 대한 책임감과 갈등을 느낌.\"\r\n\t\t},\r\n\t\t{\r\n\t\t\t\"title\": \"과거의 진실\", \r\n\t\t\t\"description\": \" 주인공은 '아스트랄' 관리자 조직의 배후에 숨겨진 거대한 음모와 자신의 과거와 관련된 비밀을 알게 됨. 히로인들과 함께 과거의 진실을 파헤치고 음모를 막아야 함. \"\r\n\t\t},\r\n\t\t{\r\n\t\t\t\"title\": \"최후의 결전\", \r\n\t\t\t\"description\": \" '아스트랄' 관리자 조직과의 최후의 결전. 주인공은 히로인들과 함께 힘을 합쳐 '아스트랄'의 안전과 자신의 목숨을 지키기 위해 싸움. \"\r\n\t\t},\r\n\t\t{\r\n\t\t\t\"title\": \"새로운 시작\", \r\n\t\t\t\"description\": \" '아스트랄'의 위기가 해결되고, 주인공은 히로인들과 함께 새로운 삶을 시작. '아스트랄'과 현실 세계의 관계, 인간의 능력과 책임에 대한 성찰.  \"\r\n\t\t}\r\n\t]\r\n}";
            //result = result.Replace("```json", "").Replace("```", "");
            //JObject json = JsonConvert.DeserializeObject<JObject>(result);
            //var resultArray = json["result"].ToArray();

            //treeView1.Nodes.Clear();

            //int count = 1;
            //foreach (var item in resultArray)
            //{
            //    TreeNode svrNode = new TreeNode(string.Format("{0}. {1}", count++, item["title"].ToString()), 0, 0);
            //    svrNode.ToolTipText = item["description"].ToString();
            //    treeView1.Nodes.Add(svrNode);
            //}

            Angles.Add(new Angle() { label = "없음", desc = "" });
            Angles.Add(new Angle() { label = "얼굴", desc = "extreme facial close up" });
            Angles.Add(new Angle() { label = "어깨 부터 위", desc = "facial close up" });
            Angles.Add(new Angle() { label = "겨드랑이 부터 위", desc = "medium close up" });
            Angles.Add(new Angle() { label = "가슴 위", desc = "bust shot" });
            Angles.Add(new Angle() { label = "허리 위", desc = "waist shot" });
            Angles.Add(new Angle() { label = "배꼽부터 위", desc = "medium shot" });
            Angles.Add(new Angle() { label = "골반부터 위", desc = "upper body" });
            Angles.Add(new Angle() { label = "허벅지 중간부터 위", desc = "cowboy shot" });
            Angles.Add(new Angle() { label = "허벅지부터 위", desc = "thigh above body" });
            Angles.Add(new Angle() { label = "발끝부터 위", desc = "full body" });

            Angles.Add(new Angle() { label = "뒷모습", desc = "from behind, back view" });
            Angles.Add(new Angle() { label = "셀카", desc = "super Wide Angle Shot, Pull the camera back from the subject, high Angle Selfie" });
            Angles.Add(new Angle() { label = "위에서 아래", desc = "from above" });
            Angles.Add(new Angle() { label = "아래에서 위", desc = "from below" });

            comboBox3.DataSource = null;
            comboBox3.DataSource = Angles;
            comboBox3.DisplayMember = "label";

            Genders.Add(new Gender() { label = "남성", desc = "1 boy, solo" });
            Genders.Add(new Gender() { label = "여성", desc = "1 girl, solo" });

            comboBox4.DataSource = null;
            comboBox4.DataSource = Genders;
            comboBox4.DisplayMember = "label";

            Bodies.Add(new Body() { label = "없음", desc = "" });
            Bodies.Add(new Body() { label = "SD 2등신", desc = "Chibi" });
            Bodies.Add(new Body() { label = "5세 이하", desc = "toddler" });
            Bodies.Add(new Body() { label = "초등학생", desc = "child" });
            Bodies.Add(new Body() { label = "중, 고등학생", desc = "tween" });
            Bodies.Add(new Body() { label = "슬랜더", desc = "slender" });
            Bodies.Add(new Body() { label = "중년 남성", desc = "middle age man" });
            Bodies.Add(new Body() { label = "중년 여성", desc = "middle age woman" });
            Bodies.Add(new Body() { label = "노인 남성", desc = "old man" });
            Bodies.Add(new Body() { label = "노인 여성", desc = "old woman" });
            Bodies.Add(new Body() { label = "근육질", desc = "muscular" });
            Bodies.Add(new Body() { label = "비만", desc = "chubby" });
            Bodies.Add(new Body() { label = "가슴 없음", desc = "flat chested" });
            Bodies.Add(new Body() { label = "기본 가슴", desc = "medium sized busts" });
            Bodies.Add(new Body() { label = "큰 가슴", desc = "busty" });
            Bodies.Add(new Body() { label = "매우 큰 가슴", desc = "huge busty" });

            comboBox5.DataSource = null;
            comboBox5.DataSource = Bodies;
            comboBox5.DisplayMember = "label";

            HairStyles.Add(new HairStyle() { label = "없음", desc = "" });
            HairStyles.Add(new HairStyle() { desc = "bang ", label = "앞머리" });
            HairStyles.Add(new HairStyle() { desc = "bob hair ", label = "보브컷" });
            HairStyles.Add(new HairStyle() { desc = "bun hair ", label = "똥머리, 주로 두개 생김" });
            HairStyles.Add(new HairStyle() { desc = "curled up hair ", label = "밑단부터 말려 올라가는 머리" });
            HairStyles.Add(new HairStyle() { desc = "curly hair ", label = "말린 머리" });
            HairStyles.Add(new HairStyle() { desc = "curved bob hair ", label = "밑단이 말린 보브컷" });
            HairStyles.Add(new HairStyle() { desc = "drill hair ", label = "말린 머리" });
            HairStyles.Add(new HairStyle() { desc = "hair slicked back ", label = "뒤로 넘긴 머리" });
            HairStyles.Add(new HairStyle() { desc = "hair slicked side ", label = "옆으로 넘긴 머리" });
            HairStyles.Add(new HairStyle() { desc = "long hair ", label = "긴 머리카락" });
            HairStyles.Add(new HairStyle() { desc = "low twintails ", label = "트윈테일이 낮은 위치서 생성" });
            HairStyles.Add(new HairStyle() { desc = "long twist hair ", label = "긴 땋은머리" });
            HairStyles.Add(new HairStyle() { desc = "matted hair ", label = "헝클어진" });
            HairStyles.Add(new HairStyle() { desc = "medium hair ", label = "중간 길이, 어깨를 넘는 길이의 머리" });
            HairStyles.Add(new HairStyle() { desc = "messy hair ", label = "덮수룩한 머리" });
            HairStyles.Add(new HairStyle() { desc = "ponytail hair ", label = "포니테일" });
            HairStyles.Add(new HairStyle() { desc = "rich hair ", label = "풍성한 머리. 웨이브 등의 스타일과 섞어쓸때 효과가 좋음" });
            HairStyles.Add(new HairStyle() { desc = "shaggy hair ", label = "샤기컷" });
            HairStyles.Add(new HairStyle() { desc = "short hair ", label = "짧은 머리카락" });
            HairStyles.Add(new HairStyle() { desc = "shoulder length bob hair ", label = "어깨길이의 보브컷" });
            HairStyles.Add(new HairStyle() { desc = "straight hair ", label = "직모" });
            HairStyles.Add(new HairStyle() { desc = "straight hair, hime_cut ", label = "히메컷, shaggy cut은 필터링" });
            HairStyles.Add(new HairStyle() { desc = "twintails ", label = "트윈테일" });
            HairStyles.Add(new HairStyle() { desc = "twin Braides ", label = "트윈테일 땋은머리" });
            HairStyles.Add(new HairStyle() { desc = "twist hair ", label = "땋은머리" });
            HairStyles.Add(new HairStyle() { desc = "two side up half hair ", label = "양쪽 반묶음 머리" });
            HairStyles.Add(new HairStyle() { desc = "unkempt hair ", label = "정리안된 뻗친" });
            HairStyles.Add(new HairStyle() { desc = "voluminous_long_hair ", label = "볼륨있는 롱헤어" });
            HairStyles.Add(new HairStyle() { desc = "wavy hair ", label = "웨이브진 머리" });
            HairStyles.Add(new HairStyle() { desc = "updo hair ", label = "올림 머리" });

            comboBox6.DataSource = null;
            comboBox6.DataSource = HairStyles;
            comboBox6.DisplayMember = "label";

            Facies.Add(new Face() { label = "없음", desc = "" });
            Facies.Add(new Face() { desc = "blanked eyes ", label = "동태눈" });
            Facies.Add(new Face() { desc = "blush ", label = "홍조,부끄러운 표정" });
            Facies.Add(new Face() { desc = "crying ", label = "우는얼굴" });
            Facies.Add(new Face() { desc = "crying with eyes open ", label = "눈뜬 우는얼굴" });
            Facies.Add(new Face() { desc = "drooling ", label = "침 흘리는" });
            Facies.Add(new Face() { desc = "empty eyes ", label = "레이프눈" });
            Facies.Add(new Face() { desc = "heart in pupils ", label = "눈동자의 하트" });
            Facies.Add(new Face() { desc = "open mouth ", label = "입 벌림" });
            Facies.Add(new Face() { desc = "smile ", label = "미소" });
            Facies.Add(new Face() { desc = "stick out tongue ", label = "내민 혀" });
            Facies.Add(new Face() { desc = "tears ", label = "눈물" });

            comboBox7.DataSource = null;
            comboBox7.DataSource = Facies;
            comboBox7.DisplayMember = "label";

            Looks.Add(new Look() { label = "없음", desc = "" });
            Looks.Add(new Look() { desc = "angry face ", label = "화난 표정" });
            Looks.Add(new Look() { desc = "applying makeup ", label = "화장하다" });
            Looks.Add(new Look() { desc = "aroused face ", label = "흥분한 표정" });
            Looks.Add(new Look() { desc = "arrogant face ", label = "오만한 표정" });
            Looks.Add(new Look() { desc = "benevolent face ", label = "자비로운 표정" });
            Looks.Add(new Look() { desc = "boring face ", label = "지루한 표정" });
            Looks.Add(new Look() { desc = "bright face ", label = "해맑은 표정" });
            Looks.Add(new Look() { desc = "charmed face ", label = "매혹한 표정" });
            Looks.Add(new Look() { desc = "confused face ", label = "혼란한 표정" });
            Looks.Add(new Look() { desc = "crazy face ", label = "미친 표정" });
            Looks.Add(new Look() { desc = "crying face ", label = "우는 표정" });
            Looks.Add(new Look() { desc = "desired face ", label = "희망한 표정" });
            Looks.Add(new Look() { desc = "despair face ", label = "절망한 표정" });
            Looks.Add(new Look() { desc = "determined face ", label = "단호한 표정" });
            Looks.Add(new Look() { desc = "disappointed face ", label = "실망한 표정" });
            Looks.Add(new Look() { desc = "distressed face ", label = "괴로운 표정" });
            Looks.Add(new Look() { desc = "drunk face ", label = "취한 표정" });
            Looks.Add(new Look() { desc = "earnest face ", label = "간절한 표정" });
            Looks.Add(new Look() { desc = "easygoing face ", label = "느긋한 표정" });
            Looks.Add(new Look() { desc = "ecstasy face ", label = "황홀한 표정" });
            Looks.Add(new Look() { desc = "embarrassed face ", label = "당황한 표정" });
            Looks.Add(new Look() { desc = "envious face ", label = "부러운 표정" });
            Looks.Add(new Look() { desc = "evil face ", label = "사악한 표정" });
            Looks.Add(new Look() { desc = "expression face ", label = "무표정한 표정" });
            Looks.Add(new Look() { desc = "frightened face ", label = "질겁한 표정" });
            Looks.Add(new Look() { desc = "frustrated face ", label = "좌절한 표정" });
            Looks.Add(new Look() { desc = "gentle face ", label = "상냥한 표정" });
            Looks.Add(new Look() { desc = "giddy face ", label = "들뜬 표정" });
            Looks.Add(new Look() { desc = "gloomy face ", label = "암울한 표정" });
            Looks.Add(new Look() { desc = "happy face ", label = "기쁜 표정" });
            Looks.Add(new Look() { desc = "idea face ", label = "생각한 표정" });
            Looks.Add(new Look() { desc = "irritating face ", label = "짜증난 표정" });
            Looks.Add(new Look() { desc = "joyful face ", label = "즐거운 표정" });
            Looks.Add(new Look() { desc = "lamented face ", label = "한탄한 표정" });
            Looks.Add(new Look() { desc = "light face ", label = "가벼운 표정" });
            Looks.Add(new Look() { desc = "lonely face ", label = "외로운 표정" });
            Looks.Add(new Look() { desc = "miserable face ", label = "비참한 표정" });
            Looks.Add(new Look() { desc = "nervous face ", label = "초조한 표정" });
            Looks.Add(new Look() { desc = "outraged face ", label = "분노한 표정" });
            Looks.Add(new Look() { desc = "pale face ", label = "창백한 표정" });
            Looks.Add(new Look() { desc = "pathetic face ", label = "한심한 표정" });
            Looks.Add(new Look() { desc = "pretentious face ", label = "잘난 척한 표정" });
            Looks.Add(new Look() { desc = "sacred face ", label = "신성한 표정" });
            Looks.Add(new Look() { desc = "sad face ", label = "슬픈 표정" });
            Looks.Add(new Look() { desc = "scary face ", label = "무서운 표정" });
            Looks.Add(new Look() { desc = "scoffing face ", label = "비웃는 표정" });
            Looks.Add(new Look() { desc = "scornful face ", label = "경멸한 표정" });
            Looks.Add(new Look() { desc = "seduced face ", label = "유혹한 표정" });
            Looks.Add(new Look() { desc = "serious face ", label = "심각한 표정" });
            Looks.Add(new Look() { desc = "shameful face ", label = "부끄러운 표정" });
            Looks.Add(new Look() { desc = "sleepy face ", label = "졸린 표정" });
            Looks.Add(new Look() { desc = "smiling face ", label = "웃는 표정" });
            Looks.Add(new Look() { desc = "sorrowful face ", label = "애달픈 표정" });
            Looks.Add(new Look() { desc = "suppressed face ", label = "억눌린 표정" });
            Looks.Add(new Look() { desc = "surprised face ", label = "놀란 표정" });
            Looks.Add(new Look() { desc = "suspicious face ", label = "의심한 표정" });
            Looks.Add(new Look() { desc = "tearful face ", label = "울먹이는 표정" });
            Looks.Add(new Look() { desc = "tired face ", label = "피곤한 표정" });
            Looks.Add(new Look() { desc = "touched face ", label = "감동한 표정" });
            Looks.Add(new Look() { desc = "turn red face ", label = "붉히다 표정" });
            Looks.Add(new Look() { desc = "unfair face ", label = "억울한 표정" });
            Looks.Add(new Look() { desc = "unfortunate face ", label = "불행한 표정" });
            Looks.Add(new Look() { desc = "unstable face ", label = "불안한 표정" });
            Looks.Add(new Look() { desc = "upset face ", label = "속상한 표정" });
            Looks.Add(new Look() { desc = "with distaste face ", label = "억지로 표정" });
            Looks.Add(new Look() { desc = "worried face ", label = "걱정한 표정" });

            comboBox8.DataSource = null;
            comboBox8.DataSource = Looks;
            comboBox8.DisplayMember = "label";
        }

        private Bitmap stringToImage(string inputString)
        {
            Bitmap img = new Bitmap(1, 1);
            Graphics g = Graphics.FromImage(img);

            Font f = new Font("Arial", 14);

            SizeF size = g.MeasureString(inputString, f);

            img = new Bitmap((int)Math.Ceiling(size.Width), (int)Math.Ceiling(size.Height));
            g = Graphics.FromImage(img);
            g.Clear(Color.White);
            g.DrawString(inputString, f, Brushes.Black, 0, 0);

            return img;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            this.Text = textBox2.Text.Length.ToString() + "자";
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Concepts.Find(x => x.title == textBox8.Text) == null)
            {
                Concepts.Add(new Concept() { label = "[" + comboBox1.Text + "] " + textBox8.Text, text = textBox1.Text, type = comboBox1.Text, title = textBox8.Text });

                APIS.AddRAG(textBox8.Text, textBox1.Text);

                textBox8.Text = "";
                textBox1.Text = "";

                listBox1.DataSource = null;
                listBox1.DataSource = Concepts;
                listBox1.DisplayMember = "label";
            }
            else
            {
                MessageBox.Show("레이블이 중첩됩니다.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox3.Text))
            {
                MessageBox.Show("장르 설정이 비어있습니다.");
                return;
            }

            var additional = textBox7.Text;
            if (string.IsNullOrWhiteSpace(additional) == false)
                additional = "명심해야 할 정보는 ***\n" + additional + "\n*** 이야.";

            if (comboBox1.Text.Equals("배경"))
            {
                textBox1.Text = APIS.CallAPI(string.Format(
                    "너는 유명하고 훌륭한 한국의 웹소설 작가야. 단계적으로 생각해서 정확한 답을 내줘.\n" +
                    "나는 지금 [" + textBox3.Text + "] 장르의 웹소설을 쓰려고 해.\n" +
                    "너가 알아야 할 정보는 다음과 같아:\n" +
                    "***\n 세계관은 공간적 배경, 시간적 배경, 특징적 배경 세 가지로 나뉘어져.\n" +
                    "공간적 배경은 자세한 지형지물, 위치, 대륙의 모습, 기후, 국가와 국경 같은 것들이 포함되고,\n" +
                    "시간적 배경은 시대적 특징, 국가 체제, 계급제도, 인종 구성, 언어, 도덕(세계관 내 윤리관), 종교, 역사, 경제 시스템(화폐경제인가 아닌가, 무역 시스템은 어떤가, 어떤 산업이 강세인가 등등을 포함해서), 예술(의 발전상태, 유행하는 스타일), 건축 양식, 과학(의 발전정도), 체육, 놀이문화, 해당 시대의 주요 사건들, 사건축 등이 포함 돼." +
                    "특징적 배경은 그 세계관만의 독특한 설정이야. 종족 설정이나 마법이 있다면 마법에 대한 것들, 외계인과 만난다든가 하면 외계인에 대해서도 써 줘야 하고, 특수 조직이 등장한다면 그 특수 조직에 대해서도 설명해야 해.\n" +
                    "좋은 세계관은 '철학이 있고' '오류가 없는' 세계관이야. \n***\n" +
                    "창작할 세계관에 대한 반드시 {0}\n" +
                    "\n\n위 정보를 참고해서 이야기의 무대가 될 세계관을 창작해줘.\n" +
                    "등장인물이나 주인공에 대한 정보는 제외해, 오로지 세계관에 대한 내용만 들어가야 해.\n" +
                    "응답은 짧은 단문으로 구성된 개조식으로 1000자 내외로 작성해줘.", additional));
            }
            else if (comboBox1.Text.Equals("등장인물"))
            {
                var ele = Concepts.Find(x => x.type == "배경");
                if (ele == null)
                {
                    MessageBox.Show("배경 설정이 비어있습니다.");
                    return;
                }

                var worldView = ele.text;

                textBox1.Text = APIS.CallAPI(string.Format(
                    "너는 유명하고 훌륭한 한국의 웹소설 작가야. 단계적으로 생각해서 정확한 답을 내줘.\n" +
                    "나는 지금 [" + textBox3.Text + "] 장르의 웹소설을 쓰려고 해.\n" +
                    "너가 알아야 할 정보는 다음과 같아:\n" +
                    "***\n 등장인물 창작시 포함되어야 할 요소는 아래와 같아:\n" +
                    "명확한 목표와 욕구, 과거 경험과 충격적인 사건, 성격과 특성, 신념과 가치관, 감정과 정서, 신체적 특징과 외모, 직업과 사회적 지위, 관계와 인간관계능력, 언어와 말투, 문화적 배경과 가족 구성, 취미와 관심사, 성격의 어두운 면과 결함, 강점과 장점, 약점과 단점, 성격과 행동의 일관성, 내면적 변화와 성장, 타인과의 대처 방식, 유머 감각과 태도, 신체적 건강과 피로도, 지적 능력과 교육 수준, 종교나 철학적 신념, 윤리적 가치관과 도덕성, 인생관과 시각, 이성적인 판단력과 감각적인 직관, 경험에 따른 인식과 신념의 변화, 과거의 잘못된 선택과 후회, 그들에게 영향을 주는 인물들과의 관계, 지역적, 문화적 배경에 따른 독특한 특징, 기존의 보편적 인식과 다른 관점을 갖게 된 경험, 타인의 행동에 대한 반응과 대처능력 등등 \n***\n" +
                    "창작할 등장인물에 대한 반드시 {0}\n" +
                    "쓰려고하는 웹소설의 배경 정보는 다음과 같아:\n" +
                    "***\n {1} \n***\n" +
                    "\n\n위 정보를 참고해서 될 등장인물 한명을 창작해줘.\n" +
                    "응답은 짧은 단문으로 구성된 개조식으로 1000자 내외로 작성해줘.", additional, worldView));
            }
            else if (comboBox1.Text.Equals("장소"))
            {

            }
            else if (comboBox1.Text.Equals("사물"))
            {

            }
            else if (comboBox1.Text.Equals("콘셉트"))
            {

            }

        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox3.Text))
            {
                MessageBox.Show("장르 설정이 비어있습니다.");
                return;
            }

            var ele = Concepts.Find(x => x.type == "배경");
            if (ele == null)
            {
                MessageBox.Show("배경 설정이 비어있습니다.");
                return;
            }

            var worldView = ele.text;
            var additional = textBox6.Text;

            if (comboBox2.Text.Equals("에피소드"))
            {
                var result = APIS.CallAPI(string.Format(
                    "너는 유명하고 훌륭한 한국의 웹소설 작가야. 단계적으로 생각해서 정확한 답을 내줘.\n" +
                    "나는 지금 [" + textBox3.Text + "] 장르의 웹소설을 쓰려고 해.\n" +
                    "너가 알아야 할 정보는 다음과 같아:\n" +
                    "***\n {0} \n***\n" +
                    "쓰려고하는 웹소설의 배경 정보는 다음과 같아:\n" +
                    "***\n {1} \n***\n" +
                    "\n\n위 정보를 참고해서 웹소설의 도입부터 결말까지의 에피소드를 10개 정도 만들어줘.\n" +
                    "응답은 짧은 단문으로 구성된 개조식으로 2000자 내외로 작성해줘.\n" +
                    "출력은 아래와 같은 json 포맷으로 정리해줘.\n{{\n\t\"result\": [\n\t\t{{\n\t\t\t\"title\": \"제목\", \n\t\t\t\"description\": \"내용\"\n\t\t}},\n\t\t{{\n\t\t\t\"title\": \"제목\", \n\t\t\t\"description\": \"내용\"\n\t\t}},\n\t]\n}}", additional, worldView));

                result = result.Replace("```json", "").Replace("```", "");
                JObject json = JsonConvert.DeserializeObject<JObject>(result);
                var resultArray = json["result"].ToArray();

                treeView1.Nodes.Clear();

                int count = 1;
                foreach (var item in resultArray)
                {
                    TreeNode svrNode = new TreeNode(string.Format("{0}. {1}", count++, item["title"].ToString()), 0, 0);
                    svrNode.ToolTipText = item["description"].ToString();
                    treeView1.Nodes.Add(svrNode);
                }
            }
            else if (comboBox2.Text.Equals("플롯"))
            {
                if (treeView1.SelectedNode == null)
                {
                    MessageBox.Show("플롯을 생성할 에피소드를 선택해 주세요.");
                    return;
                }
                else
                {
                    if (treeView1.SelectedNode.ImageIndex != 0)
                    {
                        MessageBox.Show("에피소드를 골라주세요.");
                        return;
                    }
                }

                //textBox9.Text = treeView1.SelectedNode.ToolTipText;

                var rag = APIS.CallRAG(treeView1.SelectedNode.Text + "\n" + treeView1.SelectedNode.ToolTipText);
                Debug.WriteLine(rag);

                var epis = "";
                foreach (TreeNode epi in treeView1.Nodes)
                {
                    epis += epi.Text + ":\n" + epi.ToolTipText + "\n";
                }

                var cur_epi = treeView1.SelectedNode.Text + ":\n" + treeView1.SelectedNode.ToolTipText;

                var result = APIS.CallAPI(string.Format(
                   "너는 유명하고 훌륭한 한국의 웹소설 작가야. 단계적으로 생각해서 정확한 답을 내줘.\n" +
                   "나는 지금 [" + textBox3.Text + "] 장르의 웹소설을 쓰고있어.\n" +
                   "너가 알아야 할 정보는 다음과 같아:\n" +
                   "***\n {0} \n***\n" +
                   "쓰려고하는 웹소설의 배경 정보는 다음과 같아:\n" +
                   "***\n {1} \n***\n" +
                   "전체 에피소드는 다음과 같아:\n" +
                   "***\n {2} \n***\n" +
                   "쓰고자 하는 현재 에피소드는 다음과 같아:\n" +
                   "***\n {3} \n***\n" +
                   "너가 참고할 수 있는 데이터베이스의 내용은 다음과 같아:\n" +
                   "***\n {4} \n***\n" +
                   "\n\n위 정보들을 참고해서 해당 에피소드의 플롯을 50개 정도 만들어줘.\n" +
                   "플롯에는 해당 에피소드의 발단-전개-위기-절정-결말이 들어가야 하고, 에피소드가 진행되기 위한 각 등장인물의 행동, 생각이나 환경의 변화 등등 개연성과 핍진성을 충족하는 일련의 변화들이 포함되어야 해.\n" +
                   "해당 에피소드의 이전 회차와 다음 회차에 자연스럽고 유기적으로 연결되는 플롯이어야 해.\n" +
                   "만약 이전 회차가 없다면 강렬한 발단부를, 다음 회차가 없다면 여운이 남는 결말부를 만들어줘.\n" +
                   "소설의 전체에 해당하는 플롯이 아니라 해당 에피소드의 플롯이라는 점을 명심해.\n" +
                   "응답은 짧은 단문으로 구성된 개조식으로 4000자 내외로 작성해줘.\n" +
                   "출력은 아래와 같은 json 포맷으로 정리해줘.\n{{\n\t\"result\": [\n\t\t{{\n\t\t\t\"title\": \"제목\", \n\t\t\t\"description\": \"내용\"\n\t\t}},\n\t\t{{\n\t\t\t\"title\": \"제목\", \n\t\t\t\"description\": \"내용\"\n\t\t}},\n\t]\n}}", additional, worldView, epis, cur_epi, rag));

                result = result.Replace("```json", "").Replace("```", "");
                JObject json = JsonConvert.DeserializeObject<JObject>(result);
                var resultArray = json["result"].ToArray();

                var selectedNode = treeView1.SelectedNode;
                selectedNode.Nodes.Clear();

                int count = 1;
                foreach (var item in resultArray)
                {
                    TreeNode svrNode = new TreeNode(string.Format("{0}. {1}", count++, item["title"].ToString()), 1, 1);
                    svrNode.ToolTipText = item["description"].ToString();
                    selectedNode.Nodes.Add(svrNode);
                }

                selectedNode.ExpandAll();
            }
            else if (comboBox2.Text.Equals("스크립트"))
            {
                if (treeView1.SelectedNode == null)
                {
                    MessageBox.Show("스크립트를 생성할 플롯을 선택해 주세요.");
                    return;
                }
                else
                {
                    if (treeView1.SelectedNode.ImageIndex != 1)
                    {
                        MessageBox.Show("플롯 골라주세요.");
                        return;
                    }
                }

                //textBox9.Text = treeView1.SelectedNode.ToolTipText;

                var rag = APIS.CallRAG(treeView1.SelectedNode.Text + "\n" + treeView1.SelectedNode.ToolTipText);
                Debug.WriteLine(rag);

                var epis = "";
                foreach (TreeNode epi in treeView1.SelectedNode.Nodes)
                {
                    epis += epi.Text + ":\n" + epi.ToolTipText + "\n";
                }

                var cur_epi = treeView1.SelectedNode.Text + ":\n" + treeView1.SelectedNode.ToolTipText;

                var scr = textBox2.Text;

                if (string.IsNullOrWhiteSpace(scr) == false)
                {
                    scr = "너가 이어서 써야할 이전에 작성된 원고는 다음과 같아:\n***\n" + scr + "\n***\n";
                }

                var result = APIS.CallAPI(string.Format(
                   "너는 유명하고 훌륭한 한국의 웹소설 작가야. 단계적으로 생각해서 정확한 답을 내줘.\n" +
                   "나는 지금 [" + textBox3.Text + "] 장르의 웹소설을 쓰고있어.\n" +
                   "너가 알아야 할 정보는 다음과 같아:\n" +
                   "***\n {0} \n***\n" +
                   "쓰려고하는 웹소설의 배경 정보는 다음과 같아:\n" +
                   "***\n {1} \n***\n" +
                   "현재 에피소드의 전체 플롯은 다음과 같아:\n" +
                   "***\n {2} \n***\n" +
                   "쓰고자 하는 플롯은 다음과 같아:\n" +
                   "***\n {3} \n***\n" +
                   "너가 참고할 수 있는 데이터베이스의 내용은 다음과 같아:\n" +
                   "***\n {4} \n***\n" +
                   "데이터베이스의 내용은 꼭 참고하지 않아도 좋아.\n" +
                   "{5}" +
                   "\n\n위 정보들을 참고해서 쓰고자 하는 플롯 한개를 100~500자 정도로 묘사해서 이전에 작성된 원고를 이어서 써줘.\n" +
                   "해당 플롯의 이전 플롯, 다음 플롯과 자연스럽고 유기적으로 연결되는 내용이어야 해.\n" +
                   "소설의 전체에 해당하는 내용이 아니라 일부 플롯 만을 묘사한다는 점을 명심해.\n", textBox6.Text + "\n" + textBox5.Text, worldView, epis, cur_epi, rag, scr));

                textBox2.Text += "\n" + result + "\n";
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            var prompt = "(score_9,score_8_up,score_7_up,source_anime) <white solid background:1.4>, ";

            if (Genders[comboBox4.SelectedIndex].desc != "") prompt += Genders[comboBox4.SelectedIndex].desc + ", ";
            if (Angles[comboBox3.SelectedIndex].desc != "") prompt += Angles[comboBox3.SelectedIndex].desc + ", ";
            if (Bodies[comboBox5.SelectedIndex].desc != "") prompt += Bodies[comboBox5.SelectedIndex].desc + ", ";
            if (HairStyles[comboBox6.SelectedIndex].desc != "") prompt += HairStyles[comboBox6.SelectedIndex].desc + ", ";
            if (string.IsNullOrWhiteSpace(textBox12.Text) == false) prompt += textBox12.Text + ", ";
            if (Looks[comboBox7.SelectedIndex].desc != "") prompt += Looks[comboBox7.SelectedIndex].desc + ", ";
            if (Facies[comboBox8.SelectedIndex].desc != "") prompt += Facies[comboBox8.SelectedIndex].desc + ", ";

            if (string.IsNullOrWhiteSpace(textBox10.Text) == false) prompt += textBox10.Text + ", ";
            if (string.IsNullOrWhiteSpace(textBox11.Text) == false) prompt += textBox11.Text + ", ";

            pictureBox1.Image = APIS.CallSD(System.Text.Json.JsonSerializer.Serialize(new
            {
                args = new
                {
                    prompt = prompt,
                }
            }));
        }
    }
}
