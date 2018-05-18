using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SPFS
{
    class Errors
    {
        //TODO: привести время к одному стандартному для MySQL виду
        static private void WriteDB(string text, User user)
        { 
            UserInterface.Base.WriteError(text, DateTime.Now.ToShortTimeString(),user.ID);
        }

        static private void WrkiteLog(string text,User user)
        {
            string nameLog = "Log.txt";
            string time = DateTime.Now.ToShortTimeString();

            //string user = super.User.Login;
            try
            {
                //проверить существует ли файл
                if (File.Exists(nameLog))
                {
                    //есла да, то записываем
                    StreamWriter sr = new StreamWriter(nameLog, true);
                    sr.WriteLine(time + " | " + user.Login + " | " + text);
                    sr.WriteLine("-----------------------------------------------------------");
                    sr.Close();
                }
                else
                {
                    //если нет то создаём и пытаемся снова
                    File.Create(nameLog);
                    WriteLog(text, user);
                }
            }catch(Exception ex)
            {
                Handle(ex);//, user);
            }
        }

        static private void Write(string text,User user)
        {
            WriteLog(text, user);
            WriteDB(text,user);
        }

        static private void ShowMessage(string ErrorText)
        {
            //вывод ошибки пользователю
            MessageBox.Show(ErrorText, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //#if DEBUG
            //            //вывод текста
            //            MessageBox.Show(ex.ToString(), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //#endif
        }

        static public void Handle(Exception ex)//,User user=null)
        {
            //TODO: Виды ошибок
            string ErrorText = "";
            //#if DEBUG
                        ErrorText = "Возникла непредвиденная ошибка";
            //#endif        
            string ErrorTextLog = ex.ToString();
            
            ShowMessage(ErrorText);
            
            Write(ErrorTextLog, UserInterface.User);
            //TODO: обработка варианта ошибки через if и подстановка соответствующего сообщения

            //TODO: запись ошибка в БД через класс БД
        }

    }
}
