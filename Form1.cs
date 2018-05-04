using CsQuery;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
//
//..

namespace scrape_getfpv_com
{
    public partial class Form1 : Form
    {
        //public event Action ProgressBarPlus;

        #region Form Init
        public Form1()
        {
            InitializeComponent();
            // this.ProgressBarPlus += ProgressBarPlusPlus;
            checkBoxDownloadPhoto.Checked = true;
        }
        #endregion

        Net net = new Net();

        string baseUrl = "https://www.getfpv.com";
        List<Category> categories = new List<Category>();
        

        string resultFilePath = "result.csv";

        //nkYellOw при загрузке групп на открытие формы загружать прогресс бар
        public void ProgressBarPlusPlus()
        {
            if (progressBar1.InvokeRequired)
            {
                progressBar1.BeginInvoke(new Action(() =>
                {
                    progressBar1.Value = progressBar1.Value + 1;
                }));
            }
            else
            {
                progressBar1.Value = progressBar1.Value + 1;
            }

        }

        // Функция добавления триальной версии программы
        private static void TrialCheck()
        {
            using (WebClient wc = new WebClient())
            {
                string HTML = wc.DownloadString("https://time100.ru/api.php");
                DateTime now = UnixTimeStampToDateTime(Convert.ToInt64(HTML));

                DateTime end = new DateTime(2018, 04, 25, 9, 30, 0);
                if (now > end)
                {
                    MessageBox.Show("Триальная версия");
                    //Console.WriteLine("Триальная версия");
                    //Console.ReadKey();

                    Environment.Exit(0);
                }
            }
        }
        // Функция перевода времени из TimeStamp (Unix) в DateTime (C#)
        private static DateTime UnixTimeStampToDateTime(long unixTimeStamp)
        {
            DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp);
            return dtDateTime;
        }

        #region Функции интерфейса и работы с ним

        private void Form1_Load(object sender, EventArgs e)
        {
            //ProxyIp.Text = "122.138.168.182:8197";

            //ProxyIp.Text = "149.202.38.124:32321";
            //TrialCheck();

            //nkYellOw
            //AddToListBox("Загрузка...");

            //progressBar1.Maximum = 40;
            //progressBar1.Value = 0;

            //new Task(() =>
            //{
            //changeMaximumBar(40);
            //SetProgress(0);

            //ScrapeCategory();

            //ClearTreeView();
            //LoadTreeView();

            //nkYellOw
            //RemoveFromListBox(0);
            //AddToListBox("Группы загружены!");
            //changeMaximumBar(100);
            //SetProgress(0);

            //}).Start();

        }

        private void changeMaximumBar(int v)

        {
            if (progressBar1.InvokeRequired)
            {
                progressBar1.BeginInvoke(new Action(() =>
                {
                    progressBar1.Maximum = v;
                }));

            }
            else
            {
                progressBar1.Maximum = v;
            }


        }

        private void RemoveFromListBox()
        {
            if (listBox1.InvokeRequired)
            {
                listBox1.BeginInvoke(new Action(() =>
                {
                    listBox1.Items.Clear();
                }));
            }
            else
            {
                listBox1.Items.Clear();
            }
        }

        string folderPath = "";
        int countCategoryNow = 0;


        private void Button_StartScrape_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            int downloadDelay = Convert.ToInt32(DownloadDelay.Value)*1000;
            string proxyIp = "";
            if (ProxyIp.SelectedItem != null)
            {
                proxyIp = ProxyIp.SelectedItem.ToString();
            }


            AddToListBox($"Всего выбрано {countCheckedCategory} категорий");
            SetProgress(0);
            countCategoryNow = 0;
            /// TEST
            new Task(() =>
            {
            SetInterface(false);

            for (int i = 0; i < categories.Count; i++)
            {
                Sleep(downloadDelay);

                    folderPath = Func.WindowsFileNameClear(categories[i].Name);

                    if (categories[i].Checked)
                    {
                        if (!Directory.Exists(folderPath))
                        {
                            Directory.CreateDirectory(folderPath);//
                  }

                        ScrapeProductList(categories[i], proxyIp, downloadDelay);
                        SetProgress(Func.ProgressProcent(++countCategoryNow, countCheckedCategory));
                    }

                    for (int j = 0; j < categories[i].Children.Count; j++)
                    {
                        Sleep(downloadDelay);

                        folderPath += "\\" + Func.WindowsFileNameClear(categories[i].Children[j].Name);

                        if (categories[i].Children[j].Checked)
                        {
                            if (!Directory.Exists(folderPath))
                            {
                                Directory.CreateDirectory(folderPath);
                            }

                            ScrapeProductList(categories[i].Children[j], proxyIp, downloadDelay);
                            SetProgress(Func.ProgressProcent(++countCategoryNow, countCheckedCategory));
                        }

                        for (int k = 0; k < categories[i].Children[j].Children.Count; k++)
                        {
                            Sleep(downloadDelay);

                            folderPath += "\\" + Func.WindowsFileNameClear(categories[i].Children[j].Children[k].Name);

                            if (categories[i].Children[j].Children[k].Checked)
                            {
                                if (!Directory.Exists(folderPath))
                                {
                                    Directory.CreateDirectory(folderPath);
                                }

                                ScrapeProductList(categories[i].Children[j].Children[k], proxyIp, downloadDelay);
                                SetProgress(Func.ProgressProcent(++countCategoryNow, countCheckedCategory));
                            }

                            folderPath = Func.WindowsFileNameClear(categories[i].Name) + "\\" + Func.WindowsFileNameClear(categories[i].Children[j].Name);
                        }

                        folderPath = Func.WindowsFileNameClear(categories[i].Name);
                    }

                    folderPath = "";
                }

                SetInterface(true);
                AddToListBox("Парсинг завершен");
            }).Start();
        }

        private void TreeView1_AfterCheck(object sender, TreeViewEventArgs e)
        {
            List<string> categoryContains = new List<string>();

            if (e.Node.Parent != null)
            {
                if (e.Node.Parent.Parent != null)
                {
                    categoryContains.Add(e.Node.Parent.Parent.Text);
                }
                categoryContains.Add(e.Node.Parent.Text);
            }
            categoryContains.Add(e.Node.Text);

            CheckFromTree(categoryContains,e.Node.Checked);
        }

        /// <summary>
        /// Загрузка списка категорий из коллекции в интерфейс (дерево)
        /// </summary>
        void LoadTreeView()
        {
            for (int i = 0; i < categories.Count; i++)
            {
                AddToTreeViewRoot(categories[i].Name);
                for (int j = 0; j < categories[i].Children.Count; j++)
                {
                    AddToTreeViewRootSub(categories[i].Children[j].Name);
                    for (int k = 0; k < categories[i].Children[j].Children.Count; k++)
                    {
                        AddToTreeViewRootSubSub(categories[i].Children[j].Children[k].Name);
                    }
                }
            }
        }
        void ClearTreeView()
        {
            if (treeView1.InvokeRequired)
            {
                treeView1.BeginInvoke(new Action(() =>
                {
                    treeView1.Nodes.Clear();
                }));
            }
            else
            {
                treeView1.Nodes.Clear();
            }
        }
        void AddToTreeViewRoot(string text)
        {
            if (treeView1.InvokeRequired)
            {
                treeView1.BeginInvoke(new Action(() =>
                {
                    treeView1.Nodes.Add(text);

                }));
            }
            else
            {
                treeView1.Nodes.Add(text);
            }
        }
        void AddToTreeViewRootSub(string text)
        {
            if (treeView1.InvokeRequired)
            {
                treeView1.BeginInvoke(new Action(() =>
                {
                    treeView1.Nodes[treeView1.Nodes.Count - 1].Nodes.Add(text);
                }));
            }
            else
            {
                treeView1.Nodes[treeView1.Nodes.Count - 1].Nodes.Add(text);
            }
        }
        void AddToTreeViewRootSubSub(string text)
        {
            if (treeView1.InvokeRequired)
            {
                treeView1.BeginInvoke(new Action(() =>
                {
                    int lastIndexChildren = treeView1.Nodes[treeView1.Nodes.Count - 1].Nodes.Count - 1;
                    treeView1.Nodes[treeView1.Nodes.Count - 1].Nodes[lastIndexChildren].Nodes.Add(text);
                }));
            }
            else
            {
                int lastIndexChildren = treeView1.Nodes[treeView1.Nodes.Count - 1].Nodes.Count - 1;
                treeView1.Nodes[treeView1.Nodes.Count - 1].Nodes[lastIndexChildren].Nodes.Add(text);
            }
        }

        /// <summary>
        /// Добавление текста в ListBox (не зависимо от выполняемого потока)
        /// </summary>
        /// <param name="text">Передаваемый текст</param>
        void AddToListBox(string text)
        {
            if (listBox1.InvokeRequired)
            {
                listBox1.BeginInvoke(new Action(() =>
                {
                    listBox1.Items.Add(text);
                    listBox1.SelectedIndex = listBox1.Items.Count - 1;
                }));
            }
            else
            {
                listBox1.Items.Add(text);
                listBox1.SelectedIndex = listBox1.Items.Count - 1;
            }
        }

        void SetProgress(int value)
        {
            if (progressBar1.InvokeRequired)
            {
                progressBar1.BeginInvoke(new Action(() =>
                {
                    if (value > progressBar1.Maximum)
                    {
                        progressBar1.Value = progressBar1.Maximum;
                    }
                    else
                    {
                        progressBar1.Value = value;
                    }
                }));
            }
            else
            {
                if (value > progressBar1.Maximum)
                {
                    progressBar1.Value = progressBar1.Maximum;
                }
                else
                {
                    progressBar1.Value = value;
                }
            }
        }

        void SetInterface(bool value)
        {
            if (groupBox1.InvokeRequired)
            {
                groupBox1.BeginInvoke(new Action(() =>
                {
                    groupBox1.Enabled = value;
                }));
            }
            else
            {
                groupBox1.Enabled = value;
            }
            if (Button_StartScrape.InvokeRequired)
            {
                Button_StartScrape.BeginInvoke(new Action(() =>
                {
                    Button_StartScrape.Enabled = value;
                }));
            }
            else
            {
                Button_StartScrape.Enabled = value;
            }

            if (checkBoxDownloadPhoto.InvokeRequired)
            {
                checkBoxDownloadPhoto.BeginInvoke(new Action(() =>
                {
                    checkBoxDownloadPhoto.Enabled = value;
                }));
            }
            else
            {
                checkBoxDownloadPhoto.Enabled = value;
            }

            if (downloadGroups.InvokeRequired)
            {
                downloadGroups.BeginInvoke(new Action(() =>
                {
                    downloadGroups.Enabled = value;
                }));
            }
            else
            {
                downloadGroups.Enabled = value;
            }

            if (checkBoxAll_ON.InvokeRequired)
            {
                checkBoxAll_ON.BeginInvoke(new Action(() =>
                {
                    checkBoxAll_ON.Enabled = value;
                }));
            }
            else
            {
                checkBoxAll_ON.Enabled = value;
            }

            if (checkBoxAll_OFF.InvokeRequired)
            {
                checkBoxAll_OFF.BeginInvoke(new Action(() =>
                {
                    checkBoxAll_OFF.Enabled = value;
                }));
            }
            else
            {
                checkBoxAll_OFF.Enabled = value;
            }

            if (ProxyIp.InvokeRequired)
            {
                ProxyIp.BeginInvoke(new Action(() =>
                {
                    ProxyIp.Enabled = value;
                }));
            }
            else
            {
                ProxyIp.Enabled = value;
            }

            if (DownloadDelay.InvokeRequired)
            {
                DownloadDelay.BeginInvoke(new Action(() =>
                {
                    DownloadDelay.Enabled = value;
                }));
            }
            else
            {
                DownloadDelay.Enabled = value;
            }


            if (treeView1.InvokeRequired)
            {
                treeView1.BeginInvoke(new Action(() =>
                {
                    treeView1.Enabled = value;
                }));
            }
            else
            {
                treeView1.Enabled = value;
            }




        }

        #endregion

        /// <summary>
        /// Парсинг категорий с сайта
        /// </summary>
        void ScrapeCategory(string proxyIp="")
        {
            int downloadDelay = Convert.ToInt32(DownloadDelay.Value)*1000;

            string res = net.GET(baseUrl,null,null,null, proxyIp, downloadDelay);

            CQ dom = CQ.Create(res);
            
            var categoryList = dom["a.level0"];
            for (int i = 0; i < categoryList.Length; i++)
            {
                
                Sleep(downloadDelay);
                
                SetProgress(i);

                var category = categoryList.Eq(i);
                categories.Add(new Category
                {
                    Name = category.Text(),
                    Link = category.Attr("href"),
                    //Checked = true
                });

                if (category.HasClass("has-children"))
                {
                    var subCategoryList = category.Parent().Find("a.level1");
                    for (int j = 0; j < subCategoryList.Length; j++)
                    {
                        Sleep(downloadDelay);
                        var subCategory = subCategoryList.Eq(j);
                        categories[categories.Count - 1].Children.Add(new Category
                        {
                            Name = subCategory.Text(),
                            Link = subCategory.Attr("href"),
                            //Checked = true
                        });
                        if (subCategory.HasClass("has-children"))
                        {
                            Sleep(downloadDelay);
                            var subSubCategoryList = subCategory.Parent().Find("a.level2");
                            for (int k = 0; k < subSubCategoryList.Length; k++)
                            {
                                Sleep(downloadDelay);
                                var subSubCategory = subSubCategoryList.Eq(k);
                                int lastChildrenIndex = categories[categories.Count - 1].Children.Count - 1;
                                categories[categories.Count - 1].Children[lastChildrenIndex].Children.Add(new Category
                                {
                                    Name = subSubCategory.Text(),
                                    Link = subSubCategory.Attr("href"),
                                    //Checked = true
                                });
                            }
                        }
                        break;  
                    }
                }
                else
                {
                
                    // В родительской категории нет подкатегорий - проверить на странице
                    string resCategory = net.GET(categories[categories.Count - 1].Link,null,null,null, proxyIp,downloadDelay);
                    var pageCategory = CQ.Create(resCategory);
                    var subCategoryOnPage = pageCategory["ul li h3 a"];
                    for (int j = 0; j < subCategoryOnPage.Length; j++)
                    {
                        Sleep(downloadDelay);
                        categories[categories.Count - 1].Children.Add(new Category
                        {
                            Name = subCategoryOnPage.Eq(j).Text(),
                            Link = baseUrl + subCategoryOnPage.Eq(j).Attr("href"),
                            //Checked=true
                        });
                    }
                }
                break;
            }
        }

        public void Sleep(int v)
        {
            System.Threading.Thread.Sleep(v);
        }

        /// <summary>
        /// Парсинг списка товаров на странице категории
        /// </summary>
        /// <param name="category">Объект категории</param>
        void ScrapeProductList(Category category,string proxyIp="",int downloadDelay=0)
        {
            string featured = "";
            if(FeaturedCheckBox.Checked)
            {
                featured = "&dir=asc&order=position";
            }

            string limit = "?limit=100"+ featured;
            int itemsCount = 0;
            int maximumItems = Convert.ToInt32(maxItems.Value);

            CQ dom = null;
            int page = 1;
            do
            {
                AddToListBox($"Категория {category.Name}. Страница {page}");
          
                string link = category.Link + limit;
                if (page > 1)
                {
                    link += "&p=" + page;
                }

                string res = net.GET(link,null,null,null,"", downloadDelay);
                if (net.ResponseUri != link)
                {
                    // Если произошел редирект на другую страницу - Пример: категория FPV Cameras
                    category.Link = net.ResponseUri;
                    link = category.Link + limit;
                    if (page > 1)
                    {
                        link += "&p=" + page;
                    }

                    res = net.GET(link,null,null,null, proxyIp, downloadDelay);
                }

                dom = CQ.Create(res);
                var productList = dom[".products-grid .item h2.product-name a"];

                if (page == 1 && productList.Length == 0)
                {
                    // На странице нет товаров - проверяем наличие категорий на странице
                    var categoryOnPage = dom["ul li h3 a"];
                    List<Category> categoryListOnPage = new List<Category>();
                    for (int i = 0; i < categoryOnPage.Length; i++)
                    {
                        categoryListOnPage.Add(new Category
                        {
                            Name = categoryOnPage.Eq(i).Text(),
                            Link = baseUrl + categoryOnPage.Eq(i).Attr("href"),
                            Checked = true
                        });
                    }

                    for (int i = 0; i < categoryListOnPage.Count; i++)
                    {
                        ScrapeProductList(categoryListOnPage[i], proxyIp, downloadDelay);
                    }

                    return;
                }
                for (int i = 0; i < productList.Length; i++)
                {
                    ScrapeProduct(productList.Eq(i).Text().Trim(), productList.Eq(i).Attr("href"),proxyIp,downloadDelay);

                    if (maximumItems > 0)
                    {
                        itemsCount += 1;
                        if (itemsCount >= 50)
                        {
                            break;
                        }
                    }
                }

                page++;
            } while (dom.Find(".pages li a.next").Length > 0 && itemsCount < 51);
        }

        /// <summary>
        /// Парсинг товара
        /// </summary>
        /// <param name="name">Название товара</param>
        /// <param name="link">Ссылка на страницу с товаром</param>///
        void ScrapeProduct(string name, string link,string proxyIp="", int downloadDelay=0)
        {
             
            string res = net.GET(link,null,null,null,proxyIp,downloadDelay);

            var dom = CQ.Create(res);

            string desc = dom["#collateral-tabs .tab-container"].Eq(0).Find(".tab-content").Text();

            var objCsv = new ObjectCsv
            {
                Name = name,
                Description = desc,
            };
            if (checkBoxDownloadPhoto.Checked)
            {
                var imageList = dom[".product-image-gallery img[id^='image']"];
                for (int i = 1; i < imageList.Length && i <= 3; i++)
                {
                    Sleep(downloadDelay);

                    string imageSrc = imageList.Eq(i).Attr("src");
                    string fileName = Func.WindowsFileNameClear(name) + "_" + (i).ToString() + imageSrc.Remove(0, imageSrc.LastIndexOf("."));

                    if (!File.Exists(folderPath + "\\" + fileName))
                    {
                        if (!new FindFile().LookingFileAllDirectories(folderPath,fileName))
                        {
                            net.DownloadFile(imageSrc, folderPath + "\\" + fileName);
                        }
                    }

                    string filePath = Environment.CurrentDirectory + "\\" + folderPath + "\\" + fileName;
                    if (i == 1)
                    {
                        objCsv.Image_1 = filePath;
                    }
                    else if (i == 2)
                    {
                        objCsv.Image_2 = filePath;
                    }
                    else if (i == 3)
                    {
                        objCsv.Image_3 = filePath;
                    }
                }
            }

            string[] categoryToFile = folderPath.Split('\\');
            if (categoryToFile.Length >= 1)
            {
                objCsv.Category_1 = categoryToFile[0];
            }
            if (categoryToFile.Length >= 2)
            {
                objCsv.Category_2 = categoryToFile[1];
            }
            if (categoryToFile.Length >= 3)
            {
                objCsv.Category_3 = categoryToFile[2];
            }

            Func.SaveObjectToCsv(objCsv, resultFilePath);

            AddToListBox($"Товар {name} спарсен");
        }

        int countCheckedCategory = 0;
        /// <summary>
        /// Устанавливаем флаг выбора определенной категории в коллекции categories
        /// </summary>
        /// <param name="checkedCategory">Коллекция названий категорий согласно вложенности</param>
        private void CheckFromTree(List<string> checkedCategory,bool turnOn=false)
        {
            if (categories.Count == 0) return;

            int level0Index = -1;
            int level1Index = -1;
            int level2Index = -1;

            if (checkedCategory.Count >= 1)
            {
                for (int i = 0; i < categories.Count; i++)
                {
                    if (checkedCategory[0] == categories[i].Name)
                    {
                        level0Index = i;
                        break;
                    }
                }
            }

            if (checkedCategory.Count >= 2)
            {
                for (int i = 0; i < categories[level0Index].Children.Count; i++)
                {
                    if (checkedCategory[1] == categories[level0Index].Children[i].Name)
                    {
                        level1Index = i;
                        break;
                    }
                }

                if (checkedCategory.Count >= 3)
                {
                    for (int i = 0; i < categories[level0Index].Children[level1Index].Children.Count; i++)
                    {
                        if (checkedCategory[2] == categories[level0Index].Children[level1Index].Children[i].Name)
                        {
                            level2Index = i;
                            break;
                        }
                    }

                    categories[level0Index].Children[level1Index].Children[level2Index].Checked = turnOn;//!categories[level0Index].Children[level1Index].Children[level2Index].Checked;
                    if (categories[level0Index].Children[level1Index].Children[level2Index].Checked)
                    {
                        countCheckedCategory++;
                    }
                    else
                    {
                        countCheckedCategory--;
                    }
                }
                else
                {
                    categories[level0Index].Children[level1Index].Checked = turnOn;//!categories[level0Index].Children[level1Index].Checked;
                    if (categories[level0Index].Children[level1Index].Checked)
                    {
                        countCheckedCategory++;
                    }
                    else
                    {
                        countCheckedCategory--;
                    }
                }
            }
            else
            {
                categories[level0Index].Checked = turnOn;//!categories[level0Index].Checked;
                if (categories[level0Index].Checked)
                {
                    countCheckedCategory++;
                }
                else
                {
                    countCheckedCategory--;
                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxAll_ON.Checked)
            {
                turnCheckBox(checkBoxAll_ON.Checked);
            }
        }

        // nkYellOw
        // Установка/снятие галочек по все группам.
        private void turnCheckBox(bool v)
        {

            List<string> categoryContains = new List<string>();

            for (int i = 0; i < treeView1.Nodes.Count; i++)
            {
                TreeNode firstNode = this.treeView1.Nodes[i];
                TreeNode secondNode = null;
                TreeNode threeNode = null;

                firstNode.Checked = v;

                for (int ii = 0; ii < firstNode.Nodes.Count; ii++)
                {
                    secondNode = firstNode.Nodes[ii];

                    secondNode.Checked = v;

                    for (int iii = 0; iii < secondNode.Nodes.Count; iii++)
                    {
                        threeNode = secondNode.Nodes[iii];

                        threeNode.Checked = v;

                        categoryContains.Clear();
                        categoryContains.Add(firstNode.Text);
                        categoryContains.Add(secondNode.Text);
                        categoryContains.Add(threeNode.Text);
                        CheckFromTree(categoryContains, v);

                    }

                    if (secondNode.Nodes.Count == 0)
                    {
                        categoryContains.Clear();
                        categoryContains.Add(firstNode.Text);
                        categoryContains.Add(secondNode.Text);
                        CheckFromTree(categoryContains, v);
                    }
                }

                if (firstNode.Nodes.Count == 0)
                {
                    categoryContains.Clear();
                    categoryContains.Add(firstNode.Text);
                    CheckFromTree(categoryContains, v);
                }
            }



            checkBoxAll_ON.Checked = v;
            checkBoxAll_OFF.Checked = !v;
        }

        private void checkBoxAll_OFF_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxAll_OFF.Checked)
            {
                turnCheckBox(!checkBoxAll_OFF.Checked);
            }
        }

        private void checkBoxDownloadPhoto_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void downloadGroups_Click(object sender, EventArgs e)
        {
            string proxyIp = "";
            if (ProxyIp.SelectedItem != null)
            {
                proxyIp = ProxyIp.SelectedItem.ToString();
            }
            //TrialCheck();

            //nkYellOw
            AddToListBox("Загрузка...");

            progressBar1.Maximum = 40;
            progressBar1.Value = 0;

            new Task(() =>
            {
                changeMaximumBar(40);
                SetProgress(0);

                ScrapeCategory(proxyIp);

                ClearTreeView();
                LoadTreeView();

                //nkYellOw
                RemoveFromListBox();
                AddToListBox("Группы загружены!");
                changeMaximumBar(100);
                SetProgress(0);

            }).Start();
        }

        private void downloadGroups_Click_1(object sender, EventArgs e)
        {
            SetInterface(false);
            string proxyIp = "";
            if (ProxyIp.SelectedItem != null)
            {
                proxyIp = ProxyIp.SelectedItem.ToString();
            }
            //TrialCheck();

            //nkYellOw
            AddToListBox("Загрузка...");

            progressBar1.Maximum = 40;
            progressBar1.Value = 0;

            new Task(() =>
            {
            //changeMaximumBar(40);
            SetProgress(0);

            ScrapeCategory(proxyIp);

            ClearTreeView();
            LoadTreeView();

            //nkYellOw
            RemoveFromListBox();
            AddToListBox("Группы загружены!");
            changeMaximumBar(100);
            SetProgress(0);
            SetInterface(true);

            }).Start();


        }
    }
}