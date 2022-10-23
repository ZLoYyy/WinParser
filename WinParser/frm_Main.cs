using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinParser.Data;
using WinParser.Tools;

using Emgu.CV;
using Emgu.Util;
using Emgu.CV.OCR;
using Emgu.CV.Structure;
using System.Collections.ObjectModel;
using RandomUserAgent;
using System.Drawing.Imaging;
using System.Net;
using System.IO;
using System.Diagnostics;

namespace WinParser
{
    public partial class frm_Main : Form
    {


        private readonly int __coutnAction = 50;
        private List<Order> _orders;
        private User _user;
        public frm_Main()
        {
            InitializeComponent();

            Parser.Init();

            bs_Orders.DataSource = _orders;
            dgv_Orders.DataSource = bs_Orders;
            _orders = new List<Order>();

            
        }

        private void frm_Main_Load(object sender, EventArgs e)
        {
            if(_user != null)
                _orders = Executor.Get_Orders(_user.ID, out string error);
            RefreshData();
        }


        private void frm_Main_Shown(object sender, EventArgs e)
        {
            if (_user == null)
            {
                using (frm_Login frm = new frm_Login())
                {
                    if (frm.ShowDialog() != DialogResult.OK)
                    {
                        Close();
                        return;
                    }

                    _user = frm.CurrentUser;

                    lbl_Login.Text = _user.Login;
                    lbl_SheetCount.Text = _user.SheetCount.ToString();
                }
            }

            tb_OrderRegion.Text = "Амурская область";
            tb_OrderDistrict.Text = "Благовещенск";
            tb_OrderStreet.Text = "Амурская";
            tb_OrderHome.Text = "25";
        }

        private void RefreshData() 
        {
            Task.Run(() => Login());
            lbl_key.Text = Setts.Key;
        }

        /// <summary>
        /// Авторизация
        /// </summary>
        private async void Login() 
        {
            ReadOnlyCollection<IWebElement> inputs = Parser.GetElements(1, ".v-textfield");
            if (inputs == null)
            {
                await Task.Delay(1000);
                inputs = Parser.GetElements(1, ".v-textfield"); 
            }

            for (int i = 0; i < inputs.Count; i++)
            {
                inputs[i].SendKeys(Setts.KeySplit[i]);
                await Task.Delay(500);
            }

            IWebElement btnLogin = Parser.GetElement(1, ".v-button-normalButton");

            if (btnLogin != null)
                btnLogin.Click();
            else
                return;

            await Task.Delay(1000);
            IWebElement btnCreateOrder = Parser.GetElement(2, "//*[@id=\"v-Z7_01HA1A42KODT90AR30VLN22003\"]/div/div[2]/div/div[1]/div/div/div/div[1]/div/div/div/div[1]/div/div/div/div/div[1]/div/div");
            if (btnCreateOrder == null) 
            {
                int i = 0;
                while (btnCreateOrder == null && i < __coutnAction)
                {
                    Parser.RefreshPage();
                    Login();
                    await Task.Delay(1000);
                    i++;
                }

            }
            else
                return;
        }
        /// <summary>
        /// Получить заявки
        /// </summary>
        /// <param name="orderNumber"></param>
        /// <param name="dateBegin"></param>
        private async void GetOrders(string orderNumber, DateTime dateBegin) 
        {
            _orders = new List<Order>();
            //await Task.Delay(5000);
            IWebElement btnOrders = Parser.GetElement(2, "//*[@id=\"v-Z7_01HA1A42KODT90AR30VLN22003\"]/" +
                "div/div[2]/div/div[1]/div/div/div/div[1]/div/div/div/div[1]/div/div/div/div/div[2]/" +
                "div/div");
            if (btnOrders == null)
                Login();

            btnOrders.Click();
            await Task.Delay(2000);

            ///Кнопка след страницы
            IWebElement btnNext = Parser.GetElement(2, "//*[@id=\"v-Z7_01HA1A42KODT90AR30VLN22003\"]/" +
                "div/div[2]/div/div[2]/div/div/div/div[1]/div/div/div/div[4]/div/div/div/div/" +
                "div[1]/div/div/div/div[5]/div/div");
            ///Картинка постраничной навигации
            IWebElement img = Parser.GetElement(2, "//*[@id=\"v-Z7_01HA1A42KODT90AR30VLN22003\"]/" +
                "div/div[2]/div/div[2]/div/div/div/div[1]/div/div/div/div[4]/div/div/div/div/" +
                "div[1]/div/div/div/div[5]/div/div/span/img"); ;
            
            if (btnNext == null)
                return;

            ///Пока картинки=а активна
            while (img != null)
            {
                ///Строки
                ReadOnlyCollection<IWebElement> rows = Parser.GetElements(1, ".v-table-row");
                foreach (var row in rows)
                {
                    Order newOrder = new Order();
                    ///Ячейки
                    ReadOnlyCollection<IWebElement> cells = Parser.GetElements(1, ".v-table-cell-wrapper", row);
                    for (int i = 0; i < cells.Count; i++)
                    {
                            switch (i)
                            {
                                case 0:
                                    newOrder.Number = cells[i].Text;
                                    break;
                                case 1:
                                    DateTime.TryParse(cells[i].Text, out DateTime date);
                                    newOrder.DateCreate = date;
                                    break;
                                case 2:
                                    newOrder.State = cells[i].Text;
                                    break;
                                case 3:
                                    newOrder.Link = cells[i].Text;
                                    break;
                            }
                    }
                    Order order = _orders.Find(X => X.Number == newOrder.Number);
                    if (order != null) 
                    {
                        order.State = newOrder.State;
                        order.Link = newOrder.Link;
                    }
                    else
                        _orders.Add(newOrder);
                }

                btnNext.Click();
                await Task.Delay(5000);
                
                img = Parser.GetElement(2, "//*[@id=\"v-Z7_01HA1A42KODT90AR30VLN22003\"]/div/div[2]/" +
                    "div/div[2]/div/div/div/div[1]/div/div/div/div[4]/div/div/div/div/div[1]/div/" +
                    "div/div/div[5]/div/div/span/img");
            }

            ///Создаем/Обновляем заявки
            Executor.Action_Orders(_user.ID, _orders, out string error);
            dgv_Orders.Refresh();
            bs_Orders.DataSource = _orders;
            dgv_Orders.DataSource = bs_Orders;

        }

        private void frm_Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            Parser.Close();
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void btn_OrdersRefresh_Click(object sender, EventArgs e)
        {
            await Task.Run(()=> GetOrders(tb_OrderNumber.Text, dtp_Begin.Value));
        }

        private async void btn_OrderSend_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tb_OrderRegion.Text) || string.IsNullOrEmpty(tb_OrderDistrict.Text))
            {
                MessageBox.Show("Заполните поля", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //Отображаем прогресс бар
            pb_Load.Visible = lbl_Load.Visible = true;
            btn_OrderSend.Enabled = btn_Close.Enabled = btn_OrderClearValues.Enabled =
                tb_OrderDistrict.Enabled = tb_OrderFlat.Enabled = tb_OrderHome.Enabled =
                tb_OrderLocation.Enabled = tb_OrderRegion.Enabled = tb_OrderStreet.Enabled = false;

            lbl_Load.Text = "Отправка данных...";
            try 
            {
                IWebElement btnCreateOrder = Parser.GetElement(2, "//*[@id=\"v-Z7_01HA1A42KODT90AR30VLN22003\"]/div/div[2]/div/div[1]/div/div/div/div[1]/div/div/div/div[1]/div/div/div/div/div[1]/div/div"); 

                if (btnCreateOrder == null)
                    return;

                btnCreateOrder.Click();

                await Task.Delay(1000);
                pb_Load.Maximum = 100;
                pb_Load.Value = 10;
                ///Регион, населенный пункт
                ReadOnlyCollection<IWebElement> inputTB = Parser.GetElements(1, ".v-filterselect-input");
                for (int i = 0; i < inputTB.Count; i++)
                {
                    switch (i)
                    {
                        case 0:
                            inputTB[i].Click();
                            await Task.Delay(2000);
                            inputTB[i].SendKeys(tb_OrderRegion.Text);
                            await Task.Delay(1000);
                            inputTB[i].SendKeys(OpenQA.Selenium.Keys.Up);
                            await Task.Delay(2000);
                            inputTB[i].SendKeys(OpenQA.Selenium.Keys.Enter);
                            //inputTB[i+1].Click();
                            await Task.Delay(2000);
                            /*if (string.IsNullOrEmpty(inputTB[i].Text))
                            {
                                inputTB[i].SendKeys(tb_OrderRegion.Text);
                                inputTB[i].SendKeys(OpenQA.Selenium.Keys.Up);
                            }*/

                            break;
                        case 1:
                            inputTB[i].Click();
                            await Task.Delay(2000);
                            inputTB[i].SendKeys(tb_OrderDistrict.Text);
                            await Task.Delay(2000);
                            //inputTB[i].SendKeys(OpenQA.Selenium.Keys.Up);
                            //await Task.Delay(2000);
                            inputTB[i].SendKeys(OpenQA.Selenium.Keys.Enter);
                            await Task.Delay(2000);
                            /*if (string.IsNullOrEmpty(inputTB[i].Text))
                            {
                                inputTB[i].SendKeys(tb_OrderRegion.Text);
                                inputTB[i].SendKeys(OpenQA.Selenium.Keys.Up);
                            }*/
                            break;
                        case 2:
                            if (!string.IsNullOrEmpty(tb_OrderLocation.Text))
                            {
                                inputTB[i].Click();
                                await Task.Delay(2000);
                                inputTB[i].SendKeys(tb_OrderLocation.Text);
                                await Task.Delay(2000);
                                inputTB[i].SendKeys(OpenQA.Selenium.Keys.Up);
                                await Task.Delay(2000);
                                inputTB[i].SendKeys(OpenQA.Selenium.Keys.Enter);
                                /*if (string.IsNullOrEmpty(inputTB[i].Text))
                                    inputTB[i].SendKeys(tb_OrderRegion.Text);*/
                            }
                            break;
                        case 3:
                            break;
                    }

                    pb_Load.Value = pb_Load.Value + 5;
                }

                ///Улица, дом, квартира
                ReadOnlyCollection<IWebElement> inputSubTB = Parser.GetElements(1, ".v-textfield");                
                for (int i = 0; i < inputSubTB.Count; i++)
                {
                    switch (i)
                    {
                        case 0:
                            break;
                        case 1:
                            if (!string.IsNullOrEmpty(tb_OrderStreet.Text))
                            {
                                inputSubTB[i].Click();
                                inputSubTB[i].SendKeys(tb_OrderStreet.Text);
                            }
                            break;
                        case 2:
                            if (!string.IsNullOrEmpty(tb_OrderHome.Text))
                            {
                                inputSubTB[i].Click();
                                inputSubTB[i].SendKeys(tb_OrderHome.Text);
                            }
                            break;
                        case 3:
                            if (!string.IsNullOrEmpty(tb_OrderFlat.Text))
                            {
                                inputSubTB[i].Click();
                                inputSubTB[i].SendKeys(tb_OrderFlat.Text);
                            }
                            break;
                    }

                    pb_Load.Value = pb_Load.Value + 5;
                }

                IWebElement btn = Parser.GetElement(2, "//*[@id=\"v-Z7_01HA1A42KODT90AR30VLN22003\"]/div/div[2]/div/div[2]/div/div/div/div[1]/div/div/div/div[3]/div/div/div/div[1]/div/div/div/div[1]/div/div");
                btn.Click();
                await Task.Delay(10000);

                lbl_Load.Text = "Поиск обьектов...";
                pb_Load.Value = pb_Load.Maximum;
                //Разбираем полученные строки
                List<Order> newOrders = new List<Order>();

                ReadOnlyCollection<IWebElement> tableRow = Parser.GetElements(1, ".v-table-row");
                pb_Load.Value = 0;
                pb_Load.Maximum = tableRow.Count;
                foreach (var row in tableRow)
                {
                    Order newOrder = new Order();
                    ReadOnlyCollection<IWebElement> cells = Parser.GetElements(1, ".v-table-cell-wrapper", row);

                    for (int i = 0; i < cells.Count; i++)
                    {
                        switch (i)
                        {
                            case 0:
                                newOrder.CadastralNumber = cells[i].Text;
                                lbl_Load.Text = "Поиск обьектов...(Кадастровый номер: "+ newOrder.CadastralNumber + ")";
                                break;
                            case 1:
                                newOrder.FullAdderess = cells[i].Text;
                                break;
                            case 2:
                                newOrder.TypeObject = cells[i].Text;
                                break;
                            case 3:
                                newOrder.Square = cells[i].Text;
                                break;
                            case 4:
                                newOrder.CategoryZU = cells[i].Text;
                                break;
                            case 5:
                                newOrder.TypeZU = cells[i].Text;
                                break;
                            case 6:
                                newOrder.Purpose = cells[i].Text;
                                break;
                        }
                    }
                    newOrder.HtmlObject = row;
                    newOrders.Add(newOrder);
            
                    pb_Load.Value++;
                }

                //Разбираем полученные строки не четные
                ReadOnlyCollection<IWebElement> tableRowOdd = Parser.GetElements(1, ".v-table-row-odd");
                pb_Load.Value = 0;
                pb_Load.Maximum = tableRowOdd.Count;
                foreach (var row in tableRowOdd)
                {
                        Order newOrder = new Order();
                        ReadOnlyCollection<IWebElement> cells = Parser.GetElements(1, ".v-table-cell-wrapper", row);

                        for (int i = 0; i < cells.Count; i++)
                        {
                            switch (i)
                            {
                                case 0:
                                    newOrder.CadastralNumber = cells[i].Text;
                                    lbl_Load.Text = "Поиск обьектов...(Кадастровый номер: " + newOrder.CadastralNumber + ")";
                                    break;
                                case 1:
                                    newOrder.FullAdderess = cells[i].Text;
                                    break;
                                case 2:
                                    newOrder.TypeObject = cells[i].Text;
                                    break;
                                case 3:
                                    newOrder.Square = cells[i].Text;
                                    break;
                                case 4:
                                    newOrder.CategoryZU = cells[i].Text;
                                    break;
                                case 5:
                                    newOrder.TypeZU = cells[i].Text;
                                    break;
                                case 6:
                                    newOrder.Purpose = cells[i].Text;
                                    break;
                            }
                        }

                        newOrder.HtmlObject = row;
                        newOrders.Add(newOrder);

                    pb_Load.Value++;
                }

                //Открываем форму подзаявок
                using Frm_CreateOrderList frm = new Frm_CreateOrderList(newOrders);
                frm.ShowDialog();
                if (frm.DialogResult == DialogResult.OK)
                {
                    pb_Load.Value = 0;
                    pb_Load.Maximum = frm.SelectedOrders.Count;
                    int index = 0;
                    foreach (Order order in frm.SelectedOrders)
                    {
                        int time = ((pb_Load.Maximum - pb_Load.Value) * 5);
                        string timeStr = string.Empty;
                        if (time >= 60)
                        {
                            int h = time / 60;
                            int m = time - (h * 60);

                            if (m == 0)
                                timeStr = h + " ч.";
                            else
                                timeStr = h + " ч. " + m + " мин.";
                        }
                        else
                            timeStr = time + " мин.";
                        lbl_Load.Text = "Запрос сведений об объекте " +
                            pb_Load.Value + "/" + pb_Load.Maximum + " : " +
                            order.CadastralNumber + " (общее время ожидания примерно " + timeStr + ")";

                        if (order.HtmlObject == null)
                            return;
                        await Task.Delay(3000);
                        pb_Load.Value++;

                        if(index == 0)
                            SendOrder(order);
                        else if(index > 0)
                            SendOrderWithRelog(order);

                        index++;
                    }

                    Executor.Add_Orders(_user.ID, _orders, out string error);
                }
            }
            catch (Exception ex)
            { }
            finally
            {
                //Скрываем прогресс бар
                pb_Load.Visible = lbl_Load.Visible = false;
                btn_OrderSend.Enabled = btn_Close.Enabled = btn_OrderClearValues.Enabled =
                    tb_OrderDistrict.Enabled = tb_OrderFlat.Enabled = tb_OrderHome.Enabled =
                    tb_OrderLocation.Enabled = tb_OrderRegion.Enabled = tb_OrderStreet.Enabled = true;
            }
        }
        /// <summary>
        /// Отправка заявок
        /// </summary>
        /// <param name="order"></param>
        private async void SendOrder(Order order) 
        {            
            //continue;
            /*Проверка на наличие листов*/
            /**/

            IWebElement orderBtn = Parser.GetElement(1, ".v-table-cell-content-cadastral_num", order.HtmlObject);
            if (orderBtn == null)
            {
                await Task.Delay(5000);
                var orderBtn2 = Parser.GetElement(2, "//*[contains(., '" + order.FullAdderess + "')]");
                orderBtn = Parser.GetElement(1, ".v-table-cell-content-cadastral_num", orderBtn2);
            }
            orderBtn.Click();
            await Task.Delay(5000);

            IWebElement capcha = Parser.GetElement(2, "//*[@id=\"v-Z7_01HA1A42KODT90AR30VLN22003\"]/div/div[2]/div/div[2]/div/div/div/div[1]/div/div/div/div[1]/div/div/div/div[3]/div/div/div/div[1]/div/div/div/div[2]/div/div/div/div[1]/div/div/img");
            string imageSrc = string.Format(@"{0}", capcha.GetAttribute("src"));// capcha.GetAttribute("src");

            string captPath = Parser.CopyLink(imageSrc);
            string error = "";
            //string res = Parser.GetCapcha(captPath, error);
            string res = "2222";
            if (!string.IsNullOrEmpty(res))
                File.Delete(captPath);
            else 
            {
                return;

            }





            /*Обработать капчу*/
            IWebElement capchaInput = Parser.GetElement(1, ".v-textfield-srv-field");
            /*Записать значение капчи*/
            capchaInput.Click();
            capchaInput.SendKeys(res);
            IWebElement capchaInputAfter = Parser.GetElement(1, ".v-textfield-srv-field");
            int i = 0;
            while(capchaInputAfter == null || string.IsNullOrEmpty(capchaInputAfter.GetAttribute("value")) && i < __coutnAction) 
            {
                capchaInputAfter.Click();
                capchaInputAfter.SendKeys(res);
                capchaInputAfter = Parser.GetElement(1, ".v-textfield-srv-field");
                i++;
            }

            //Parser.SetUserAgent();
            //string userAgent = RandomUa.RandomUserAgent;

            IWebElement btnSend = Parser.GetElement(2, "//*[@id=\"v-Z7_01HA1A42KODT90AR30VLN22003\"]/div/div[2]/div/div[2]/div/div/div/div[1]/div/div/div/div[1]/div/div/div/div[4]/div/div/div/div[1]/div/div/div/div[1]/div/div");
            btnSend.Click();
            await Task.Delay(3000);
            IWebElement wind = Parser.GetElement(1, ".v-window-wrap");
            ///Сообщение
            IWebElement sendMess = Parser.GetElement(1, ".v-label-tipFont", wind);
            if (sendMess != null)
            {
                IWebElement code = Parser.GetElement(3, "b", sendMess);

                ///Сохраняем
                order.Number = code.Text;
                _orders.Add(order);

                ///Продолжить работу
                IWebElement btnContinue = wind.FindElement(By.CssSelector(".v-button"));
                btnContinue.Click();
                await Task.Delay(5000);
                if(pb_Load.Value < pb_Load.Maximum)
                    pb_Load.Value +=1;
            }
            //В случае ошибки ожидаем и пробуем снова
            else 
            {
                await Task.Delay(50000);
                SendOrder(order);
            }            
        }
        /// <summary>
        /// Отправка заявок со сменой ключа
        /// </summary>
        /// <param name="order"></param>
        private async void SendOrderWithRelog(Order order) 
        {

            Parser.Close();
            await Task.Delay(2000);
            Parser.Init();
            await Task.Delay(2000);
            IWebElement serchRes = SearchByCadastral(order.CadastralNumber);
            SendOrder(order);
        }

        private  IWebElement SearchByCadastral(string cadastral) 
        {
            return null;
        }

        private void rb_BrowserOn_CheckedChanged(object sender, EventArgs e)
        {
            /*ChromeOptions options = new ChromeOptions();
            //options.AddArgument("headless");
            _driver = new ChromeDriver(options);
            _driver.Url = Setts.URL;*/
        }

        private void rb_BrowserOff_CheckedChanged(object sender, EventArgs e)
        {
            /*
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("headless");
            _driver = new ChromeDriver(options);*/
        }

        private void btn_ClearSession_Click(object sender, EventArgs e)
        {
            Parser.ClearSession();
        }

        private void btn_RossLogin_Click(object sender, EventArgs e)
        {
            Login();
        }
    }
}
