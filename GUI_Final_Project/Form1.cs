using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web.Script.Serialization;
using System.Net;
using System.IO;
using CefSharp;
using CefSharp.WinForms;
using System.Runtime.ConstrainedExecution;
using System.Threading;

namespace GUI_Final_Project
{
    public partial class Form1 : Form
    {
        public ChromiumWebBrowser Broswer;

        List<Tuple<string, double, double>>tuples = new List<Tuple<string, double, double>>();
        public Form1()
        {
            InitializeComponent();
            InitBrowser();
        }

        public void InitBrowser()
        {
            CefSettings cefSettings = new CefSettings();
            Cef.Initialize(cefSettings);
            Broswer = new ChromiumWebBrowser("google.com");
            this.webBrowser1.Controls.Add(Broswer);
            Broswer.Dock = DockStyle.Fill;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Version ver = webBrowser1.Version;
            string name = webBrowser1.ProductName;
            string str = webBrowser1.ProductVersion;
            string html = "C:\\Users\\seongbin\\source\\repos\\GUI_Final_Project\\GUI_Final_Project\\kakaoMap.html";
            string dir = System.IO.Directory.GetCurrentDirectory();
            string path = System.IO.Path.Combine(dir, html);
            webBrowser1.Navigate(path);
        }
        public void Search(string area) // 지역 검색
        {
            // 요청을 보낼 url 
            string site = "https://dapi.kakao.com/v2/local/search/keyword.json";
            string query = string.Format("{0}?query={1}", site, area);

            WebRequest request = WebRequest.Create(query); // 요청 생성. 
            string api_key = "5a8a270fd40f327a408d9d81395ecca6"; // API 인증키 입력. (각자 발급한 API 인증키를 입력하자)
            string header = "KakaoAK " + api_key;

            request.Headers.Add("Authorization", header); // HTTP 헤더 "Authorization" 에 header 값 설정. 
            WebResponse response = request.GetResponse(); // 요청을 보내고 응답 객체를 받는다. 
            Stream stream = response.GetResponseStream(); // 응답객체의 결과물
            StreamReader reader = new StreamReader(stream, Encoding.UTF8);
            String json = reader.ReadToEnd(); // JOSN 포멧 문자열

            JavaScriptSerializer js = new JavaScriptSerializer(); // (Reference 에 System.Web.Extensions.dll 을 추가해야한다)
            var dob = js.Deserialize<dynamic>(json);
            var docs = dob["documents"];
            object[] buf = docs;
            int length = buf.Length;

            for (int i = 0; i < length; i++) // 지역명, 위도, 경도 읽어오기. 
            {
                string address_name = docs[i]["place_name"];
                double x = double.Parse(docs[i]["x"]); // 위도
                double y = double.Parse(docs[i]["y"]); // 경도
                tuples.Add(new Tuple<string, double, double>(address_name, x, y));
            }
        }
       

        private void input(string str)
        {
            listBox1.Items.Clear();
            tuples.Clear();

            Search(search_textbox.Text);
            for (int i = 0; i < tuples.Count; i++)
            {
                listBox1.Items.Add(tuples[i].Item1);
            }
        }
     

        private void ShowMap()
        {
            var sel = tuples[listBox1.SelectedIndex];
            object[] arr = new object[] { sel.Item3, sel.Item2 }; // 위도, 경도
            object res = webBrowser1.Document.InvokeScript("panTo", arr); // html 의 panTo 자바스크립트 함수 호출.
            object res2 = webBrowser1.Document.InvokeScript("markTo", arr);                                             //
        }

        private void search_textbox_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    input(search_textbox.Text);
                    break;
            }
        }

        private void search_button_Click(object sender, EventArgs e)
        {
            try
            {
                object[] arr = new object[] { search_textbox.Text };
                webBrowser1.Document.InvokeScript("geo", arr); // html 의 geo 자바스크립트 함수 호출. 
            }
            catch(Exception ex)
            {
                ex.ToString();
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void listBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                ShowMap();
            }
                
        }

        private void large_button_Click(object sender, EventArgs e)
        {
            webBrowser1.Document.InvokeScript("zoomIn"); // 줌인
        }

        private void small_button_Click(object sender, EventArgs e)
        {
            webBrowser1.Document.InvokeScript("zoomOut"); // 줌아웃
        }


     

        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                ShowMap();      
            }
                
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }
    }
}

/*
 * HTTP/1.1 200 OK

Content-Type: application/json;charset=UTF-8

{

  "meta": {

    "same_name": {

      "region": [],

      "keyword": "카카오프렌즈",

      "selected_region": ""

    },

    "pageable_count": 14,

    "total_count": 14,

    "is_end": true

  },

  "documents": [

    {

      "place_name": "카카오프렌즈 코엑스점",

      "distance": "418",

      "place_url": "http://place.map.daum.net/26338954",

      "category_name": "가정,생활 > 문구,사무용품 > 디자인문구 > 카카오프렌즈",

      "address_name": "서울 강남구 삼성동 159",

      "road_address_name": "서울 강남구 영동대로 513",

      "id": "26338954",

      "phone": "02-6002-1880",

      "category_group_code": "",

      "category_group_name": "",

      "x": "127.05902969025047",

      "y": "37.51207412593136"

    },

    ...

  ]

}
 */