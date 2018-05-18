using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;

namespace SPFS
{
    public partial class UserInterface : Form
    {
        public UserInterface()
        {
            InitializeComponent();
            //mysqlCSB = new MySqlConnectionStringBuilder();
            файлToolStripMenuItem.Visible = false;
            правкаToolStripMenuItem.Visible = false;
            TbFind.Visible = false;
            MenuFind.Visible = false;
            LbCriterion.Visible = false;
            string ip= Settings.ReedSettings("Server", "IpAdress");
            string port = Settings.ReedSettings("Server", "Port");
            string timeout = Settings.ReedSettings("Server", "Timeout");
            Base = new DB();
            Base.SetConnectionSettings(ip, port, timeout);
        }

        //MySqlConnectionStringBuilder mysqlCSB;
        //MySqlConnection myConnection;
        //MySqlCommand command;
        public static DB Base;
        public static User User;

        private void BtnEnter_Click(object sender, EventArgs e)
        {
            Settings.WriteSettings("Auth", "Login", TbLogin.Text);
            //MySqlConnectionStringBuilder mysqlCSB;
            //mysqlCSB = new MySqlConnectionStringBuilder();
            //mysqlCSB.Database = "sectors_status_map";
            string Login = TbLogin.Text;
            string Password = TbPassword.Text;
            //mysqlCSB.UserID = TbLogin.Text;
            //mysqlCSB.Password = TbPassword.Text;
            //создаем подключение
            try
            {
                //MainWindow.WriteSettings("Auth", "Login", TbLogin.Text);
                //слишком долго запускается, надо поправить
                //mysqlCSB.Server = Settings.ReedSettings("Server", "IP");
                //mysqlCSB.Port = Convert.ToUInt32(Settings.ReedSettings("Server", "Port"));
                ////TODO: Временно!

                //mysqlCSB.UserID = "Admin";
                //mysqlCSB.Password = "1234";

                ////----



                ////TODO: Временные настройки сервера
                //mysqlCSB.Server = "192.168.0.106";
                //mysqlCSB.Port = 3306;
                //mysqlCSB.SslMode = MySqlSslMode.None;
                /////-----
                //mysqlCSB.ConnectionTimeout = 5;
                //mysqlCSB.ConvertZeroDateTime = true;
                //myConnection = new MySqlConnection(mysqlCSB.ConnectionString);
                //myConnection.Open();
                //new MainWindow(mysqlCSB.UserID, mysqlCSB.Password).Show();
                //this.Hide();
                PanelAuth.Visible = false;
                файлToolStripMenuItem.Visible = true;
                правкаToolStripMenuItem.Visible = true;
                TbFind.Visible = true;
                MenuFind.Visible = true;
                LbCriterion.Visible = true;
                Split.Visible = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                MessageBox.Show("Неверный логин или пароль.", "Ошибка входа", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TbPassword.Text = "";
                return;
            }
            PanelAuth.Visible = false;
            DG1.Visible = true;
            MainWindow_LoadEd(sender, new EventArgs());
            //myConnection.Close(); //Обязательно закрываем соединение!

        }

        private void TbPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyData == Keys.Enter) && (BtnEnter.Enabled))
            {
                BtnEnter_Click(new object(), new EventArgs());
            }
        }

        private void настройкиСервераToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private string getName(string table, string field)
        {
            string query = @"SELECT column_comment
                                                        FROM information_schema.columns
                                                           WHERE table_schema = 'sectors_status_map' and 
                                                                table_name = '" + table +
                                                                "' and COLUMN_NAME='" + field + "'";
            //string text = new MySqlCommand(query, myConnection).ExecuteScalar().ToString();
            string text = ((string)Base.Select(query).Tables[0].Rows[0][0]);
            TablesColumns.Add(new List<string>());
            TablesColumns[TablesColumns.Count - 1].Add(table);
            TablesColumns[TablesColumns.Count - 1].Add(field);
            ColumnsName.Add(text);
            return text;
        }

        //двумерный массив стрингов для хранения в одном таблиц в другом полей

        List<List<string>> TablesColumns = new List<List<string>>();
        List<string> ColumnsName = new List<string>();
        private void MainWindow_LoadEd(object sender, EventArgs e)
        {
            //GetSettings();
            //MySqlConnectionStringBuilder mysqlCSB;
            //mysqlCSB = new MySqlConnectionStringBuilder();
            //mysqlCSB.Server = MainWindow.ReedSettings("Server", "IpAdress");
            //mysqlCSB.Port = Convert.ToUInt32(MainWindow.ReedSettings("Server", "Port"));
            //mysqlCSB.Database = "sectors_status_map";
            //TODO: Временно!

            //mysqlCSB.UserID = "Admin";
            //mysqlCSB.Password = "1234";

            //----

            //надо получить логин и пароль с первого окна
            //для того что бы получать только станции данного региона            
            //создаем подключение
            //myConnection = new MySqlConnection(mysqlCSB.ConnectionString);
            //запрос
            string queryString = @"SELECT 	PI.ID as '" + getName("PLATFORM_INFORMATION", "ID") +
                                                "',PI.NAME_SP as '" + getName("PLATFORM_INFORMATION", "NAME_SP") +
                                                "',TSP.TYPE_SP as '" + getName("TYPE_SP", "TYPE_SP") +
                                                    "',TP.TYPE_PLATFORM as '" + getName("TYPE_PLATFORM", "TYPE_PLATFORM") +
                                                        "',TPS.TYPE_PLATFORM_SIZE as '" + getName("TYPE_PLATFORM_SIZE", "TYPE_PLATFORM_SIZE") +
                                                            "',U.COUNT as '" + getName("URN", "COUNT") +
                                                            "',U.NORM as '" + getName("URN", "NORM") +
                                                            "',U.COLORED_AREA as '" + getName("URN", "COLORED_AREA") +
                                                                    "',PVL_M.TYPE_PAVILION_MATERIAL_WALL as '" + getName("TYPE_PAVILION_MATERIAL_WALL", "TYPE_PAVILION_MATERIAL_WALL") +
                                                                "',PVL.TYPE_PAVILION_MATERIAL_WALL_METER as '" + getName("PAVILION", "TYPE_PAVILION_MATERIAL_WALL_METER") +
                                                                "',PVL.TICKET as '" + getName("PAVILION", "TICKET") +
                                                                "',PVL.COLORED_AREA as '" + getName("PAVILION", "COLORED_AREA") +
                                                                    "',B.COUNT as '" + getName("BENCH", "COUNT") +
                                                                    "',B.NORM as '" + getName("BENCH", "NORM") +
                                                                    "', B.COLORED_AREA as '" + getName("BENCH", "COLORED_AREA") +
                                            "' FROM PLATFORM_INFORMATION PI " +
                                                "LEFT JOIN TYPE_SP TSP ON TSP.ID=PI.TYPE_SP " +
                                                    "LEFT JOIN TYPE_PLATFORM TP ON TP.ID=PI.TYPE_PLATFORM " +
                                                        "LEFT JOIN TYPE_PLATFORM_SIZE TPS ON TPS.ID=PI.TYPE_SIZE " +
                                                            "LEFT JOIN (select * from urn t " +
                                                                        "where Data_change = (select Max(Data_change) from urn " +
                                                                                             "WHERE platform = t.platform " +
                                                                                           "GROUP by Platform)) U ON U.PLATFORM=PI.ID " +
                                                                "LEFT JOIN (select * from PAVILION t " +
                                                                            "where Data_change = (select Max(Data_change) from PAVILION " +
                                                                                                 "WHERE platform = t.platform " +
                                                                                               "GROUP by Platform))	 PVL ON PVL.PLATFORM=PI.ID " +
                                                                    "LEFT JOIN TYPE_PAVILION_MATERIAL_WALL PVL_M ON PVL_M.ID=PVL.TYPE_PAVILION_MATERIAL_WALL " +
                                                                    "LEFT JOIN (select * from BENCH t " +
                                                                                "where Data_change = (select Max(Data_change) from BENCH " +
                                                                                                     "WHERE platform = t.platform " +
                                                                                                   "GROUP by Platform)) B ON B.PLATFORM=PI.ID";

            //Where pi.Num_sector=(
            //                     Select Num_sector
            //                        From User
            //                        Where Login='"+ mysqlCSB.UserID+"')";

            //Создадим объект DataTable, который будет возвращать наш метод и принимать datagridView.

            //DataSet dataSet = new DataSet();
            //MySqlDataAdapter dataAdapter = new MySqlDataAdapter(queryString, myConnection);

            //command = new MySqlCommand(queryString, myConnection);

            //try
            //{
            //    myConnection.Open(); //Устанавливаем соединение с базой данных.
            //                         //Что то делаем...
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.ToString());
            //    myConnection.Close(); //Обязательно закрываем соединение!
            //}

            //MySqlDataReader dataReader = command.ExecuteReader();
            //dataAdapter.
            //dataAdapter.Fill(dataSet);
            DataSet dataSet = Base.Select(queryString);
            try
            {
                if (dataSet.Tables[0].Rows.Count > 0)
                    //DG1.DataSource = dataSet.Tables[0];
                    DG1.DataSource = dataSet.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            DG1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            for (int i = 0; i < DG1.ColumnCount; i++)
            {
                if ((ColumnsName.IndexOf(ColumnsName[i]) == i))
                {
                    DG1.Columns[i].Name = ColumnsName[i];
                    DG1.Columns[i].HeaderText = ColumnsName[i];
                }
                else
                {
                    DG1.Columns[i].Name = ColumnsName[i] + "1";
                    DG1.Columns[i].HeaderText = ColumnsName[i] + "1";
                }
                DG1.Columns[i].Tag = TablesColumns[i];
                DG1.Columns[i].Visible = false;
                LbCriterion.Items.Add(new TextBox().Text = DG1.Columns[i].HeaderText);
            }

            ////есть записи?
            //if (dataReader.HasRows)
            //{
            //    //заполняем объект DataTable
            //    dataSet.Load(dataReader,);
            //}

            //удалить потом 2 строки
            //DG1.Columns.Clear();
            //DG1.Items.Clear();

            //DG1 = new DataGrid();


            //dataTable.Columns.RemoveAt(1);

            //получение названий столбцов из комментариев в базе данных
            //foreach (DataColumn column in dataSet.Tables[0].Columns)
            //{
            //    column.ColumnName = new MySqlCommand(@"SELECT column_comment
            //                                            FROM information_schema.columns
            //                                               WHERE table_schema = 'sectors_status_map' and 
            //                                                    (table_name = 'platform_information' or 
            //                                                        table_name = 'bench' 
            //                                                        )and
            //                                                        COLUMN_NAME='" + column.ColumnName + "' ", myConnection).ExecuteScalar().ToString();
            //    //DG1.ColumnWidth = 80;
            //}




            //можно сделать сортировку по значениям 
            //
            //      // Create DataView
            //DataView view = new DataView(locationTable);

            //      // Sort by State and ZipCode column in descending order
            //      view.Sort = "State ASC, ZipCode ASC";

            //myConnection.Close(); //Обязательно закрываем соединение!

            //DG1.DataSource = dataSet.Tables[0];
            DG1.Columns[0].Frozen = true;
            DG1.Columns[1].Frozen = true;
            DG1.Columns[0].Visible = true;
            DG1.Columns[1].Visible = true;
            LbCriterion.Items.RemoveAt(0);
            LbCriterion.Items.RemoveAt(0);
            Analyse();
        }


        List<string> CriterionsFact = new List<string>
        {
            "Лавочки. Количество",
            "Урны. Количество",
            "Лавочки. Площадь окраски",
            "Павильоны. Площадь окраски",
            "Урны. Площадь окраски"
        };

        List<string> CriterionsNorm = new List<string>
        {
            "Лавочки. Норма",
            "Урны. Норма"
        };

        public void Analyse()
        {
            //for (int i = 3; i < 7; i++)
            //{
            //    for (int j = 0; j < DG1.RowCount; j++)
            //    {
            //        DG1_CellEndEdit(DG1, new DataGridViewCellEventArgs(i, j));
            //    }
            //}

            for (int i = 0; i < CriterionsFact.Count; i++)
            {
                for (int j = 0; j < DG1.RowCount; j++)
                {
                    if (i > CriterionsNorm.Count - 1)
                    {
                        if (DG1[DG1.Columns[CriterionsFact[i]].Index, j].Value.ToString() != "")
                            if (Convert.ToInt16(DG1[DG1.Columns[CriterionsFact[i]].Index, j].Value) > 0)
                            {
                                DG1[DG1.Columns[CriterionsFact[i]].Index, j].Style.BackColor = Color.Salmon;
                            }
                            else
                            {
                                DG1[DG1.Columns[CriterionsFact[i]].Index, j].Style.BackColor = Color.LightGreen;
                            }
                        continue;
                    }
                    //MessageBox.Show("!" + DG1[DG1.Columns[CriterionsFact[i]].Index, j].Value + "!");
                    if ((DG1[DG1.Columns[CriterionsFact[i]].Index, j].Value.ToString() != "") || (DG1[DG1.Columns[CriterionsNorm[i]].Index, j].Value.ToString() != ""))
                    {
                        if (((int)DG1[DG1.Columns[CriterionsFact[i]].Index, j].Value) < ((int)DG1[DG1.Columns[CriterionsNorm[i]].Index, j].Value))
                        {
                            DG1[DG1.Columns[CriterionsFact[i]].Index, j].Style.BackColor = Color.Salmon;
                        }
                        else
                        {
                            DG1[DG1.Columns[CriterionsFact[i]].Index, j].Style.BackColor = Color.LightGreen;
                        }
                    }

                }
            }
        }

        bool Expanded = false;
        private void button1_Click(object sender, EventArgs e)
        {
            if (Expanded)
            {
                Split.SplitterDistance = Split.Width - 300;
                Expanded = false;
                BtnExpander.Text = "◀";
            }
            else
            {
                Split.SplitterDistance -= 300;
                BtnExpander.Text = "▶";
                Expanded = true;
            }
            BtnExpander.Left = Split.SplitterDistance - 1;
        }

        private void LbCriterion_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < LbCriterion.SelectedItems.Count; i++)
            {
                DG1.Columns[LbCriterion.SelectedIndices[i] + 2].Visible = true;
            }
            for (int i = 2; i < DG1.ColumnCount; i++)
            {
                if (!LbCriterion.SelectedIndices.Contains(DG1.Columns[i].Index - 2))
                {
                    DG1.Columns[i].Visible = false;
                }
            }

            //DG1.Columns[LbCriterion.SelectedIndices[LbCriterion.SelectedIndices.Count - 1]].Visible = !DG1.Columns[LbCriterion.SelectedIndices[LbCriterion.SelectedIndices.Count - 1]].Visible;
        }

        private void LbCriterion_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(((TextBox)LbCriterion.SelectedItem).ToString());

        }

        private void DG1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //if (((int)DG1[e.ColumnIndex, e.RowIndex].Value) < 100)
            //{
            //    DG1[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.Green;
            //}

            string table = (DG1.Columns[e.ColumnIndex].Tag as List<string>)[0];
            string field = (DG1.Columns[e.ColumnIndex].Tag as List<string>)[1];
            string value = (e.RowIndex + 1).ToString();
            string query =

                "CREATE TEMPORARY TABLE tmp AS  SELECT * FROM " + table +
                                                " t WHERE platform=" + value +
                                                " and Data_change = (select Max(Data_change) from " + table +
                                                                    " WHERE platform= t.platform" +
                                                       " GROUP by platform);" +
                " update tmp " +
                    " set id = (select max(id) + 1 from " + table + ")," +
                    " " + field + "=" + DG1[e.ColumnIndex, e.RowIndex].Value.ToString() + "," +
                    " Data_change = CURTIME();" +

            " insert into " + table +
                    " select * FROM tmp;" +
                    "drop table tmp;";
            try
            {
                //myConnection.Open();
                //command = new MySqlCommand(query, myConnection);
                //MessageBox.Show(query);
                //textBox1.Text = query;
                //MessageBox.Show(command.ExecuteNonQuery().ToString());
                //command.ExecuteNonQuery();
                Base.Insert(query);
                //if (command.ExecuteNonQuery() >0)
                //    MessageBox.Show("Изменение прошло успешно");
                //myConnection.Close();
            }
            catch (Exception ex)
            {              MessageBox.Show(ex.ToString());
                //myConnection.Close();
            }
            Analyse();
        }

        private void печатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //string FileXml = @"data.xml";
            //if (!File.Exists(FileXml))
            //    File.Create(FileXml);
            ////DataSet ds = (DataSet)DG1.DataSource;
            ////ds.WriteXml(FileXml);
            //DataTable dt = (DataTable)DG1.DataSource;
            //dt.WriteXml(FileXml);
            SaveToExcel();
            //Reports R = new Reports();
            //R.Save(DG1, @"D:\ЭСПО.pdf", Reports.ReportFormats.PDF);
        }

        private void SaveToExcel()
        {
            //создаём объект Excel
            Excel._Application excel = new Excel.Application();
            Excel._Workbook workbook = excel.Workbooks.Add(Type.Missing);
            Excel._Worksheet worksheet = null;

            try
            {
                worksheet = workbook.ActiveSheet;
                worksheet.Name = "ЭСПО";
                int cellRowIndex = 1;
                int cellColumnIndex = 1;

                //Обработка по каждой строке и столбцу
                for (int i = 0; i < DG1.Rows.Count; i++)
                {
                    for (int j = 0; j < DG1.Columns.Count; j++)
                    {
                        if (DG1.Columns[j].Visible)
                        {
                            //DG1.Columns[j].Selected = true;
                            //DG1.
                            cellColumnIndex = DG1.Columns[j].DisplayIndex + 1;
                            
                            // Excel index starts from 1,1. As first Row would have the Column headers, adding a condition check. 
                            //Если строка Excel=1 то пишем туда заголовок столбца
                            if (cellRowIndex == 1)
                            {
                                worksheet.Cells[cellRowIndex, cellColumnIndex] = DG1.Columns[j].HeaderText;
                                (worksheet.Cells[cellRowIndex, cellColumnIndex] as Excel.Range).BorderAround(Excel.XlLineStyle.xlContinuous);
                            }

                            int cellRowIndexPlus1 = cellRowIndex + 1;
                            (worksheet.Cells[cellRowIndexPlus1, cellColumnIndex] as Excel.Range).NumberFormat = "@";
                            worksheet.Cells[cellRowIndexPlus1, cellColumnIndex] = DG1.Rows[i].Cells[j].Value.ToString();

                            //DG1.column

                            //цвет
                            if (DG1.Rows[i].Cells[j].Style.BackColor.Name != "0")
                            {
                                (worksheet.Cells[cellRowIndexPlus1, cellColumnIndex] as Excel.Range).Interior.Color = DG1.Rows[i].Cells[j].Style.BackColor;
                            }

                            //бордюры
                            (worksheet.Cells[cellRowIndexPlus1, cellColumnIndex] as Excel.Range).BorderAround(Excel.XlLineStyle.xlContinuous);
                            cellColumnIndex++;
                        }
                        else
                        {
                            continue;
                        }
                    }
                    cellColumnIndex = 1;
                    cellRowIndex++;
                }

                worksheet.PageSetup.Orientation = Excel.XlPageOrientation.xlLandscape;
                worksheet.PageSetup.LeftMargin = 5;
                worksheet.PageSetup.RightMargin = 5;
                worksheet.PageSetup.BottomMargin = 5;
                worksheet.PageSetup.PrintTitleColumns = "$A:$B";
                //Ширина столбца по содержимому
                worksheet.Columns.EntireColumn.AutoFit();



                ////Getting the location and file name of the excel to save from user. 
                //SaveFileDialog saveDialog = new SaveFileDialog();
                string FileAddr = @"Reports\ЭСПО.pdf";
                FileInfo file = new FileInfo(FileAddr);
                //if (!File.Exists(FileExcel))
                //    File.Create(FileExcel);

                //workbook.SaveAs(FileExcel);


                workbook.ExportAsFixedFormat(Excel.XlFixedFormatType.xlTypePDF, file.FullName);
                //saveDialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                //saveDialog.FilterIndex = 2;

                //if (saveDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                //{
                //    workbook.SaveAs(saveDialog.FileName);
                //    MessageBox.Show("Export Successful");
                //}
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + ex.ToString());
            }
            finally
            {
                excel.DisplayAlerts = false;
                excel.Quit();
                workbook = null;
                excel = null;
            }
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            SetSettings();
        }

        private void SetSettings()
        {
            Settings.WriteSettings("Window", "Split", Split.SplitterDistance.ToString());
            Settings.WriteSettings("Window", "Width", this.Width.ToString());
            Settings.WriteSettings("Window", "Height", this.Height.ToString());
            Settings.WriteSettings("Window", "Top", this.Top.ToString());
            Settings.WriteSettings("Window", "Left", this.Left.ToString());
        }

   
        private void MainWindow_Load(object sender, EventArgs e)
        {
            GetSettings();
            PanelAuth.Top = this.Height / 2 - PanelAuth.Height / 2;
            PanelAuth.Left = Menu.Width / 2 - PanelAuth.Width / 2;
        }

        private void GetSettings()
        {
            Split.SplitterDistance = Convert.ToInt16(Settings.ReedSettings("Window", "Split"));
            this.Width = Convert.ToInt16(Settings.ReedSettings("Window", "Width"));
            this.Height = Convert.ToInt16(Settings.ReedSettings("Window", "Height"));
            this.Top = Convert.ToInt16(Settings.ReedSettings("Window", "Top"));
            this.Left = Convert.ToInt16(Settings.ReedSettings("Window", "Left"));
            TbLogin.Text = Settings.ReedSettings("Auth", "Login");

            //настройки сервера
            //String URL="192.168.0.101";
            //URL=SettingsMngr.GetPrivateString("SQLServer", "URL");
        }

        private void MenuFind_Click(object sender, EventArgs e)
        {
            string text = TbFind.Text;
            for (int i = 0; i < DG1.RowCount; i++)
            {
                if (DG1["Наименование остановочного пункта", i].Value.ToString().ToLower().Contains(text.ToLower()))
                {
                    DG1.Rows[i].Selected = true;
                    return;
                }
            }

        }

        private void TbFind_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyData == Keys.Enter) && (BtnEnter.Enabled))
            {
                MenuFind_Click(new object(), new EventArgs());
            }
        }
    }
}
