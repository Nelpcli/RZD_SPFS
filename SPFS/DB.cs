using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace SPFS
{
    public class DB
    {
        /// <summary>
        /// IP Адрес сервера БД MySQL
        /// </summary>
        string IPAddress;
        /// <summary>
        /// Номер порта сервера БД MySQL
        /// </summary>
        int Port;
        /// <summary>
        /// Имя базы данных
        /// </summary>
        string DBName = "sector_status_map";
        /// <summary>
        /// Версия схемы БД
        /// </summary>
        string Version;

        MySqlConnectionStringBuilder mysqlCSB;
        MySqlConnection myConnection;
        MySqlCommand command;
        /// <summary>
        /// Конструктор класса работы с БД. 
        /// Задаются первоначальные жизненноважные настройки.
        /// </summary>
        public DB()
        {
            mysqlCSB = new MySqlConnectionStringBuilder();
            mysqlCSB.UserID = "RZD";//"Admin";// "RZD";
            mysqlCSB.Password = "rzd";//"1234";// "rzd";
            mysqlCSB.ConvertZeroDateTime = true;
            mysqlCSB.SslMode = MySqlSslMode.None;
            mysqlCSB.Database = "sectors_status_map";
        }

        private void Connect()
        {
            myConnection = new MySqlConnection(mysqlCSB.ConnectionString);
            myConnection.Open();
        }

        private void Disconnect()
        {
            myConnection.Close();
        }

        public string GetPassword(string password)
        {
            string query = "select PASSWORD(" + password + ")";
            return ((string)Select(query).Tables[0].Rows[0][0]);
        }

        public bool CheckLogin(string login,string password)
        {
            //TODO:вернуть номер участка, ид, права доступа
            string query = "select ID, PASSWORD, NUM_SECTOR, ROLE from user where LOGIN="+login;
            DataSet dt = Select(query);
            string realPassword = (string)dt.Tables[0].Rows[0][1];
            if (GetPassword(password).Equals(realPassword))
                return true;
            else
                return false;
        }

        /// <summary>
        /// Установка настроек соединения с сервером БД
        /// </summary>
        /// <param name="ip">IP-адрес сервера</param>
        /// <param name="port">Порт сервера</param>
        public void SetConnectionSettings(string ip,string port, string timeout="5")
        {
            IPAddress = ip;
            Port = Convert.ToInt16(port);
            mysqlCSB.Server = ip;
            mysqlCSB.Port = Convert.ToUInt16(port);
            if (!(timeout=="" || timeout==" "))
                mysqlCSB.ConnectionTimeout = Convert.ToUInt16(timeout);
            else
            {
                mysqlCSB.ConnectionTimeout = 5;
            }
            
        }

        public void WriteError(string errorText, string dateTime,int ID)
        {
            string query = "Insert into error (Error,Time,User) values (" +
                                                        errorText + "," +
                                                        dateTime + "," +
                                                        ID.ToString() + ")";
            Insert(query);
        }

        //public void Insert(string query)
        //{
        //    //string query="";
        //    int s=ExecuteQuery(query).Tables[0].Rows.Count;
        //}

        //public void Update()
        //{
        //    string query = "";
        //    int s = ExecuteQuery(query).Tables[0].Rows.Count;
        //}

        /// <summary>
        /// Выполнение запроса к БД. Возвращает DataSet (таблицу) с данными
        /// </summary>
        /// <param name="query">Строка запроса к БД</param>
        /// <returns></returns>
        public DataSet Select(string query)
        {
            Connect();
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter(query, myConnection);
            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet);
            Disconnect();
            return dataSet;
        }

        /// <summary>
        /// Выполнение запроса к БД. Возвращает DataSet (таблицу) с данными
        /// </summary>
        /// <param name="query">Строка запроса к БД</param>
        /// <returns></returns>
        public void Insert(string query)
        {
            try
            {
                Connect();
                command = new MySqlCommand(query, myConnection);
                command.ExecuteNonQuery();
                //if (command.ExecuteNonQuery() != 1)
                //{
                //    throw new Exception("Ошибка вставки данных в БД. " + query);
                //}
            }
            catch(Exception ex)
            {
                Errors.Handle(ex);
            }
            finally
            {
                Disconnect();
            }
            //return true;
        }
        //TODO: сделать транзакции
    }
}
